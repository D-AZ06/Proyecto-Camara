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
            this.btnGrabarDetener = new System.Windows.Forms.Button();
            this.btnPausarReanudar = new System.Windows.Forms.Button();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGrabarDetener
            // 
            this.btnGrabarDetener.Location = new System.Drawing.Point(133, 94);
            this.btnGrabarDetener.Name = "btnGrabarDetener";
            this.btnGrabarDetener.Size = new System.Drawing.Size(75, 23);
            this.btnGrabarDetener.TabIndex = 0;
            this.btnGrabarDetener.Text = "Grabar";
            this.btnGrabarDetener.UseVisualStyleBackColor = true;
            this.btnGrabarDetener.Click += new System.EventHandler(this.btnGrabarDetener_Click);
            // 
            // btnPausarReanudar
            // 
            this.btnPausarReanudar.Location = new System.Drawing.Point(254, 94);
            this.btnPausarReanudar.Name = "btnPausarReanudar";
            this.btnPausarReanudar.Size = new System.Drawing.Size(75, 23);
            this.btnPausarReanudar.TabIndex = 1;
            this.btnPausarReanudar.Text = "Pausar";
            this.btnPausarReanudar.UseVisualStyleBackColor = true;
            this.btnPausarReanudar.Click += new System.EventHandler(this.btnPausarReanudar_Click);
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Location = new System.Drawing.Point(163, 156);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(75, 42);
            this.btnTomarFoto.TabIndex = 2;
            this.btnTomarFoto.Text = "Tomar foto";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(574, 130);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(77, 28);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // FormGrabar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.btnPausarReanudar);
            this.Controls.Add(this.btnGrabarDetener);
            this.Name = "FormGrabar";
            this.Text = "FormGrabar";
            this.Load += new System.EventHandler(this.FormGrabar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGrabarDetener;
        private System.Windows.Forms.Button btnPausarReanudar;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Button btnRegresar;
    }
}