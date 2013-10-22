namespace TeoriaDeControl
{
    partial class frmRespuestaTransienteMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRespuestaTransienteMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.graficaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respuestaTransienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impulsoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.senoidalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rampaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.escalonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.impulsoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.senoidalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDatosGrafica = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.gbxFormulaEstandar = new System.Windows.Forms.GroupBox();
            this.lblNumerador = new System.Windows.Forms.Label();
            this.lblDenominador3Termino = new System.Windows.Forms.Label();
            this.lblDenominador2Termino = new System.Windows.Forms.Label();
            this.cuadroBlanco1 = new System.Windows.Forms.PictureBox();
            this.cuadroBlanco2 = new System.Windows.Forms.PictureBox();
            this.cuadroBlanco3 = new System.Windows.Forms.PictureBox();
            this.pbxFormulaEstandar = new System.Windows.Forms.PictureBox();
            this.gbxOvershootVsPsi = new System.Windows.Forms.GroupBox();
            this.btnOvershootVsPsi = new System.Windows.Forms.Button();
            this.gbxAsentamientoVsPsi = new System.Windows.Forms.GroupBox();
            this.btnTiempoAsentVSPsi = new System.Windows.Forms.Button();
            this.pbFormula = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPendienteOrigen = new System.Windows.Forms.CheckBox();
            this.chkTpoSubida = new System.Windows.Forms.CheckBox();
            this.chkTpoAsentamiento = new System.Windows.Forms.CheckBox();
            this.chkReferencias = new System.Windows.Forms.CheckBox();
            this.chkEntrada = new System.Windows.Forms.CheckBox();
            this.lblFTrans = new System.Windows.Forms.Label();
            this.btnGuardar1 = new Controles.BtnGuardar();
            this.button3 = new Controles.BtnCargar();
            this.button2 = new Controles.BtnEliminar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.gbxGrafica = new System.Windows.Forms.GroupBox();
            this.btnGraficar1 = new Controles.BtnGraficar();
            this.btnLimpiar1 = new Controles.BtnLimpiar();
            this.btnRepetirUltimaFila1 = new Controles.botones.BtnRepetirUltimaFila();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnComparar = new System.Windows.Forms.Button();
            this.btnMedidas = new Controles.botones.BtnMedidas();
            this.lstArchivos = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.pnlDatosGrafica.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.gbxFormulaEstandar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuadroBlanco1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadroBlanco2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadroBlanco3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFormulaEstandar)).BeginInit();
            this.gbxOvershootVsPsi.SuspendLayout();
            this.gbxAsentamientoVsPsi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormula)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbxGrafica.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graficaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(990, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // graficaToolStripMenuItem
            // 
            this.graficaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.graficaToolStripMenuItem.Name = "graficaToolStripMenuItem";
            this.graficaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.graficaToolStripMenuItem.Text = "Grafica";
            this.graficaToolStripMenuItem.Visible = false;
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.respuestaTransienteToolStripMenuItem});
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.nuevaToolStripMenuItem.Text = "Nueva";
            // 
            // respuestaTransienteToolStripMenuItem
            // 
            this.respuestaTransienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenToolStripMenuItem,
            this.ordenToolStripMenuItem1});
            this.respuestaTransienteToolStripMenuItem.Name = "respuestaTransienteToolStripMenuItem";
            this.respuestaTransienteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.respuestaTransienteToolStripMenuItem.Text = "Respuesta Transitoria";
            // 
            // ordenToolStripMenuItem
            // 
            this.ordenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escalonToolStripMenuItem,
            this.impulsoToolStripMenuItem,
            this.senoidalToolStripMenuItem,
            this.rampaToolStripMenuItem});
            this.ordenToolStripMenuItem.Name = "ordenToolStripMenuItem";
            this.ordenToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.ordenToolStripMenuItem.Text = "1° Orden";
            // 
            // escalonToolStripMenuItem
            // 
            this.escalonToolStripMenuItem.Name = "escalonToolStripMenuItem";
            this.escalonToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.escalonToolStripMenuItem.Text = "Escalon";
            this.escalonToolStripMenuItem.Click += new System.EventHandler(this.escalonToolStripMenuItem_Click);
            // 
            // impulsoToolStripMenuItem
            // 
            this.impulsoToolStripMenuItem.Name = "impulsoToolStripMenuItem";
            this.impulsoToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.impulsoToolStripMenuItem.Text = "Impulso";
            this.impulsoToolStripMenuItem.Click += new System.EventHandler(this.impulsoToolStripMenuItem_Click);
            // 
            // senoidalToolStripMenuItem
            // 
            this.senoidalToolStripMenuItem.Name = "senoidalToolStripMenuItem";
            this.senoidalToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.senoidalToolStripMenuItem.Text = "Senoidal";
            this.senoidalToolStripMenuItem.Click += new System.EventHandler(this.senoidalToolStripMenuItem_Click);
            // 
            // rampaToolStripMenuItem
            // 
            this.rampaToolStripMenuItem.Name = "rampaToolStripMenuItem";
            this.rampaToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.rampaToolStripMenuItem.Text = "Rampa";
            this.rampaToolStripMenuItem.Click += new System.EventHandler(this.rampaToolStripMenuItem_Click);
            // 
            // ordenToolStripMenuItem1
            // 
            this.ordenToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escalonToolStripMenuItem1,
            this.impulsoToolStripMenuItem1,
            this.senoidalToolStripMenuItem1});
            this.ordenToolStripMenuItem1.Name = "ordenToolStripMenuItem1";
            this.ordenToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.ordenToolStripMenuItem1.Text = "2° Orden";
            // 
            // escalonToolStripMenuItem1
            // 
            this.escalonToolStripMenuItem1.Name = "escalonToolStripMenuItem1";
            this.escalonToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.escalonToolStripMenuItem1.Text = "Escalon";
            this.escalonToolStripMenuItem1.Click += new System.EventHandler(this.escalonToolStripMenuItem1_Click);
            // 
            // impulsoToolStripMenuItem1
            // 
            this.impulsoToolStripMenuItem1.Name = "impulsoToolStripMenuItem1";
            this.impulsoToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.impulsoToolStripMenuItem1.Text = "Impulso";
            this.impulsoToolStripMenuItem1.Click += new System.EventHandler(this.impulsoToolStripMenuItem1_Click);
            // 
            // senoidalToolStripMenuItem1
            // 
            this.senoidalToolStripMenuItem1.Name = "senoidalToolStripMenuItem1";
            this.senoidalToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.senoidalToolStripMenuItem1.Text = "Senoidal";
            this.senoidalToolStripMenuItem1.Click += new System.EventHandler(this.senoidalToolStripMenuItem1_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.eliminarToolStripMenuItem.Text = "Volver";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // pnlDatosGrafica
            // 
            this.pnlDatosGrafica.Controls.Add(this.pnlAcciones);
            this.pnlDatosGrafica.Location = new System.Drawing.Point(12, 27);
            this.pnlDatosGrafica.Name = "pnlDatosGrafica";
            this.pnlDatosGrafica.Size = new System.Drawing.Size(978, 165);
            this.pnlDatosGrafica.TabIndex = 1;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.gbxFormulaEstandar);
            this.pnlAcciones.Controls.Add(this.gbxOvershootVsPsi);
            this.pnlAcciones.Controls.Add(this.gbxAsentamientoVsPsi);
            this.pnlAcciones.Controls.Add(this.pbFormula);
            this.pnlAcciones.Controls.Add(this.groupBox1);
            this.pnlAcciones.Controls.Add(this.lblFTrans);
            this.pnlAcciones.Controls.Add(this.btnGuardar1);
            this.pnlAcciones.Controls.Add(this.button3);
            this.pnlAcciones.Controls.Add(this.button2);
            this.pnlAcciones.Controls.Add(this.label1);
            this.pnlAcciones.Controls.Add(this.txtTitulo);
            this.pnlAcciones.Controls.Add(this.gbxGrafica);
            this.pnlAcciones.Controls.Add(this.lstArchivos);
            this.pnlAcciones.Location = new System.Drawing.Point(6, 3);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(806, 161);
            this.pnlAcciones.TabIndex = 3;
            // 
            // gbxFormulaEstandar
            // 
            this.gbxFormulaEstandar.Controls.Add(this.lblNumerador);
            this.gbxFormulaEstandar.Controls.Add(this.lblDenominador3Termino);
            this.gbxFormulaEstandar.Controls.Add(this.lblDenominador2Termino);
            this.gbxFormulaEstandar.Controls.Add(this.cuadroBlanco1);
            this.gbxFormulaEstandar.Controls.Add(this.cuadroBlanco2);
            this.gbxFormulaEstandar.Controls.Add(this.cuadroBlanco3);
            this.gbxFormulaEstandar.Controls.Add(this.pbxFormulaEstandar);
            this.gbxFormulaEstandar.Location = new System.Drawing.Point(545, 5);
            this.gbxFormulaEstandar.Name = "gbxFormulaEstandar";
            this.gbxFormulaEstandar.Size = new System.Drawing.Size(226, 105);
            this.gbxFormulaEstandar.TabIndex = 28;
            this.gbxFormulaEstandar.TabStop = false;
            this.gbxFormulaEstandar.Text = "Fórmula estándar";
            // 
            // lblNumerador
            // 
            this.lblNumerador.AutoSize = true;
            this.lblNumerador.BackColor = System.Drawing.Color.White;
            this.lblNumerador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumerador.ForeColor = System.Drawing.Color.Red;
            this.lblNumerador.Location = new System.Drawing.Point(106, 32);
            this.lblNumerador.Name = "lblNumerador";
            this.lblNumerador.Size = new System.Drawing.Size(18, 20);
            this.lblNumerador.TabIndex = 26;
            this.lblNumerador.Text = "1";
            this.lblNumerador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNumerador.Visible = false;
            // 
            // lblDenominador3Termino
            // 
            this.lblDenominador3Termino.AutoSize = true;
            this.lblDenominador3Termino.BackColor = System.Drawing.Color.White;
            this.lblDenominador3Termino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenominador3Termino.ForeColor = System.Drawing.Color.Red;
            this.lblDenominador3Termino.Location = new System.Drawing.Point(155, 65);
            this.lblDenominador3Termino.Name = "lblDenominador3Termino";
            this.lblDenominador3Termino.Size = new System.Drawing.Size(18, 20);
            this.lblDenominador3Termino.TabIndex = 28;
            this.lblDenominador3Termino.Text = "1";
            this.lblDenominador3Termino.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDenominador3Termino.Visible = false;
            // 
            // lblDenominador2Termino
            // 
            this.lblDenominador2Termino.AutoSize = true;
            this.lblDenominador2Termino.BackColor = System.Drawing.Color.White;
            this.lblDenominador2Termino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenominador2Termino.ForeColor = System.Drawing.Color.Red;
            this.lblDenominador2Termino.Location = new System.Drawing.Point(59, 65);
            this.lblDenominador2Termino.Name = "lblDenominador2Termino";
            this.lblDenominador2Termino.Size = new System.Drawing.Size(18, 20);
            this.lblDenominador2Termino.TabIndex = 27;
            this.lblDenominador2Termino.Text = "1";
            this.lblDenominador2Termino.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDenominador2Termino.Visible = false;
            // 
            // cuadroBlanco1
            // 
            this.cuadroBlanco1.BackColor = System.Drawing.Color.White;
            this.cuadroBlanco1.Image = global::TeoriaDeControl.Properties.Resources.Blanco;
            this.cuadroBlanco1.Location = new System.Drawing.Point(58, 63);
            this.cuadroBlanco1.Name = "cuadroBlanco1";
            this.cuadroBlanco1.Size = new System.Drawing.Size(54, 27);
            this.cuadroBlanco1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cuadroBlanco1.TabIndex = 29;
            this.cuadroBlanco1.TabStop = false;
            this.cuadroBlanco1.Visible = false;
            // 
            // cuadroBlanco2
            // 
            this.cuadroBlanco2.BackColor = System.Drawing.Color.White;
            this.cuadroBlanco2.Image = global::TeoriaDeControl.Properties.Resources.Blanco;
            this.cuadroBlanco2.Location = new System.Drawing.Point(152, 62);
            this.cuadroBlanco2.Name = "cuadroBlanco2";
            this.cuadroBlanco2.Size = new System.Drawing.Size(54, 27);
            this.cuadroBlanco2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cuadroBlanco2.TabIndex = 30;
            this.cuadroBlanco2.TabStop = false;
            this.cuadroBlanco2.Visible = false;
            // 
            // cuadroBlanco3
            // 
            this.cuadroBlanco3.BackColor = System.Drawing.Color.White;
            this.cuadroBlanco3.Image = global::TeoriaDeControl.Properties.Resources.Blanco;
            this.cuadroBlanco3.Location = new System.Drawing.Point(91, 26);
            this.cuadroBlanco3.Name = "cuadroBlanco3";
            this.cuadroBlanco3.Size = new System.Drawing.Size(54, 27);
            this.cuadroBlanco3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cuadroBlanco3.TabIndex = 31;
            this.cuadroBlanco3.TabStop = false;
            this.cuadroBlanco3.Visible = false;
            // 
            // pbxFormulaEstandar
            // 
            this.pbxFormulaEstandar.Image = global::TeoriaDeControl.Properties.Resources.Formula_estándar;
            this.pbxFormulaEstandar.Location = new System.Drawing.Point(6, 19);
            this.pbxFormulaEstandar.Name = "pbxFormulaEstandar";
            this.pbxFormulaEstandar.Size = new System.Drawing.Size(214, 80);
            this.pbxFormulaEstandar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxFormulaEstandar.TabIndex = 25;
            this.pbxFormulaEstandar.TabStop = false;
            // 
            // gbxOvershootVsPsi
            // 
            this.gbxOvershootVsPsi.Controls.Add(this.btnOvershootVsPsi);
            this.gbxOvershootVsPsi.Location = new System.Drawing.Point(434, 5);
            this.gbxOvershootVsPsi.Name = "gbxOvershootVsPsi";
            this.gbxOvershootVsPsi.Size = new System.Drawing.Size(105, 65);
            this.gbxOvershootVsPsi.TabIndex = 26;
            this.gbxOvershootVsPsi.TabStop = false;
            this.gbxOvershootVsPsi.Text = "Overshoot vs. Coef. amort.";
            // 
            // btnOvershootVsPsi
            // 
            this.btnOvershootVsPsi.Enabled = false;
            this.btnOvershootVsPsi.Location = new System.Drawing.Point(15, 34);
            this.btnOvershootVsPsi.Name = "btnOvershootVsPsi";
            this.btnOvershootVsPsi.Size = new System.Drawing.Size(75, 23);
            this.btnOvershootVsPsi.TabIndex = 0;
            this.btnOvershootVsPsi.Text = "Graficar";
            this.btnOvershootVsPsi.UseVisualStyleBackColor = true;
            this.btnOvershootVsPsi.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbxAsentamientoVsPsi
            // 
            this.gbxAsentamientoVsPsi.Controls.Add(this.btnTiempoAsentVSPsi);
            this.gbxAsentamientoVsPsi.Location = new System.Drawing.Point(301, 5);
            this.gbxAsentamientoVsPsi.Name = "gbxAsentamientoVsPsi";
            this.gbxAsentamientoVsPsi.Size = new System.Drawing.Size(127, 65);
            this.gbxAsentamientoVsPsi.TabIndex = 24;
            this.gbxAsentamientoVsPsi.TabStop = false;
            this.gbxAsentamientoVsPsi.Text = "Tiempo asentamiento vs. Coef. amort.";
            // 
            // btnTiempoAsentVSPsi
            // 
            this.btnTiempoAsentVSPsi.Enabled = false;
            this.btnTiempoAsentVSPsi.Location = new System.Drawing.Point(26, 34);
            this.btnTiempoAsentVSPsi.Name = "btnTiempoAsentVSPsi";
            this.btnTiempoAsentVSPsi.Size = new System.Drawing.Size(74, 23);
            this.btnTiempoAsentVSPsi.TabIndex = 23;
            this.btnTiempoAsentVSPsi.Text = "Graficar";
            this.btnTiempoAsentVSPsi.UseVisualStyleBackColor = true;
            this.btnTiempoAsentVSPsi.Click += new System.EventHandler(this.btnTiempoAsentVSPsi_Click);
            // 
            // pbFormula
            // 
            this.pbFormula.Image = global::TeoriaDeControl.Properties.Resources.FormulaEscalon1Orden;
            this.pbFormula.Location = new System.Drawing.Point(220, 76);
            this.pbFormula.Name = "pbFormula";
            this.pbFormula.Size = new System.Drawing.Size(319, 61);
            this.pbFormula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFormula.TabIndex = 20;
            this.pbFormula.TabStop = false;
            this.pbFormula.Click += new System.EventHandler(this.pbFormula_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPendienteOrigen);
            this.groupBox1.Controls.Add(this.chkTpoSubida);
            this.groupBox1.Controls.Add(this.chkTpoAsentamiento);
            this.groupBox1.Controls.Add(this.chkReferencias);
            this.groupBox1.Controls.Add(this.chkEntrada);
            this.groupBox1.Location = new System.Drawing.Point(4, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 61);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ver";
            // 
            // chkPendienteOrigen
            // 
            this.chkPendienteOrigen.AutoSize = true;
            this.chkPendienteOrigen.Location = new System.Drawing.Point(6, 58);
            this.chkPendienteOrigen.Name = "chkPendienteOrigen";
            this.chkPendienteOrigen.Size = new System.Drawing.Size(132, 17);
            this.chkPendienteOrigen.TabIndex = 4;
            this.chkPendienteOrigen.Text = "Pendiente en el origen";
            this.chkPendienteOrigen.UseVisualStyleBackColor = true;
            this.chkPendienteOrigen.Visible = false;
            this.chkPendienteOrigen.CheckedChanged += new System.EventHandler(this.chkPendienteOrigen_CheckedChanged);
            // 
            // chkTpoSubida
            // 
            this.chkTpoSubida.AutoSize = true;
            this.chkTpoSubida.Location = new System.Drawing.Point(107, 39);
            this.chkTpoSubida.Name = "chkTpoSubida";
            this.chkTpoSubida.Size = new System.Drawing.Size(97, 17);
            this.chkTpoSubida.TabIndex = 3;
            this.chkTpoSubida.Text = "Tiempo Subida";
            this.chkTpoSubida.UseVisualStyleBackColor = true;
            this.chkTpoSubida.Visible = false;
            this.chkTpoSubida.CheckedChanged += new System.EventHandler(this.chkTpoSubida_CheckedChanged);
            // 
            // chkTpoAsentamiento
            // 
            this.chkTpoAsentamiento.AutoSize = true;
            this.chkTpoAsentamiento.Location = new System.Drawing.Point(75, 19);
            this.chkTpoAsentamiento.Name = "chkTpoAsentamiento";
            this.chkTpoAsentamiento.Size = new System.Drawing.Size(128, 17);
            this.chkTpoAsentamiento.TabIndex = 2;
            this.chkTpoAsentamiento.Text = "Tiempo Asentamiento";
            this.chkTpoAsentamiento.UseVisualStyleBackColor = true;
            this.chkTpoAsentamiento.CheckedChanged += new System.EventHandler(this.check2_CheckedChanged);
            // 
            // chkReferencias
            // 
            this.chkReferencias.AutoSize = true;
            this.chkReferencias.Location = new System.Drawing.Point(6, 39);
            this.chkReferencias.Name = "chkReferencias";
            this.chkReferencias.Size = new System.Drawing.Size(83, 17);
            this.chkReferencias.TabIndex = 1;
            this.chkReferencias.Text = "Referencias";
            this.chkReferencias.UseVisualStyleBackColor = true;
            this.chkReferencias.CheckedChanged += new System.EventHandler(this.checkRef_CheckedChanged);
            // 
            // chkEntrada
            // 
            this.chkEntrada.AutoSize = true;
            this.chkEntrada.Location = new System.Drawing.Point(6, 19);
            this.chkEntrada.Name = "chkEntrada";
            this.chkEntrada.Size = new System.Drawing.Size(63, 17);
            this.chkEntrada.TabIndex = 0;
            this.chkEntrada.Text = "Entrada";
            this.chkEntrada.UseVisualStyleBackColor = true;
            this.chkEntrada.CheckedChanged += new System.EventHandler(this.checkEntrada_CheckedChanged);
            // 
            // lblFTrans
            // 
            this.lblFTrans.AutoSize = true;
            this.lblFTrans.Location = new System.Drawing.Point(412, 22);
            this.lblFTrans.Name = "lblFTrans";
            this.lblFTrans.Size = new System.Drawing.Size(0, 13);
            this.lblFTrans.TabIndex = 19;
            // 
            // btnGuardar1
            // 
            this.btnGuardar1.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar1.Image")));
            this.btnGuardar1.Location = new System.Drawing.Point(332, 76);
            this.btnGuardar1.Name = "btnGuardar1";
            this.btnGuardar1.Size = new System.Drawing.Size(43, 43);
            this.btnGuardar1.TabIndex = 13;
            this.btnGuardar1.TextoToolTip = null;
            this.btnGuardar1.UseVisualStyleBackColor = true;
            this.btnGuardar1.Visible = false;
            this.btnGuardar1.Click += new System.EventHandler(this.btnGuardar1_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(301, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 43);
            this.button3.TabIndex = 12;
            this.button3.TextoToolTip = null;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(350, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 43);
            this.button2.TabIndex = 10;
            this.button2.TextoToolTip = null;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Titulo";
            this.label1.Visible = false;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(332, 39);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(117, 20);
            this.txtTitulo.TabIndex = 7;
            this.txtTitulo.Visible = false;
            // 
            // gbxGrafica
            // 
            this.gbxGrafica.Controls.Add(this.btnGraficar1);
            this.gbxGrafica.Controls.Add(this.btnLimpiar1);
            this.gbxGrafica.Controls.Add(this.btnRepetirUltimaFila1);
            this.gbxGrafica.Controls.Add(this.btnGuardar);
            this.gbxGrafica.Controls.Add(this.btnComparar);
            this.gbxGrafica.Controls.Add(this.btnMedidas);
            this.gbxGrafica.Location = new System.Drawing.Point(4, 3);
            this.gbxGrafica.Name = "gbxGrafica";
            this.gbxGrafica.Size = new System.Drawing.Size(290, 67);
            this.gbxGrafica.TabIndex = 27;
            this.gbxGrafica.TabStop = false;
            this.gbxGrafica.Text = "Gráfica";
            // 
            // btnGraficar1
            // 
            this.btnGraficar1.Image = ((System.Drawing.Image)(resources.GetObject("btnGraficar1.Image")));
            this.btnGraficar1.Location = new System.Drawing.Point(6, 18);
            this.btnGraficar1.Name = "btnGraficar1";
            this.btnGraficar1.Size = new System.Drawing.Size(43, 43);
            this.btnGraficar1.TabIndex = 15;
            this.btnGraficar1.TextoToolTip = null;
            this.btnGraficar1.UseVisualStyleBackColor = true;
            this.btnGraficar1.Click += new System.EventHandler(this.btnGraficar1_Click);
            // 
            // btnLimpiar1
            // 
            this.btnLimpiar1.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar1.Image")));
            this.btnLimpiar1.Location = new System.Drawing.Point(153, 18);
            this.btnLimpiar1.Name = "btnLimpiar1";
            this.btnLimpiar1.Size = new System.Drawing.Size(43, 43);
            this.btnLimpiar1.TabIndex = 16;
            this.btnLimpiar1.TextoToolTip = null;
            this.btnLimpiar1.UseVisualStyleBackColor = true;
            this.btnLimpiar1.Click += new System.EventHandler(this.btnLimpiar1_Click);
            // 
            // btnRepetirUltimaFila1
            // 
            this.btnRepetirUltimaFila1.Image = ((System.Drawing.Image)(resources.GetObject("btnRepetirUltimaFila1.Image")));
            this.btnRepetirUltimaFila1.Location = new System.Drawing.Point(104, 18);
            this.btnRepetirUltimaFila1.Name = "btnRepetirUltimaFila1";
            this.btnRepetirUltimaFila1.Size = new System.Drawing.Size(43, 43);
            this.btnRepetirUltimaFila1.TabIndex = 18;
            this.btnRepetirUltimaFila1.TextoToolTip = null;
            this.btnRepetirUltimaFila1.UseVisualStyleBackColor = true;
            this.btnRepetirUltimaFila1.Click += new System.EventHandler(this.btnRepetirUltimaFila1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(202, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnComparar
            // 
            this.btnComparar.Enabled = false;
            this.btnComparar.Location = new System.Drawing.Point(202, 38);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(75, 23);
            this.btnComparar.TabIndex = 22;
            this.btnComparar.Text = "Comparar";
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnMedidas
            // 
            this.btnMedidas.Image = ((System.Drawing.Image)(resources.GetObject("btnMedidas.Image")));
            this.btnMedidas.Location = new System.Drawing.Point(55, 18);
            this.btnMedidas.Name = "btnMedidas";
            this.btnMedidas.Size = new System.Drawing.Size(43, 43);
            this.btnMedidas.TabIndex = 14;
            this.btnMedidas.TextoToolTip = null;
            this.btnMedidas.UseVisualStyleBackColor = true;
            this.btnMedidas.Click += new System.EventHandler(this.btnMedidas_Click_1);
            // 
            // lstArchivos
            // 
            this.lstArchivos.FormattingEnabled = true;
            this.lstArchivos.Location = new System.Drawing.Point(290, 12);
            this.lstArchivos.Name = "lstArchivos";
            this.lstArchivos.Size = new System.Drawing.Size(122, 121);
            this.lstArchivos.TabIndex = 2;
            this.lstArchivos.Visible = false;
            this.lstArchivos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // frmRespuestaTransienteMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(990, 444);
            this.Controls.Add(this.pnlDatosGrafica);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRespuestaTransienteMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "                         Respuesta Transitoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRespuestaTransienteMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlDatosGrafica.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.gbxFormulaEstandar.ResumeLayout(false);
            this.gbxFormulaEstandar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuadroBlanco1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadroBlanco2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadroBlanco3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFormulaEstandar)).EndInit();
            this.gbxOvershootVsPsi.ResumeLayout(false);
            this.gbxAsentamientoVsPsi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFormula)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxGrafica.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem graficaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respuestaTransienteToolStripMenuItem;
        private System.Windows.Forms.Panel pnlDatosGrafica;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.ListBox lstArchivos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkReferencias;
        private System.Windows.Forms.CheckBox chkEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitulo;
        private Controles.BtnEliminar button2;
        private Controles.BtnCargar button3;
        private Controles.BtnGuardar btnGuardar1;
        private System.Windows.Forms.CheckBox chkTpoAsentamiento;
        private System.Windows.Forms.ToolStripMenuItem ordenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impulsoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem senoidalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rampaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem escalonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem impulsoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem senoidalToolStripMenuItem1;
        private Controles.botones.BtnMedidas btnMedidas;
        private Controles.BtnGraficar btnGraficar1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private Controles.BtnLimpiar btnLimpiar1;
        private Controles.botones.BtnRepetirUltimaFila btnRepetirUltimaFila1;
        private System.Windows.Forms.Label lblFTrans;
        private System.Windows.Forms.PictureBox pbFormula;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnTiempoAsentVSPsi;
        private System.Windows.Forms.PictureBox pbxFormulaEstandar;
        private System.Windows.Forms.GroupBox gbxAsentamientoVsPsi;
        private System.Windows.Forms.GroupBox gbxOvershootVsPsi;
        private System.Windows.Forms.Button btnOvershootVsPsi;
        private System.Windows.Forms.GroupBox gbxFormulaEstandar;
        private System.Windows.Forms.GroupBox gbxGrafica;
        private System.Windows.Forms.Label lblDenominador2Termino;
        private System.Windows.Forms.Label lblNumerador;
        private System.Windows.Forms.Label lblDenominador3Termino;
        private System.Windows.Forms.PictureBox cuadroBlanco1;
        private System.Windows.Forms.PictureBox cuadroBlanco2;
        private System.Windows.Forms.PictureBox cuadroBlanco3;
        private System.Windows.Forms.CheckBox chkTpoSubida;
        private System.Windows.Forms.CheckBox chkPendienteOrigen;
    }
}