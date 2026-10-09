using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Proyecto_Camara
{
    internal class Camara
    {
        private readonly string _rutaFFmpeg;
        private Process _procesoGrabacion;
        private readonly Controladores _controladores;
        private readonly List<string> _fragmentosTemporales = new List<string>();
        private string _rutaVideoFinal;
        private readonly StringBuilder _erroresFFmpeg = new StringBuilder();

        public bool EnGrabacion { get; private set; }
        public bool EnPausa { get; private set; }

        public Camara(Controladores controladores)
        {
            _rutaFFmpeg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "ffmpeg.exe");
            _controladores = controladores;
        }

        public bool CapturarFoto(string rutaDondeGuardar)
        {
            if (!File.Exists(_rutaFFmpeg))
            {
                throw new FileNotFoundException("No se encontró el ejecutable ffmpeg.exe en la carpeta Tools.");
            }

            ProcessStartInfo opciones = new ProcessStartInfo
            {
                FileName = _rutaFFmpeg,
                Arguments = $"-f gdigrab -i desktop -vframes 1 \"{rutaDondeGuardar}\" -y",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            using (Process proceso = Process.Start(opciones))
            {
                proceso?.WaitForExit(5000);
            }

            return File.Exists(rutaDondeGuardar);
        }

        public void IniciarGrabacion(string rutaVideoSalida)
        {
            if (EnGrabacion)
            {
                throw new Exception("Ya hay una grabación en curso.");
            }

            _rutaVideoFinal = rutaVideoSalida;
            _fragmentosTemporales.Clear();

            _controladores.Detectar();
            Debug.WriteLine($"Encoder usado: {_controladores.EncoderDeVideo}");

            IniciarNuevoFragmento();

            EnGrabacion = true;
            EnPausa = false;
        }

        public void PausarGrabacion()
        {
            if (EnGrabacion && !EnPausa)
            {
                DetenerProcesoActual();
                EnPausa = true;
            }
        }

        public void ReanudarGrabacion()
        {
            if (EnGrabacion && EnPausa)
            {
                IniciarNuevoFragmento();
                EnPausa = false;
            }
        }

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
                // Solo muestra errores (menos trabajo y mensajes más claros)
                Arguments = "-hide_banner -loglevel error -nostats " + _controladores.ConstruirArgumentosGrabacion(rutaClip),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                StandardErrorEncoding = Encoding.UTF8
            };

            _erroresFFmpeg.Clear();
            _procesoGrabacion = Process.Start(opciones);

            try { _procesoGrabacion.PriorityClass = ProcessPriorityClass.AboveNormal; } catch { }

            _procesoGrabacion.ErrorDataReceived += (s, ev) =>
            {
                if (ev.Data != null) _erroresFFmpeg.AppendLine(ev.Data);
            };
            _procesoGrabacion.BeginErrorReadLine();

            // Si ffmpeg se cierra casi al instante, algo salió mal: mostramos el motivo
            if (_procesoGrabacion.WaitForExit(700))
            {
                _procesoGrabacion.WaitForExit();   // termina de leer los mensajes
                string detalle = _erroresFFmpeg.ToString();
                _procesoGrabacion.Close();
                _procesoGrabacion = null;
                throw new Exception("ffmpeg se cerró al iniciar:\n" + detalle);
            }
        }

        private void DetenerProcesoActual()
        {
            if (_procesoGrabacion != null && !_procesoGrabacion.HasExited)
            {
                try
                {
                    // Se envía 'q' y se fueraza el vaciado del búfer (Flush)
                    _procesoGrabacion.StandardInput.WriteLine("q");
                    _procesoGrabacion.StandardInput.Flush();

                    // Se le dan 10 segundos a FFmpeg para escribir el encabezado MP4 correctamente
                    if (!_procesoGrabacion.WaitForExit(10000))
                    {
                        _procesoGrabacion.Kill();
                    }
                }
                catch
                {
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
            // Un solo fragmento (sin pausas): no hace falta unir nada, solo mover el archivo
            if (fragmentos.Count == 1 && File.Exists(fragmentos[0]))
            {
                File.Move(fragmentos[0], rutaSalidaFinal);
                return;
            }

            string rutaListaTxt = Path.Combine(Path.GetTempPath(), $"lista_{Guid.NewGuid()}.txt");

            using (StreamWriter writer = new StreamWriter(rutaListaTxt))
            {
                foreach (string clip in fragmentos)
                {
                    // Solo clips que existen y no están vacíos
                    if (File.Exists(clip) && new FileInfo(clip).Length > 0)
                    {
                        writer.WriteLine($"file '{clip.Replace("\\", "/")}'");
                    }
                }
            }

            ProcessStartInfo opciones = new ProcessStartInfo
            {
                FileName = _rutaFFmpeg,
                Arguments = $"-hide_banner -loglevel warning -f concat -safe 0 -fflags +genpts -i \"{rutaListaTxt}\" -c copy -avoid_negative_ts make_zero \"{rutaSalidaFinal}\" -y",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                StandardErrorEncoding = Encoding.UTF8
            };

            string mensajes;
            int codigo;
            using (Process proceso = Process.Start(opciones))
            {
                mensajes = proceso.StandardError.ReadToEnd();
                proceso.WaitForExit();
                codigo = proceso.ExitCode;
            }

            Debug.WriteLine("Unir fragmentos: " + mensajes);

            if (File.Exists(rutaListaTxt)) File.Delete(rutaListaTxt);

            // Si falló, NO borramos los clips para no perder la grabación
            if (codigo != 0 || !File.Exists(rutaSalidaFinal))
            {
                throw new Exception("No se pudieron unir los fragmentos. Los clips quedaron en:\n"
                    + Path.GetTempPath() + "\n\n" + mensajes);
            }

            foreach (string clip in fragmentos)
            {
                if (File.Exists(clip)) File.Delete(clip);
            }
        }
    }
}