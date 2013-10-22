namespace TeoriaDeControl
{
    partial class frmOvershootVsPsi
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
            this.pbxFormula = new System.Windows.Forms.PictureBox();
            this.pbxOvershootVsPsi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFormula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOvershootVsPsi)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxFormula
            // 
            this.pbxFormula.Image = global::TeoriaDeControl.Properties.Resources.Funcion_overshoot;
            this.pbxFormula.Location = new System.Drawing.Point(48, 12);
            this.pbxFormula.Name = "pbxFormula";
            this.pbxFormula.Size = new System.Drawing.Size(587, 71);
            this.pbxFormula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxFormula.TabIndex = 1;
            this.pbxFormula.TabStop = false;
            // 
            // pbxOvershootVsPsi
            // 
            this.pbxOvershootVsPsi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbxOvershootVsPsi.Image = global::TeoriaDeControl.Properties.Resources.Grafica_Overshoot_vs_Psi;
            this.pbxOvershootVsPsi.Location = new System.Drawing.Point(0, 94);
            this.pbxOvershootVsPsi.Name = "pbxOvershootVsPsi";
            this.pbxOvershootVsPsi.Size = new System.Drawing.Size(679, 507);
            this.pbxOvershootVsPsi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxOvershootVsPsi.TabIndex = 0;
            this.pbxOvershootVsPsi.TabStop = false;
            // 
            // frmOvershootVsPsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 601);
            this.Controls.Add(this.pbxFormula);
            this.Controls.Add(this.pbxOvershootVsPsi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmOvershootVsPsi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráfica Overshoot vs. Coeficiente Amortiguamiento";
            ((System.ComponentModel.ISupportInitialize)(this.pbxFormula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOvershootVsPsi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxOvershootVsPsi;
        private System.Windows.Forms.PictureBox pbxFormula;
    }
}