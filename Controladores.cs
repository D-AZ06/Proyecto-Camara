using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace Proyecto_Camara
{
    /// <summary>
    /// Descubre qué herramientas tiene tu PC para grabar y arma los argumentos de ffmpeg.
    /// Al detectar, PRUEBA de verdad cada forma de capturar y se queda con la más liviana
    /// que funcione en tu equipo:
    ///   1) DxgiGpu : captura, escalado y compresión en la GPU (la CPU casi no trabaja).
    ///   2) DxgiCpu : captura DXGI (ddagrab); el escalado lo hace la CPU (más pesado).
    ///   3) Gdi     : captura clásica (gdigrab), la más pesada, queda como reserva.
    /// </summary>
    public class Controladores
    {
        private readonly string _rutaFFmpeg;

        public enum CalidadVideo
        {
            Alta,   // tamaño original de la pantalla
            Media,  // 1280 de ancho
            Baja    // 854 de ancho
        }

        private enum ModoCaptura
        {
            Gdi,
            DxgiCpu,
            DxgiGpu
        }

        // ---------- Opciones que elige el usuario ----------
        public List<string> EncodersDisponibles { get; private set; } = new List<string>();
        public string EncoderDeVideo { get; set; } = "libx264";
        public List<string> DispositivosAudio { get; private set; } = new List<string>();
        public List<string> DispositivosVideo { get; private set; } = new List<string>();
        public string Microfono { get; set; }
        public int Fps { get; set; } = 24;                      // un ritmo estable se ve mejor que uno que no se alcanza
        public double GananciaMicrofono { get; set; } = 2.0;    // 1.0 = sin cambios
        public CalidadVideo Calidad { get; set; } = CalidadVideo.Alta;
        public bool Detectado { get; private set; }

        // ---------- Resultado de las pruebas ----------
        private bool _qsvOk;
        private bool _dxgiCpuOk;
        private bool _dxgiGpuOk;

        public Controladores(string rutaFFmpeg)
        {
            _rutaFFmpeg = rutaFFmpeg;
        }

        // Texto corto para mostrar en FormInicio
        public string Descripcion
        {
            get
            {
                switch (ElegirModo())
                {
                    case ModoCaptura.DxgiGpu:
                        return "captura y compresión por GPU";
                    case ModoCaptura.DxgiCpu:
                        return EncoderDeVideo == "h264_qsv" ? "captura DXGI + compresión GPU" : "captura DXGI + compresión CPU";
                    default:
                        return "captura básica GDI";
                }
            }
        }

        // ==========================================
        // DETECCIÓN
        // ==========================================

        public void Detectar()
        {
            if (Detectado) return;

            _qsvOk = FuncionaQsv();

            EncodersDisponibles.Clear();
            if (_qsvOk) EncodersDisponibles.Add("h264_qsv");
            EncodersDisponibles.Add("libx264");
            EncoderDeVideo = EncodersDisponibles[0];

            _dxgiCpuOk = ProbarCaptura(ModoCaptura.DxgiCpu, _qsvOk);
            _dxgiGpuOk = _qsvOk && ProbarCaptura(ModoCaptura.DxgiGpu, true);

            ListarDispositivos();

            Debug.WriteLine($"Detección -> QSV: {_qsvOk} | DXGI+CPU: {_dxgiCpuOk} | DXGI+GPU: {_dxgiGpuOk}");
            Detectado = true;
        }

        // Codifica unos cuadros de video negro con el encoder de la GPU
        private bool FuncionaQsv()
        {
            string argumentos =
                "-hide_banner -loglevel error -f lavfi -i color=c=black:s=640x360:d=0.2 " +
                "-c:v h264_qsv -preset veryfast -bf 0 -global_quality 28 -pix_fmt nv12 -f null -";

            string salida;
            return EjecutarFFmpeg(argumentos, out salida) == 0;
        }

        // Captura unos cuadros reales de tu pantalla con el modo indicado
        private bool ProbarCaptura(ModoCaptura modo, bool usarQsv)
        {
            string entrada;
            string video = PartesVideo(modo, usarQsv, false, out entrada);
            string argumentos = $"-hide_banner -loglevel error {entrada} {video} -frames:v 6 -f null -";

            string salida;
            int codigo = EjecutarFFmpeg(argumentos, out salida);
            if (codigo != 0) Debug.WriteLine($"Prueba {modo} falló: {salida}");
            return codigo == 0;
        }

        // Lista micrófonos y cámaras. ffmpeg imprime líneas como:  "Micrófono (Realtek)" (audio)
        private void ListarDispositivos()
        {
            DispositivosAudio = new List<string>();
            DispositivosVideo = new List<string>();

            string salida;
            EjecutarFFmpeg("-hide_banner -list_devices true -f dshow -i dummy", out salida);

            foreach (string linea in salida.Split('\n'))
            {
                bool esAudio = linea.Contains("(audio)");
                bool esVideo = linea.Contains("(video)");
                if (!esAudio && !esVideo) continue;

                int inicio = linea.IndexOf('"');
                int fin = linea.IndexOf('"', inicio + 1);
                if (inicio < 0 || fin <= inicio) continue;

                string nombre = linea.Substring(inicio + 1, fin - inicio - 1);

                if (esAudio) DispositivosAudio.Add(nombre);
                else DispositivosVideo.Add(nombre);
            }
        }

        // ==========================================
        // ARGUMENTOS PARA GRABAR
        // ==========================================

        private ModoCaptura ElegirModo()
        {
            bool usarQsv = EncoderDeVideo == "h264_qsv";

            if (usarQsv && _dxgiGpuOk) return ModoCaptura.DxgiGpu;
            if (_dxgiCpuOk) return ModoCaptura.DxgiCpu;
            return ModoCaptura.Gdi;
        }

        private void ParametrosCalidad(out int ancho, out int crf, out int globalQuality)
        {
            switch (Calidad)
            {
                case CalidadVideo.Alta:
                    ancho = 0; crf = 22; globalQuality = 23;
                    break;
                case CalidadVideo.Baja:
                    ancho = 854; crf = 28; globalQuality = 28;
                    break;
                default: // Media
                    ancho = 1280; crf = 25; globalQuality = 25;
                    break;
            }
        }

        /// <summary>
        /// Arma la parte de VIDEO de la línea de ffmpeg para el modo indicado.
        /// 'entrada' devuelve las opciones de entrada (solo hacen falta con gdigrab).
        /// </summary>
        private string PartesVideo(ModoCaptura modo, bool usarQsv, bool conAudio, out string entrada)
        {
            int ancho, crf, gq;
            ParametrosCalidad(out ancho, out crf, out gq);

            string pix = usarQsv ? "nv12" : "yuv420p";

            // Se añade -profile:v main y async_depth para mayor estabilidad en la UHD 600
            // Se añade -g {Fps * 2} para fijar keyframes y -look_ahead 0 para no ahogar la VRAM
            string codec = usarQsv
                ? $"-c:v h264_qsv -preset veryfast -profile:v main -bf 0 -g {Fps * 2} -look_ahead 0 -global_quality {gq} -async_depth 1"
                : $"-c:v libx264 -preset ultrafast -tune zerolatency -crf {crf} -threads 2";

            string escalaCpu = ancho > 0
                ? $"scale={ancho}:-2:flags=fast_bilinear"
                : "scale=trunc(iw/2)*2:trunc(ih/2)*2:flags=fast_bilinear";

            // FIX CLAVE: vpp_qsv no soporta bien h=-1. 
            // Usamos una fórmula que calcula el alto proporcional exacto y lo fuerza a ser número par.
            string escalaGpu = ancho > 0 ? $"w={ancho}:h='trunc({ancho}*ih/iw/2)*2':" : "";

            string dxgi = $"ddagrab=output_idx=0:framerate={Fps}:draw_mouse=1";
            string mapAudio = conAudio ? " -map 0:a" : "";

            switch (modo)
            {
                case ModoCaptura.DxgiGpu:
                    // Inicializar el dispositivo globalmente ayuda a que ddagrab y qsv compartan memoria sin errores
                    entrada = "-init_hw_device qsv=hw -filter_hw_device hw";
                    return $"-filter_complex \"{dxgi},hwmap=derive_device=qsv,format=qsv,vpp_qsv={escalaGpu}format=nv12[v]\" -map \"[v]\"{mapAudio} {codec}";

                case ModoCaptura.DxgiCpu:
                    entrada = "";
                    return $"-filter_complex \"{dxgi},hwdownload,format=bgra,{escalaCpu},format={pix}[v]\" -map \"[v]\"{mapAudio} {codec}";

                default: // Gdi
                    entrada = $"-rtbufsize 100M -f gdigrab -framerate {Fps} -draw_mouse 1 -i desktop";
                    return $"-vf \"{escalaCpu},format={pix}\" {codec}";
            }
        }

        public string ConstruirArgumentosGrabacion(string rutaSalida)
        {
            bool usarQsv = EncoderDeVideo == "h264_qsv";
            bool conAudio = !string.IsNullOrEmpty(Microfono);

            string entradaVideo;
            string video = PartesVideo(ElegirModo(), usarQsv, conAudio, out entradaVideo);

            // AUMENTO DE BUFFER: thread_queue_size pasa a 2048
            string entradaAudio = conAudio
                ? $"-thread_queue_size 2048 -rtbufsize 100M -f dshow -i audio=\"{Microfono}\""
                : "";

            string ganancia = GananciaMicrofono.ToString("0.0", CultureInfo.InvariantCulture);
            string audio = conAudio
                ? $"-af \"volume={ganancia},alimiter=limit=0.9\" -c:a aac -b:a 64k -ar 44100"
                : "-an";

            // RITMO CONSTANTE: Añadimos -fps_mode crf antes de la ruta de salida
            return $"{entradaVideo} {entradaAudio} {video} {audio} -fps_mode vfr \"{rutaSalida}\" -y";
        }

        // ==========================================
        // UTILIDAD: ejecutar ffmpeg (con tiempo máximo) y leer lo que responde
        // ==========================================

        private int EjecutarFFmpeg(string argumentos, out string mensajes)
        {
            ProcessStartInfo opciones = new ProcessStartInfo
            {
                FileName = _rutaFFmpeg,
                Arguments = argumentos,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                StandardErrorEncoding = System.Text.Encoding.UTF8
            };

            using (Process proceso = Process.Start(opciones))
            {
                Task<string> lector = proceso.StandardError.ReadToEndAsync();

                if (!proceso.WaitForExit(15000))
                {
                    try { proceso.Kill(); } catch { }
                    mensajes = "Tiempo agotado esperando a ffmpeg.";
                    return -1;
                }

                mensajes = lector.Result;
                return proceso.ExitCode;
            }
        }
    }
}