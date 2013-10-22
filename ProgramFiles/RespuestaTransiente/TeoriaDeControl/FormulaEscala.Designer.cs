namespace TeoriaDeControl
{
    partial class FormulaEscala
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
            this.pbFormulaEscalada = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormulaEscalada)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFormulaEscalada
            // 
            this.pbFormulaEscalada.Location = new System.Drawing.Point(17, 12);
            this.pbFormulaEscalada.Name = "pbFormulaEscalada";
            this.pbFormulaEscalada.Size = new System.Drawing.Size(867, 162);
            this.pbFormulaEscalada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFormulaEscalada.TabIndex = 0;
            this.pbFormulaEscalada.TabStop = false;
            // 
            // FormulaEscala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 180);
            this.Controls.Add(this.pbFormulaEscalada);
            this.MaximizeBox = false;
            this.Name = "FormulaEscala";
            ((System.ComponentModel.ISupportInitialize)(this.pbFormulaEscalada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFormulaEscalada;
    }
}