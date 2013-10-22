namespace Ejemplos
{
    partial class FrmEscalónSegundoOrdenSubmarino
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
            this.txtConstanteDeTiempo = new System.Windows.Forms.TextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblConstanteDeTiempo = new System.Windows.Forms.Label();
            this.txtValorFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCoeficienteDeAmortiguamiento = new System.Windows.Forms.TextBox();
            this.lblCoeficienteDeAmortiguamiento = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gaugeControl2 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.circularGauge1 = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.profundidad = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleSpindleCapComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbxSubmarino = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profundidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSubmarino)).BeginInit();
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
            // txtConstanteDeTiempo
            // 
            this.txtConstanteDeTiempo.Location = new System.Drawing.Point(123, 48);
            this.txtConstanteDeTiempo.Name = "txtConstanteDeTiempo";
            this.txtConstanteDeTiempo.Size = new System.Drawing.Size(74, 20);
            this.txtConstanteDeTiempo.TabIndex = 4;
            this.txtConstanteDeTiempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // btnInicio
            // 
            this.btnInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInicio.Location = new System.Drawing.Point(26, 636);
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
            this.btnLimpiar.Location = new System.Drawing.Point(173, 635);
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
            this.lblConstanteDeTiempo.Location = new System.Drawing.Point(6, 51);
            this.lblConstanteDeTiempo.Name = "lblConstanteDeTiempo";
            this.lblConstanteDeTiempo.Size = new System.Drawing.Size(111, 13);
            this.lblConstanteDeTiempo.TabIndex = 0;
            this.lblConstanteDeTiempo.Text = "Constante de Tiempo:";
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.Location = new System.Drawing.Point(123, 22);
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.Size = new System.Drawing.Size(74, 20);
            this.txtValorFinal.TabIndex = 2;
            this.txtValorFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Profundidad deseada:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCoeficienteDeAmortiguamiento);
            this.groupBox1.Controls.Add(this.lblCoeficienteDeAmortiguamiento);
            this.groupBox1.Controls.Add(this.txtValorFinal);
            this.groupBox1.Controls.Add(this.txtConstanteDeTiempo);
            this.groupBox1.Controls.Add(this.lblConstanteDeTiempo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 525);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 102);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "metros";
            // 
            // txtCoeficienteDeAmortiguamiento
            // 
            this.txtCoeficienteDeAmortiguamiento.Location = new System.Drawing.Point(123, 74);
            this.txtCoeficienteDeAmortiguamiento.Name = "txtCoeficienteDeAmortiguamiento";
            this.txtCoeficienteDeAmortiguamiento.Size = new System.Drawing.Size(74, 20);
            this.txtCoeficienteDeAmortiguamiento.TabIndex = 14;
            this.txtCoeficienteDeAmortiguamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidar_KeyPress);
            // 
            // lblCoeficienteDeAmortiguamiento
            // 
            this.lblCoeficienteDeAmortiguamiento.AutoSize = true;
            this.lblCoeficienteDeAmortiguamiento.Location = new System.Drawing.Point(6, 77);
            this.lblCoeficienteDeAmortiguamiento.Name = "lblCoeficienteDeAmortiguamiento";
            this.lblCoeficienteDeAmortiguamiento.Size = new System.Drawing.Size(71, 13);
            this.lblCoeficienteDeAmortiguamiento.TabIndex = 15;
            this.lblCoeficienteDeAmortiguamiento.Text = "Coef. Amort. :";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.gaugeControl2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 664);
            this.panel1.TabIndex = 14;
            // 
            // gaugeControl2
            // 
            this.gaugeControl2.AutoLayout = false;
            this.gaugeControl2.BackColor = System.Drawing.SystemColors.Control;
            this.gaugeControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl2.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGauge1});
            this.gaugeControl2.Location = new System.Drawing.Point(13, 342);
            this.gaugeControl2.Name = "gaugeControl2";
            this.gaugeControl2.Size = new System.Drawing.Size(260, 178);
            this.gaugeControl2.TabIndex = 19;
            // 
            // circularGauge1
            // 
            this.circularGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.circularGauge1.Bounds = new System.Drawing.Rectangle(5, 5, 248, 167);
            this.circularGauge1.Name = "circularGauge1";
            this.circularGauge1.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
            this.circularGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.profundidad});
            this.circularGauge1.SpindleCaps.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent[] {
            this.arcScaleSpindleCapComponent1});
            // 
            // arcScaleBackgroundLayerComponent1
            // 
            this.arcScaleBackgroundLayerComponent1.ArcScale = this.profundidad;
            this.arcScaleBackgroundLayerComponent1.Name = "bg";
            this.arcScaleBackgroundLayerComponent1.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.695F);
            this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularHalf_Style16;
            this.arcScaleBackgroundLayerComponent1.Size = new System.Drawing.SizeF(250F, 179F);
            this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // profundidad
            // 
            this.profundidad.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profundidad.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.profundidad.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 165F);
            this.profundidad.EndAngle = 0F;
            this.profundidad.MajorTickCount = 5;
            this.profundidad.MajorTickmark.FormatString = "{0:F0}";
            this.profundidad.MajorTickmark.ShapeOffset = -13F;
            this.profundidad.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1;
            this.profundidad.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.profundidad.MaxValue = 2000F;
            this.profundidad.MinorTickCount = 4;
            this.profundidad.MinorTickmark.ShapeOffset = -9F;
            this.profundidad.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2;
            this.profundidad.Name = "scale1";
            this.profundidad.RadiusX = 98F;
            this.profundidad.RadiusY = 98F;
            this.profundidad.StartAngle = -180F;
            // 
            // arcScaleNeedleComponent1
            // 
            this.arcScaleNeedleComponent1.ArcScale = this.profundidad;
            this.arcScaleNeedleComponent1.EndOffset = 3F;
            this.arcScaleNeedleComponent1.Name = "needle";
            this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style16;
            this.arcScaleNeedleComponent1.ZOrder = -50;
            // 
            // arcScaleSpindleCapComponent1
            // 
            this.arcScaleSpindleCapComponent1.ArcScale = this.profundidad;
            this.arcScaleSpindleCapComponent1.Name = "circularGauge1_SpindleCap1";
            this.arcScaleSpindleCapComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.SpindleCapShapeType.CircularFull_Style16;
            this.arcScaleSpindleCapComponent1.Size = new System.Drawing.SizeF(25F, 25F);
            this.arcScaleSpindleCapComponent1.ZOrder = -100;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Ejemplos.Properties.Resources.FondoSubmarino;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pbxSubmarino);
            this.panel2.Location = new System.Drawing.Point(14, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 284);
            this.panel2.TabIndex = 21;
            // 
            // pbxSubmarino
            // 
            this.pbxSubmarino.BackColor = System.Drawing.Color.Transparent;
            this.pbxSubmarino.Image = global::Ejemplos.Properties.Resources.Submarino;
            this.pbxSubmarino.Location = new System.Drawing.Point(3, 3);
            this.pbxSubmarino.Name = "pbxSubmarino";
            this.pbxSubmarino.Size = new System.Drawing.Size(253, 102);
            this.pbxSubmarino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSubmarino.TabIndex = 18;
            this.pbxSubmarino.TabStop = false;
            // 
            // FrmEscalónSegundoOrdenSubmarino
            // 
            this.AcceptButton = this.btnInicio;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1030, 667);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEscalónSegundoOrdenSubmarino";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Escalón Unitario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profundidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSubmarino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl zgcEscalon;
        private System.Windows.Forms.TextBox txtConstanteDeTiempo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblConstanteDeTiempo;
        private System.Windows.Forms.TextBox txtValorFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCoeficienteDeAmortiguamiento;
        private System.Windows.Forms.TextBox txtCoeficienteDeAmortiguamiento;
        private System.Windows.Forms.PictureBox pbxSubmarino;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl2;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent profundidad;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent1;
        private System.Windows.Forms.Panel panel2;
    }
}

