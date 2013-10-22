namespace Root_Locus
{
    partial class FrmDiagramaDeBloques
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.menuPlanta = new System.Windows.Forms.MenuStrip();
            this.plantaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primerOrden = new System.Windows.Forms.ToolStripMenuItem();
            this.segundoOrden = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlador = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcional = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcionalIntegral = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcionalDerivativo = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcionalIntegralDerivativo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSensor = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.realimentaciónUnitaria = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxPlanta = new System.Windows.Forms.GroupBox();
            this.lblPolo2 = new System.Windows.Forms.Label();
            this.txbPolo2 = new System.Windows.Forms.TextBox();
            this.lblPolo1 = new System.Windows.Forms.Label();
            this.txbPolo1 = new System.Windows.Forms.TextBox();
            this.gbxControlador = new System.Windows.Forms.GroupBox();
            this.lblDerivativo = new System.Windows.Forms.Label();
            this.lblIntegral = new System.Windows.Forms.Label();
            this.txbDerivativo = new System.Windows.Forms.TextBox();
            this.txbIntegral = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuPlanta.SuspendLayout();
            this.menuControlador.SuspendLayout();
            this.menuSensor.SuspendLayout();
            this.gbxPlanta.SuspendLayout();
            this.gbxControlador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(380, 262);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 26);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // menuPlanta
            // 
            this.menuPlanta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(218)))), ((int)(((byte)(169)))));
            this.menuPlanta.Dock = System.Windows.Forms.DockStyle.None;
            this.menuPlanta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plantaToolStripMenuItem});
            this.menuPlanta.Location = new System.Drawing.Point(313, 46);
            this.menuPlanta.Name = "menuPlanta";
            this.menuPlanta.Size = new System.Drawing.Size(60, 24);
            this.menuPlanta.TabIndex = 3;
            this.menuPlanta.Text = "Planta";
            // 
            // plantaToolStripMenuItem
            // 
            this.plantaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primerOrden,
            this.segundoOrden});
            this.plantaToolStripMenuItem.Name = "plantaToolStripMenuItem";
            this.plantaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.plantaToolStripMenuItem.Text = "Planta";
            // 
            // primerOrden
            // 
            this.primerOrden.Name = "primerOrden";
            this.primerOrden.Size = new System.Drawing.Size(152, 22);
            this.primerOrden.Text = "1° Orden";
            this.primerOrden.Click += new System.EventHandler(this.primerOrden_Click);
            // 
            // segundoOrden
            // 
            this.segundoOrden.Name = "segundoOrden";
            this.segundoOrden.Size = new System.Drawing.Size(152, 22);
            this.segundoOrden.Text = "2° Orden";
            this.segundoOrden.Click += new System.EventHandler(this.segundoOrden_Click);
            // 
            // menuControlador
            // 
            this.menuControlador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(218)))));
            this.menuControlador.Dock = System.Windows.Forms.DockStyle.None;
            this.menuControlador.Enabled = false;
            this.menuControlador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuControlador.Location = new System.Drawing.Point(139, 46);
            this.menuControlador.Name = "menuControlador";
            this.menuControlador.Size = new System.Drawing.Size(91, 24);
            this.menuControlador.TabIndex = 4;
            this.menuControlador.Text = "Controlador";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proporcional,
            this.proporcionalIntegral,
            this.proporcionalDerivativo,
            this.proporcionalIntegralDerivativo});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(83, 20);
            this.toolStripMenuItem1.Text = "Controlador";
            // 
            // proporcional
            // 
            this.proporcional.Name = "proporcional";
            this.proporcional.Size = new System.Drawing.Size(241, 22);
            this.proporcional.Text = "Proporcional";
            this.proporcional.Click += new System.EventHandler(this.proporcional_Click);
            // 
            // proporcionalIntegral
            // 
            this.proporcionalIntegral.Name = "proporcionalIntegral";
            this.proporcionalIntegral.Size = new System.Drawing.Size(241, 22);
            this.proporcionalIntegral.Text = "Proporcional Integral";
            this.proporcionalIntegral.Click += new System.EventHandler(this.proporcionalIntegral_Click);
            // 
            // proporcionalDerivativo
            // 
            this.proporcionalDerivativo.Name = "proporcionalDerivativo";
            this.proporcionalDerivativo.Size = new System.Drawing.Size(241, 22);
            this.proporcionalDerivativo.Text = "Proporcional Derivativo";
            this.proporcionalDerivativo.Click += new System.EventHandler(this.proporcionalDerivativo_Click);
            // 
            // proporcionalIntegralDerivativo
            // 
            this.proporcionalIntegralDerivativo.Name = "proporcionalIntegralDerivativo";
            this.proporcionalIntegralDerivativo.Size = new System.Drawing.Size(241, 22);
            this.proporcionalIntegralDerivativo.Text = "Proporcional Integral Derivativo";
            this.proporcionalIntegralDerivativo.Click += new System.EventHandler(this.proporcionalIntegralDerivativo_Click);
            // 
            // menuSensor
            // 
            this.menuSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(205)))), ((int)(((byte)(203)))));
            this.menuSensor.Dock = System.Windows.Forms.DockStyle.None;
            this.menuSensor.Enabled = false;
            this.menuSensor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.menuSensor.Location = new System.Drawing.Point(229, 126);
            this.menuSensor.Name = "menuSensor";
            this.menuSensor.Size = new System.Drawing.Size(154, 24);
            this.menuSensor.TabIndex = 5;
            this.menuSensor.Text = "Sensor";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realimentaciónUnitaria});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem4.Text = "Sensor";
            // 
            // realimentaciónUnitaria
            // 
            this.realimentaciónUnitaria.Name = "realimentaciónUnitaria";
            this.realimentaciónUnitaria.Size = new System.Drawing.Size(200, 22);
            this.realimentaciónUnitaria.Text = "Realimentación Unitaria";
            this.realimentaciónUnitaria.Click += new System.EventHandler(this.realimentaciónUnitaria_Click);
            // 
            // gbxPlanta
            // 
            this.gbxPlanta.Controls.Add(this.lblPolo2);
            this.gbxPlanta.Controls.Add(this.txbPolo2);
            this.gbxPlanta.Controls.Add(this.lblPolo1);
            this.gbxPlanta.Controls.Add(this.txbPolo1);
            this.gbxPlanta.Location = new System.Drawing.Point(63, 176);
            this.gbxPlanta.Name = "gbxPlanta";
            this.gbxPlanta.Size = new System.Drawing.Size(142, 80);
            this.gbxPlanta.TabIndex = 6;
            this.gbxPlanta.TabStop = false;
            this.gbxPlanta.Text = "Planta";
            this.gbxPlanta.Visible = false;
            // 
            // lblPolo2
            // 
            this.lblPolo2.AutoSize = true;
            this.lblPolo2.Enabled = false;
            this.lblPolo2.Location = new System.Drawing.Point(6, 54);
            this.lblPolo2.Name = "lblPolo2";
            this.lblPolo2.Size = new System.Drawing.Size(40, 13);
            this.lblPolo2.TabIndex = 9;
            this.lblPolo2.Text = "Polo 2:";
            // 
            // txbPolo2
            // 
            this.txbPolo2.Enabled = false;
            this.txbPolo2.Location = new System.Drawing.Point(59, 51);
            this.txbPolo2.Name = "txbPolo2";
            this.txbPolo2.Size = new System.Drawing.Size(69, 20);
            this.txbPolo2.TabIndex = 8;
            this.txbPolo2.TextChanged += new System.EventHandler(this.txbPolo2_TextChanged);
            this.txbPolo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros_KeyPress);
            // 
            // lblPolo1
            // 
            this.lblPolo1.AutoSize = true;
            this.lblPolo1.Enabled = false;
            this.lblPolo1.Location = new System.Drawing.Point(6, 27);
            this.lblPolo1.Name = "lblPolo1";
            this.lblPolo1.Size = new System.Drawing.Size(40, 13);
            this.lblPolo1.TabIndex = 7;
            this.lblPolo1.Text = "Polo 1:";
            // 
            // txbPolo1
            // 
            this.txbPolo1.Enabled = false;
            this.txbPolo1.Location = new System.Drawing.Point(59, 24);
            this.txbPolo1.Name = "txbPolo1";
            this.txbPolo1.Size = new System.Drawing.Size(69, 20);
            this.txbPolo1.TabIndex = 7;
            this.txbPolo1.TextChanged += new System.EventHandler(this.txbPolo1_TextChanged);
            this.txbPolo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros_KeyPress);
            // 
            // gbxControlador
            // 
            this.gbxControlador.Controls.Add(this.lblDerivativo);
            this.gbxControlador.Controls.Add(this.lblIntegral);
            this.gbxControlador.Controls.Add(this.txbDerivativo);
            this.gbxControlador.Controls.Add(this.txbIntegral);
            this.gbxControlador.Location = new System.Drawing.Point(211, 176);
            this.gbxControlador.Name = "gbxControlador";
            this.gbxControlador.Size = new System.Drawing.Size(191, 80);
            this.gbxControlador.TabIndex = 7;
            this.gbxControlador.TabStop = false;
            this.gbxControlador.Text = "Controlador";
            this.gbxControlador.Visible = false;
            // 
            // lblDerivativo
            // 
            this.lblDerivativo.AutoSize = true;
            this.lblDerivativo.Enabled = false;
            this.lblDerivativo.Location = new System.Drawing.Point(6, 51);
            this.lblDerivativo.Name = "lblDerivativo";
            this.lblDerivativo.Size = new System.Drawing.Size(96, 13);
            this.lblDerivativo.TabIndex = 13;
            this.lblDerivativo.Text = "Tiempo Derivativo:";
            // 
            // lblIntegral
            // 
            this.lblIntegral.AutoSize = true;
            this.lblIntegral.Enabled = false;
            this.lblIntegral.Location = new System.Drawing.Point(6, 24);
            this.lblIntegral.Name = "lblIntegral";
            this.lblIntegral.Size = new System.Drawing.Size(83, 13);
            this.lblIntegral.TabIndex = 10;
            this.lblIntegral.Text = "Tiempo Integral:";
            // 
            // txbDerivativo
            // 
            this.txbDerivativo.Enabled = false;
            this.txbDerivativo.Location = new System.Drawing.Point(108, 48);
            this.txbDerivativo.Name = "txbDerivativo";
            this.txbDerivativo.Size = new System.Drawing.Size(69, 20);
            this.txbDerivativo.TabIndex = 12;
            this.txbDerivativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerosParaTiempos_KeyPress);
            // 
            // txbIntegral
            // 
            this.txbIntegral.Enabled = false;
            this.txbIntegral.Location = new System.Drawing.Point(108, 20);
            this.txbIntegral.Name = "txbIntegral";
            this.txbIntegral.Size = new System.Drawing.Size(69, 20);
            this.txbIntegral.TabIndex = 11;
            this.txbIntegral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumerosParaTiempos_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Root_Locus.Properties.Resources.DiagramaDeBloques2;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 168);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmDiagramaDeBloques
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 169);
            this.Controls.Add(this.gbxControlador);
            this.Controls.Add(this.gbxPlanta);
            this.Controls.Add(this.menuSensor);
            this.Controls.Add(this.menuControlador);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.menuPlanta);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuPlanta;
            this.MaximizeBox = false;
            this.Name = "FrmDiagramaDeBloques";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de planta/controlador";
            this.menuPlanta.ResumeLayout(false);
            this.menuPlanta.PerformLayout();
            this.menuControlador.ResumeLayout(false);
            this.menuControlador.PerformLayout();
            this.menuSensor.ResumeLayout(false);
            this.menuSensor.PerformLayout();
            this.gbxPlanta.ResumeLayout(false);
            this.gbxPlanta.PerformLayout();
            this.gbxControlador.ResumeLayout(false);
            this.gbxControlador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuPlanta;
        private System.Windows.Forms.ToolStripMenuItem plantaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primerOrden;
        private System.Windows.Forms.ToolStripMenuItem segundoOrden;
        private System.Windows.Forms.MenuStrip menuControlador;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proporcional;
        private System.Windows.Forms.ToolStripMenuItem proporcionalIntegral;
        private System.Windows.Forms.ToolStripMenuItem proporcionalDerivativo;
        private System.Windows.Forms.ToolStripMenuItem proporcionalIntegralDerivativo;
        private System.Windows.Forms.MenuStrip menuSensor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem realimentaciónUnitaria;
        private System.Windows.Forms.GroupBox gbxPlanta;
        private System.Windows.Forms.Label lblPolo2;
        private System.Windows.Forms.TextBox txbPolo2;
        private System.Windows.Forms.Label lblPolo1;
        private System.Windows.Forms.TextBox txbPolo1;
        private System.Windows.Forms.GroupBox gbxControlador;
        private System.Windows.Forms.Label lblDerivativo;
        private System.Windows.Forms.Label lblIntegral;
        private System.Windows.Forms.TextBox txbDerivativo;
        private System.Windows.Forms.TextBox txbIntegral;
    }
}