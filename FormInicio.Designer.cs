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
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudFps)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabacion
            // 
            this.btnGrabacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnGrabacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabacion.FlatAppearance.BorderSize = 0;
            this.btnGrabacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnGrabacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabacion.ForeColor = System.Drawing.Color.White;
            this.btnGrabacion.Location = new System.Drawing.Point(44, 375);
            this.btnGrabacion.Name = "btnGrabacion";
            this.btnGrabacion.Size = new System.Drawing.Size(206, 45);
            this.btnGrabacion.TabIndex = 0;
            this.btnGrabacion.Text = "● Grabar";
            this.btnGrabacion.UseVisualStyleBackColor = false;
            this.btnGrabacion.Click += new System.EventHandler(this.btnGrabacion_Click);
            // 
            // lblEncoder
            // 
            this.lblEncoder.AutoSize = true;
            this.lblEncoder.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncoder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblEncoder.Location = new System.Drawing.Point(40, 95);
            this.lblEncoder.Name = "lblEncoder";
            this.lblEncoder.Size = new System.Drawing.Size(129, 21);
            this.lblEncoder.TabIndex = 1;
            this.lblEncoder.Text = "Encoder de video";
            // 
            // cmbEncoder
            // 
            this.cmbEncoder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEncoder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEncoder.ForeColor = System.Drawing.Color.White;
            this.cmbEncoder.FormattingEnabled = true;
            this.cmbEncoder.Location = new System.Drawing.Point(44, 118);
            this.cmbEncoder.Name = "cmbEncoder";
            this.cmbEncoder.Size = new System.Drawing.Size(312, 31);
            this.cmbEncoder.TabIndex = 2;
            // 
            // lblMicrofono
            // 
            this.lblMicrofono.AutoSize = true;
            this.lblMicrofono.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicrofono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblMicrofono.Location = new System.Drawing.Point(40, 160);
            this.lblMicrofono.Name = "lblMicrofono";
            this.lblMicrofono.Size = new System.Drawing.Size(82, 21);
            this.lblMicrofono.TabIndex = 3;
            this.lblMicrofono.Text = "Micrófono";
            // 
            // cmbMicrofono
            // 
            this.cmbMicrofono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbMicrofono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMicrofono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMicrofono.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMicrofono.ForeColor = System.Drawing.Color.White;
            this.cmbMicrofono.FormattingEnabled = true;
            this.cmbMicrofono.Location = new System.Drawing.Point(44, 183);
            this.cmbMicrofono.Name = "cmbMicrofono";
            this.cmbMicrofono.Size = new System.Drawing.Size(312, 31);
            this.cmbMicrofono.TabIndex = 4;
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblFps.Location = new System.Drawing.Point(40, 290);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(36, 21);
            this.lblFps.TabIndex = 5;
            this.lblFps.Text = "FPS";
            // 
            // nudFps
            // 
            this.nudFps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.nudFps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudFps.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFps.ForeColor = System.Drawing.Color.White;
            this.nudFps.Location = new System.Drawing.Point(44, 313);
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
            this.nudFps.Size = new System.Drawing.Size(100, 30);
            this.nudFps.TabIndex = 6;
            this.nudFps.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblEstado.Location = new System.Drawing.Point(0, 440);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(400, 20);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Esperando para grabar...";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCalidad
            // 
            this.cmbCalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCalidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCalidad.ForeColor = System.Drawing.Color.White;
            this.cmbCalidad.FormattingEnabled = true;
            this.cmbCalidad.Location = new System.Drawing.Point(44, 248);
            this.cmbCalidad.Name = "cmbCalidad";
            this.cmbCalidad.Size = new System.Drawing.Size(312, 31);
            this.cmbCalidad.TabIndex = 9;
            // 
            // lblCalidad
            // 
            this.lblCalidad.AutoSize = true;
            this.lblCalidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblCalidad.Location = new System.Drawing.Point(40, 225);
            this.lblCalidad.Name = "lblCalidad";
            this.lblCalidad.Size = new System.Drawing.Size(62, 21);
            this.lblCalidad.TabIndex = 8;
            this.lblCalidad.Text = "Calidad";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.White;
            this.lblTituloPrincipal.Location = new System.Drawing.Point(0, 25);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(400, 35);
            this.lblTituloPrincipal.TabIndex = 10;
            this.lblTituloPrincipal.Text = "Configuración de Grabación";
            this.lblTituloPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlSeparador.Location = new System.Drawing.Point(150, 65);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(100, 3);
            this.pnlSeparador.TabIndex = 11;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(272, 375);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(116, 45);
            this.btnConfig.TabIndex = 12;
            this.btnConfig.Text = "Configuración";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.lblTituloPrincipal);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grabador de Pantalla";
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
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Button btnConfig;
    }
}