using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Controles
{
    public partial class IngresoFormulaBode : UserControl
    {
        public Nullable<double> K
        {
            get
            {
                if (txtK.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtK.Text);
            }
        }

        public Nullable<double> N1
        {
            get
            {
                if (txtN1.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtN1.Text);
            }
        }

        public Nullable<double> T1
        {
            get
            {
                if (txtT1.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtT1.Text);
            }
        }

        public Nullable<double> T2
        {
            get
            {
                if (txtT2.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtT2.Text);
            }
        }

        public Nullable<double> Td
        {
            get
            {
                if (txtTd.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtTd.Text);
            }
        }

        public Nullable<double> N2
        {
            get
            {
                if (txtN2.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtN2.Text);
            }
        }

        public Nullable<double> T3
        {
            get
            {
                if (txtT3.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtT3.Text);
            }
        }

        public Nullable<double> T4
        {
            get
            {
                if (txtT4.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtT4.Text);
            }
        }

        public Nullable<double> Wn
        {
            get
            {
                if (txtWn.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtWn.Text);
            }
        }

        public Nullable<double> Psi
        {
            get
            {
                if (txtPsi.Text.Equals(""))
                    return null;
                else
                    return double.Parse(txtPsi.Text);
            }
        }

        public IngresoFormulaBode()
        {
            InitializeComponent();
        }

        public string validarFormula()
        {
            string notificacion = "";

            if (string.IsNullOrEmpty(txtK.Text) && string.IsNullOrEmpty(txtN1.Text) && string.IsNullOrEmpty(txtN2.Text) &&
                string.IsNullOrEmpty(txtPsi.Text) && string.IsNullOrEmpty(txtT1.Text) && string.IsNullOrEmpty(txtT2.Text) &&
                string.IsNullOrEmpty(txtT3.Text) && string.IsNullOrEmpty(txtT4.Text) && string.IsNullOrEmpty(txtTd.Text) &&
                string.IsNullOrEmpty(txtWn.Text))
            {
                notificacion += "Fórmula vacía.";
            }

            if ((!string.IsNullOrEmpty(txtWn.Text) && string.IsNullOrEmpty(txtPsi.Text)) ||
                (string.IsNullOrEmpty(txtWn.Text) && !string.IsNullOrEmpty(txtPsi.Text)))
            {
                notificacion += " Ambos coeficientes del polo cuadrático deben tener valor.";
            }

            if ((!string.IsNullOrEmpty(txtN1.Text) && double.Parse(txtN1.Text) > 3) ||
                (!string.IsNullOrEmpty(txtN2.Text) && double.Parse(txtN2.Text) > 3))
            {
                notificacion += " Los ceros y polos en el origen deben ser menores o iguales a 3.";
            }

            if ((!string.IsNullOrEmpty(txtN1.Text) && !txtN1.Valido) ||
                (!string.IsNullOrEmpty(txtN2.Text) && !txtN2.Valido))
            {
                notificacion += " Los ceros y polos en el origen deben ser enteros.";
            }

            return notificacion;
        }

        public void llenarCampos(Nullable<double> K, Nullable<double> N1, Nullable<double> T1, Nullable<double> T2, 
            Nullable<double> Td, Nullable<double> N2, Nullable<double> T3, Nullable<double> T4, Nullable<double> Wn, Nullable<double> Psi)
        {
            if (K != null)
                txtK.Text = K.ToString();
            else
                txtK.Text = "";

            if (N1 != null)
                txtN1.Text = N1.ToString();
            else
                txtN1.Text = "";

            if (T1 != null)
                txtT1.Text = T1.ToString();
            else
                txtT1.Text = "";

            if (T2 != null)
                txtT2.Text = T2.ToString();
            else
                txtT2.Text = "";

            if (Td != null)
                txtTd.Text = Td.ToString();
            else
                txtTd.Text = "";

            if (N2 != null)
                txtN2.Text = N2.ToString();
            else
                txtN2.Text = "";

            if (T3 != null)
                txtT3.Text = T3.ToString();
            else
                txtT3.Text = "";

            if (T4 != null)
                txtT4.Text = T4.ToString();
            else
                txtT4.Text = "";

            if (Wn != null)
                txtWn.Text = Wn.ToString();
            else
                txtWn.Text = "";

            if (Psi != null)
                txtPsi.Text = Psi.ToString();
            else
                txtPsi.Text = "";
        }
    }
}
