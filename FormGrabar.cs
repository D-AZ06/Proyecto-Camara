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
        private Camara _camara = new Camara();

        public FormGrabar()
        {
            InitializeComponent();
        }

        private void FormGrabar_Load(object sender, EventArgs e)
        {
            btnPausarReanudar.Enabled = false;
            btnPausarReanudar.Text = "Pausar";

            // Decirle a Windows que esta ventana no aparezca en grabaciones ni capturas de pantalla
            SetWindowDisplayAffinity(this.Handle, WDA_EXCLUDEFROMCAPTURE);
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
                    string nombreVideo = $"pantalla_{DateTime.Now:yyyyMMdd_HHmmss}.mp4";
                    string rutaCompleta = Path.Combine(ObtenerRutaCarpetaVideos(), nombreVideo);

                    await Task.Run(() => _camara.IniciarGrabacion(rutaCompleta));

                    btnGrabarDetener.Text = "Detener Grabación";
                    btnGrabarDetener.BackColor = Color.Red;

                    btnPausarReanudar.Enabled = true;
                    btnPausarReanudar.Text = "Pausar";
                    btnPausarReanudar.BackColor = Color.Orange;
                }
                else
                {
                    await Task.Run(() => _camara.DetenerGrabacion());

                    btnGrabarDetener.Text = "Iniciar Grabación";
                    btnGrabarDetener.BackColor = Color.Green;

                    btnPausarReanudar.Enabled = false;
                    btnPausarReanudar.Text = "Pausar";

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
                    await Task.Run(() => _camara.PausarGrabacion());

                    btnPausarReanudar.Text = "Reanudar";
                    btnPausarReanudar.BackColor = Color.Yellow;
                }
                else
                {
                    await Task.Run(() => _camara.ReanudarGrabacion());

                    btnPausarReanudar.Text = "Pausar";
                    btnPausarReanudar.BackColor = Color.Orange;
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
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Close();
        }

        
    }
}
