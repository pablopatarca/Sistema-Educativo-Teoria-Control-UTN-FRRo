namespace Controles
{
    partial class IngresoFormulaBode
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

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtK = new Controles.textboxes.TxtDoubleValorAbsoluto();
            this.txtN1 = new Controles.textboxes.TxtDoubleValorAbsoluto();
            this.txtT1 = new Controles.textboxes.TxtDouble();
            this.txtT2 = new Controles.textboxes.TxtDouble();
            this.txtTd = new Controles.textboxes.TxtDoubleValorAbsoluto();
            this.txtN2 = new Controles.textboxes.TxtDoubleValorAbsoluto();
            this.txtT3 = new Controles.textboxes.TxtDouble();
            this.txtT4 = new Controles.textboxes.TxtDouble();
            this.txtWn = new Controles.textboxes.TxtDouble();
            this.txtPsi = new Controles.textboxes.TxtDouble();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ganancia Constante:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Orden Cero en el Origen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cte. Tiempo 1er. Cero Real:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cte. Tiempo 2do. Cero Real:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Retardo de Transporte:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Orden Polo en el Origen:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Cte. Tiempo 1er. Polo Real:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cte. Tiempo 2do. Polo Real:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(234, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Frec. Natural Amortiguada:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(236, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Coef. de Amortiguamiento:";
            // 
            // txtK
            // 
            this.txtK.BackColor = System.Drawing.Color.Pink;
            this.txtK.ExpresionRegular = "^(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtK.Location = new System.Drawing.Point(152, 0);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(65, 20);
            this.txtK.TabIndex = 1;
            // 
            // txtN1
            // 
            this.txtN1.BackColor = System.Drawing.Color.Pink;
            this.txtN1.ExpresionRegular = "^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$";
            this.txtN1.Location = new System.Drawing.Point(152, 23);
            this.txtN1.Name = "txtN1";
            this.txtN1.Size = new System.Drawing.Size(65, 20);
            this.txtN1.TabIndex = 2;
            // 
            // txtT1
            // 
            this.txtT1.BackColor = System.Drawing.Color.Pink;
            this.txtT1.ExpresionRegular = "^-?(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtT1.Location = new System.Drawing.Point(152, 49);
            this.txtT1.Name = "txtT1";
            this.txtT1.Size = new System.Drawing.Size(65, 20);
            this.txtT1.TabIndex = 3;
            // 
            // txtT2
            // 
            this.txtT2.BackColor = System.Drawing.Color.Pink;
            this.txtT2.ExpresionRegular = "^-?(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtT2.Location = new System.Drawing.Point(152, 75);
            this.txtT2.Name = "txtT2";
            this.txtT2.Size = new System.Drawing.Size(65, 20);
            this.txtT2.TabIndex = 4;
            // 
            // txtTd
            // 
            this.txtTd.BackColor = System.Drawing.Color.Pink;
            this.txtTd.ExpresionRegular = "^(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtTd.Location = new System.Drawing.Point(152, 101);
            this.txtTd.Name = "txtTd";
            this.txtTd.Size = new System.Drawing.Size(65, 20);
            this.txtTd.TabIndex = 5;
            // 
            // txtN2
            // 
            this.txtN2.BackColor = System.Drawing.Color.Pink;
            this.txtN2.ExpresionRegular = "^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$";
            this.txtN2.Location = new System.Drawing.Point(370, 0);
            this.txtN2.Name = "txtN2";
            this.txtN2.Size = new System.Drawing.Size(65, 20);
            this.txtN2.TabIndex = 6;
            // 
            // txtT3
            // 
            this.txtT3.BackColor = System.Drawing.Color.Pink;
            this.txtT3.ExpresionRegular = "^-?(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtT3.Location = new System.Drawing.Point(370, 23);
            this.txtT3.Name = "txtT3";
            this.txtT3.Size = new System.Drawing.Size(65, 20);
            this.txtT3.TabIndex = 7;
            // 
            // txtT4
            // 
            this.txtT4.BackColor = System.Drawing.Color.Pink;
            this.txtT4.ExpresionRegular = "^-?(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtT4.Location = new System.Drawing.Point(370, 49);
            this.txtT4.Name = "txtT4";
            this.txtT4.Size = new System.Drawing.Size(65, 20);
            this.txtT4.TabIndex = 8;
            // 
            // txtWn
            // 
            this.txtWn.BackColor = System.Drawing.Color.Pink;
            this.txtWn.ExpresionRegular = "^-?(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtWn.Location = new System.Drawing.Point(370, 75);
            this.txtWn.Name = "txtWn";
            this.txtWn.Size = new System.Drawing.Size(65, 20);
            this.txtWn.TabIndex = 9;
            // 
            // txtPsi
            // 
            this.txtPsi.BackColor = System.Drawing.Color.Pink;
            this.txtPsi.ExpresionRegular = "^-?(0|[1-9][0-9]*)(,[0-9]*[1-9])?$";
            this.txtPsi.Location = new System.Drawing.Point(370, 101);
            this.txtPsi.Name = "txtPsi";
            this.txtPsi.Size = new System.Drawing.Size(65, 20);
            this.txtPsi.TabIndex = 10;
            // 
            // IngresoFormulaBode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPsi);
            this.Controls.Add(this.txtWn);
            this.Controls.Add(this.txtT4);
            this.Controls.Add(this.txtT3);
            this.Controls.Add(this.txtN2);
            this.Controls.Add(this.txtTd);
            this.Controls.Add(this.txtT2);
            this.Controls.Add(this.txtT1);
            this.Controls.Add(this.txtN1);
            this.Controls.Add(this.txtK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IngresoFormulaBode";
            this.Size = new System.Drawing.Size(435, 123);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private textboxes.TxtDoubleValorAbsoluto txtK;
        private textboxes.TxtDoubleValorAbsoluto txtN1;
        private textboxes.TxtDouble txtT1;
        private textboxes.TxtDouble txtT2;
        private textboxes.TxtDoubleValorAbsoluto txtTd;
        private textboxes.TxtDoubleValorAbsoluto txtN2;
        private textboxes.TxtDouble txtT3;
        private textboxes.TxtDouble txtT4;
        private textboxes.TxtDouble txtWn;
        private textboxes.TxtDouble txtPsi;
    }
}
