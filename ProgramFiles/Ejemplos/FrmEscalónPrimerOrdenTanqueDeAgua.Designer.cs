namespace Ejemplos
{
    partial class FrmEscalónPrimerOrdenTanqueDeAgua
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zgcEscalon = new ZedGraph.ZedGraphControl();
            this.vpbTanqueDeAgua = new VerticalProgressBar.VerticalProgressBar();
            this.txtConstanteDeTiempo = new System.Windows.Forms.TextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblConstanteDeTiempo = new System.Windows.Forms.Label();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.contador = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.txtValorFinal = new System.Windows.Forms.TextBox();
            this.txtValorInicial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.zgcEscalon, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(282, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 667);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // zgcEscalon
            // 
            this.zgcEscalon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcEscalon.Location = new System.Drawing.Point(3, 3);
            this.zgcEscalon.Name = "zgcEscalon";
            this.zgcEscalon.ScrollGrace = 0D;
            this.zgcEscalon.ScrollMaxX = 0D;
            this.zgcEscalon.ScrollMaxY = 0D;
            this.zgcEscalon.ScrollMaxY2 = 0D;
            this.zgcEscalon.ScrollMinX = 0D;
            this.zgcEscalon.ScrollMinY = 0D;
            this.zgcEscalon.ScrollMinY2 = 0D;
            this.zgcEscalon.Size = new System.Drawing.Size(902, 661);
            this.zgcEscalon.TabIndex = 0;
            // 
            // vpbTanqueDeAgua
            // 
            this.vpbTanqueDeAgua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vpbTanqueDeAgua.BackColor = System.Drawing.SystemColors.Window;
            this.vpbTanqueDeAgua.BorderStyle = VerticalProgressBar.BorderStyles.None;
            this.vpbTanqueDeAgua.Color = System.Drawing.Color.CornflowerBlue;
            this.vpbTanqueDeAgua.Location = new System.Drawing.Point(64, 156);
            this.vpbTanqueDeAgua.Maximum = 100;
            this.vpbTanqueDeAgua.Minimum = 0;
            this.vpbTanqueDeAgua.Name = "vpbTanqueDeAgua";
            this.vpbTanqueDeAgua.Size = new System.Drawing.Size(200, 155);
            this.vpbTanqueDeAgua.Step = 1;
            this.vpbTanqueDeAgua.Style = VerticalProgressBar.Styles.Solid;
            this.vpbTanqueDeAgua.TabIndex = 0;
            this.vpbTanqueDeAgua.Value = 30;
            // 
            // txtConstanteDeTiempo
            // 
            this.txtConstanteDeTiempo.Location = new System.Drawing.Point(123, 79);
            this.txtConstanteDeTiempo.Name = "txtConstanteDeTiempo";
            this.txtConstanteDeTiempo.Size = new System.Drawing.Size(74, 20);
            this.txtConstanteDeTiempo.TabIndex = 4;
            this.txtConstanteDeTiempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // btnInicio
            // 
            this.btnInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInicio.Location = new System.Drawing.Point(16, 576);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(75, 23);
            this.btnInicio.TabIndex = 5;
            this.btnInicio.Text = "Comenzar";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.Location = new System.Drawing.Point(172, 576);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblConstanteDeTiempo
            // 
            this.lblConstanteDeTiempo.AutoSize = true;
            this.lblConstanteDeTiempo.Location = new System.Drawing.Point(6, 82);
            this.lblConstanteDeTiempo.Name = "lblConstanteDeTiempo";
            this.lblConstanteDeTiempo.Size = new System.Drawing.Size(111, 13);
            this.lblConstanteDeTiempo.TabIndex = 0;
            this.lblConstanteDeTiempo.Text = "Constante de Tiempo:";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.BackColor = System.Drawing.SystemColors.Control;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.contador});
            this.gaugeControl1.Location = new System.Drawing.Point(16, 338);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(250, 103);
            this.gaugeControl1.TabIndex = 0;
            // 
            // contador
            // 
            this.contador.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#E3E5EA");
            this.contador.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#59616F");
            this.contador.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent1});
            this.contador.Bounds = new System.Drawing.Rectangle(6, 6, 238, 92);
            this.contador.DigitCount = 5;
            this.contador.DisplayMode = DevExpress.XtraGauges.Core.Model.DigitalGaugeDisplayMode.Matrix8x14;
            this.contador.Name = "contador";
            this.contador.Padding = new DevExpress.XtraGauges.Core.Base.TextSpacing(26, 20, 26, 20);
            this.contador.Text = "000,00";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(266F, 124F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent1";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style18;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(26F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.Location = new System.Drawing.Point(123, 53);
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.Size = new System.Drawing.Size(74, 20);
            this.txtValorFinal.TabIndex = 2;
            this.txtValorFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // txtValorInicial
            // 
            this.txtValorInicial.Location = new System.Drawing.Point(123, 27);
            this.txtValorInicial.Name = "txtValorInicial";
            this.txtValorInicial.Size = new System.Drawing.Size(74, 20);
            this.txtValorInicial.TabIndex = 1;
            this.txtValorInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Contenido deseado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contenido inicial:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtValorFinal);
            this.groupBox1.Controls.Add(this.txtConstanteDeTiempo);
            this.groupBox1.Controls.Add(this.txtValorInicial);
            this.groupBox1.Controls.Add(this.lblConstanteDeTiempo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 113);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "litros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "litros";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::Ejemplos.Properties.Resources.Escala;
            this.pictureBox2.Location = new System.Drawing.Point(9, 145);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 176);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Ejemplos.Properties.Resources.Tanque;
            this.pictureBox1.Location = new System.Drawing.Point(62, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 236);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.vpbTanqueDeAgua);
            this.panel1.Controls.Add(this.gaugeControl1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 664);
            this.panel1.TabIndex = 14;
            // 
            // FrmEscalónPrimerOrdenTanqueDeAgua
            // 
            this.AcceptButton = this.btnInicio;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1038, 667);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEscalónPrimerOrdenTanqueDeAgua";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Escalón Unitario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl zgcEscalon;
        private VerticalProgressBar.VerticalProgressBar vpbTanqueDeAgua;
        private System.Windows.Forms.TextBox txtConstanteDeTiempo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblConstanteDeTiempo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge contador;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private System.Windows.Forms.TextBox txtValorFinal;
        private System.Windows.Forms.TextBox txtValorInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
    }
}

