namespace DiagramasBode
{
    partial class FrmPrincipalControladores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipalControladores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gananciaControlador = new System.Windows.Forms.GroupBox();
            this.btnGanancia = new System.Windows.Forms.Button();
            this.nudGanancia = new System.Windows.Forms.NumericUpDown();
            this.chkGraficarLentamente = new System.Windows.Forms.CheckBox();
            this.chbPasosAutom = new System.Windows.Forms.CheckBox();
            this.btnComparar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.mnuEjemplos = new System.Windows.Forms.MenuStrip();
            this.tsmnuEjemplos = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFormula = new Controles.botones.BtnFormula();
            this.lblResultado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFuncionEntrada = new System.Windows.Forms.Panel();
            this.lblN2 = new System.Windows.Forms.Label();
            this.pbOrdenPoloOrigen = new System.Windows.Forms.PictureBox();
            this.lblWn3 = new System.Windows.Forms.Label();
            this.lblWn2 = new System.Windows.Forms.Label();
            this.lblPsi = new System.Windows.Forms.Label();
            this.lblWn1 = new System.Windows.Forms.Label();
            this.lblT4 = new System.Windows.Forms.Label();
            this.lblT3 = new System.Windows.Forms.Label();
            this.pbLineaDivisoria = new System.Windows.Forms.PictureBox();
            this.lblT1 = new System.Windows.Forms.Label();
            this.lblTd = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.pbFuncionG = new System.Windows.Forms.PictureBox();
            this.lblOrdenPoloOrigen = new System.Windows.Forms.Label();
            this.pbFNACA = new System.Windows.Forms.PictureBox();
            this.pbCT2PS = new System.Windows.Forms.PictureBox();
            this.pbCT1PS = new System.Windows.Forms.PictureBox();
            this.pbRetardoTiempo = new System.Windows.Forms.PictureBox();
            this.pbCT2CS = new System.Windows.Forms.PictureBox();
            this.pbCT1CS = new System.Windows.Forms.PictureBox();
            this.lblN1 = new System.Windows.Forms.Label();
            this.pbOrdenCeroOrigen = new System.Windows.Forms.PictureBox();
            this.lblK = new System.Windows.Forms.Label();
            this.pbFuncionEntrada = new System.Windows.Forms.PictureBox();
            this.btnLimpiar = new Controles.BtnLimpiar();
            this.btnRetroceder = new Controles.BtnRetroceder();
            this.btnAvanzar = new Controles.BtnAvanzar();
            this.btnEjemplos = new Controles.BtnEjemplos();
            this.dgvMargenes = new System.Windows.Forms.DataGridView();
            this.colMargen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrdenada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbOcultarTerminosIndividuales = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDiagramas = new System.Windows.Forms.TableLayoutPanel();
            this.zgcFase = new ZedGraph.ZedGraphControl();
            this.zgcMagnitud = new ZedGraph.ZedGraphControl();
            this.panel1.SuspendLayout();
            this.gananciaControlador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGanancia)).BeginInit();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.mnuEjemplos.SuspendLayout();
            this.pnlFuncionEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrdenPoloOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLineaDivisoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFuncionG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFNACA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT2PS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT1PS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRetardoTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT2CS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT1CS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrdenCeroOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFuncionEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMargenes)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.tlpDiagramas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gananciaControlador);
            this.panel1.Controls.Add(this.chkGraficarLentamente);
            this.panel1.Controls.Add(this.chbPasosAutom);
            this.panel1.Controls.Add(this.btnComparar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.toolStripContainer1);
            this.panel1.Controls.Add(this.btnFormula);
            this.panel1.Controls.Add(this.lblResultado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnlFuncionEntrada);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnRetroceder);
            this.panel1.Controls.Add(this.btnAvanzar);
            this.panel1.Controls.Add(this.btnEjemplos);
            this.panel1.Controls.Add(this.dgvMargenes);
            this.panel1.Controls.Add(this.cbOcultarTerminosIndividuales);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 104);
            this.panel1.TabIndex = 1;
            // 
            // gananciaControlador
            // 
            this.gananciaControlador.Controls.Add(this.btnGanancia);
            this.gananciaControlador.Controls.Add(this.nudGanancia);
            this.gananciaControlador.Location = new System.Drawing.Point(1018, 6);
            this.gananciaControlador.Name = "gananciaControlador";
            this.gananciaControlador.Size = new System.Drawing.Size(89, 101);
            this.gananciaControlador.TabIndex = 71;
            this.gananciaControlador.TabStop = false;
            this.gananciaControlador.Text = "Ganancia del controlador";
            // 
            // btnGanancia
            // 
            this.btnGanancia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGanancia.Enabled = false;
            this.btnGanancia.Location = new System.Drawing.Point(12, 72);
            this.btnGanancia.Name = "btnGanancia";
            this.btnGanancia.Size = new System.Drawing.Size(66, 23);
            this.btnGanancia.TabIndex = 1;
            this.btnGanancia.Text = "Cambiar";
            this.btnGanancia.UseVisualStyleBackColor = true;
            this.btnGanancia.Click += new System.EventHandler(this.btnGanancia_Click);
            // 
            // nudGanancia
            // 
            this.nudGanancia.DecimalPlaces = 3;
            this.nudGanancia.Enabled = false;
            this.nudGanancia.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudGanancia.Location = new System.Drawing.Point(18, 40);
            this.nudGanancia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudGanancia.Name = "nudGanancia";
            this.nudGanancia.Size = new System.Drawing.Size(51, 20);
            this.nudGanancia.TabIndex = 0;
            this.nudGanancia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkGraficarLentamente
            // 
            this.chkGraficarLentamente.AutoSize = true;
            this.chkGraficarLentamente.Location = new System.Drawing.Point(721, 82);
            this.chkGraficarLentamente.Name = "chkGraficarLentamente";
            this.chkGraficarLentamente.Size = new System.Drawing.Size(122, 17);
            this.chkGraficarLentamente.TabIndex = 70;
            this.chkGraficarLentamente.Text = "Graficar Lentamente";
            this.chkGraficarLentamente.UseVisualStyleBackColor = true;
            // 
            // chbPasosAutom
            // 
            this.chbPasosAutom.AutoSize = true;
            this.chbPasosAutom.Location = new System.Drawing.Point(599, 82);
            this.chbPasosAutom.Name = "chbPasosAutom";
            this.chbPasosAutom.Size = new System.Drawing.Size(115, 17);
            this.chbPasosAutom.TabIndex = 69;
            this.chbPasosAutom.Text = "Pasos automáticos";
            this.chbPasosAutom.UseVisualStyleBackColor = true;
            // 
            // btnComparar
            // 
            this.btnComparar.Enabled = false;
            this.btnComparar.Location = new System.Drawing.Point(934, 80);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(75, 23);
            this.btnComparar.TabIndex = 68;
            this.btnComparar.Text = "Comparar";
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(859, 80);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(68, 23);
            this.btnGuardar.TabIndex = 67;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(64, 48);
            this.toolStripContainer1.Location = new System.Drawing.Point(788, 10);
            this.toolStripContainer1.MaximumSize = new System.Drawing.Size(100, 100);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(64, 48);
            this.toolStripContainer1.TabIndex = 66;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mnuEjemplos);
            // 
            // mnuEjemplos
            // 
            this.mnuEjemplos.BackColor = System.Drawing.SystemColors.Control;
            this.mnuEjemplos.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuEjemplos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuEjemplos});
            this.mnuEjemplos.Location = new System.Drawing.Point(0, 0);
            this.mnuEjemplos.Name = "mnuEjemplos";
            this.mnuEjemplos.Size = new System.Drawing.Size(66, 53);
            this.mnuEjemplos.TabIndex = 0;
            this.mnuEjemplos.Text = "Ejemplos";
            this.mnuEjemplos.Visible = false;
            this.mnuEjemplos.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // tsmnuEjemplos
            // 
            this.tsmnuEjemplos.BackColor = System.Drawing.SystemColors.Control;
            this.tsmnuEjemplos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejemplo1ToolStripMenuItem,
            this.ejemplo2ToolStripMenuItem,
            this.ejemplo3ToolStripMenuItem});
            this.tsmnuEjemplos.Enabled = false;
            this.tsmnuEjemplos.Image = ((System.Drawing.Image)(resources.GetObject("tsmnuEjemplos.Image")));
            this.tsmnuEjemplos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmnuEjemplos.Name = "tsmnuEjemplos";
            this.tsmnuEjemplos.Size = new System.Drawing.Size(58, 49);
            this.tsmnuEjemplos.ToolTipText = "Ejemplos";
            this.tsmnuEjemplos.Visible = false;
            // 
            // ejemplo1ToolStripMenuItem
            // 
            this.ejemplo1ToolStripMenuItem.Name = "ejemplo1ToolStripMenuItem";
            this.ejemplo1ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ejemplo1ToolStripMenuItem.Text = "Ejemplo 1";
            this.ejemplo1ToolStripMenuItem.Click += new System.EventHandler(this.ejemplo1ToolStripMenuItem_Click);
            // 
            // ejemplo2ToolStripMenuItem
            // 
            this.ejemplo2ToolStripMenuItem.Name = "ejemplo2ToolStripMenuItem";
            this.ejemplo2ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ejemplo2ToolStripMenuItem.Text = "Ejemplo 2";
            this.ejemplo2ToolStripMenuItem.Click += new System.EventHandler(this.ejemplo2ToolStripMenuItem_Click);
            // 
            // ejemplo3ToolStripMenuItem
            // 
            this.ejemplo3ToolStripMenuItem.Name = "ejemplo3ToolStripMenuItem";
            this.ejemplo3ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ejemplo3ToolStripMenuItem.Text = "Ejemplo 3";
            this.ejemplo3ToolStripMenuItem.Click += new System.EventHandler(this.ejemplo3ToolStripMenuItem_Click);
            // 
            // btnFormula
            // 
            this.btnFormula.Image = ((System.Drawing.Image)(resources.GetObject("btnFormula.Image")));
            this.btnFormula.Location = new System.Drawing.Point(599, 14);
            this.btnFormula.Name = "btnFormula";
            this.btnFormula.Size = new System.Drawing.Size(43, 43);
            this.btnFormula.TabIndex = 65;
            this.btnFormula.TextoToolTip = null;
            this.btnFormula.UseVisualStyleBackColor = true;
            this.btnFormula.Click += new System.EventHandler(this.btnFormula_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(1038, 82);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 13);
            this.lblResultado.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(973, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 63;
            this.label1.Visible = false;
            // 
            // pnlFuncionEntrada
            // 
            this.pnlFuncionEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFuncionEntrada.Controls.Add(this.lblN2);
            this.pnlFuncionEntrada.Controls.Add(this.pbOrdenPoloOrigen);
            this.pnlFuncionEntrada.Controls.Add(this.lblWn3);
            this.pnlFuncionEntrada.Controls.Add(this.lblWn2);
            this.pnlFuncionEntrada.Controls.Add(this.lblPsi);
            this.pnlFuncionEntrada.Controls.Add(this.lblWn1);
            this.pnlFuncionEntrada.Controls.Add(this.lblT4);
            this.pnlFuncionEntrada.Controls.Add(this.lblT3);
            this.pnlFuncionEntrada.Controls.Add(this.pbLineaDivisoria);
            this.pnlFuncionEntrada.Controls.Add(this.lblT1);
            this.pnlFuncionEntrada.Controls.Add(this.lblTd);
            this.pnlFuncionEntrada.Controls.Add(this.lblT2);
            this.pnlFuncionEntrada.Controls.Add(this.pbFuncionG);
            this.pnlFuncionEntrada.Controls.Add(this.lblOrdenPoloOrigen);
            this.pnlFuncionEntrada.Controls.Add(this.pbFNACA);
            this.pnlFuncionEntrada.Controls.Add(this.pbCT2PS);
            this.pnlFuncionEntrada.Controls.Add(this.pbCT1PS);
            this.pnlFuncionEntrada.Controls.Add(this.pbRetardoTiempo);
            this.pnlFuncionEntrada.Controls.Add(this.pbCT2CS);
            this.pnlFuncionEntrada.Controls.Add(this.pbCT1CS);
            this.pnlFuncionEntrada.Controls.Add(this.lblN1);
            this.pnlFuncionEntrada.Controls.Add(this.pbOrdenCeroOrigen);
            this.pnlFuncionEntrada.Controls.Add(this.lblK);
            this.pnlFuncionEntrada.Controls.Add(this.pbFuncionEntrada);
            this.pnlFuncionEntrada.Location = new System.Drawing.Point(9, 13);
            this.pnlFuncionEntrada.Name = "pnlFuncionEntrada";
            this.pnlFuncionEntrada.Size = new System.Drawing.Size(567, 79);
            this.pnlFuncionEntrada.TabIndex = 62;
            // 
            // lblN2
            // 
            this.lblN2.AutoSize = true;
            this.lblN2.BackColor = System.Drawing.Color.White;
            this.lblN2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblN2.Location = new System.Drawing.Point(64, 37);
            this.lblN2.Name = "lblN2";
            this.lblN2.Size = new System.Drawing.Size(15, 15);
            this.lblN2.TabIndex = 7;
            this.lblN2.Text = "0";
            // 
            // pbOrdenPoloOrigen
            // 
            this.pbOrdenPoloOrigen.Image = global::DiagramasBode.Properties.Resources.OrdenPoloOrigen;
            this.pbOrdenPoloOrigen.Location = new System.Drawing.Point(54, 36);
            this.pbOrdenPoloOrigen.Name = "pbOrdenPoloOrigen";
            this.pbOrdenPoloOrigen.Size = new System.Drawing.Size(38, 36);
            this.pbOrdenPoloOrigen.TabIndex = 18;
            this.pbOrdenPoloOrigen.TabStop = false;
            this.pbOrdenPoloOrigen.Visible = false;
            // 
            // lblWn3
            // 
            this.lblWn3.AutoSize = true;
            this.lblWn3.BackColor = System.Drawing.Color.White;
            this.lblWn3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWn3.Location = new System.Drawing.Point(521, 60);
            this.lblWn3.Name = "lblWn3";
            this.lblWn3.Size = new System.Drawing.Size(15, 15);
            this.lblWn3.TabIndex = 13;
            this.lblWn3.Text = "0";
            // 
            // lblWn2
            // 
            this.lblWn2.AutoSize = true;
            this.lblWn2.BackColor = System.Drawing.Color.White;
            this.lblWn2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWn2.Location = new System.Drawing.Point(450, 59);
            this.lblWn2.Name = "lblWn2";
            this.lblWn2.Size = new System.Drawing.Size(15, 15);
            this.lblWn2.TabIndex = 12;
            this.lblWn2.Text = "0";
            // 
            // lblPsi
            // 
            this.lblPsi.AutoSize = true;
            this.lblPsi.BackColor = System.Drawing.Color.White;
            this.lblPsi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPsi.Location = new System.Drawing.Point(402, 59);
            this.lblPsi.Name = "lblPsi";
            this.lblPsi.Size = new System.Drawing.Size(15, 15);
            this.lblPsi.TabIndex = 11;
            this.lblPsi.Text = "0";
            // 
            // lblWn1
            // 
            this.lblWn1.AutoSize = true;
            this.lblWn1.BackColor = System.Drawing.Color.White;
            this.lblWn1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWn1.Location = new System.Drawing.Point(423, 38);
            this.lblWn1.Name = "lblWn1";
            this.lblWn1.Size = new System.Drawing.Size(15, 15);
            this.lblWn1.TabIndex = 10;
            this.lblWn1.Text = "0";
            // 
            // lblT4
            // 
            this.lblT4.AutoSize = true;
            this.lblT4.BackColor = System.Drawing.Color.White;
            this.lblT4.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT4.Location = new System.Drawing.Point(260, 45);
            this.lblT4.Name = "lblT4";
            this.lblT4.Size = new System.Drawing.Size(19, 20);
            this.lblT4.TabIndex = 9;
            this.lblT4.Text = "0";
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.BackColor = System.Drawing.Color.White;
            this.lblT3.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT3.Location = new System.Drawing.Point(148, 45);
            this.lblT3.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(19, 20);
            this.lblT3.TabIndex = 8;
            this.lblT3.Text = "0";
            // 
            // pbLineaDivisoria
            // 
            this.pbLineaDivisoria.Image = global::DiagramasBode.Properties.Resources.lineaDivisoria;
            this.pbLineaDivisoria.Location = new System.Drawing.Point(54, 30);
            this.pbLineaDivisoria.Name = "pbLineaDivisoria";
            this.pbLineaDivisoria.Size = new System.Drawing.Size(511, 4);
            this.pbLineaDivisoria.TabIndex = 24;
            this.pbLineaDivisoria.TabStop = false;
            this.pbLineaDivisoria.Visible = false;
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.BackColor = System.Drawing.Color.White;
            this.lblT1.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT1.Location = new System.Drawing.Point(211, 5);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(19, 20);
            this.lblT1.TabIndex = 4;
            this.lblT1.Text = "0";
            // 
            // lblTd
            // 
            this.lblTd.AutoSize = true;
            this.lblTd.BackColor = System.Drawing.Color.White;
            this.lblTd.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTd.Location = new System.Drawing.Point(430, -1);
            this.lblTd.Name = "lblTd";
            this.lblTd.Size = new System.Drawing.Size(15, 15);
            this.lblTd.TabIndex = 6;
            this.lblTd.Text = "0";
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.BackColor = System.Drawing.Color.White;
            this.lblT2.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT2.Location = new System.Drawing.Point(324, 6);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(19, 20);
            this.lblT2.TabIndex = 5;
            this.lblT2.Text = "0";
            // 
            // pbFuncionG
            // 
            this.pbFuncionG.Image = global::DiagramasBode.Properties.Resources.FuncionGs;
            this.pbFuncionG.Location = new System.Drawing.Point(2, 1);
            this.pbFuncionG.Name = "pbFuncionG";
            this.pbFuncionG.Size = new System.Drawing.Size(52, 73);
            this.pbFuncionG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFuncionG.TabIndex = 23;
            this.pbFuncionG.TabStop = false;
            // 
            // lblOrdenPoloOrigen
            // 
            this.lblOrdenPoloOrigen.AutoSize = true;
            this.lblOrdenPoloOrigen.BackColor = System.Drawing.Color.White;
            this.lblOrdenPoloOrigen.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenPoloOrigen.Location = new System.Drawing.Point(60, 46);
            this.lblOrdenPoloOrigen.Name = "lblOrdenPoloOrigen";
            this.lblOrdenPoloOrigen.Size = new System.Drawing.Size(19, 20);
            this.lblOrdenPoloOrigen.TabIndex = 22;
            this.lblOrdenPoloOrigen.Text = "1";
            this.lblOrdenPoloOrigen.Visible = false;
            // 
            // pbFNACA
            // 
            this.pbFNACA.Image = global::DiagramasBode.Properties.Resources.FrecNA___CAmort;
            this.pbFNACA.Location = new System.Drawing.Point(335, 36);
            this.pbFNACA.Name = "pbFNACA";
            this.pbFNACA.Size = new System.Drawing.Size(231, 39);
            this.pbFNACA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFNACA.TabIndex = 21;
            this.pbFNACA.TabStop = false;
            this.pbFNACA.Visible = false;
            // 
            // pbCT2PS
            // 
            this.pbCT2PS.Image = global::DiagramasBode.Properties.Resources.CteTiempo2PoloSimple;
            this.pbCT2PS.Location = new System.Drawing.Point(217, 38);
            this.pbCT2PS.Name = "pbCT2PS";
            this.pbCT2PS.Size = new System.Drawing.Size(116, 36);
            this.pbCT2PS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCT2PS.TabIndex = 20;
            this.pbCT2PS.TabStop = false;
            this.pbCT2PS.Visible = false;
            // 
            // pbCT1PS
            // 
            this.pbCT1PS.Image = global::DiagramasBode.Properties.Resources.CteTiempo1PoloSimple;
            this.pbCT1PS.Location = new System.Drawing.Point(98, 38);
            this.pbCT1PS.Name = "pbCT1PS";
            this.pbCT1PS.Size = new System.Drawing.Size(116, 36);
            this.pbCT1PS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCT1PS.TabIndex = 19;
            this.pbCT1PS.TabStop = false;
            this.pbCT1PS.Visible = false;
            // 
            // pbRetardoTiempo
            // 
            this.pbRetardoTiempo.Image = global::DiagramasBode.Properties.Resources.RetardoTiempo;
            this.pbRetardoTiempo.Location = new System.Drawing.Point(393, 2);
            this.pbRetardoTiempo.Name = "pbRetardoTiempo";
            this.pbRetardoTiempo.Size = new System.Drawing.Size(109, 27);
            this.pbRetardoTiempo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRetardoTiempo.TabIndex = 17;
            this.pbRetardoTiempo.TabStop = false;
            this.pbRetardoTiempo.Visible = false;
            // 
            // pbCT2CS
            // 
            this.pbCT2CS.Image = global::DiagramasBode.Properties.Resources.CteTiempo2CeroSimple;
            this.pbCT2CS.Location = new System.Drawing.Point(279, -1);
            this.pbCT2CS.Name = "pbCT2CS";
            this.pbCT2CS.Size = new System.Drawing.Size(113, 30);
            this.pbCT2CS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCT2CS.TabIndex = 16;
            this.pbCT2CS.TabStop = false;
            this.pbCT2CS.Visible = false;
            this.pbCT2CS.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pbCT1CS
            // 
            this.pbCT1CS.Image = global::DiagramasBode.Properties.Resources.CteTiempo1PoloSimple;
            this.pbCT1CS.Location = new System.Drawing.Point(171, -1);
            this.pbCT1CS.Name = "pbCT1CS";
            this.pbCT1CS.Size = new System.Drawing.Size(109, 30);
            this.pbCT1CS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCT1CS.TabIndex = 15;
            this.pbCT1CS.TabStop = false;
            this.pbCT1CS.Visible = false;
            // 
            // lblN1
            // 
            this.lblN1.AutoSize = true;
            this.lblN1.BackColor = System.Drawing.Color.White;
            this.lblN1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblN1.Location = new System.Drawing.Point(136, 0);
            this.lblN1.Name = "lblN1";
            this.lblN1.Size = new System.Drawing.Size(15, 15);
            this.lblN1.TabIndex = 3;
            this.lblN1.Text = "0";
            // 
            // pbOrdenCeroOrigen
            // 
            this.pbOrdenCeroOrigen.Image = global::DiagramasBode.Properties.Resources.OrdenCeroEnElOrigen;
            this.pbOrdenCeroOrigen.Location = new System.Drawing.Point(98, -1);
            this.pbOrdenCeroOrigen.Name = "pbOrdenCeroOrigen";
            this.pbOrdenCeroOrigen.Size = new System.Drawing.Size(69, 30);
            this.pbOrdenCeroOrigen.TabIndex = 14;
            this.pbOrdenCeroOrigen.TabStop = false;
            this.pbOrdenCeroOrigen.Visible = false;
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.BackColor = System.Drawing.Color.White;
            this.lblK.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblK.Location = new System.Drawing.Point(70, 9);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(19, 20);
            this.lblK.TabIndex = 2;
            this.lblK.Text = "1";
            // 
            // pbFuncionEntrada
            // 
            this.pbFuncionEntrada.BackColor = System.Drawing.Color.White;
            this.pbFuncionEntrada.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbFuncionEntrada.Location = new System.Drawing.Point(0, 0);
            this.pbFuncionEntrada.Name = "pbFuncionEntrada";
            this.pbFuncionEntrada.Size = new System.Drawing.Size(566, 77);
            this.pbFuncionEntrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFuncionEntrada.TabIndex = 1;
            this.pbFuncionEntrada.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(746, 13);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(43, 43);
            this.btnLimpiar.TabIndex = 60;
            this.btnLimpiar.TextoToolTip = null;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.Image = ((System.Drawing.Image)(resources.GetObject("btnRetroceder.Image")));
            this.btnRetroceder.Location = new System.Drawing.Point(648, 14);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(43, 43);
            this.btnRetroceder.TabIndex = 59;
            this.btnRetroceder.TextoToolTip = null;
            this.btnRetroceder.UseVisualStyleBackColor = true;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnAvanzar
            // 
            this.btnAvanzar.Image = ((System.Drawing.Image)(resources.GetObject("btnAvanzar.Image")));
            this.btnAvanzar.Location = new System.Drawing.Point(697, 13);
            this.btnAvanzar.Name = "btnAvanzar";
            this.btnAvanzar.Size = new System.Drawing.Size(43, 43);
            this.btnAvanzar.TabIndex = 58;
            this.btnAvanzar.TextoToolTip = null;
            this.btnAvanzar.UseVisualStyleBackColor = true;
            this.btnAvanzar.Click += new System.EventHandler(this.btnAvanzar_Click);
            // 
            // btnEjemplos
            // 
            this.btnEjemplos.Image = ((System.Drawing.Image)(resources.GetObject("btnEjemplos.Image")));
            this.btnEjemplos.Location = new System.Drawing.Point(809, 59);
            this.btnEjemplos.Name = "btnEjemplos";
            this.btnEjemplos.Size = new System.Drawing.Size(43, 43);
            this.btnEjemplos.TabIndex = 55;
            this.btnEjemplos.TextoToolTip = null;
            this.btnEjemplos.UseVisualStyleBackColor = true;
            this.btnEjemplos.Visible = false;
            this.btnEjemplos.Click += new System.EventHandler(this.btnEjemplos_Click);
            // 
            // dgvMargenes
            // 
            this.dgvMargenes.AllowUserToAddRows = false;
            this.dgvMargenes.AllowUserToDeleteRows = false;
            this.dgvMargenes.AllowUserToResizeColumns = false;
            this.dgvMargenes.AllowUserToResizeRows = false;
            this.dgvMargenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMargenes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMargenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMargenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMargen,
            this.colOrdenada});
            this.dgvMargenes.Enabled = false;
            this.dgvMargenes.Location = new System.Drawing.Point(859, 9);
            this.dgvMargenes.Name = "dgvMargenes";
            this.dgvMargenes.ReadOnly = true;
            this.dgvMargenes.RowHeadersVisible = false;
            this.dgvMargenes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMargenes.Size = new System.Drawing.Size(153, 63);
            this.dgvMargenes.TabIndex = 54;
            // 
            // colMargen
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.colMargen.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMargen.HeaderText = "Margen";
            this.colMargen.Name = "colMargen";
            this.colMargen.ReadOnly = true;
            // 
            // colOrdenada
            // 
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.colOrdenada.DefaultCellStyle = dataGridViewCellStyle2;
            this.colOrdenada.HeaderText = "Valor";
            this.colOrdenada.Name = "colOrdenada";
            this.colOrdenada.ReadOnly = true;
            // 
            // cbOcultarTerminosIndividuales
            // 
            this.cbOcultarTerminosIndividuales.AutoSize = true;
            this.cbOcultarTerminosIndividuales.Location = new System.Drawing.Point(599, 63);
            this.cbOcultarTerminosIndividuales.Name = "cbOcultarTerminosIndividuales";
            this.cbOcultarTerminosIndividuales.Size = new System.Drawing.Size(160, 17);
            this.cbOcultarTerminosIndividuales.TabIndex = 53;
            this.cbOcultarTerminosIndividuales.Text = "Ocultar términos individuales";
            this.cbOcultarTerminosIndividuales.UseVisualStyleBackColor = true;
            this.cbOcultarTerminosIndividuales.CheckedChanged += new System.EventHandler(this.cbOcultarTerminosIndividuales_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(596, 81);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 15);
            this.lblError.TabIndex = 52;
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.tlpDiagramas, 0, 1);
            this.tlpPrincipal.Controls.Add(this.panel1, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.Size = new System.Drawing.Size(1038, 592);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // tlpDiagramas
            // 
            this.tlpDiagramas.ColumnCount = 1;
            this.tlpDiagramas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDiagramas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDiagramas.Controls.Add(this.zgcFase, 0, 1);
            this.tlpDiagramas.Controls.Add(this.zgcMagnitud, 0, 0);
            this.tlpDiagramas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiagramas.Location = new System.Drawing.Point(3, 113);
            this.tlpDiagramas.Name = "tlpDiagramas";
            this.tlpDiagramas.RowCount = 2;
            this.tlpDiagramas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiagramas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiagramas.Size = new System.Drawing.Size(1032, 483);
            this.tlpDiagramas.TabIndex = 3;
            // 
            // zgcFase
            // 
            this.zgcFase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcFase.Location = new System.Drawing.Point(3, 244);
            this.zgcFase.Name = "zgcFase";
            this.zgcFase.ScrollGrace = 0D;
            this.zgcFase.ScrollMaxX = 0D;
            this.zgcFase.ScrollMaxY = 0D;
            this.zgcFase.ScrollMaxY2 = 0D;
            this.zgcFase.ScrollMinX = 0D;
            this.zgcFase.ScrollMinY = 0D;
            this.zgcFase.ScrollMinY2 = 0D;
            this.zgcFase.Size = new System.Drawing.Size(1026, 236);
            this.zgcFase.TabIndex = 0;
            this.zgcFase.DoubleClick += new System.EventHandler(this.zgcFase_DoubleClick);
            // 
            // zgcMagnitud
            // 
            this.zgcMagnitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcMagnitud.Location = new System.Drawing.Point(3, 3);
            this.zgcMagnitud.Name = "zgcMagnitud";
            this.zgcMagnitud.ScrollGrace = 0D;
            this.zgcMagnitud.ScrollMaxX = 0D;
            this.zgcMagnitud.ScrollMaxY = 0D;
            this.zgcMagnitud.ScrollMaxY2 = 0D;
            this.zgcMagnitud.ScrollMinX = 0D;
            this.zgcMagnitud.ScrollMinY = 0D;
            this.zgcMagnitud.ScrollMinY2 = 0D;
            this.zgcMagnitud.Size = new System.Drawing.Size(1026, 235);
            this.zgcMagnitud.TabIndex = 0;
            this.zgcMagnitud.Load += new System.EventHandler(this.zgcMagnitud_Load);
            this.zgcMagnitud.DoubleClick += new System.EventHandler(this.zgcMagnitud_DoubleClick);
            // 
            // FrmPrincipalControladores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1038, 592);
            this.Controls.Add(this.tlpPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuEjemplos;
            this.Name = "FrmPrincipalControladores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diagramas de Bode con efectos de la acción de control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBode_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gananciaControlador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudGanancia)).EndInit();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.mnuEjemplos.ResumeLayout(false);
            this.mnuEjemplos.PerformLayout();
            this.pnlFuncionEntrada.ResumeLayout(false);
            this.pnlFuncionEntrada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrdenPoloOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLineaDivisoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFuncionG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFNACA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT2PS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT1PS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRetardoTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT2CS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCT1CS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrdenCeroOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFuncionEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMargenes)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpDiagramas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpDiagramas;
        private ZedGraph.ZedGraphControl zgcFase;
        private ZedGraph.ZedGraphControl zgcMagnitud;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox cbOcultarTerminosIndividuales;
        private System.Windows.Forms.DataGridView dgvMargenes;
        private Controles.BtnEjemplos btnEjemplos;
        private Controles.BtnAvanzar btnAvanzar;
        private Controles.BtnRetroceder btnRetroceder;
        private Controles.BtnLimpiar btnLimpiar;
        private System.Windows.Forms.Panel pnlFuncionEntrada;
        private System.Windows.Forms.PictureBox pbFuncionEntrada;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.Label lblN1;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblTd;
        private System.Windows.Forms.Label lblWn3;
        private System.Windows.Forms.Label lblWn2;
        private System.Windows.Forms.Label lblPsi;
        private System.Windows.Forms.Label lblWn1;
        private System.Windows.Forms.Label lblT4;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.Label lblN2;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMargen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrdenada;
        private Controles.botones.BtnFormula btnFormula;
        private System.Windows.Forms.PictureBox pbRetardoTiempo;
        private System.Windows.Forms.PictureBox pbCT2CS;
        private System.Windows.Forms.PictureBox pbCT1CS;
        private System.Windows.Forms.PictureBox pbOrdenCeroOrigen;
        private System.Windows.Forms.PictureBox pbFNACA;
        private System.Windows.Forms.PictureBox pbCT2PS;
        private System.Windows.Forms.PictureBox pbCT1PS;
        private System.Windows.Forms.PictureBox pbOrdenPoloOrigen;
        private System.Windows.Forms.Label lblOrdenPoloOrigen;
        private System.Windows.Forms.PictureBox pbFuncionG;
        private System.Windows.Forms.PictureBox pbLineaDivisoria;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip mnuEjemplos;
        private System.Windows.Forms.ToolStripMenuItem tsmnuEjemplos;
        private System.Windows.Forms.ToolStripMenuItem ejemplo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejemplo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejemplo3ToolStripMenuItem;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.CheckBox chbPasosAutom;
        private System.Windows.Forms.CheckBox chkGraficarLentamente;
        private System.Windows.Forms.GroupBox gananciaControlador;
        private System.Windows.Forms.Button btnGanancia;
        private System.Windows.Forms.NumericUpDown nudGanancia;




    }
}

