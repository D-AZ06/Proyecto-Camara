using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Proyecto_Camara
{
    public partial class FormGrabar : Form
    {
        // Importación de la API de Windows para excluir la ventana de capturas/grabaciones
        [DllImport("user32.dll")]
        private static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        private const uint WDA_NONE = 0x00000000;                  // Visible en capturas
        private const uint WDA_EXCLUDEFROMCAPTURE = 0x00000011;    // Invisible en capturas (Windows 10/11)

        // Instancia del backend
        private readonly Camara _camara;

        // Referencia al formulario de inicio para poder volver a él
        private readonly FormInicio _inicio;

        public FormGrabar(Controladores controladores, FormInicio inicio)
        {
            InitializeComponent();
            _inicio = inicio;
            _camara = new Camara(controladores);
        }

        private readonly Stopwatch _cronometro = new Stopwatch();

        private void FormGrabar_Load(object sender, EventArgs e)
        {
            timerTiempo.Interval = 500;
            timerTiempo.Tick -= timerTiempo_Tick;   // evita duplicarlo si el diseñador ya lo conectó
            timerTiempo.Tick += timerTiempo_Tick;
            btnPausarReanudar.Enabled = false;
            btnPausarReanudar.Text = "Pausar";

            // Decirle a Windows que esta ventana no aparezca en grabaciones ni capturas de pantalla
            SetWindowDisplayAffinity(this.Handle, WDA_EXCLUDEFROMCAPTURE);

            lblTiempo.Text = "00:00:00";
            ActualizarEstadoUI(EstadoVisual.Detenido);
        }

        /// <summary>
        /// Obtiene la ruta de la carpeta 'ProyectoCamara' dentro de 'Videos'.
        /// Si no existe en la PC del usuario, la crea automáticamente.
        /// </summary>
        private string ObtenerRutaCarpetaVideos()
        {
            // Apunta a: Este Equipo / Vídeos / ProyectoCamara 
            string rutaVideos = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                "ProyectoCamara"
            );

            // Si la carpeta no existe en la PC del usuario, C# la crea
            if (!Directory.Exists(rutaVideos))
            {
                Directory.CreateDirectory(rutaVideos);
            }

            return rutaVideos;
        }

        private enum EstadoVisual
        {
            Detenido,
            Grabando,
            Pausado,
            Finalizado
        }

        private void ActualizarEstadoUI(EstadoVisual estado)
        {
            switch (estado)
            {
                case EstadoVisual.Detenido:
                    pnlEstado.BackColor = Color.Gray;
                    lblEstadoTexto.Text = "Listo / Detenido";
                    lblEstadoTexto.ForeColor = Color.White;
                    break;

                case EstadoVisual.Grabando:
                    pnlEstado.BackColor = Color.Crimson; // Rojo activo
                    lblEstadoTexto.Text = "● GRABANDO";
                    lblEstadoTexto.ForeColor = Color.White;
                    break;

                case EstadoVisual.Pausado:
                    pnlEstado.BackColor = Color.DarkOrange; // Naranja pausa
                    lblEstadoTexto.Text = "⏸ EN PAUSA";
                    lblEstadoTexto.ForeColor = Color.White;
                    break;

                case EstadoVisual.Finalizado:
                    pnlEstado.BackColor = Color.ForestGreen; // Verde completado
                    lblEstadoTexto.Text = "✔ GRABACIÓN GUARDADA";
                    lblEstadoTexto.ForeColor = Color.White;
                    break;
            }
        }

        private void timerTiempo_Tick(object sender, EventArgs e)
        {
            lblTiempo.Text = _cronometro.Elapsed.ToString(@"hh\:mm\:ss");
        }

        // ==========================================
        // BOTÓN 1: TOMAR CAPTURA DE PANTALLA (SIN EL FORMULARIO)
        // ==========================================
        private async void btnTomarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreFoto = $"captura_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
                string rutaCompleta = Path.Combine(ObtenerRutaCarpetaVideos(), nombreFoto);

                // Ya no usamos this.Hide(), Windows oculta la ventana automáticamente en la foto
                bool exito = await Task.Run(() => _camara.CapturarFoto(rutaCompleta));

                if (exito)
                {
                    MessageBox.Show($"Captura guardada en:\n{rutaCompleta}", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al tomar captura: {ex.Message}", "Error");
            }
        }

        // ==========================================
        // BOTÓN 2: GRABAR / DETENER PANTALLA (RÁPIDO Y FLUIDO)
        // ==========================================
        private async void btnGrabarDetener_Click(object sender, EventArgs e)
        {
            btnGrabarDetener.Enabled = false;

            try
            {
                if (!_camara.EnGrabacion)
                {
                    // --- INICIANDO GRABACIÓN ---
                    string nombreVideo = $"pantalla_{DateTime.Now:yyyyMMdd_HHmmss}.mp4";
                    string rutaCompleta = Path.Combine(ObtenerRutaCarpetaVideos(), nombreVideo);

                    await Task.Run(() => _camara.IniciarGrabacion(rutaCompleta));

                    btnGrabarDetener.Text = "Detener Grabación";
                    btnGrabarDetener.BackColor = Color.Red;

                    btnPausarReanudar.Enabled = true;
                    btnPausarReanudar.Text = "Pausar";
                    btnPausarReanudar.BackColor = Color.Orange;

                    // Integración de Cronómetro y Panel (Rojo)
                    _cronometro.Restart();
                    lblTiempo.Text = "00:00:00";
                    timerTiempo.Start();
                    ActualizarEstadoUI(EstadoVisual.Grabando);
                }
                else
                {
                    // --- DETENIENDO GRABACIÓN ---
                    await Task.Run(() => _camara.DetenerGrabacion());

                    btnGrabarDetener.Text = "Iniciar Grabación";
                    btnGrabarDetener.BackColor = Color.Green;

                    btnPausarReanudar.Enabled = false;
                    btnPausarReanudar.Text = "Pausar";

                    // Integración de Cronómetro y Panel (Verde)
                    _cronometro.Stop();
                    timerTiempo.Stop();
                    ActualizarEstadoUI(EstadoVisual.Finalizado);

                    MessageBox.Show("Grabación guardada en la carpeta ProyectoCamara.", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error");
            }
            finally
            {
                btnGrabarDetener.Enabled = true;
            }
        }

        // ==========================================
        // BOTÓN 3: PAUSAR / REANUDAR (RESPUESTA INMEDIATA)
        // ==========================================
        private async void btnPausarReanudar_Click(object sender, EventArgs e)
        {
            btnPausarReanudar.Enabled = false;

            try
            {
                if (!_camara.EnPausa)
                {
                    // --- PAUSANDO ---
                    await Task.Run(() => _camara.PausarGrabacion());

                    btnPausarReanudar.Text = "Reanudar";
                    btnPausarReanudar.BackColor = Color.Yellow;

                    // Integración: Detener reloj y cambiar a Naranja
                    _cronometro.Stop();
                    timerTiempo.Stop();
                    ActualizarEstadoUI(EstadoVisual.Pausado);
                }
                else
                {
                    // --- REANUDANDO ---
                    await Task.Run(() => _camara.ReanudarGrabacion());

                    btnPausarReanudar.Text = "Pausar";
                    btnPausarReanudar.BackColor = Color.Orange;

                    // Integración: Reanudar reloj y volver a Rojo
                    _cronometro.Start();
                    timerTiempo.Start();
                    ActualizarEstadoUI(EstadoVisual.Grabando);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al pausar/reanudar: {ex.Message}", "Error");
            }
            finally
            {
                btnPausarReanudar.Enabled = true;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            _inicio.Show();
            this.Close();
        }


    }
}