namespace TeoriaDeControl
{
    partial class FrmTiempoAsentVsPsi
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zgcTiempoAsentVsPsi = new ZedGraph.ZedGraphControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.zgcTiempoAsentVsPsi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50592F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.49408F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(871, 591);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // zgcTiempoAsentVsPsi
            // 
            this.zgcTiempoAsentVsPsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcTiempoAsentVsPsi.Location = new System.Drawing.Point(3, 70);
            this.zgcTiempoAsentVsPsi.Name = "zgcTiempoAsentVsPsi";
            this.zgcTiempoAsentVsPsi.ScrollGrace = 0D;
            this.zgcTiempoAsentVsPsi.ScrollMaxX = 0D;
            this.zgcTiempoAsentVsPsi.ScrollMaxY = 0D;
            this.zgcTiempoAsentVsPsi.ScrollMaxY2 = 0D;
            this.zgcTiempoAsentVsPsi.ScrollMinX = 0D;
            this.zgcTiempoAsentVsPsi.ScrollMinY = 0D;
            this.zgcTiempoAsentVsPsi.ScrollMinY2 = 0D;
            this.zgcTiempoAsentVsPsi.Size = new System.Drawing.Size(865, 518);
            this.zgcTiempoAsentVsPsi.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::TeoriaDeControl.Properties.Resources.Formulas_asentamiento;
            this.pictureBox1.Location = new System.Drawing.Point(39, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(792, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmTiempoAsentVsPsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmTiempoAsentVsPsi";
            this.Text = "Grafica Tiempo Asentamiento vs. Coeficiente Amortiguamiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl zgcTiempoAsentVsPsi;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}