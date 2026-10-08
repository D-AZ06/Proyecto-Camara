using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Camara
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnGrabacion_Click(object sender, EventArgs e)
        {
            FormGrabar grabar = new FormGrabar();
            grabar.Show();
            this.Hide();
        }
    }
}
