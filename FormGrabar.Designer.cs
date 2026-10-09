namespace Proyecto_Camara
{
    partial class FormGrabar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGrabarDetener = new System.Windows.Forms.Button();
            this.btnPausarReanudar = new System.Windows.Forms.Button();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.timerTiempo = new System.Windows.Forms.Timer(this.components);
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.lblEstadoTexto = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGrabarDetener
            // 
            this.btnGrabarDetener.Location = new System.Drawing.Point(298, 11);
            this.btnGrabarDetener.Name = "btnGrabarDetener";
            this.btnGrabarDetener.Size = new System.Drawing.Size(75, 23);
            this.btnGrabarDetener.TabIndex = 0;
            this.btnGrabarDetener.Text = "Grabar";
            this.btnGrabarDetener.UseVisualStyleBackColor = true;
            this.btnGrabarDetener.Click += new System.EventHandler(this.btnGrabarDetener_Click);
            // 
            // btnPausarReanudar
            // 
            this.btnPausarReanudar.Location = new System.Drawing.Point(298, 40);
            this.btnPausarReanudar.Name = "btnPausarReanudar";
            this.btnPausarReanudar.Size = new System.Drawing.Size(75, 23);
            this.btnPausarReanudar.TabIndex = 1;
            this.btnPausarReanudar.Text = "Pausar";
            this.btnPausarReanudar.UseVisualStyleBackColor = true;
            this.btnPausarReanudar.Click += new System.EventHandler(this.btnPausarReanudar_Click);
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Location = new System.Drawing.Point(12, 12);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(75, 42);
            this.btnTomarFoto.TabIndex = 2;
            this.btnTomarFoto.Text = "Tomar foto";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(622, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(77, 28);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // timerTiempo
            // 
            this.timerTiempo.Interval = 1000;
            // 
            // pnlEstado
            // 
            this.pnlEstado.Location = new System.Drawing.Point(482, 12);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(22, 22);
            this.pnlEstado.TabIndex = 4;
            // 
            // lblEstadoTexto
            // 
            this.lblEstadoTexto.AutoSize = true;
            this.lblEstadoTexto.Location = new System.Drawing.Point(466, 38);
            this.lblEstadoTexto.Name = "lblEstadoTexto";
            this.lblEstadoTexto.Size = new System.Drawing.Size(50, 16);
            this.lblEstadoTexto.TabIndex = 5;
            this.lblEstadoTexto.Text = "Estado";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(398, 18);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(55, 16);
            this.lblTiempo.TabIndex = 6;
            this.lblTiempo.Text = "00:00:00";
            // 
            // FormGrabar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 77);
            this.ControlBox = false;
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblEstadoTexto);
            this.Controls.Add(this.pnlEstado);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.btnPausarReanudar);
            this.Controls.Add(this.btnGrabarDetener);
            this.Name = "FormGrabar";
            this.Text = "FormGrabar";
            this.Load += new System.EventHandler(this.FormGrabar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabarDetener;
        private System.Windows.Forms.Button btnPausarReanudar;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Timer timerTiempo;
        private System.Windows.Forms.Panel pnlEstado;
        private System.Windows.Forms.Label lblEstadoTexto;
        private System.Windows.Forms.Label lblTiempo;
    }
}