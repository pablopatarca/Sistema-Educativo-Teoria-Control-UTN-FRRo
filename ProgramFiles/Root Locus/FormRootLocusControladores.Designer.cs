namespace Root_Locus
{
    partial class FormRootLocusControladores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRootLocusControladores));
            this.pnlBase = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCompara = new System.Windows.Forms.Button();
            this.btnDatos = new System.Windows.Forms.Button();
            this.btnSig = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnAtras = new System.Windows.Forms.Button();
            this.rtbxInfo = new System.Windows.Forms.RichTextBox();
            this.zedC = new ZedGraph.ZedGraphControl();
            this.cbReferencias = new System.Windows.Forms.CheckBox();
            this.cbLineasAmortCte = new System.Windows.Forms.CheckBox();
            this.cBoxAutomatico = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.ColumnCount = 4;
            this.pnlBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pnlBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pnlBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pnlBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBase.Controls.Add(this.btnGuardar, 2, 1);
            this.pnlBase.Controls.Add(this.btnCompara, 0, 7);
            this.pnlBase.Controls.Add(this.btnDatos, 0, 6);
            this.pnlBase.Controls.Add(this.btnSig, 1, 1);
            this.pnlBase.Controls.Add(this.dgvDatos, 0, 5);
            this.pnlBase.Controls.Add(this.btnAtras, 0, 1);
            this.pnlBase.Controls.Add(this.rtbxInfo, 0, 0);
            this.pnlBase.Controls.Add(this.zedC, 3, 0);
            this.pnlBase.Controls.Add(this.cbReferencias, 0, 4);
            this.pnlBase.Controls.Add(this.cbLineasAmortCte, 0, 3);
            this.pnlBase.Controls.Add(this.cBoxAutomatico, 0, 2);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.RowCount = 8;
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlBase.Size = new System.Drawing.Size(1020, 592);
            this.pnlBase.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::Root_Locus.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(163, 165);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(74, 43);
            this.btnGuardar.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar gráfica");
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCompara
            // 
            this.pnlBase.SetColumnSpan(this.btnCompara, 3);
            this.btnCompara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCompara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompara.Image = global::Root_Locus.Properties.Resources.cargar;
            this.btnCompara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompara.Location = new System.Drawing.Point(3, 545);
            this.btnCompara.Name = "btnCompara";
            this.btnCompara.Size = new System.Drawing.Size(234, 44);
            this.btnCompara.TabIndex = 21;
            this.btnCompara.Text = "Comparar";
            this.toolTip1.SetToolTip(this.btnCompara, "Comparar gráficas");
            this.btnCompara.UseVisualStyleBackColor = true;
            this.btnCompara.Click += new System.EventHandler(this.btnCompara_Click);
            // 
            // btnDatos
            // 
            this.pnlBase.SetColumnSpan(this.btnDatos, 3);
            this.btnDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDatos.Enabled = false;
            this.btnDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatos.Image = global::Root_Locus.Properties.Resources.ejemplo;
            this.btnDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatos.Location = new System.Drawing.Point(3, 495);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(234, 44);
            this.btnDatos.TabIndex = 20;
            this.btnDatos.Text = "Ingresar Datos";
            this.toolTip1.SetToolTip(this.btnDatos, "Ingresar Datos");
            this.btnDatos.UseVisualStyleBackColor = true;
            this.btnDatos.Click += new System.EventHandler(this.btnDatos_Click);
            // 
            // btnSig
            // 
            this.btnSig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSig.Image = global::Root_Locus.Properties.Resources.flecha_derecha;
            this.btnSig.Location = new System.Drawing.Point(83, 165);
            this.btnSig.Name = "btnSig";
            this.btnSig.Size = new System.Drawing.Size(74, 43);
            this.btnSig.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnSig, "Regla Siguiente");
            this.btnSig.UseVisualStyleBackColor = true;
            this.btnSig.Click += new System.EventHandler(this.btnSig_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.ColumnHeadersVisible = false;
            this.pnlBase.SetColumnSpan(this.dgvDatos, 3);
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDatos.Location = new System.Drawing.Point(3, 280);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.ShowEditingIcon = false;
            this.dgvDatos.Size = new System.Drawing.Size(234, 209);
            this.dgvDatos.TabIndex = 17;
            this.dgvDatos.TabStop = false;
            // 
            // btnAtras
            // 
            this.btnAtras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Image = global::Root_Locus.Properties.Resources.flecha_izquierda;
            this.btnAtras.Location = new System.Drawing.Point(3, 165);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(74, 43);
            this.btnAtras.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnAtras, "Regla anterior");
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // rtbxInfo
            // 
            this.rtbxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlBase.SetColumnSpan(this.rtbxInfo, 3);
            this.rtbxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbxInfo.Location = new System.Drawing.Point(3, 3);
            this.rtbxInfo.Name = "rtbxInfo";
            this.rtbxInfo.ReadOnly = true;
            this.rtbxInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbxInfo.Size = new System.Drawing.Size(234, 156);
            this.rtbxInfo.TabIndex = 15;
            this.rtbxInfo.TabStop = false;
            this.rtbxInfo.Text = "";
            // 
            // zedC
            // 
            this.zedC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedC.IsEnableSelection = true;
            this.zedC.Location = new System.Drawing.Point(243, 3);
            this.zedC.Name = "zedC";
            this.pnlBase.SetRowSpan(this.zedC, 8);
            this.zedC.ScrollGrace = 0D;
            this.zedC.ScrollMaxX = 0D;
            this.zedC.ScrollMaxY = 0D;
            this.zedC.ScrollMaxY2 = 0D;
            this.zedC.ScrollMinX = 0D;
            this.zedC.ScrollMinY = 0D;
            this.zedC.ScrollMinY2 = 0D;
            this.zedC.Size = new System.Drawing.Size(774, 586);
            this.zedC.TabIndex = 1;
            this.zedC.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.zedC_ZoomEvent);
            this.zedC.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedC_PointValueEvent);
            this.zedC.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedC_MouseDownEvent);
            this.zedC.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedC_MouseUpEvent);
            // 
            // cbReferencias
            // 
            this.cbReferencias.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbReferencias.AutoSize = true;
            this.pnlBase.SetColumnSpan(this.cbReferencias, 2);
            this.cbReferencias.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReferencias.Location = new System.Drawing.Point(10, 257);
            this.cbReferencias.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbReferencias.Name = "cbReferencias";
            this.cbReferencias.Size = new System.Drawing.Size(109, 17);
            this.cbReferencias.TabIndex = 23;
            this.cbReferencias.Text = "Ocultar Asintotas";
            this.cbReferencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbReferencias.UseVisualStyleBackColor = true;
            this.cbReferencias.CheckedChanged += new System.EventHandler(this.cbReferencias_CheckedChanged);
            // 
            // cbLineasAmortCte
            // 
            this.cbLineasAmortCte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLineasAmortCte.AutoSize = true;
            this.pnlBase.SetColumnSpan(this.cbLineasAmortCte, 3);
            this.cbLineasAmortCte.Location = new System.Drawing.Point(10, 236);
            this.cbLineasAmortCte.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbLineasAmortCte.Name = "cbLineasAmortCte";
            this.cbLineasAmortCte.Size = new System.Drawing.Size(166, 15);
            this.cbLineasAmortCte.TabIndex = 24;
            this.cbLineasAmortCte.Text = "Líneas de Amortiguación Cte.";
            this.cbLineasAmortCte.UseVisualStyleBackColor = true;
            this.cbLineasAmortCte.CheckedChanged += new System.EventHandler(this.cbLineasAmortCte_CheckedChanged);
            // 
            // cBoxAutomatico
            // 
            this.cBoxAutomatico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cBoxAutomatico.AutoSize = true;
            this.pnlBase.SetColumnSpan(this.cBoxAutomatico, 2);
            this.cBoxAutomatico.Location = new System.Drawing.Point(10, 214);
            this.cBoxAutomatico.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cBoxAutomatico.Name = "cBoxAutomatico";
            this.cBoxAutomatico.Size = new System.Drawing.Size(116, 16);
            this.cBoxAutomatico.TabIndex = 25;
            this.cBoxAutomatico.Text = "Pasos Automáticos";
            this.cBoxAutomatico.UseVisualStyleBackColor = true;
            // 
            // FormRootLocusControladores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1020, 592);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRootLocusControladores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Root Locus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlBase;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCompara;
        private System.Windows.Forms.Button btnDatos;
        private System.Windows.Forms.Button btnSig;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.RichTextBox rtbxInfo;
        private ZedGraph.ZedGraphControl zedC;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbReferencias;
        private System.Windows.Forms.CheckBox cbLineasAmortCte;
        private System.Windows.Forms.CheckBox cBoxAutomatico;

    }
}

