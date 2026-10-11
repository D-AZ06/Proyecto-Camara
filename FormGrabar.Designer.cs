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
            this.btnGrabarDetener.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnGrabarDetener.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabarDetener.FlatAppearance.BorderSize = 0;
            this.btnGrabarDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarDetener.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabarDetener.ForeColor = System.Drawing.Color.White;
            this.btnGrabarDetener.Location = new System.Drawing.Point(135, 20);
            this.btnGrabarDetener.Name = "btnGrabarDetener";
            this.btnGrabarDetener.Size = new System.Drawing.Size(110, 40);
            this.btnGrabarDetener.TabIndex = 0;
            this.btnGrabarDetener.Text = "● Grabar";
            this.btnGrabarDetener.UseVisualStyleBackColor = false;
            this.btnGrabarDetener.Click += new System.EventHandler(this.btnGrabarDetener_Click);
            // 
            // btnPausarReanudar
            // 
            this.btnPausarReanudar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnPausarReanudar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPausarReanudar.FlatAppearance.BorderSize = 0;
            this.btnPausarReanudar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPausarReanudar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausarReanudar.ForeColor = System.Drawing.Color.White;
            this.btnPausarReanudar.Location = new System.Drawing.Point(255, 20);
            this.btnPausarReanudar.Name = "btnPausarReanudar";
            this.btnPausarReanudar.Size = new System.Drawing.Size(110, 40);
            this.btnPausarReanudar.TabIndex = 1;
            this.btnPausarReanudar.Text = "⏸ Pausar";
            this.btnPausarReanudar.UseVisualStyleBackColor = false;
            this.btnPausarReanudar.Click += new System.EventHandler(this.btnPausarReanudar_Click);
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnTomarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTomarFoto.FlatAppearance.BorderSize = 0;
            this.btnTomarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTomarFoto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTomarFoto.ForeColor = System.Drawing.Color.White;
            this.btnTomarFoto.Location = new System.Drawing.Point(15, 20);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(110, 40);
            this.btnTomarFoto.TabIndex = 2;
            this.btnTomarFoto.Text = "📷 Captura";
            this.btnTomarFoto.UseVisualStyleBackColor = false;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(569, 20);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(105, 40);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "↩ Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // timerTiempo
            // 
            this.timerTiempo.Interval = 1000;
            // 
            // pnlEstado
            // 
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.pnlEstado.Location = new System.Drawing.Point(510, 32);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(15, 15);
            this.pnlEstado.TabIndex = 4;
            // 
            // lblEstadoTexto
            // 
            this.lblEstadoTexto.AutoSize = true;
            this.lblEstadoTexto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblEstadoTexto.Location = new System.Drawing.Point(392, 51);
            this.lblEstadoTexto.Name = "lblEstadoTexto";
            this.lblEstadoTexto.Size = new System.Drawing.Size(49, 20);
            this.lblEstadoTexto.TabIndex = 5;
            this.lblEstadoTexto.Text = "Listo...";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.White;
            this.lblTiempo.Location = new System.Drawing.Point(389, 6);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(136, 41);
            this.lblTiempo.TabIndex = 6;
            this.lblTiempo.Text = "00:00:00";
            // 
            // FormGrabar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(687, 80);
            this.ControlBox = false;
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblEstadoTexto);
            this.Controls.Add(this.pnlEstado);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.btnPausarReanudar);
            this.Controls.Add(this.btnGrabarDetener);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormGrabar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barra de Grabación";
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