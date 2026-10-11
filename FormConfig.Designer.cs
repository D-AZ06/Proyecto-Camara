namespace Proyecto_Camara
{
    partial class FormConfig
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlConfig;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabCamara;
        private System.Windows.Forms.CheckBox chkHabilitarCamara;
        private System.Windows.Forms.ComboBox cmbDispositivos;
        private System.Windows.Forms.Label lblDispositivos;
        private System.Windows.Forms.ComboBox cmbFormaCamara;
        private System.Windows.Forms.Label lblForma;
        private System.Windows.Forms.Panel pnlPantallaSimulada;
        private System.Windows.Forms.PictureBox picCamaraPreview;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblInfoSimulador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlConfig = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabCamara = new System.Windows.Forms.TabPage();
            this.lblInfoSimulador = new System.Windows.Forms.Label();
            this.pnlPantallaSimulada = new System.Windows.Forms.Panel();
            this.picCamaraPreview = new System.Windows.Forms.PictureBox();
            this.cmbFormaCamara = new System.Windows.Forms.ComboBox();
            this.lblForma = new System.Windows.Forms.Label();
            this.cmbDispositivos = new System.Windows.Forms.ComboBox();
            this.lblDispositivos = new System.Windows.Forms.Label();
            this.chkHabilitarCamara = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabControlConfig.SuspendLayout();
            this.tabCamara.SuspendLayout();
            this.pnlPantallaSimulada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamaraPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlConfig
            // 
            this.tabControlConfig.Controls.Add(this.tabGeneral);
            this.tabControlConfig.Controls.Add(this.tabCamara);
            this.tabControlConfig.Location = new System.Drawing.Point(12, 12);
            this.tabControlConfig.Name = "tabControlConfig";
            this.tabControlConfig.SelectedIndex = 0;
            this.tabControlConfig.Size = new System.Drawing.Size(560, 420);
            this.tabControlConfig.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(552, 391);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabCamara
            // 
            this.tabCamara.Controls.Add(this.lblInfoSimulador);
            this.tabCamara.Controls.Add(this.pnlPantallaSimulada);
            this.tabCamara.Controls.Add(this.cmbFormaCamara);
            this.tabCamara.Controls.Add(this.lblForma);
            this.tabCamara.Controls.Add(this.cmbDispositivos);
            this.tabCamara.Controls.Add(this.lblDispositivos);
            this.tabCamara.Controls.Add(this.chkHabilitarCamara);
            this.tabCamara.Location = new System.Drawing.Point(4, 25);
            this.tabCamara.Name = "tabCamara";
            this.tabCamara.Padding = new System.Windows.Forms.Padding(3);
            this.tabCamara.Size = new System.Drawing.Size(552, 391);
            this.tabCamara.TabIndex = 1;
            this.tabCamara.Text = "Cámara Flotante";
            this.tabCamara.UseVisualStyleBackColor = true;
            // 
            // lblInfoSimulador
            // 
            this.lblInfoSimulador.AutoSize = true;
            this.lblInfoSimulador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInfoSimulador.Location = new System.Drawing.Point(17, 95);
            this.lblInfoSimulador.Name = "lblInfoSimulador";
            this.lblInfoSimulador.Size = new System.Drawing.Size(411, 20);
            this.lblInfoSimulador.TabIndex = 5;
            this.lblInfoSimulador.Text = "Arrastra el cuadro azul para elegir dónde aparecerá en el video:";
            // 
            // pnlPantallaSimulada
            // 
            this.pnlPantallaSimulada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlPantallaSimulada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPantallaSimulada.Controls.Add(this.picCamaraPreview);
            this.pnlPantallaSimulada.Location = new System.Drawing.Point(20, 115);
            this.pnlPantallaSimulada.Name = "pnlPantallaSimulada";
            this.pnlPantallaSimulada.Size = new System.Drawing.Size(480, 270);
            this.pnlPantallaSimulada.TabIndex = 6;
            // 
            // picCamaraPreview
            // 
            this.picCamaraPreview.BackColor = System.Drawing.Color.DodgerBlue;
            this.picCamaraPreview.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.picCamaraPreview.Location = new System.Drawing.Point(380, 200);
            this.picCamaraPreview.Name = "picCamaraPreview";
            this.picCamaraPreview.Size = new System.Drawing.Size(80, 60);
            this.picCamaraPreview.TabIndex = 0;
            this.picCamaraPreview.TabStop = false;
            // 
            // cmbFormaCamara
            // 
            this.cmbFormaCamara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaCamara.FormattingEnabled = true;
            this.cmbFormaCamara.Location = new System.Drawing.Point(350, 52);
            this.cmbFormaCamara.Name = "cmbFormaCamara";
            this.cmbFormaCamara.Size = new System.Drawing.Size(150, 24);
            this.cmbFormaCamara.TabIndex = 4;
            // 
            // lblForma
            // 
            this.lblForma.AutoSize = true;
            this.lblForma.Location = new System.Drawing.Point(300, 55);
            this.lblForma.Name = "lblForma";
            this.lblForma.Size = new System.Drawing.Size(49, 16);
            this.lblForma.TabIndex = 3;
            this.lblForma.Text = "Forma:";
            // 
            // cmbDispositivos
            // 
            this.cmbDispositivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispositivos.FormattingEnabled = true;
            this.cmbDispositivos.Location = new System.Drawing.Point(80, 52);
            this.cmbDispositivos.Name = "cmbDispositivos";
            this.cmbDispositivos.Size = new System.Drawing.Size(200, 24);
            this.cmbDispositivos.TabIndex = 2;
            // 
            // lblDispositivos
            // 
            this.lblDispositivos.AutoSize = true;
            this.lblDispositivos.Location = new System.Drawing.Point(17, 55);
            this.lblDispositivos.Name = "lblDispositivos";
            this.lblDispositivos.Size = new System.Drawing.Size(58, 16);
            this.lblDispositivos.TabIndex = 1;
            this.lblDispositivos.Text = "Cámara:";
            // 
            // chkHabilitarCamara
            // 
            this.chkHabilitarCamara.AutoSize = true;
            this.chkHabilitarCamara.Location = new System.Drawing.Point(20, 20);
            this.chkHabilitarCamara.Name = "chkHabilitarCamara";
            this.chkHabilitarCamara.Size = new System.Drawing.Size(181, 20);
            this.chkHabilitarCamara.TabIndex = 0;
            this.chkHabilitarCamara.Text = "Habilitar Cámara Flotante";
            this.chkHabilitarCamara.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(470, 440);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // FormConfig
            // 
            this.ClientSize = new System.Drawing.Size(584, 481);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControlConfig);
            this.Name = "FormConfig";
            this.Text = "Configuración del Grabador";
            this.tabControlConfig.ResumeLayout(false);
            this.tabCamara.ResumeLayout(false);
            this.tabCamara.PerformLayout();
            this.pnlPantallaSimulada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamaraPreview)).EndInit();
            this.ResumeLayout(false);

        }
    }
}