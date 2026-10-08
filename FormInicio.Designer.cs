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
            this.SuspendLayout();
            // 
            // btnGrabacion
            // 
            this.btnGrabacion.Location = new System.Drawing.Point(378, 60);
            this.btnGrabacion.Name = "btnGrabacion";
            this.btnGrabacion.Size = new System.Drawing.Size(75, 23);
            this.btnGrabacion.TabIndex = 0;
            this.btnGrabacion.Text = "button1";
            this.btnGrabacion.UseVisualStyleBackColor = true;
            this.btnGrabacion.Click += new System.EventHandler(this.btnGrabacion_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGrabacion);
            this.Name = "FormInicio";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGrabacion;
    }
}

