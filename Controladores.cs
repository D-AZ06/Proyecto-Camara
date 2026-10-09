using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Proyecto_Camara
{
    public class Controladores
    {
        private readonly string _rutaFFmpeg;

        public List<string> EncodersDisponibles { get; private set; } = new List<string>();
        public string EncoderDeVideo { get; set; } = "libx264";
        public List<string> DispositivosAudio { get; private set; } = new List<string>();
        public List<string> DispositivosVideo { get; private set; } = new List<string>();
        public string Microfono { get; set; }
        public int Fps { get; set; } = 24;
        public bool Detectado { get; private set; }
        // 1.0 = sin cambios, 2.0 = el doble (+6 dB). Súbelo o bájalo a tu gusto.
        public double GananciaMicrofono { get; set; } = 2.0;

        public enum CalidadVideo
        {
            Alta,  
            Media, 
            Baja   
        }

        public CalidadVideo Calidad { get; set; } = CalidadVideo.Media;

        public Controladores(string rutaFFmpeg)
        {
            _rutaFFmpeg = rutaFFmpeg;
        }

        public void Detectar()
        {
            if (Detectado) return;

            EncodersDisponibles.Clear();
            if (FuncionaQsv()) EncodersDisponibles.Add("h264_qsv");
            EncodersDisponibles.Add("libx264");
            EncoderDeVideo = EncodersDisponibles[0];

            ListarDispositivos();
            Detectado = true;
        }

        private bool FuncionaQsv()
        {
            string argumentos =
                "-hide_banner -f lavfi -i color=c=black:s=640x360:d=0.2 " +
                "-c:v h264_qsv -preset veryfast -global_quality 28 -pix_fmt nv12 -f null -";

            int codigo = EjecutarFFmpeg(argumentos, out _);
            return codigo == 0;
        }

        private void ListarDispositivos()
        {
            DispositivosAudio = new List<string>();
            DispositivosVideo = new List<string>();

            EjecutarFFmpeg("-hide_banner -list_devices true -f dshow -i dummy", out string salida);

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

        public string ConstruirArgumentosGrabacion(string rutaSalida)
        {
            string filtro;
            int crf;
            int globalQuality;

            switch (Calidad)
            {
                case CalidadVideo.Alta:
                    // Tamaño original; el crop solo asegura medidas pares (H.264 lo exige)
                    filtro = "crop=trunc(iw/2)*2:trunc(ih/2)*2";
                    crf = 23;
                    globalQuality = 25;
                    break;

                case CalidadVideo.Baja:
                    filtro = "scale=854:-2:flags=fast_bilinear";
                    crf = 32;
                    globalQuality = 34;
                    break;

                case CalidadVideo.Media:
                default:
                    filtro = "scale=1280:-2:flags=fast_bilinear";
                    crf = 28;
                    globalQuality = 30;
                    break;
            }

            string entradaVideo = $"-rtbufsize 100M -f gdigrab -framerate {Fps} -draw_mouse 1 -i desktop";
            string entradaAudio = !string.IsNullOrEmpty(Microfono) ? $"-rtbufsize 50M -f dshow -i audio=\"{Microfono}\"" : "";

            string video = (EncoderDeVideo == "h264_qsv")
                ? $"-vf \"{filtro},format=nv12\" -c:v h264_qsv -preset veryfast -bf 0 -global_quality {globalQuality} -async_depth 1"
                : $"-vf \"{filtro},format=yuv420p\" -c:v libx264 -preset ultrafast -tune zerolatency -crf {crf} -threads 2";

            // InvariantCulture: en español el decimal sale con coma ("2,0") y ffmpeg no lo entiende
            string ganancia = GananciaMicrofono.ToString("0.0", CultureInfo.InvariantCulture);
            string audio = string.IsNullOrEmpty(Microfono)
                ? "-an"
                : $"-af \"volume={ganancia},alimiter=limit=0.9\" -c:a aac -b:a 64k -ar 44100";

            return $"{entradaVideo} {entradaAudio} {video} {audio} \"{rutaSalida}\" -y";
        }

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
                mensajes = proceso?.StandardError.ReadToEnd() ?? string.Empty;
                proceso?.WaitForExit();
                return proceso?.ExitCode ?? -1;
            }
        }
    }
}