namespace Root_Locus
{
    partial class FrmCompara
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Gráfica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Polos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ceros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantPolos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantCeros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantRamas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PtoRuptura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kCritico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.SystemColors.Control;
            this.zedGraphControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(426, 230);
            this.zedGraphControl1.TabIndex = 7;
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.BackColor = System.Drawing.SystemColors.Control;
            this.zedGraphControl4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl4.Location = new System.Drawing.Point(435, 239);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0D;
            this.zedGraphControl4.ScrollMaxX = 0D;
            this.zedGraphControl4.ScrollMaxY = 0D;
            this.zedGraphControl4.ScrollMaxY2 = 0D;
            this.zedGraphControl4.ScrollMinX = 0D;
            this.zedGraphControl4.ScrollMinY = 0D;
            this.zedGraphControl4.ScrollMinY2 = 0D;
            this.zedGraphControl4.Size = new System.Drawing.Size(427, 230);
            this.zedGraphControl4.TabIndex = 8;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl3.Location = new System.Drawing.Point(3, 239);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(426, 230);
            this.zedGraphControl3.TabIndex = 4;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl2.Location = new System.Drawing.Point(435, 3);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(427, 230);
            this.zedGraphControl2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.zedGraphControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.zedGraphControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.zedGraphControl3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.zedGraphControl4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvDatos, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 582);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Gráfica,
            this.Polos,
            this.Ceros,
            this.CantPolos,
            this.CantCeros,
            this.CantRamas,
            this.CG,
            this.PtoRuptura,
            this.kCritico});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvDatos, 2);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(3, 475);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDatos.Size = new System.Drawing.Size(859, 104);
            this.dgvDatos.TabIndex = 9;
            // 
            // Gráfica
            // 
            this.Gráfica.Frozen = true;
            this.Gráfica.HeaderText = "Gráfica";
            this.Gráfica.Name = "Gráfica";
            this.Gráfica.ReadOnly = true;
            this.Gráfica.Width = 74;
            // 
            // Polos
            // 
            this.Polos.Frozen = true;
            this.Polos.HeaderText = "Cant. Polos";
            this.Polos.Name = "Polos";
            this.Polos.ReadOnly = true;
            this.Polos.Width = 99;
            // 
            // Ceros
            // 
            this.Ceros.Frozen = true;
            this.Ceros.HeaderText = "Polos";
            this.Ceros.Name = "Ceros";
            this.Ceros.ReadOnly = true;
            this.Ceros.Width = 66;
            // 
            // CantPolos
            // 
            this.CantPolos.Frozen = true;
            this.CantPolos.HeaderText = "Cant. Ceros";
            this.CantPolos.Name = "CantPolos";
            this.CantPolos.ReadOnly = true;
            // 
            // CantCeros
            // 
            this.CantCeros.Frozen = true;
            this.CantCeros.HeaderText = "Ceros";
            this.CantCeros.Name = "CantCeros";
            this.CantCeros.ReadOnly = true;
            this.CantCeros.Width = 67;
            // 
            // CantRamas
            // 
            this.CantRamas.Frozen = true;
            this.CantRamas.HeaderText = "Ramas";
            this.CantRamas.Name = "CantRamas";
            this.CantRamas.ReadOnly = true;
            this.CantRamas.Width = 75;
            // 
            // CG
            // 
            this.CG.Frozen = true;
            this.CG.HeaderText = "Centro de Gravedad";
            this.CG.Name = "CG";
            this.CG.ReadOnly = true;
            this.CG.Width = 153;
            // 
            // PtoRuptura
            // 
            this.PtoRuptura.Frozen = true;
            this.PtoRuptura.HeaderText = "Punto de Ruptura";
            this.PtoRuptura.Name = "PtoRuptura";
            this.PtoRuptura.ReadOnly = true;
            this.PtoRuptura.Width = 134;
            // 
            // kCritico
            // 
            this.kCritico.Frozen = true;
            this.kCritico.HeaderText = "Valor K Crítico";
            this.kCritico.Name = "kCritico";
            this.kCritico.ReadOnly = true;
            this.kCritico.Width = 114;
            // 
            // FrmCompara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(865, 582);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCompara";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCompara_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gráfica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Polos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ceros;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantPolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantCeros;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantRamas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PtoRuptura;
        private System.Windows.Forms.DataGridViewTextBoxColumn kCritico;

    }
}