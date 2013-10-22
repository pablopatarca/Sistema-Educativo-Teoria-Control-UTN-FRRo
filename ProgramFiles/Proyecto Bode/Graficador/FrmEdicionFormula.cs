using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using System.IO;
using System.Xml.Serialization;
using System.Security.Permissions;
using System.Runtime.Serialization.Formatters.Binary;

namespace DiagramasBode
{
    public partial class FrmEdicionFormula : Form
    {
        /// <summary>
        /// Modos del formulario: creación de nueva fórmula o edición de fórmula existente.
        /// </summary>
        private enum Modos
        {
            Creacion,
            Edicion
        };

        /// <summary>
        /// Modo actual del formulario.
        /// </summary>
        private Modos modo;

        /// <summary>
        /// Fórmula a editar, en caso de estar en modo edición.
        /// </summary>
        private Formula formulaAEditar;

        public FrmEdicionFormula()
        {
            InitializeComponent();
            this.modo = Modos.Creacion;
        }

        public FrmEdicionFormula(Formula formula)
        {
            InitializeComponent();

            this.formulaAEditar = formula;

            this.modo = Modos.Edicion;
            txtTitulo.Enabled = false;
            llenarFormulario(formula);
        }

        /// <summary>
        /// Llena el formulario con los valores de una fórmula.
        /// </summary>
        /// <param name="formula">Fórmula con la que se llenará el formulario.</param>
        private void llenarFormulario(Formula formula)
        {
            txtTitulo.Text = formula.Titulo;
            txtDescripcion.Text = formula.Descripcion;
            ingresoFormulaBode.llenarCampos(formula.K, formula.N1, formula.T1, formula.T2, formula.Td, formula.N2,
                formula.T3, formula.T4, formula.Wn, formula.Psi);
        }

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Si la fórmula es válida.
            if (ingresoFormulaBode.validarFormula().Equals(""))
            {
                if (this.modo == Modos.Creacion)
                {
                    Formula formula = new Formula();

                    formula.Titulo = txtTitulo.Text;
                    formula.Descripcion = txtDescripcion.Text;
                    formula.K = ingresoFormulaBode.K;
                    formula.N1 = ingresoFormulaBode.N1;
                    formula.T1 = ingresoFormulaBode.T1;
                    formula.T2 = ingresoFormulaBode.T2;
                    formula.Td = ingresoFormulaBode.Td;
                    formula.N2 = ingresoFormulaBode.N2;
                    formula.T3 = ingresoFormulaBode.T3;
                    formula.T4 = ingresoFormulaBode.T4;
                    formula.Wn = ingresoFormulaBode.Wn;
                    formula.Psi = ingresoFormulaBode.Psi;

                    Formula.save(formula);
                } 
                else
                {
                    this.formulaAEditar.Descripcion = txtDescripcion.Text;
                    this.formulaAEditar.K = ingresoFormulaBode.K;
                    this.formulaAEditar.N1 = ingresoFormulaBode.N1;
                    this.formulaAEditar.T1 = ingresoFormulaBode.T1;
                    this.formulaAEditar.T2 = ingresoFormulaBode.T2;
                    this.formulaAEditar.Td = ingresoFormulaBode.Td;
                    this.formulaAEditar.N2 = ingresoFormulaBode.N2;
                    this.formulaAEditar.T3 = ingresoFormulaBode.T3;
                    this.formulaAEditar.T4 = ingresoFormulaBode.T4;
                    this.formulaAEditar.Wn = ingresoFormulaBode.Wn;
                    this.formulaAEditar.Psi = ingresoFormulaBode.Psi;

                    Formula.update(this.formulaAEditar);
                }

                Dispose();
            }
            //Si la fórmula es inválida.
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
