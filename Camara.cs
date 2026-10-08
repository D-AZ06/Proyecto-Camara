using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Proyecto_Camara
{
    internal class Camara
    {
        private readonly string _rutaFFmpeg;
        private Process _procesoGrabacion;

        // Lista de fragmentos temporales creados al pausar/reanudar
        private readonly List<string> _fragmentosTemporales = new List<string>();

        private string _rutaVideoFinal;

        // Estados de la grabación
        public bool EnGrabacion { get; private set; }
        public bool EnPausa { get; private set; }

        public Camara()
        {
            _rutaFFmpeg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "ffmpeg.exe");
        }

        /// <summary>
        /// Captura una foto de la pantalla completa del PC.
        /// </summary>
        public bool CapturarFoto(string rutaDondeGuardar)
        {
            if (!File.Exists(_rutaFFmpeg))
            {
                throw new FileNotFoundException("No se encontró el ejecutable ffmpeg.exe en la carpeta Tools.");
            }

            ProcessStartInfo opciones = new ProcessStartInfo
            {
                FileName = _rutaFFmpeg,
                // gdigrab -i desktop toma la pantalla entera del PC
                Arguments = $"-f gdigrab -i desktop -vframes 1 \"{rutaDondeGuardar}\" -y",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            using (Process proceso = Process.Start(opciones))
            {
                proceso.WaitForExit(5000); // Espera máxima de 5 segundos
            }

            return File.Exists(rutaDondeGuardar);
        }

        /// <summary>
        /// Inicia la grabación de la pantalla del PC.
        /// </summary>
        public void IniciarGrabacion(string rutaVideoSalida)
        {
            if (EnGrabacion)
            {
                throw new Exception("Ya hay una grabación en curso.");
            }

            _rutaVideoFinal = rutaVideoSalida;
            _fragmentosTemporales.Clear();

            IniciarNuevoFragmento();

            EnGrabacion = true;
            EnPausa = false;
        }

        /// <summary>
        /// Pausa la grabación cerrando el fragmento temporal activo.
        /// </summary>
        public void PausarGrabacion()
        {
            if (EnGrabacion && !EnPausa)
            {
                DetenerProcesoActual();
                EnPausa = true;
            }
        }

        /// <summary>
        /// Reanuda la grabación creando otro fragmento temporal de la pantalla.
        /// </summary>
        public void ReanudarGrabacion()
        {
            if (EnGrabacion && EnPausa)
            {
                IniciarNuevoFragmento();
                EnPausa = false;
            }
        }

        /// <summary>
        /// Detiene la grabación y une todos los fragmentos temporales en el archivo MP4 final.
        /// </summary>
        public void DetenerGrabacion()
        {
            if (!EnGrabacion) return;

            if (!EnPausa)
            {
                DetenerProcesoActual();
            }

            if (_fragmentosTemporales.Count > 0)
            {
                UnirFragmentos(_fragmentosTemporales, _rutaVideoFinal);
            }

            EnGrabacion = false;
            EnPausa = false;
        }

        // ==========================================
        // MÉTODOS PRIVADOS
        // ==========================================

        private void IniciarNuevoFragmento()
        {
            string rutaClip = Path.Combine(Path.GetTempPath(), $"clip_{Guid.NewGuid()}.mp4");
            _fragmentosTemporales.Add(rutaClip);

            ProcessStartInfo opciones = new ProcessStartInfo
            {
                FileName = _rutaFFmpeg,
                // Grabación de pantalla mediante gdigrab
                Arguments = $"-f gdigrab -framerate 30 -i desktop -c:v libx264 -pix_fmt yuv420p \"{rutaClip}\" -y",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true
            };

            _procesoGrabacion = Process.Start(opciones);
        }

        private void DetenerProcesoActual()
        {
            if (_procesoGrabacion != null && !_procesoGrabacion.HasExited)
            {
                try
                {
                    _procesoGrabacion.StandardInput.WriteLine("q");
                    _procesoGrabacion.WaitForExit(3000);
                }
                catch
                {
                    // Si el proceso no responde a la orden 'q', lo cerramos
                    if (!_procesoGrabacion.HasExited)
                    {
                        _procesoGrabacion.Kill();
                    }
                }
                finally
                {
                    _procesoGrabacion.Close();
                    _procesoGrabacion = null;
                }
            }
        }

        private void UnirFragmentos(List<string> fragmentos, string rutaSalidaFinal)
        {
            string rutaListaTxt = Path.Combine(Path.GetTempPath(), $"lista_{Guid.NewGuid()}.txt");

            using (StreamWriter writer = new StreamWriter(rutaListaTxt))
            {
                foreach (string clip in fragmentos)
                {
                    writer.WriteLine($"file '{clip.Replace("\\", "/")}'");
                }
            }

            ProcessStartInfo opciones = new ProcessStartInfo
            {
                FileName = _rutaFFmpeg,
                Arguments = $"-f concat -safe 0 -i \"{rutaListaTxt}\" -c copy \"{rutaSalidaFinal}\" -y",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            using (Process proceso = Process.Start(opciones))
            {
                proceso.WaitForExit();
            }

            // Limpieza de archivos temporales
            if (File.Exists(rutaListaTxt)) File.Delete(rutaListaTxt);
            foreach (string clip in fragmentos)
            {
                if (File.Exists(clip)) File.Delete(clip);
            }
        }
    }
}
