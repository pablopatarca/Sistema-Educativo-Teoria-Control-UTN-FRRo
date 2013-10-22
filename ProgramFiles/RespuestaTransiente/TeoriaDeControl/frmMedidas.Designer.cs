namespace TeoriaDeControl
{
    partial class frmMedidas
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
            this.dgvMedidas = new System.Windows.Forms.DataGridView();
            this.dgvRetardoFase = new System.Windows.Forms.DataGridView();
            this.lblRetardoDeFase = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetardoFase)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMedidas
            // 
            this.dgvMedidas.AllowUserToAddRows = false;
            this.dgvMedidas.AllowUserToDeleteRows = false;
            this.dgvMedidas.AllowUserToResizeColumns = false;
            this.dgvMedidas.AllowUserToResizeRows = false;
            this.dgvMedidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMedidas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvMedidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMedidas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedidas.Location = new System.Drawing.Point(6, 12);
            this.dgvMedidas.Name = "dgvMedidas";
            this.dgvMedidas.Size = new System.Drawing.Size(718, 60);
            this.dgvMedidas.TabIndex = 0;
            this.dgvMedidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvRetardoFase
            // 
            this.dgvRetardoFase.AllowUserToAddRows = false;
            this.dgvRetardoFase.AllowUserToDeleteRows = false;
            this.dgvRetardoFase.AllowUserToResizeColumns = false;
            this.dgvRetardoFase.AllowUserToResizeRows = false;
            this.dgvRetardoFase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRetardoFase.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRetardoFase.Location = new System.Drawing.Point(6, 114);
            this.dgvRetardoFase.Name = "dgvRetardoFase";
            this.dgvRetardoFase.Size = new System.Drawing.Size(421, 42);
            this.dgvRetardoFase.TabIndex = 1;
            this.dgvRetardoFase.Visible = false;
            // 
            // lblRetardoDeFase
            // 
            this.lblRetardoDeFase.AutoSize = true;
            this.lblRetardoDeFase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetardoDeFase.Location = new System.Drawing.Point(12, 91);
            this.lblRetardoDeFase.Name = "lblRetardoDeFase";
            this.lblRetardoDeFase.Size = new System.Drawing.Size(433, 20);
            this.lblRetardoDeFase.TabIndex = 2;
            this.lblRetardoDeFase.Text = "Retardo de fase en función de la frecuencia (grados)";
            this.lblRetardoDeFase.Visible = false;
            this.lblRetardoDeFase.Click += new System.EventHandler(this.lblRetardoDeFase_Click);
            // 
            // frmMedidas
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(728, 375);
            this.Controls.Add(this.lblRetardoDeFase);
            this.Controls.Add(this.dgvRetardoFase);
            this.Controls.Add(this.dgvMedidas);
            this.MaximizeBox = false;
            this.Name = "frmMedidas";
            this.Text = "Medidas de Desempeño";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetardoFase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvMedidas;
        public System.Windows.Forms.DataGridView dgvRetardoFase;
        private System.Windows.Forms.Label lblRetardoDeFase;
    }
}