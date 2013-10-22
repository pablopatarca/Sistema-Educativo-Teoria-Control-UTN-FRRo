namespace DiagramasBode
{
    partial class FrmFormulas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFormulas));
            this.btnAceptar = new Controles.BtnAceptar();
            this.btnCancelar = new Controles.BtnCancelar();
            this.lbFormulas = new System.Windows.Forms.ListBox();
            this.btnNuevo = new Controles.BtnNuevo();
            this.btnEditar = new Controles.BtnEditar();
            this.btnEliminar = new Controles.BtnEliminar();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(235, 215);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(43, 43);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.TextoToolTip = null;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(284, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(43, 43);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.TextoToolTip = null;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbFormulas
            // 
            this.lbFormulas.FormattingEnabled = true;
            this.lbFormulas.Location = new System.Drawing.Point(12, 10);
            this.lbFormulas.Name = "lbFormulas";
            this.lbFormulas.Size = new System.Drawing.Size(138, 199);
            this.lbFormulas.TabIndex = 2;
            this.lbFormulas.SelectedIndexChanged += new System.EventHandler(this.lbFormulas_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(12, 215);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(43, 43);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.TextoToolTip = null;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(61, 215);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(43, 43);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.TextoToolTip = null;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(110, 215);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(43, 43);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.TextoToolTip = null;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(156, 10);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(171, 199);
            this.txtDescripcion.TabIndex = 6;
            // 
            // FrmFormulas
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(339, 269);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lbFormulas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFormulas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ejemplos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.BtnAceptar btnAceptar;
        private Controles.BtnCancelar btnCancelar;
        private System.Windows.Forms.ListBox lbFormulas;
        private Controles.BtnNuevo btnNuevo;
        private Controles.BtnEditar btnEditar;
        private Controles.BtnEliminar btnEliminar;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}