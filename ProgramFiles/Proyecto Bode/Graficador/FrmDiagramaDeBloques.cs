using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiagramasBode
{
    public partial class FrmDiagramaDeBloques : Form
    {
        double i, d, g;
        string resp;
        public bool ingresoCorrecto = false;
        bool _coefAmor;
        bool _frecNat;

        public bool coefAmor
        {
            get
            {
                return _coefAmor;
            }
            set
            {
                _coefAmor = value;
            }
        }

        public bool frecNat
        {
            get
            {
                return _frecNat;
            }
            set
            {
                _frecNat = value;
            }
        }

        // Constante real.
        Nullable<double> _K;
        public Nullable<double> K
        {
            get
            {
                return _K;
            }
            set
            {
                _K = value;
            }
        }

        // Orden del Cero en el Origen.
        Nullable<double> _N1;
        public Nullable<double> N1
        {
            get
            {
                return _N1;
            }
            set
            {
                _N1 = value;
            }
        }

        // Constante de tiempo del primer Cero Simple.
        Nullable<double> _T1;
        public Nullable<double> T1
        {
            get
            {
                return _T1;
            }
            set
            {
                _T1 = value;
            }
        }

        // Constante de tiempo del segundo Cero Simple.
        Nullable<double> _T2;
        public Nullable<double> T2
        {
            get
            {
                return _T2;
            }
            set
            {
                _T2 = value;
            }
        }

        // Retardo de Tiempo.
        Nullable<double> _Td;
        public Nullable<double> Td
        {
            get
            {
                return _Td;
            }
            set
            {
                _Td = value;
            }
        }

        // Orden del Polo en el Origen.
        Nullable<double> _N2;
        public Nullable<double> N2
        {
            get
            {
                return _N2;
            }
            set
            {
                _N2 = value;
            }
        }

        // Constante de tiempo del primer Polo Simple.
        Nullable<double> _T3;
        public Nullable<double> T3
        {
            get
            {
                return _T3;
            }
            set
            {
                _T3 = value;
            }
        }

        // Constante de tiempo del segundo Polo Simple.
        Nullable<double> _T4;
        public Nullable<double> T4
        {
            get
            {
                return _T4;
            }
            set
            {
                _T4 = value;
            }
        }

        // Frecuencia natural amortiguada.
        Nullable<double> _Wn;
        public Nullable<double> Wn
        {
            get
            {
                return _Wn;
            }
            set
            {
                _Wn = value;
            }
        }

        // Coeficiente de amortiguamiento.
        Nullable<double> _Psi;
        public Nullable<double> Psi
        {
            get
            {
                return _Psi;
            }
            set
            {
                _Psi = value;
            }
        }


        Nullable<double> _ControladorPIDSinK;
        public Nullable<double> ControladorPIDSinK
        {
            get
            {
                return _ControladorPIDSinK;
            }
            set
            {
                _ControladorPIDSinK = value;
            }
        }


        Nullable<double> _ControladorPISinK;
        public Nullable<double> ControladorPISinK
        {
            get
            {
                return _ControladorPISinK;
            }
            set
            {
                _ControladorPISinK = value;
            }
        }

        string _TipoControlador;
        public string TipoControlador
        {
            get
            {
                return _TipoControlador;
            }
            set
            {
                _TipoControlador = value;
            }
        }

        public FrmDiagramaDeBloques()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.manejadorDeVentanasAControladores();
        }

        private void manejadorDeVentanasAControladores()
        {
        }

        private void primerOrden_Click(object sender, EventArgs e)
        {
            this.Height = 373;

            if (segundoOrden.Checked)
            {
                segundoOrden.Checked = false;
            }

            gbxPlanta.Text = "1° Orden";
            gbxPlanta.Visible = true;
            primerOrden.Checked = true;
            lblConstTiempo.Enabled = true;
            txbConstTiempo.Enabled = true;
            lblFrecNaturalAmort.Enabled = false;
            txbFrecNaturalAmort.Enabled = false;
            lblCoefAmortiguamiento.Enabled = false;
            txbCoefAmortiguamiento.Enabled = false;
        }

        private void segundoOrden_Click(object sender, EventArgs e)
        {
            this.Height = 373;
        
            if (primerOrden.Checked)
            {
                primerOrden.Checked = false;
            }

            segundoOrden.Checked = true;
            gbxPlanta.Visible = true;
            gbxPlanta.Text = "2° Orden";
            lblConstTiempo.Enabled = false;
            txbConstTiempo.Enabled = false;
            lblFrecNaturalAmort.Enabled = true;
            txbFrecNaturalAmort.Enabled = true;
            lblCoefAmortiguamiento.Enabled = true;
            txbCoefAmortiguamiento.Enabled = true;
        }

        private void realimentaciónUnitaria_Click(object sender, EventArgs e)
        {
            realimentaciónUnitaria.Checked = true;
            retardoPuro.Checked = false;
            menuControlador.Enabled = true;
            gbxSensor.Visible = true;
            gbxSensor.Text = "Realimentación Unitaria";

            lblRetardo.Enabled = false;
            txbRetardo.Enabled = false;
        }

        private void retardoPuroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realimentaciónUnitaria.Checked = false;
            retardoPuro.Checked = true;
            gbxSensor.Visible = true;
            gbxSensor.Text = "Retardo Puro";

            lblRetardo.Enabled = true;
            txbRetardo.Enabled = true;
        }

        private void proporcional_Click(object sender, EventArgs e)
        {
            proporcionalDerivativo.Checked = false;
            proporcionalIntegral.Checked = false;
            proporcionalIntegralDerivativo.Checked = false;
            proporcional.Checked = true;

            gbxControlador.Visible = true;
            gbxControlador.Text = "Proporcional";
            lblIntegral.Enabled = false;
            lblDerivativo.Enabled = false;
            txbIntegral.Enabled = false;
            txbDerivativo.Enabled = false;

        }

        private void proporcionalIntegral_Click(object sender, EventArgs e)
        {
            proporcionalDerivativo.Checked = false;
            proporcionalIntegral.Checked = true;
            proporcionalIntegralDerivativo.Checked = false;
            proporcional.Checked = false;

            gbxControlador.Visible = true;
            gbxControlador.Text = "Proporcional Integral";
            lblIntegral.Enabled = true;
            lblDerivativo.Enabled = false;
            txbIntegral.Enabled = true;
            txbDerivativo.Enabled = false;
        }

        private void proporcionalDerivativo_Click(object sender, EventArgs e)
        {
            proporcionalDerivativo.Checked = true;
            proporcionalIntegral.Checked = false;
            proporcionalIntegralDerivativo.Checked = false;
            proporcional.Checked = false;

            gbxControlador.Visible = true;
            gbxControlador.Text = "Proporcional Derivativo";
            lblIntegral.Enabled = false;
            lblDerivativo.Enabled = true;
            txbIntegral.Enabled = false;
            txbDerivativo.Enabled = true;
        }

        private void proporcionalIntegralDerivativo_Click(object sender, EventArgs e)
        {
            proporcionalDerivativo.Checked = false;
            proporcionalIntegral.Checked = false;
            proporcionalIntegralDerivativo.Checked = true;
            proporcional.Checked = false;

            gbxControlador.Visible = true;
            gbxControlador.Text = "Proporcional Integral Derivativo";
            lblIntegral.Enabled = true;
            lblDerivativo.Enabled = true;
            txbIntegral.Enabled = true;
            txbDerivativo.Enabled = true;
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            reiniciarValores();

            bool validoOrden = false;
            bool validoSensor = false;
            bool validoControlador = false;

            resp ="";

            validoOrden = validarOrden();
            validoSensor = validarSensor();
            validoControlador = validarControlador();

            if (validoOrden && validoSensor && validoControlador)
            {
                this.Hide();
                ingresoCorrecto = true;
            }
            else
            {
                errores();
                MessageBox.Show(resp, "Error de ingreso de datos",MessageBoxButtons.OK, MessageBoxIcon.Error);
                ingresoCorrecto = false;
            }
        }

        private void reiniciarValores()
        {
            K = null;
            N1 = null;
            T1 = null;
            T2 = null;
            Td = null;
            N2 = null;
            T3 = null;
            T4 = null;
            Wn = null;
            Psi = null;
            ControladorPIDSinK = null;
            ControladorPISinK = null;
            TipoControlador = "";
        }
        
        public bool validarOrden()
        {
            bool validoT3 = false;
            bool validoWn = false;
            bool validoPsi = false;
            bool valido = false;

            if (primerOrden.Checked)
            {
                try
                {
                    T3 = double.Parse(txbConstTiempo.Text.Replace(".", ","));
                }
                catch
                {
                    validoT3 = false;
                }

                if (T3 != null && T3 != 0)
                {
                    validoT3 = true;
                }
                else
                {
                    validoT3 = false;
                    resp += "- Ingreso de la constante de tiempo incorrecto.\n";
                }
            }
            else if (segundoOrden.Checked)
            {
                try
                {
                    Wn = double.Parse(txbFrecNaturalAmort.Text.Replace(".", ","));
                }
                catch
                {
                    validoWn = false;
                }

                try
                {
                Psi = double.Parse(txbCoefAmortiguamiento.Text.Replace(".", ","));
                }
                catch
                {
                    validoPsi = false;
                }

                if (Wn != null && Wn != 0)
                {
                    validoWn = true;
                }
                else
                {
                    validoWn = false;
                    resp += "- Ingreso de la frecuencia natural amortiguada incorrecto.\n";
                }

                if (Psi != null && Psi != 0)
                {
                    validoPsi = true;
                }
                else
                {
                    validoPsi = false;
                    resp += "- Ingreso del coeficiente de amortiguamiento incorrecto.\n";
                }
            }

            if (primerOrden.Checked)
            {
                if (validoT3)
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            }
            else if (segundoOrden.Checked)
            {
                if (validoPsi && validoWn)
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            }

            return valido;
        }

        public bool validarSensor()
        {
            bool valido = false;

            if (realimentaciónUnitaria.Checked)
            {
                valido = true;
            }
            else if (retardoPuro.Checked)
            {
                try
                {
                Td = double.Parse(txbRetardo.Text.Replace(".", ","));
                }
                catch
                {
                    valido = false;
                }

                if (Td != null && Td != 0)
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                    resp += "- Ingreso del tiempo de retardo incorrecto.\n";
                }
            }

            if (retardoPuro.Checked == false && realimentaciónUnitaria.Checked == false)
            {
                valido = false;
            }

            return valido;
        }

        public bool validarControlador()
        {
            bool valido = false;

            if (proporcional.Checked)
            {
                valido = validarP();
            }

            if (proporcionalIntegral.Checked)
            {
                valido = validarPI();
            }

            if (proporcionalDerivativo.Checked)
            {
                valido = validarPD();
            }

            if (proporcionalIntegralDerivativo.Checked)
            {
                valido = validarPID();
            }

            if (proporcional.Checked == false && proporcionalDerivativo.Checked == false && proporcionalIntegral.Checked == false && proporcionalIntegralDerivativo.Checked == false)
            {
                valido = false;
            }

            return valido;
        }

        private bool validarPID()
        {
            bool validoI = false;
            bool validoD = false;
            bool validoT1 = false;
            bool validoT2 = false;
            bool validoG = false;
            bool validoK = false;
            bool validoCond = false;
            double a, b;

            try
            {
                i = double.Parse(txbIntegral.Text.Replace(".", ","));
            }
            catch
            {
                validoI = false;
            }

            try
            {
                d = double.Parse(txbDerivativo.Text.Replace(".", ","));
            }
            catch
            {
                validoD = false;
            }

            a = (i - Math.Sqrt((i * i) - (4 * i * d))) / (2 * i * d);
            b = (i + Math.Sqrt((i * i) - (4 * i * d))) / (2 * i * d);

            try
            {
                T1 = Math.Round((1 / a), 2);
            }
            catch
            {
                validoT1 = false;
            }

            try
            {
                T2 = Math.Round((1 / b), 2);
            }
            catch
            {
                validoT2 = false;
            }

            N2 = 1;

            try
            {
                g = double.Parse(txbGanancia.Text.Replace(".", ","));
            }
            catch
            {
                validoG = false;
            }

            try
            {
                ControladorPIDSinK = (a * b) / i;
                K = Math.Round(g, 3);
                TipoControlador = "PID";
            }
            catch
            {
                validoK = false;
            }

            if (T1 != null && T1 != 0)
            {
                validoT1 = true;
            }
            else
            {
                validoT1 = false;
            }

            if (T2 != null && T2 != 0)
            {
                validoT2 = true;
            }
            else
            {
                validoT2 = false;
            }

            if (K != null && K != 0)
            {
                validoK = true;
            }
            else
            {
                validoK = false;
            }

            if (i != null && i != 0)
            {
                validoI = true;
            }
            else
            {
                validoI = false;
                resp += "- Ingreso de la constante de tiempo integral incorrecto.\n";
            }

            if (d != null && d != 0)
            {
                validoD = true;
            }
            else
            {
                validoD = false;
                resp += "- Ingreso de constante de tiempo derivativo incorrecto.\n";
            }

            if (g != null && g != 0)
            {
                validoG = true;
            }
            else
            {
                validoG = false;
                resp += "- Ingreso de la ganancia incorrecto.\n";
            }

            if ((i * i) >= (4 * d * i))
            {
                validoCond = true;
            }
            else
            {
                validoCond = false;
                resp += "- Ingreso de valores de tiempo integral/derivativo incorrectos.\nDebe cumplirse: (Tiempo Integral^2) >= (4 * Tiempo Integral * Tiempo Derivativo)\n";
            }

            if (validoCond && validoD && validoG && validoI && validoK && validoT1 && validoT2)
            {
                return true;
            }
            {
                return false;
            }
        }

        private bool validarPD()
        {
            bool validoK = false;
            bool validoT1 = false;

            try
            {
                K = double.Parse(txbGanancia.Text.Replace(".", ","));
                TipoControlador = "PD";
            }
            catch
            {
                validoK = false;
            }

            try
            {
                T1 = double.Parse(txbDerivativo.Text.Replace(".", ","));
            }
            catch
            {
                validoT1 = false;
            }

            if (T1 != null && T1 != 0)
            {
                validoT1 = true;
            }
            else
            {
                validoT1 = false;
                resp += "- Ingreso de la constante de tiempo integral incorrecto.\n";
            }

            if (K != null && K != 0)
            {
                validoK = true;
            }
            else
            {
                validoK = false;
                resp += "- Ingreso de la ganancia incorrecto.\n";
            }

            if (validoK && validoT1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validarPI()
        {
            bool validoT1 = false;
            bool validoG = false;
            bool validoK = false;

            try
            {
                T1 = double.Parse(txbIntegral.Text.Replace(".", ","));
            }
            catch
            {
                validoT1 = false;
            }

            try
            {
                g = double.Parse(txbGanancia.Text.Replace(".", ","));
            }
            catch
            {
                validoG = false;
            }

            N2 = 1;

            try
            {
                ControladorPISinK = Math.Round((1 / double.Parse(txbIntegral.Text.Replace(".", ","))), 3);
                K = Math.Round(g, 3);
                TipoControlador = "PI";
            }
            catch
            {
                validoK = false;
            }

            if (K != null && K != 0)
            {
                validoK = true;
            }
            else
            {
                validoK = false;
            }

            if (T1 != null && T1 != 0)
            {
                validoT1 = true;
            }
            else
            {
                validoT1 = false;
                resp += "- Ingreso de la constante de tiempo derivativo incorrecto.\n";
            }

            if (g != 0)
            {
                validoG = true;
            }
            else
            {
                validoG = false;
                resp += "- Ingreso de la ganancia incorrecto.\n";
            }

            if (validoG && validoK && validoT1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validarP()
        {
            bool valido = false;

            try
            {
                K = double.Parse(txbGanancia.Text.Replace(".", ","));
                TipoControlador = "P";
            }
            catch
            {
                valido = false;
            }

            if (K != null && K != 0)
            {
                valido = true;
            }
            else
            {
                valido = false;
                resp += "- Ingreso de la ganancia incorrecto.\n";
            }

            return valido;
        }

        public void errores()
        {
            if (primerOrden.Checked == false && segundoOrden.Checked == false)
            {
                resp += "- Debe seleccionar el tipo de planta.\n";
            }

            if (retardoPuro.Checked == false && realimentaciónUnitaria.Checked == false)
            {
                resp += "- Debe seleccionar el tipo de sensor.\n";
            }

            if (proporcional.Checked == false && proporcionalDerivativo.Checked == false && proporcionalIntegral.Checked == false && proporcionalIntegralDerivativo.Checked == false)
            {
                resp += "- Debe seleccionar el tipo de controlador.\n";
            }
        }

        private void validarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 44)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }
                if (textBox.Text.IndexOf(',') > -1 && textBox.Text.Substring(textBox.Text.IndexOf(',')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void txbConstTiempo_TextChanged(object sender, EventArgs e)
        {
            menuSensor.Enabled = true;
        }

        public void txbFrecNaturalAmort_TextChanged(object sender, EventArgs e)
        {
            frecNat = true;
            comprobarIngreso();
        }

        public void txbCoefAmortiguamiento_TextChanged(object sender, EventArgs e)
        {
            coefAmor = true;
            comprobarIngreso();
        }

        public void comprobarIngreso()
        {
            if (frecNat && coefAmor)
            {
                menuSensor.Enabled = true;
            }
        }

        private void txbRetardo_TextChanged(object sender, EventArgs e)
        {
            menuControlador.Enabled = true;
        }
    }
}
