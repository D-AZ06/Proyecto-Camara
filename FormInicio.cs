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
using static Proyecto_Camara.Controladores;

namespace Proyecto_Camara
{
    public partial class FormInicio : Form
    {
        // Las herramientas de grabación: se crean aquí y se pasan a FormGrabar
        private readonly Controladores _controladores;

        public FormInicio()
        {
            InitializeComponent();

            string rutaFFmpeg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "ffmpeg.exe");
            _controladores = new Controladores(rutaFFmpeg);
        }

        private async void FormInicio_Load(object sender, EventArgs e)
        {
            btnGrabacion.Enabled = false;
            lblEstado.Text = "Detectando herramientas...";

            try
            {
                // Corre en segundo plano para que la ventana no se congele
                await Task.Run(() => _controladores.Detectar());

                cmbEncoder.DataSource = _controladores.EncodersDisponibles;

                List<string> micros = new List<string> { "(Sin audio)" };
                micros.AddRange(_controladores.DispositivosAudio);
                cmbMicrofono.DataSource = micros;

                nudFps.Value = _controladores.Fps;

                // El orden debe coincidir con el enum: Alta = 0, Media = 1, Baja = 2
                cmbCalidad.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCalidad.Items.Clear();
                cmbCalidad.Items.Add("Alta - Original (tamaño de tu pantalla)");
                cmbCalidad.Items.Add("Media - 1280 x 720");
                cmbCalidad.Items.Add("Baja - 854 x 480");
                cmbCalidad.SelectedIndex = 0;   // Alta por defecto

                lblEstado.Text = "Listo (" + _controladores.Descripcion + ")";
                btnGrabacion.Enabled = true;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al detectar";
                MessageBox.Show($"No se pudo detectar: {ex.Message}", "Error");
            }
        }

        private void btnGrabacion_Click(object sender, EventArgs e)
        {
            // Guardamos lo que el usuario eligió
            _controladores.EncoderDeVideo = cmbEncoder.SelectedItem.ToString();
            _controladores.Microfono = cmbMicrofono.SelectedIndex == 0
                ? null
                : cmbMicrofono.SelectedItem.ToString();
            _controladores.Fps = (int)nudFps.Value;
            _controladores.Calidad = (CalidadVideo)cmbCalidad.SelectedIndex;

            FormGrabar grabar = new FormGrabar(_controladores, this);
            grabar.Show();
            this.Hide();
        }
    }
}