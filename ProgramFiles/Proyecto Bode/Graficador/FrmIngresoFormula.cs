using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;

namespace DiagramasBode
{
    public partial class FrmIngresoFormula : Form
    {
        /// <summary>
        /// Fórmula ingresada a través del formulario.
        /// </summary>
        private Formula _Formula;
        public Formula Formula
        {
            get
            {
                return _Formula;
            }
            set
            {
                _Formula = value;
            }
        }

        public FrmIngresoFormula()
        {
            InitializeComponent();
        }

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ingresoFormulaBode.validarFormula().Equals(""))
            {
                //Seteamos las propiedades de la fórmula según los valores ingresados.
                //Esta fórmula va a ser usada por el formulario llamador.
                this.Formula = new Formula();
                this.Formula.K = ingresoFormulaBode.K;
                this.Formula.N1 = ingresoFormulaBode.N1;
                this.Formula.T1 = ingresoFormulaBode.T1;
                this.Formula.T2 = ingresoFormulaBode.T2;
                this.Formula.Td = ingresoFormulaBode.Td;
                this.Formula.N2 = ingresoFormulaBode.N2;
                this.Formula.T3 = ingresoFormulaBode.T3;
                this.Formula.T4 = ingresoFormulaBode.T4;
                this.Formula.Wn = ingresoFormulaBode.Wn;
                this.Formula.Psi = ingresoFormulaBode.Psi;

                Dispose();
            }
            else
            {
                MessageBox.Show(ingresoFormulaBode.validarFormula(), "Diagramas de Bode",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        } 

        #endregion

    }
}
