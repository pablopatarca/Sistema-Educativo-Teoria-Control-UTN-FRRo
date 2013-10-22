namespace Ejemplos
{
    partial class FrmEscalónPrimerOrdenTermómetro
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
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange1 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange2 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange3 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zgcEscalon = new ZedGraph.ZedGraphControl();
            this.txtConstanteDeTiempo = new System.Windows.Forms.TextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblConstanteDeTiempo = new System.Windows.Forms.Label();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.linearGauge1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.linearScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.linearScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.termometro = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.gaugeControl2 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.contador = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorInicial = new System.Windows.Forms.TextBox();
            this.txtValorFinal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.termometro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(350, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(688, 667);
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
            this.zgcEscalon.Size = new System.Drawing.Size(682, 661);
            this.zgcEscalon.TabIndex = 0;
            // 
            // txtConstanteDeTiempo
            // 
            this.txtConstanteDeTiempo.Location = new System.Drawing.Point(123, 76);
            this.txtConstanteDeTiempo.Name = "txtConstanteDeTiempo";
            this.txtConstanteDeTiempo.Size = new System.Drawing.Size(74, 20);
            this.txtConstanteDeTiempo.TabIndex = 4;
            this.txtConstanteDeTiempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(60, 595);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(75, 23);
            this.btnInicio.TabIndex = 5;
            this.btnInicio.Text = "Comenzar";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(200, 595);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblConstanteDeTiempo
            // 
            this.lblConstanteDeTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConstanteDeTiempo.AutoSize = true;
            this.lblConstanteDeTiempo.Location = new System.Drawing.Point(6, 79);
            this.lblConstanteDeTiempo.Name = "lblConstanteDeTiempo";
            this.lblConstanteDeTiempo.Size = new System.Drawing.Size(111, 13);
            this.lblConstanteDeTiempo.TabIndex = 0;
            this.lblConstanteDeTiempo.Text = "Constante de Tiempo:";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.BackColor = System.Drawing.SystemColors.Control;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.linearGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(36, 24);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(270, 352);
            this.gaugeControl1.TabIndex = 0;
            // 
            // linearGauge1
            // 
            this.linearGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.linearScaleBackgroundLayerComponent1});
            this.linearGauge1.Bounds = new System.Drawing.Rectangle(14, 7, 238, 337);
            this.linearGauge1.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.termometro});
            this.linearGauge1.Name = "linearGauge1";
            this.linearGauge1.OptionsToolTip.TooltipTitleFormat = "{0}";
            this.linearGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.linearScaleComponent1});
            // 
            // linearScaleBackgroundLayerComponent1
            // 
            this.linearScaleBackgroundLayerComponent1.LinearScale = this.linearScaleComponent1;
            this.linearScaleBackgroundLayerComponent1.Name = "bg1";
            this.linearScaleBackgroundLayerComponent1.ScaleEndPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.15F);
            this.linearScaleBackgroundLayerComponent1.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.8F);
            this.linearScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style12;
            this.linearScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // linearScaleComponent1
            // 
            this.linearScaleComponent1.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 8F);
            this.linearScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#3A3832");
            this.linearScaleComponent1.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 38F);
            this.linearScaleComponent1.MajorTickCount = 8;
            this.linearScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
            this.linearScaleComponent1.MajorTickmark.ShapeOffset = -23F;
            this.linearScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style26_1;
            this.linearScaleComponent1.MajorTickmark.TextOffset = -35F;
            this.linearScaleComponent1.MaxValue = 42F;
            this.linearScaleComponent1.MinorTickCount = 0;
            this.linearScaleComponent1.MinorTickmark.ShapeOffset = -18F;
            this.linearScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style26_2;
            this.linearScaleComponent1.MinValue = 35F;
            this.linearScaleComponent1.Name = "scale1";
            linearScaleRange1.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#90C05E");
            linearScaleRange1.EndThickness = 11F;
            linearScaleRange1.EndValue = 37.5F;
            linearScaleRange1.Name = "Range0";
            linearScaleRange1.ShapeOffset = -23F;
            linearScaleRange1.StartThickness = 11F;
            linearScaleRange1.StartValue = 35F;
            linearScaleRange2.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#FEDA6F");
            linearScaleRange2.EndThickness = 11F;
            linearScaleRange2.EndValue = 40F;
            linearScaleRange2.Name = "Range1";
            linearScaleRange2.ShapeOffset = -23F;
            linearScaleRange2.StartThickness = 11F;
            linearScaleRange2.StartValue = 37.5F;
            linearScaleRange3.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#F4957E");
            linearScaleRange3.EndThickness = 11F;
            linearScaleRange3.EndValue = 42F;
            linearScaleRange3.Name = "Range2";
            linearScaleRange3.ShapeOffset = -23F;
            linearScaleRange3.StartThickness = 11F;
            linearScaleRange3.StartValue = 40F;
            this.linearScaleComponent1.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange1,
            linearScaleRange2,
            linearScaleRange3});
            this.linearScaleComponent1.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 200F);
            this.linearScaleComponent1.Value = 35F;
            // 
            // termometro
            // 
            this.termometro.LinearScale = this.linearScaleComponent1;
            this.termometro.Name = "level1";
            this.termometro.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style26;
            this.termometro.ZOrder = -50;
            // 
            // gaugeControl2
            // 
            this.gaugeControl2.AutoLayout = false;
            this.gaugeControl2.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl2.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.contador});
            this.gaugeControl2.Location = new System.Drawing.Point(36, 382);
            this.gaugeControl2.Name = "gaugeControl2";
            this.gaugeControl2.Size = new System.Drawing.Size(270, 92);
            this.gaugeControl2.TabIndex = 0;
            // 
            // contador
            // 
            this.contador.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#E3E5EA");
            this.contador.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#59616F");
            this.contador.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent1});
            this.contador.Bounds = new System.Drawing.Rectangle(15, 7, 236, 77);
            this.contador.DigitCount = 5;
            this.contador.DisplayMode = DevExpress.XtraGauges.Core.Model.DigitalGaugeDisplayMode.Matrix8x14;
            this.contador.Name = "contador";
            this.contador.Text = "000,00";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(260F, 124F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent13";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style18;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(20F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Temperatura inicial:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Temperatura deseada:";
            // 
            // txtValorInicial
            // 
            this.txtValorInicial.Location = new System.Drawing.Point(123, 23);
            this.txtValorInicial.Name = "txtValorInicial";
            this.txtValorInicial.Size = new System.Drawing.Size(74, 20);
            this.txtValorInicial.TabIndex = 1;
            this.txtValorInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.Location = new System.Drawing.Point(123, 49);
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.Size = new System.Drawing.Size(74, 20);
            this.txtValorFinal.TabIndex = 2;
            this.txtValorFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 667);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btnLimpiar);
            this.panel2.Controls.Add(this.btnInicio);
            this.panel2.Controls.Add(this.gaugeControl2);
            this.panel2.Controls.Add(this.gaugeControl1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 664);
            this.panel2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtValorFinal);
            this.groupBox1.Controls.Add(this.lblConstanteDeTiempo);
            this.groupBox1.Controls.Add(this.txtConstanteDeTiempo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtValorInicial);
            this.groupBox1.Location = new System.Drawing.Point(51, 480);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "º C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "º C";
            // 
            // FrmEscalónPrimerOrdenTermómetro
            // 
            this.AcceptButton = this.btnInicio;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1038, 667);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEscalónPrimerOrdenTermómetro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Escalón Unitario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.linearGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearScaleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.termometro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl zgcEscalon;
        private System.Windows.Forms.TextBox txtConstanteDeTiempo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblConstanteDeTiempo;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge linearGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent linearScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent linearScaleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent termometro;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl2;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge contador;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorInicial;
        private System.Windows.Forms.TextBox txtValorFinal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
    }
}

