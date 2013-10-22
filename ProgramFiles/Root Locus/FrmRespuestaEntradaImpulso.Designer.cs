namespace Root_Locus
{
    partial class FrmRespuestaEntradaImpulso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRespuestaEntradaImpulso));
            this.zgPlanoComplejo = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zgPlanoComplejo
            // 
            this.zgPlanoComplejo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgPlanoComplejo.IsEnableHZoom = false;
            this.zgPlanoComplejo.IsEnableSelection = true;
            this.zgPlanoComplejo.IsEnableVZoom = false;
            this.zgPlanoComplejo.IsEnableWheelZoom = false;
            this.zgPlanoComplejo.Location = new System.Drawing.Point(0, 0);
            this.zgPlanoComplejo.Name = "zgPlanoComplejo";
            this.zgPlanoComplejo.ScrollGrace = 0D;
            this.zgPlanoComplejo.ScrollMaxX = 0D;
            this.zgPlanoComplejo.ScrollMaxY = 0D;
            this.zgPlanoComplejo.ScrollMaxY2 = 0D;
            this.zgPlanoComplejo.ScrollMinX = 0D;
            this.zgPlanoComplejo.ScrollMinY = 0D;
            this.zgPlanoComplejo.ScrollMinY2 = 0D;
            this.zgPlanoComplejo.Size = new System.Drawing.Size(1020, 599);
            this.zgPlanoComplejo.TabIndex = 1;
            this.zgPlanoComplejo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedC_MouseClick);
            // 
            // FrmRespuestaEntradaImpulso
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1020, 599);
            this.Controls.Add(this.zgPlanoComplejo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRespuestaEntradaImpulso";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Respuesta a una Entrada Impulso Unitario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRespuestaEntradaImpulso_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zgPlanoComplejo;
    }
}