namespace DiagramasBode
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFrecNaturalAmort = new System.Windows.Forms.Label();
            this.txbFrecNaturalAmort = new System.Windows.Forms.TextBox();
            this.gbxPlanta = new System.Windows.Forms.GroupBox();
            this.lblCoefAmortiguamiento = new System.Windows.Forms.Label();
            this.txbCoefAmortiguamiento = new System.Windows.Forms.TextBox();
            this.lblConstTiempo = new System.Windows.Forms.Label();
            this.txbConstTiempo = new System.Windows.Forms.TextBox();
            this.gbxControlador = new System.Windows.Forms.GroupBox();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.txbGanancia = new System.Windows.Forms.TextBox();
            this.lblDerivativo = new System.Windows.Forms.Label();
            this.lblIntegral = new System.Windows.Forms.Label();
            this.txbDerivativo = new System.Windows.Forms.TextBox();
            this.txbIntegral = new System.Windows.Forms.TextBox();
            this.lblRetardo = new System.Windows.Forms.Label();
            this.gbxSensor = new System.Windows.Forms.GroupBox();
            this.txbRetardo = new System.Windows.Forms.TextBox();
            this.retardoPuro = new System.Windows.Forms.ToolStripMenuItem();
            this.realimentaciónUnitaria = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.segundoOrden = new System.Windows.Forms.ToolStripMenuItem();
            this.primerOrden = new System.Windows.Forms.ToolStripMenuItem();
            this.plantaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlador = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcional = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcionalIntegral = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcionalDerivativo = new System.Windows.Forms.ToolStripMenuItem();
            this.proporcionalIntegralDerivativo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.menuPlanta = new System.Windows.Forms.MenuStrip();
            this.menuSensor = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbxPlanta.SuspendLayout();
            this.gbxControlador.SuspendLayout();
            this.gbxSensor.SuspendLayout();
            this.menuControlador.SuspendLayout();
            this.menuPlanta.SuspendLayout();
            this.menuSensor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DiagramasBode.Properties.Resources.DiagramaDeBloques;
            this.pictureBox1.Location = new System.Drawing.Point(6, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 168);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblFrecNaturalAmort
            // 
            this.lblFrecNaturalAmort.AutoSize = true;
            this.lblFrecNaturalAmort.Enabled = false;
            this.lblFrecNaturalAmort.Location = new System.Drawing.Point(4, 58);
            this.lblFrecNaturalAmort.Name = "lblFrecNaturalAmort";
            this.lblFrecNaturalAmort.Size = new System.Drawing.Size(95, 26);
            this.lblFrecNaturalAmort.TabIndex = 0;
            this.lblFrecNaturalAmort.Text = "Frecuencia natural\r\namortiguada:";
            // 
            // txbFrecNaturalAmort
            // 
            this.txbFrecNaturalAmort.Enabled = false;
            this.txbFrecNaturalAmort.Location = new System.Drawing.Point(102, 64);
            this.txbFrecNaturalAmort.Name = "txbFrecNaturalAmort";
            this.txbFrecNaturalAmort.Size = new System.Drawing.Size(50, 20);
            this.txbFrecNaturalAmort.TabIndex = 2;
            this.txbFrecNaturalAmort.TextChanged += new System.EventHandler(this.txbFrecNaturalAmort_TextChanged);
            this.txbFrecNaturalAmort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validarNumeros_KeyPress);
            // 
            // gbxPlanta
            // 
            this.gbxPlanta.Controls.Add(this.lblCoefAmortiguamiento);
            this.gbxPlanta.Controls.Add(this.txbCoefAmortiguamiento);
            this.gbxPlanta.Controls.Add(this.lblFrecNaturalAmort);
            this.gbxPlanta.Controls.Add(this.txbFrecNaturalAmort);
            this.gbxPlanta.Controls.Add(this.lblConstTiempo);
            this.gbxPlanta.Controls.Add(this.txbConstTiempo);
            this.gbxPlanta.Location = new System.Drawing.Point(3, 176);
            this.gbxPlanta.Name = "gbxPlanta";
            this.gbxPlanta.Size = new System.Drawing.Size(158, 129);
            this.gbxPlanta.TabIndex = 0;
            this.gbxPlanta.TabStop = false;
            this.gbxPlanta.Text = "Planta";
            this.gbxPlanta.Visible = false;
            // 
            // lblCoefAmortiguamiento
            // 
            this.lblCoefAmortiguamiento.AutoSize = true;
            this.lblCoefAmortiguamiento.Enabled = false;
            this.lblCoefAmortiguamiento.Location = new System.Drawing.Point(4, 93);
            this.lblCoefAmortiguamiento.Name = "lblCoefAmortiguamiento";
            this.lblCoefAmortiguamiento.Size = new System.Drawing.Size(87, 26);
            this.lblCoefAmortiguamiento.TabIndex = 0;
            this.lblCoefAmortiguamiento.Text = "Coeficiente de\r\namortiguamiento:";
            // 
            // txbCoefAmortiguamiento
            // 
            this.txbCoefAmortiguamiento.Enabled = false;
            this.txbCoefAmortiguamiento.Location = new System.Drawing.Point(102, 99);
            this.txbCoefAmortiguamiento.Name = "txbCoefAmortiguamiento";
            this.txbCoefAmortiguamiento.Size = new System.Drawing.Size(50, 20);
            this.txbCoefAmortiguamiento.TabIndex = 3;
            this.txbCoefAmortiguamiento.TextChanged += new System.EventHandler(this.txbCoefAmortiguamiento_TextChanged);
            this.txbCoefAmortiguamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validarNumeros_KeyPress);
            // 
            // lblConstTiempo
            // 
            this.lblConstTiempo.AutoSize = true;
            this.lblConstTiempo.Enabled = false;
            this.lblConstTiempo.Location = new System.Drawing.Point(4, 26);
            this.lblConstTiempo.Name = "lblConstTiempo";
            this.lblConstTiempo.Size = new System.Drawing.Size(56, 26);
            this.lblConstTiempo.TabIndex = 0;
            this.lblConstTiempo.Text = "Constante\r\nde tiempo:";
            // 
            // txbConstTiempo
            // 
            this.txbConstTiempo.Enabled = false;
            this.txbConstTiempo.Location = new System.Drawing.Point(102, 32);
            this.txbConstTiempo.Name = "txbConstTiempo";
            this.txbConstTiempo.Size = new System.Drawing.Size(50, 20);
            this.txbConstTiempo.TabIndex = 1;
            this.txbConstTiempo.TextChanged += new System.EventHandler(this.txbConstTiempo_TextChanged);
            this.txbConstTiempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validarNumeros_KeyPress);
            // 
            // gbxControlador
            // 
            this.gbxControlador.Controls.Add(this.lblGanancia);
            this.gbxControlador.Controls.Add(this.txbGanancia);
            this.gbxControlador.Controls.Add(this.lblDerivativo);
            this.gbxControlador.Controls.Add(this.lblIntegral);
            this.gbxControlador.Controls.Add(this.txbDerivativo);
            this.gbxControlador.Controls.Add(this.txbIntegral);
            this.gbxControlador.Location = new System.Drawing.Point(305, 176);
            this.gbxControlador.Name = "gbxControlador";
            this.gbxControlador.Size = new System.Drawing.Size(173, 129);
            this.gbxControlador.TabIndex = 0;
            this.gbxControlador.TabStop = false;
            this.gbxControlador.Text = "Controlador";
            this.gbxControlador.Visible = false;
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Location = new System.Drawing.Point(4, 26);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(56, 13);
            this.lblGanancia.TabIndex = 0;
            this.lblGanancia.Text = "Ganancia:";
            // 
            // txbGanancia
            // 
            this.txbGanancia.Location = new System.Drawing.Point(106, 23);
            this.txbGanancia.Name = "txbGanancia";
            this.txbGanancia.Size = new System.Drawing.Size(52, 20);
            this.txbGanancia.TabIndex = 5;
            this.txbGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validarNumeros_KeyPress);
            // 
            // lblDerivativo
            // 
            this.lblDerivativo.AutoSize = true;
            this.lblDerivativo.Enabled = false;
            this.lblDerivativo.Location = new System.Drawing.Point(4, 98);
            this.lblDerivativo.Name = "lblDerivativo";
            this.lblDerivativo.Size = new System.Drawing.Size(94, 13);
            this.lblDerivativo.TabIndex = 0;
            this.lblDerivativo.Text = "Tiempo derivativo:";
            // 
            // lblIntegral
            // 
            this.lblIntegral.AutoSize = true;
            this.lblIntegral.Enabled = false;
            this.lblIntegral.Location = new System.Drawing.Point(4, 61);
            this.lblIntegral.Name = "lblIntegral";
            this.lblIntegral.Size = new System.Drawing.Size(82, 13);
            this.lblIntegral.TabIndex = 0;
            this.lblIntegral.Text = "Tiempo integral:";
            // 
            // txbDerivativo
            // 
            this.txbDerivativo.Enabled = false;
            this.txbDerivativo.Location = new System.Drawing.Point(106, 95);
            this.txbDerivativo.Name = "txbDerivativo";
            this.txbDerivativo.Size = new System.Drawing.Size(52, 20);
            this.txbDerivativo.TabIndex = 7;
            this.txbDerivativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validarNumeros_KeyPress);
            // 
            // txbIntegral
            // 
            this.txbIntegral.Enabled = false;
            this.txbIntegral.Location = new System.Drawing.Point(106, 58);
            this.txbIntegral.Name = "txbIntegral";
            this.txbIntegral.Size = new System.Drawing.Size(52, 20);
            this.txbIntegral.TabIndex = 6;
            this.txbIntegral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validarNumeros_KeyPress);
            // 
            // lblRetardo
            // 
            this.lblRetardo.AutoSize = true;
            this.lblRetardo.Enabled = false;
            this.lblRetardo.Location = new System.Drawing.Point(6, 26);
            this.lblRetardo.Name = "lblRetardo";
            this.lblRetardo.Size = new System.Drawing.Size(56, 26);
            this.lblRetardo.TabIndex = 0;
            this.lblRetardo.Text = "Retardo\r\nde tiempo:";
            // 
            // gbxSensor
            // 
            this.gbxSensor.Controls.Add(this.lblRetardo);
            this.gbxSensor.Controls.Add(this.txbRetardo);
            this.gbxSensor.Location = new System.Drawing.Point(163, 176);
            this.gbxSensor.Name = "gbxSensor";
            this.gbxSensor.Size = new System.Drawing.Size(139, 129);
            this.gbxSensor.TabIndex = 0;
            this.gbxSensor.TabStop = false;
            this.gbxSensor.Text = "Sensor";
            this.gbxSensor.Visible = false;
            // 
            // txbRetardo
            // 
            this.txbRetardo.Enabled = false;
            this.txbRetardo.Location = new System.Drawing.Point(68, 32);
            this.txbRetardo.Name = "txbRetardo";
            this.txbRetardo.Size = new System.Drawing.Size(59, 20);
            this.txbRetardo.TabIndex = 4;
            this.txbRetardo.TextChanged += new System.EventHandler(this.txbRetardo_TextChanged);
            this.txbRetardo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validarNumeros_KeyPress);
            // 
            // retardoPuro
            // 
            this.retardoPuro.Name = "retardoPuro";
            this.retardoPuro.Size = new System.Drawing.Size(200, 22);
            this.retardoPuro.Text = "Retardo Puro";
            this.retardoPuro.Click += new System.EventHandler(this.retardoPuroToolStripMenuItem_Click);
            // 
            // realimentaciónUnitaria
            // 
            this.realimentaciónUnitaria.Name = "realimentaciónUnitaria";
            this.realimentaciónUnitaria.Size = new System.Drawing.Size(200, 22);
            this.realimentaciónUnitaria.Text = "Realimentación Unitaria";
            this.realimentaciónUnitaria.Click += new System.EventHandler(this.realimentaciónUnitaria_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realimentaciónUnitaria,
            this.retardoPuro});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem4.Text = "Sensor";
            // 
            // segundoOrden
            // 
            this.segundoOrden.Name = "segundoOrden";
            this.segundoOrden.Size = new System.Drawing.Size(121, 22);
            this.segundoOrden.Text = "2° Orden";
            this.segundoOrden.Click += new System.EventHandler(this.segundoOrden_Click);
            // 
            // primerOrden
            // 
            this.primerOrden.Name = "primerOrden";
            this.primerOrden.Size = new System.Drawing.Size(121, 22);
            this.primerOrden.Text = "1° Orden";
            this.primerOrden.Click += new System.EventHandler(this.primerOrden_Click);
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
            // menuControlador
            // 
            this.menuControlador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(218)))));
            this.menuControlador.Dock = System.Windows.Forms.DockStyle.None;
            this.menuControlador.Enabled = false;
            this.menuControlador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuControlador.Location = new System.Drawing.Point(147, 46);
            this.menuControlador.Name = "menuControlador";
            this.menuControlador.Size = new System.Drawing.Size(91, 24);
            this.menuControlador.TabIndex = 0;
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
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(402, 311);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 26);
            this.btnAceptar.TabIndex = 8;
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
            this.menuPlanta.Location = new System.Drawing.Point(321, 45);
            this.menuPlanta.Name = "menuPlanta";
            this.menuPlanta.Size = new System.Drawing.Size(60, 24);
            this.menuPlanta.TabIndex = 0;
            this.menuPlanta.Text = "Planta";
            // 
            // menuSensor
            // 
            this.menuSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(205)))), ((int)(((byte)(203)))));
            this.menuSensor.Dock = System.Windows.Forms.DockStyle.None;
            this.menuSensor.Enabled = false;
            this.menuSensor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.menuSensor.Location = new System.Drawing.Point(236, 126);
            this.menuSensor.Name = "menuSensor";
            this.menuSensor.Size = new System.Drawing.Size(154, 24);
            this.menuSensor.TabIndex = 0;
            this.menuSensor.Text = "Sensor";
            // 
            // FrmDiagramaDeBloques
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 169);
            this.Controls.Add(this.gbxPlanta);
            this.Controls.Add(this.gbxControlador);
            this.Controls.Add(this.gbxSensor);
            this.Controls.Add(this.menuControlador);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.menuPlanta);
            this.Controls.Add(this.menuSensor);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDiagramaDeBloques";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diagrama De Bloques";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbxPlanta.ResumeLayout(false);
            this.gbxPlanta.PerformLayout();
            this.gbxControlador.ResumeLayout(false);
            this.gbxControlador.PerformLayout();
            this.gbxSensor.ResumeLayout(false);
            this.gbxSensor.PerformLayout();
            this.menuControlador.ResumeLayout(false);
            this.menuControlador.PerformLayout();
            this.menuPlanta.ResumeLayout(false);
            this.menuPlanta.PerformLayout();
            this.menuSensor.ResumeLayout(false);
            this.menuSensor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFrecNaturalAmort;
        private System.Windows.Forms.TextBox txbFrecNaturalAmort;
        private System.Windows.Forms.GroupBox gbxPlanta;
        private System.Windows.Forms.Label lblConstTiempo;
        private System.Windows.Forms.TextBox txbConstTiempo;
        private System.Windows.Forms.GroupBox gbxControlador;
        private System.Windows.Forms.Label lblDerivativo;
        private System.Windows.Forms.Label lblIntegral;
        private System.Windows.Forms.TextBox txbDerivativo;
        private System.Windows.Forms.TextBox txbIntegral;
        private System.Windows.Forms.Label lblRetardo;
        private System.Windows.Forms.GroupBox gbxSensor;
        private System.Windows.Forms.TextBox txbRetardo;
        private System.Windows.Forms.ToolStripMenuItem retardoPuro;
        private System.Windows.Forms.ToolStripMenuItem realimentaciónUnitaria;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem segundoOrden;
        private System.Windows.Forms.ToolStripMenuItem primerOrden;
        private System.Windows.Forms.ToolStripMenuItem plantaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuControlador;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proporcional;
        private System.Windows.Forms.ToolStripMenuItem proporcionalIntegral;
        private System.Windows.Forms.ToolStripMenuItem proporcionalDerivativo;
        private System.Windows.Forms.ToolStripMenuItem proporcionalIntegralDerivativo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.MenuStrip menuPlanta;
        private System.Windows.Forms.MenuStrip menuSensor;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.TextBox txbGanancia;
        private System.Windows.Forms.Label lblCoefAmortiguamiento;
        private System.Windows.Forms.TextBox txbCoefAmortiguamiento;

    }
}