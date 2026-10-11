using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AForge.Video.DirectShow;

namespace Proyecto_Camara
{
    public partial class FormConfig : Form
    {
        public CamaraFlotante ConfigCamara { get; private set; } = new CamaraFlotante();

        private bool _arrastrando = false;
        private Point _puntoInicio;

        // Basado en tu captura de pantalla de 1920x1080 (Escala 100%)
        private const int AnchoPantallaReal = 1920;
        private const int AltoPantallaReal = 1080;

        public FormConfig()
        {
            InitializeComponent();
            CargarDispositivosDeVideo();
            ConfigurarEventos();
            CargarValoresPrevios();
        }

        private void CargarDispositivosDeVideo()
        {
            try
            {
                FilterInfoCollection dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo dispositivo in dispositivos)
                {
                    cmbDispositivos.Items.Add(dispositivo.Name);
                }

                if (cmbDispositivos.Items.Count > 0)
                    cmbDispositivos.SelectedIndex = 0;
                else
                    cmbDispositivos.Items.Add("No se detectó cámara");
            }
            catch (Exception)
            {
                cmbDispositivos.Items.Add("Error al cargar cámaras");
            }
        }

        private void ConfigurarEventos()
        {
            cmbFormaCamara.DataSource = Enum.GetValues(typeof(FormaCamara));
            cmbFormaCamara.SelectedIndexChanged += (s, e) => AplicarFormaPreview();

            chkHabilitarCamara.CheckedChanged += (s, e) =>
            {
                cmbDispositivos.Enabled = chkHabilitarCamara.Checked;
                cmbFormaCamara.Enabled = chkHabilitarCamara.Checked;
                picCamaraPreview.Visible = chkHabilitarCamara.Checked;
            };

            // Eventos para arrastrar el recuadro
            picCamaraPreview.MouseDown += (s, e) => { _arrastrando = true; _puntoInicio = e.Location; };
            picCamaraPreview.MouseUp += (s, e) => { _arrastrando = false; };
            picCamaraPreview.MouseMove += PicCamaraPreview_MouseMove;
        }

        private void CargarValoresPrevios()
        {
            chkHabilitarCamara.Checked = ConfigCamara.HabilitarCamara;
            cmbFormaCamara.SelectedItem = ConfigCamara.Forma;

            // Factor de escala (1920x1080 -> 480x270 es 1/4)
            float escala = (float)pnlPantallaSimulada.Width / AnchoPantallaReal;

            picCamaraPreview.Width = (int)(ConfigCamara.Ancho * escala);
            picCamaraPreview.Height = (int)(ConfigCamara.Alto * escala);
            picCamaraPreview.Left = (int)(ConfigCamara.PosicionX * escala);
            picCamaraPreview.Top = (int)(ConfigCamara.PosicionY * escala);

            AplicarFormaPreview();
        }

        private void PicCamaraPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (_arrastrando)
            {
                int nuevoLeft = picCamaraPreview.Left + e.X - _puntoInicio.X;
                int nuevoTop = picCamaraPreview.Top + e.Y - _puntoInicio.Y;

                // Limitar movimiento a los bordes del panel simulado
                nuevoLeft = Math.Max(0, Math.Min(nuevoLeft, pnlPantallaSimulada.Width - picCamaraPreview.Width));
                nuevoTop = Math.Max(0, Math.Min(nuevoTop, pnlPantallaSimulada.Height - picCamaraPreview.Height));

                picCamaraPreview.Left = nuevoLeft;
                picCamaraPreview.Top = nuevoTop;

                // Guardar la coordenada real (multiplicando por 4)
                float factorInverso = (float)AnchoPantallaReal / pnlPantallaSimulada.Width;
                ConfigCamara.PosicionX = (int)(nuevoLeft * factorInverso);
                ConfigCamara.PosicionY = (int)(nuevoTop * factorInverso);
            }
        }

        private void AplicarFormaPreview()
        {
            if (cmbFormaCamara.SelectedItem == null) return;
            ConfigCamara.Forma = (FormaCamara)cmbFormaCamara.SelectedItem;

            using (GraphicsPath path = new GraphicsPath())
            {
                int w = picCamaraPreview.Width;
                int h = picCamaraPreview.Height;

                if (ConfigCamara.Forma == FormaCamara.Circular)
                {
                    path.AddEllipse(0, 0, w, h);
                }
                else if (ConfigCamara.Forma == FormaCamara.BordesRedondeados)
                {
                    int radio = 10;
                    path.AddArc(0, 0, radio, radio, 180, 90);
                    path.AddArc(w - radio, 0, radio, radio, 270, 90);
                    path.AddArc(w - radio, h - radio, radio, radio, 0, 90);
                    path.AddArc(0, h - radio, radio, radio, 90, 90);
                    path.CloseAllFigures();
                }
                else
                {
                    path.AddRectangle(new Rectangle(0, 0, w, h));
                }

                picCamaraPreview.Region = new Region(path);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            ConfigCamara.HabilitarCamara = chkHabilitarCamara.Checked;
            if (cmbDispositivos.SelectedItem != null)
            {
                ConfigCamara.NombreDispositivo = cmbDispositivos.SelectedItem.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
