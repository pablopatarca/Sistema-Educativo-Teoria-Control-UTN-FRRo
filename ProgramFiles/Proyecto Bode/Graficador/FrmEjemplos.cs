using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Util;

namespace DiagramasBode
{
    public partial class FrmFormulas : Form
    {
        /// <summary>
        /// Fórmula seleccionada en el formulario.
        /// </summary>
        private Formula _FormulaSeleccionada;
        public Formula FormulaSeleccionada
        {
            get
            {
                return _FormulaSeleccionada;
            }
            set
            {
                _FormulaSeleccionada = value;
            }
        }

        /// <summary>
        /// Lista de fórmulas disponibles para su selección en el formulario.
        /// </summary>
        private List<Formula> formulas;

        public FrmFormulas()
        {
            InitializeComponent();

            formulas = new List<Formula>();
            actualizar();
        }

        /// <summary>
        /// Actualiza la lista de fórmulas disponibles para su selección en el formulario,
        /// luego de haber agregado o quitado alguna de ellas.
        /// </summary>
        private void actualizar()
        {
            lbFormulas.Items.Clear();
            txtDescripcion.Text = "";

            this.formulas = Formula.getAll();

            if (formulas.Count > 0)
            {
                foreach (Formula formula in this.formulas)
                    lbFormulas.Items.Add(formula.Titulo);

                lbFormulas.SelectedIndex = 0;
                txtDescripcion.Text = formulas[0].Descripcion;
            }
        }

        #region Eventos

        private void lbFormulas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text = this.formulas[lbFormulas.SelectedIndex].Descripcion;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmEdicionFormula frmNuevo = new FrmEdicionFormula();
            frmNuevo.Text = "Nueva fórmula";

            frmNuevo.ShowDialog();
            actualizar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Puedo editar una fórmula solamente si hay, como mínimo, una en la colección.
            if (this.formulas.Count > 0)
            {
                //Los ejemplos del libro quedarán fijos y no podrán editarse.
                //Los individualizamos sabiendo que tienen el índice más bajo.
                 if (lbFormulas.SelectedIndex != 0 &&
                    lbFormulas.SelectedIndex != 1 &&
                    lbFormulas.SelectedIndex != 2)
                 {
                    FrmEdicionFormula frmEditar = new FrmEdicionFormula(this.formulas[lbFormulas.SelectedIndex]);
                    frmEditar.Text = "Editar fórmula";

                    frmEditar.ShowDialog();
                    actualizar();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            for (int indiceFormula = 0; indiceFormula < this.formulas.Count; indiceFormula++)
            {
                //Los ejemplos del libro quedarán fijos y no podrán borrarse.
                //Los individualizamos sabiendo que tienen el índice más bajo.
                if (indiceFormula != 0 && indiceFormula != 1 && indiceFormula != 2)
                {
                    if (this.formulas[indiceFormula].Titulo.Equals(lbFormulas.SelectedItem.ToString())
                                && MessageBox.Show("¿Desea eliminar el ejemplo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Formula.delete(this.formulas[indiceFormula]);
                        actualizar();
                        break;
                    } 
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Asignamos la fórmula seleccionada para que lo use el formulario llamador.
            if (lbFormulas.Items.Count > 0)
                this.FormulaSeleccionada = this.formulas[lbFormulas.SelectedIndex]; 

            Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion
    }
}
