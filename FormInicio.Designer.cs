namespace Proyecto_Camara
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGrabacion = new System.Windows.Forms.Button();
            this.lblEncoder = new System.Windows.Forms.Label();
            this.cmbEncoder = new System.Windows.Forms.ComboBox();
            this.lblMicrofono = new System.Windows.Forms.Label();
            this.cmbMicrofono = new System.Windows.Forms.ComboBox();
            this.lblFps = new System.Windows.Forms.Label();
            this.nudFps = new System.Windows.Forms.NumericUpDown();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbCalidad = new System.Windows.Forms.ComboBox();
            this.lblCalidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFps)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabacion
            // 
            this.btnGrabacion.Location = new System.Drawing.Point(200, 260);
            this.btnGrabacion.Name = "btnGrabacion";
            this.btnGrabacion.Size = new System.Drawing.Size(120, 35);
            this.btnGrabacion.TabIndex = 0;
            this.btnGrabacion.Text = "Grabar";
            this.btnGrabacion.UseVisualStyleBackColor = true;
            this.btnGrabacion.Click += new System.EventHandler(this.btnGrabacion_Click);
            // 
            // lblEncoder
            // 
            this.lblEncoder.AutoSize = true;
            this.lblEncoder.Location = new System.Drawing.Point(60, 60);
            this.lblEncoder.Name = "lblEncoder";
            this.lblEncoder.Size = new System.Drawing.Size(117, 16);
            this.lblEncoder.TabIndex = 1;
            this.lblEncoder.Text = "Encoder de video:";
            // 
            // cmbEncoder
            // 
            this.cmbEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoder.FormattingEnabled = true;
            this.cmbEncoder.Location = new System.Drawing.Point(200, 57);
            this.cmbEncoder.Name = "cmbEncoder";
            this.cmbEncoder.Size = new System.Drawing.Size(300, 24);
            this.cmbEncoder.TabIndex = 2;
            // 
            // lblMicrofono
            // 
            this.lblMicrofono.AutoSize = true;
            this.lblMicrofono.Location = new System.Drawing.Point(60, 110);
            this.lblMicrofono.Name = "lblMicrofono";
            this.lblMicrofono.Size = new System.Drawing.Size(69, 16);
            this.lblMicrofono.TabIndex = 3;
            this.lblMicrofono.Text = "Micrófono:";
            // 
            // cmbMicrofono
            // 
            this.cmbMicrofono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMicrofono.FormattingEnabled = true;
            this.cmbMicrofono.Location = new System.Drawing.Point(200, 107);
            this.cmbMicrofono.Name = "cmbMicrofono";
            this.cmbMicrofono.Size = new System.Drawing.Size(300, 24);
            this.cmbMicrofono.TabIndex = 4;
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(60, 160);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(36, 16);
            this.lblFps.TabIndex = 5;
            this.lblFps.Text = "FPS:";
            // 
            // nudFps
            // 
            this.nudFps.Location = new System.Drawing.Point(200, 158);
            this.nudFps.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudFps.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFps.Name = "nudFps";
            this.nudFps.Size = new System.Drawing.Size(80, 22);
            this.nudFps.TabIndex = 6;
            this.nudFps.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(60, 215);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(50, 16);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            // 
            // cmbCalidad
            // 
            this.cmbCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalidad.FormattingEnabled = true;
            this.cmbCalidad.Location = new System.Drawing.Point(200, 186);
            this.cmbCalidad.Name = "cmbCalidad";
            this.cmbCalidad.Size = new System.Drawing.Size(300, 24);
            this.cmbCalidad.TabIndex = 9;
            // 
            // lblCalidad
            // 
            this.lblCalidad.AutoSize = true;
            this.lblCalidad.Location = new System.Drawing.Point(60, 189);
            this.lblCalidad.Name = "lblCalidad";
            this.lblCalidad.Size = new System.Drawing.Size(57, 16);
            this.lblCalidad.TabIndex = 8;
            this.lblCalidad.Text = "Calidad:";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbCalidad);
            this.Controls.Add(this.lblCalidad);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.nudFps);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.cmbMicrofono);
            this.Controls.Add(this.lblMicrofono);
            this.Controls.Add(this.cmbEncoder);
            this.Controls.Add(this.lblEncoder);
            this.Controls.Add(this.btnGrabacion);
            this.Name = "FormInicio";
            this.Text = "Proyecto Cámara";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabacion;
        private System.Windows.Forms.Label lblEncoder;
        private System.Windows.Forms.ComboBox cmbEncoder;
        private System.Windows.Forms.Label lblMicrofono;
        private System.Windows.Forms.ComboBox cmbMicrofono;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.NumericUpDown nudFps;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbCalidad;
        private System.Windows.Forms.Label lblCalidad;
    }
}