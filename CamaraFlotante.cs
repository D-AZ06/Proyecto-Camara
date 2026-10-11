using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Camara
{
    
    public enum FormaCamara
        {
            Rectangular,
            BordesRedondeados,
            Circular
        }

    public class CamaraFlotante
    {
        public bool HabilitarCamara { get; set; } = false;
        public string NombreDispositivo { get; set; } = "";

        // Coordenadas basadas en tu resolución nativa (1920x1080)
        public int PosicionX { get; set; } = 1550; // Esquina inferior derecha
        public int PosicionY { get; set; } = 800;
        public int Ancho { get; set; } = 320;
        public int Alto { get; set; } = 240;
        public FormaCamara Forma { get; set; } = FormaCamara.Rectangular;
        
    }
}
