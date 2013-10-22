namespace Controladores
{
    partial class frmControladores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControladores));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgControlador = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new Controles.BtnCargar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLimpiar1 = new Controles.BtnLimpiar();
            this.btnGraficar1 = new Controles.BtnGraficar();
            this.btnGuardar1 = new Controles.BtnGuardar();
            this.button2 = new Controles.BtnEliminar();
            this.imgSalida = new System.Windows.Forms.PictureBox();
            this.imgError = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgControlador)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgError)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(963, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imgControlador);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 419);
            this.panel1.TabIndex = 1;
            // 
            // imgControlador
            // 
            this.imgControlador.BackColor = System.Drawing.SystemColors.Window;
            this.imgControlador.Image = global::Controladores.Properties.Resources.controlador_proporcional_integral_derivativo;
            this.imgControlador.Location = new System.Drawing.Point(6, 326);
            this.imgControlador.Margin = new System.Windows.Forms.Padding(2);
            this.imgControlador.Name = "imgControlador";
            this.imgControlador.Size = new System.Drawing.Size(293, 39);
            this.imgControlador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgControlador.TabIndex = 5;
            this.imgControlador.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtTitulo);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Location = new System.Drawing.Point(477, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 179);
            this.panel2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(146, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 43);
            this.button3.TabIndex = 12;
            this.button3.TextoToolTip = null;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Titulo";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Enabled = false;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(43, 5);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(151, 18);
            this.txtTitulo.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 95);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLimpiar1);
            this.panel3.Controls.Add(this.btnGraficar1);
            this.panel3.Controls.Add(this.btnGuardar1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(477, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 48);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // btnLimpiar1
            // 
            this.btnLimpiar1.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar1.Image")));
            this.btnLimpiar1.Location = new System.Drawing.Point(149, 0);
            this.btnLimpiar1.Name = "btnLimpiar1";
            this.btnLimpiar1.Size = new System.Drawing.Size(43, 43);
            this.btnLimpiar1.TabIndex = 17;
            this.btnLimpiar1.TextoToolTip = null;
            this.btnLimpiar1.UseVisualStyleBackColor = true;
            this.btnLimpiar1.Click += new System.EventHandler(this.btnLimpiar1_Click_1);
            // 
            // btnGraficar1
            // 
            this.btnGraficar1.Image = ((System.Drawing.Image)(resources.GetObject("btnGraficar1.Image")));
            this.btnGraficar1.Location = new System.Drawing.Point(3, 0);
            this.btnGraficar1.Name = "btnGraficar1";
            this.btnGraficar1.Size = new System.Drawing.Size(43, 43);
            this.btnGraficar1.TabIndex = 15;
            this.btnGraficar1.TextoToolTip = null;
            this.btnGraficar1.UseVisualStyleBackColor = true;
            this.btnGraficar1.Click += new System.EventHandler(this.btnGraficar1_Click);
            // 
            // btnGuardar1
            // 
            this.btnGuardar1.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar1.Image")));
            this.btnGuardar1.Location = new System.Drawing.Point(52, 0);
            this.btnGuardar1.Name = "btnGuardar1";
            this.btnGuardar1.Size = new System.Drawing.Size(43, 43);
            this.btnGuardar1.TabIndex = 13;
            this.btnGuardar1.TextoToolTip = null;
            this.btnGuardar1.UseVisualStyleBackColor = true;
            this.btnGuardar1.Click += new System.EventHandler(this.btnGuardar1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(100, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 43);
            this.button2.TabIndex = 10;
            this.button2.TextoToolTip = null;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imgSalida
            // 
            this.imgSalida.BackColor = System.Drawing.SystemColors.Window;
            this.imgSalida.Location = new System.Drawing.Point(502, 20);
            this.imgSalida.Margin = new System.Windows.Forms.Padding(2);
            this.imgSalida.Name = "imgSalida";
            this.imgSalida.Size = new System.Drawing.Size(591, 41);
            this.imgSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgSalida.TabIndex = 2;
            this.imgSalida.TabStop = false;
            this.imgSalida.Visible = false;
            // 
            // imgError
            // 
            this.imgError.BackColor = System.Drawing.SystemColors.Window;
            this.imgError.Location = new System.Drawing.Point(502, 208);
            this.imgError.Margin = new System.Windows.Forms.Padding(2);
            this.imgError.Name = "imgError";
            this.imgError.Size = new System.Drawing.Size(591, 41);
            this.imgError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgError.TabIndex = 3;
            this.imgError.TabStop = false;
            this.imgError.Visible = false;
            // 
            // frmControladores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(963, 444);
            this.Controls.Add(this.imgError);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.imgSalida);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmControladores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Teoria de Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgControlador)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitulo;
        private Controles.BtnEliminar button2;
        private Controles.BtnCargar button3;
        private Controles.BtnGuardar btnGuardar1;
        private Controles.BtnGraficar btnGraficar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgSalida;
        private System.Windows.Forms.PictureBox imgControlador;
        private System.Windows.Forms.PictureBox imgError;
        private Controles.BtnLimpiar btnLimpiar1;
    }
}