namespace DiagramasBode
{
    partial class FrmIngresoFormula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngresoFormula));
            this.btnAceptar = new Controles.BtnAceptar();
            this.btnCancelar = new Controles.BtnCancelar();
            this.ingresoFormulaBode = new Controles.IngresoFormulaBode();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(353, 135);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(43, 43);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.TextoToolTip = null;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(402, 135);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(43, 43);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.TextoToolTip = null;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ingresoFormulaBode
            // 
            this.ingresoFormulaBode.Location = new System.Drawing.Point(12, 12);
            this.ingresoFormulaBode.Name = "ingresoFormulaBode";
            this.ingresoFormulaBode.Size = new System.Drawing.Size(435, 123);
            this.ingresoFormulaBode.TabIndex = 3;
            // 
            // FrmIngresoFormula
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(455, 186);
            this.Controls.Add(this.ingresoFormulaBode);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmIngresoFormula";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar valores";
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.BtnAceptar btnAceptar;
        private Controles.BtnCancelar btnCancelar;
        private Controles.IngresoFormulaBode ingresoFormulaBode;
    }
}