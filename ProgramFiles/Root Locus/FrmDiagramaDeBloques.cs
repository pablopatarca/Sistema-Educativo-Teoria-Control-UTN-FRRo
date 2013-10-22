using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ZedGraph;


namespace Root_Locus
{
    public partial class FrmDiagramaDeBloques : Form
    {
        RootLocus rl;
        PointPairList polos;
        PointPairList ceros;

        bool _ingresoPolo1, _ingresoPolo2;

        public bool ingresoPolo1
        {
            get
            {
                return _ingresoPolo1;
            }
            set
            {
                _ingresoPolo1 = value;
            }
        }

        public bool ingresoPolo2
        {
            get
            {
                return _ingresoPolo2;
            }
            set
            {
                _ingresoPolo2 = value;
            }
        }

        public FrmDiagramaDeBloques()
        {
            InitializeComponent();
        }

        public FrmDiagramaDeBloques(PointPairList polos, PointPairList ceros, RootLocus rl):this()
        {
            this.rl = rl;
            this.polos = polos;
            this.ceros = ceros;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.manejadorDeVentanasAControladores();
        }

        private void manejadorDeVentanasAControladores()
        {
        }

        public FormClosingEventHandler form_FormClosing
        {
            get;
            set;
        }

        private void FormDiagramaDeBloques_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void primerOrden_Click(object sender, EventArgs e)
        {
            this.Height = 326;

            if (segundoOrden.Checked)
            {
                segundoOrden.Checked = false;
            }

            primerOrden.Checked = true;
            gbxPlanta.Text = "1° Orden";
            gbxPlanta.Visible = true;
            lblPolo1.Enabled = true;
            lblPolo2.Enabled = false;
            txbPolo1.Enabled = true;
            txbPolo2.Enabled = false;
        }

        private void segundoOrden_Click(object sender, EventArgs e)
        {
            this.Height = 326;

            if (primerOrden.Checked)
            {
                primerOrden.Checked = false;
            }

            segundoOrden.Checked = true;
            gbxPlanta.Visible = true;
            gbxPlanta.Text = "2° Orden";
            lblPolo1.Enabled = true;
            lblPolo2.Enabled = true;
            txbPolo1.Enabled = true;
            txbPolo2.Enabled = true;
        }

        private void realimentaciónUnitaria_Click(object sender, EventArgs e)
        {
            realimentaciónUnitaria.Checked = true;
            menuControlador.Enabled = true;
        }

        private void proporcional_Click(object sender, EventArgs e)
        {
            if (proporcionalDerivativo.Checked)
            {
                proporcionalDerivativo.Checked = false;
            }
            else if (proporcionalIntegral.Checked)
            {
                proporcionalIntegral.Checked = false;
            }
            else if (proporcionalIntegralDerivativo.Checked)
            {
                proporcionalIntegralDerivativo.Checked = false;
            }
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
            if (proporcionalDerivativo.Checked)
            {
                proporcionalDerivativo.Checked = false;
            }
            else if (proporcional.Checked)
            {
                proporcional.Checked = false;
            }
            else if (proporcionalIntegralDerivativo.Checked)
            {
                proporcionalIntegralDerivativo.Checked = false;
            }
            proporcionalIntegral.Checked = true;

            gbxControlador.Visible = true;
            gbxControlador.Text = "Proporcional Integral";
            lblIntegral.Enabled = true;
            lblDerivativo.Enabled = false;
            txbIntegral.Enabled = true;
            txbDerivativo.Enabled = false;
        }

        private void proporcionalDerivativo_Click(object sender, EventArgs e)
        {
            if (proporcional.Checked)
            {
                proporcional.Checked = false;
            }
            else if (proporcionalIntegral.Checked)
            {
                proporcionalIntegral.Checked = false;
            }
            else if (proporcionalIntegralDerivativo.Checked)
            {
                proporcionalIntegralDerivativo.Checked = false;
            }
            proporcionalDerivativo.Checked = true;

            gbxControlador.Visible = true;
            gbxControlador.Text = "Proporcional Derivativo";
            lblIntegral.Enabled = false;
            lblDerivativo.Enabled = true;
            txbIntegral.Enabled = false;
            txbDerivativo.Enabled = true;
        }

        private void proporcionalIntegralDerivativo_Click(object sender, EventArgs e)
        {
            if (proporcionalDerivativo.Checked)
            {
                proporcionalDerivativo.Checked = false;
            }
            else if (proporcionalIntegral.Checked)
            {
                proporcionalIntegral.Checked = false;
            }
            else if (proporcional.Checked)
            {
                proporcional.Checked = false;
            }
            proporcionalIntegralDerivativo.Checked = true;

            gbxControlador.Visible = true;
            gbxControlador.Text = "Proporcional Integral Derivativo";
            lblIntegral.Enabled = true;
            lblDerivativo.Enabled = true;
            txbIntegral.Enabled = true;
            txbDerivativo.Enabled = true;
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

            if (realimentaciónUnitaria.Checked == false)
            {
                MessageBox.Show("Falta seleccionar el Sensor", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (proporcional.Checked == false && proporcionalDerivativo.Checked==false && proporcionalIntegral.Checked==false && proporcionalIntegralDerivativo.Checked==false)
            {
                MessageBox.Show("Falta seleccionar el Controlador", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            //primer orden proporcional
            if (primerOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcional.Checked == true)
            {
                
               string error="";
               error=ValproporcionalPrimerOrden();
                
                if (error == "")
                {
                    FrmDatosPrimerOrdenProporcional frmPrimerOrdenProporcional = new FrmDatosPrimerOrdenProporcional(polos, ceros, rl, this.txbPolo1.Text.Replace(".", ","));
                    frmPrimerOrdenProporcional.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            //segundo orden porporcional
            if (segundoOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcional.Checked == true)
            {

                string error = "";
                error = ValproporcionalSegundoOrden();

                if (error == "")
                {
                    FrmDatosSegundoOrdenProporcional frmSegundoOrdenProporcional = new FrmDatosSegundoOrdenProporcional(polos, ceros, rl, this.txbPolo1.Text.Replace(".", ","), this.txbPolo2.Text.Replace(".", ","));
                    frmSegundoOrdenProporcional.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Primer orden integral
            if (primerOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcionalIntegral.Checked == true)
            {

                string error = "";
                error = ValproporcionalIntegralPrimerOrden();

                if (error == "")
                {
                    FrmDatosPrimerOrdenProporcionalIntegral frmPrimerOrdenProporcionalIntegral = new FrmDatosPrimerOrdenProporcionalIntegral(polos, ceros, rl, "0", this.txbPolo1.Text.Replace(".", ","), calcularCeroIntegral(this.txbIntegral.Text.Replace(".", ",")));
                    frmPrimerOrdenProporcionalIntegral.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Segundo orden integral
            if (segundoOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcionalIntegral.Checked == true)
            {

                string error = "";
                error = ValproporcionalIntegralSegundoOrden();

                if (error == "")
                {
                    FrmDatosSegundoOrdenProporcionalIntegral frmSegundoOrdenProporcionalIntegral = new FrmDatosSegundoOrdenProporcionalIntegral(polos, ceros, rl, "0", this.txbPolo1.Text.Replace(".", ","), this.txbPolo2.Text.Replace(".", ","), calcularCeroIntegral(this.txbIntegral.Text.Replace(".", ",")));
                    frmSegundoOrdenProporcionalIntegral.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Primer orden derivativo
            if (primerOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcionalDerivativo.Checked == true)
            {

                string error = "";
                error = ValproporcionalDerivativoPrimerOrden();

                if (error == "")
                {
                    FrmDatosPrimerOrdenProporcionalDerivativo frmPrimerOrdenProporcionalDerivativo = new FrmDatosPrimerOrdenProporcionalDerivativo(polos, ceros, rl, this.txbPolo1.Text.Replace(".", ","), calcularCeroDerivativo(this.txbDerivativo.Text.Replace(".", ",")));
                    frmPrimerOrdenProporcionalDerivativo.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Segundo orden derivativo
            if (segundoOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcionalDerivativo.Checked == true)
            {

                string error = "";
                error = ValproporcionalDerivativoSegundoOrden();

                if (error == "")
                {
                    FrmDatosSegundoOrdenProporcionalDerivativo frmSegundoOrdenProporcionalDerivativo = new FrmDatosSegundoOrdenProporcionalDerivativo(polos, ceros, rl, this.txbPolo1.Text.Replace(".", ","), this.txbPolo2.Text.Replace(".", ","), calcularCeroDerivativo(this.txbDerivativo.Text.Replace(".", ",")));
                    frmSegundoOrdenProporcionalDerivativo.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Primer orden PID
            if (primerOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcionalIntegralDerivativo.Checked == true)
            {

                string error = "";
                error = ValPIDPrimerOrden();

                if (error == "")
                {
                    string realOComplejo = determinarRealOComplejo(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                    string calculoPrimerConstante,calculoSegundaConstate;
                    if (realOComplejo == "real")
                    {
                        calculoPrimerConstante = calculoPrimerConstanteReal(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        calculoSegundaConstate = calculoSegundaConstanteReal(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        FrmDatosPrimerOrdenProporcionalIntegralDerivativo frmPrimerOrdenProporcionalIntegralDerivativo = new FrmDatosPrimerOrdenProporcionalIntegralDerivativo(polos, ceros, rl, "0", this.txbPolo1.Text.Replace(".", ","), calculoPrimerConstante, calculoSegundaConstate, realOComplejo);
                        frmPrimerOrdenProporcionalIntegralDerivativo.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        string calculoPrimeraParteConstante;
                        string calculoSegundaParteConstante;

                        calculoPrimeraParteConstante = calculoPrimerConstanteCompleja(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        calculoSegundaParteConstante = calculoSegundaConstanteCompleja(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        FrmDatosPrimerOrdenProporcionalIntegralDerivativo frmPrimerOrdenProporcionalIntegralDerivativo = new FrmDatosPrimerOrdenProporcionalIntegralDerivativo(polos, ceros, rl, "0", this.txbPolo1.Text.Replace(".", ","), calculoPrimeraParteConstante, calculoSegundaParteConstante, realOComplejo);
                        frmPrimerOrdenProporcionalIntegralDerivativo.ShowDialog();
                        this.Hide();
                    }


                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Segundo orden PID
            if (segundoOrden.Checked == true && realimentaciónUnitaria.Checked == true && proporcionalIntegralDerivativo.Checked == true)
            {

                string error = "";
                error = ValPIDSegundoOrden();

                if (error == "")
                {
                    string realOComplejo = determinarRealOComplejo(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                    string calculoPrimerConstante, calculoSegundaConstate;
                    if (realOComplejo == "real")
                    {
                        calculoPrimerConstante = calculoPrimerConstanteReal(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        calculoSegundaConstate = calculoSegundaConstanteReal(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        FrmDatosSegundoOrdenProporcionalIntegralDerivativo frmSegundoOrdenProporcionalIntegralDerivativo = new FrmDatosSegundoOrdenProporcionalIntegralDerivativo(polos, ceros, rl, "0", this.txbPolo1.Text.Replace(".", ","), this.txbPolo2.Text.Replace(".", ","), calculoPrimerConstante, calculoSegundaConstate, realOComplejo);
                        frmSegundoOrdenProporcionalIntegralDerivativo.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        string calculoPrimeraParteConstante;
                        string calculoSegundaParteConstante;

                        calculoPrimeraParteConstante = calculoPrimerConstanteCompleja(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        calculoSegundaParteConstante = calculoSegundaConstanteCompleja(this.txbDerivativo.Text.Replace(".", ","), this.txbIntegral.Text.Replace(".", ","));
                        FrmDatosSegundoOrdenProporcionalIntegralDerivativo frmSegundoOrdenProporcionalIntegralDerivativo = new FrmDatosSegundoOrdenProporcionalIntegralDerivativo(polos, ceros, rl, "0", this.txbPolo1.Text.Replace(".", ","), this.txbPolo2.Text.Replace(".", ","), calculoPrimeraParteConstante, calculoSegundaParteConstante, realOComplejo);
                        frmSegundoOrdenProporcionalIntegralDerivativo.ShowDialog();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(error, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string calcularCeroIntegral(string p)
        {
            return Math.Round(-1 / double.Parse(this.txbIntegral.Text.Replace(".", ",")), 2).ToString();
        }

        private string calcularCeroDerivativo(string p)
        {
            return Math.Round(-1 / double.Parse(this.txbDerivativo.Text.Replace(".", ",")), 2).ToString();
        }

        private string determinarRealOComplejo(string thaud,string thaui)
        {
            if ((Math.Round(double.Parse(thaui),2)*Math.Round(double.Parse(thaui),2)) >= (4 * Math.Round(double.Parse(thaud),2)*Math.Round(double.Parse(thaui),2)))
                return "real";
            else
                return "complejo";
        }

        private string calculoPrimerConstanteReal(string thaud,string thaui)
        { 
            double douThaui = Math.Round(double.Parse(thaui),2);
            double douThaud = Math.Round(double.Parse(thaud),2);
            double raiz = Math.Sqrt(Math.Pow((douThaui), 2) - 4 * douThaui * douThaud);

            return ((-1*douThaui+raiz)/(2*douThaui*douThaud)).ToString();
        }

        private string calculoSegundaConstanteReal(string thaud, string thaui)
        {
            double douThaui = Math.Round(double.Parse(thaui), 2);
            double douThaud = Math.Round(double.Parse(thaud), 2);
            double raiz = Math.Sqrt(Math.Pow((douThaui), 2) - 4 * douThaui * douThaud);

            return ((-1 * douThaui-raiz) / (2 * douThaui * douThaud)).ToString();
        }

        private string calculoPrimerConstanteCompleja(string thaud, string thaui)
        {
            double douThaui = Math.Round(double.Parse(thaui), 2);
            double douThaud = Math.Round(double.Parse(thaud), 2);

            return (-1 * douThaui / (2 * douThaui * douThaud)).ToString();
        }

        private string calculoSegundaConstanteCompleja(string thaud, string thaui)
        {
            double douThaui = Math.Round(double.Parse(thaui), 2);
            double douThaud = Math.Round(double.Parse(thaud), 2);
            double numerador = Math.Sqrt((4 * douThaui * douThaud)-(douThaui*douThaui));
            return (numerador / (2 * douThaui * douThaud)).ToString();
        }

        public string ValproporcionalPrimerOrden()
        {
            string errores = "";
            string a="";

            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío\n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo\n";
            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }

            return errores;

        }
        public string ValproporcionalSegundoOrden()
        {
            string errores = "";
            string a = "";
            string b = "";

            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío \n";
            if (txbPolo2.Text.Replace(".", ",") == "") errores += "- Campo Polo 2 Vacío \n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 1 \n";
            if (txbPolo2.Text.Replace(".", ",") == "0" || txbPolo2.Text.Replace(".", ",") == "0,0" || txbPolo2.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 2 \n";

            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }
            b = validarNumeroBienEscrito(txbPolo2.Text.Replace(".", ","));
            if (b != "")
            {
                errores += "- Polo 2 no es numérico \n";
            }

            return errores;

        }

        public string ValproporcionalIntegralPrimerOrden()
        {
            string errores = "";
            string a = "";
            string b = "";

            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío \n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 1 \n";
            if (txbIntegral.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Integral Vacío \n";
            if (txbIntegral.Text.Replace(".", ",") == "0" || txbIntegral.Text.Replace(".", ",") == "0,0" || txbIntegral.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Integral \n";

            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }
            b = validarNumeroBienEscrito(txbIntegral.Text.Replace(".", ","));
            if (b != "")
            {
                errores += "- Tiempo Integral no es numérico \n";
            }
           
            return errores;

        }

        public string ValproporcionalIntegralSegundoOrden()
        {
            string errores = "";
            string a = "";
            string b = "";
            string c = "";

            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío \n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 1 \n";
            if (txbPolo2.Text.Replace(".", ",") == "") errores += "- Campo Polo 2 Vacío \n";
            if (txbPolo2.Text.Replace(".", ",") == "0" || txbPolo2.Text.Replace(".", ",") == "0,0" || txbPolo2.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 2 \n";
            if (txbIntegral.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Integral Vacío \n";
            if (txbIntegral.Text.Replace(".", ",") == "0" || txbIntegral.Text.Replace(".", ",") == "0,0" || txbIntegral.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Integral \n";

            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }
            b = validarNumeroBienEscrito(txbPolo2.Text.Replace(".", ","));
            if (b != "")
            {
                errores += "- Polo 2 no es numérico \n";
            }
            c = validarNumeroBienEscrito(txbIntegral.Text.Replace(".", ","));
            if (c != "")
            {
                errores += "- Tiempo Integral no es numérico \n";
            }

            return errores;

        }

        public string ValproporcionalDerivativoPrimerOrden()
        {
            string errores = "";
            string a = "";
            string b = "";

            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío \n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 1 \n";
            if (txbDerivativo.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Derivativo Vacío \n";
            if (txbDerivativo.Text.Replace(".", ",") == "0" || txbDerivativo.Text.Replace(".", ",") == "0,0" || txbDerivativo.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Derivativo \n";

            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }

            b = validarNumeroBienEscrito(txbDerivativo.Text.Replace(".", ","));
            if (b != "")
            {
                errores += "- Tiempo Dervativo no es numérico \n";
            }

            return errores;

        }

        public string ValproporcionalDerivativoSegundoOrden()
        {
            string errores = "";
            string a = "";
            string b = "";
            string c = "";


            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío \n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 1 \n";
            if (txbPolo2.Text.Replace(".", ",") == "") errores += "- Campo Polo 2 Vacío \n";
            if (txbPolo2.Text.Replace(".", ",") == "0" || txbPolo2.Text.Replace(".", ",") == "0,0" || txbPolo2.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 2 \n";
            if (txbDerivativo.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Derivativo Vacío \n";
            if (txbDerivativo.Text.Replace(".", ",") == "0" || txbDerivativo.Text.Replace(".", ",") == "0,0" || txbDerivativo.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Derivativo \n";

            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }
            b = validarNumeroBienEscrito(txbPolo2.Text.Replace(".", ","));
            if (b != "")
            {
                errores += "- Polo 2 no es numérico \n";
            }
            c = validarNumeroBienEscrito(txbDerivativo.Text.Replace(".", ","));
            if (c != "")
            {
                errores += "- Tiempo Derivativo no es numérico \n";
            }

            return errores;

        }

        public string ValPIDPrimerOrden()
        {
            string errores = "";
            string a = "";
            string b = "";
            string c = "";

            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío \n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 1 \n";
            if (txbIntegral.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Integral Vacío \n";
            if (txbIntegral.Text.Replace(".", ",") == "0" || txbIntegral.Text.Replace(".", ",") == "0,0" || txbIntegral.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Integral \n";
            if (txbDerivativo.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Derivativo Vacío \n";
            if (txbDerivativo.Text.Replace(".", ",") == "0" || txbDerivativo.Text.Replace(".", ",") == "0,0" || txbDerivativo.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Derivativo \n";

            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }
            b = validarNumeroBienEscrito(txbDerivativo.Text.Replace(".", ","));
            if (b != "")
            {
                errores += "- Tiempo Derivativo no es numérico \n";
            }
            c = validarNumeroBienEscrito(txbIntegral.Text.Replace(".", ","));
            if (c != "")
            {
                errores += "- Tiempo Integral no es numérico \n";
            }
            return errores;

        }

        public string ValPIDSegundoOrden()
        {
            string errores = "";
            string a = "";
            string b = "";
            string c = "";
            string d = "";

            if (txbPolo1.Text.Replace(".", ",") == "") errores += "- Campo Polo 1 Vacío \n";
            if (txbPolo1.Text.Replace(".", ",") == "0" || txbPolo1.Text.Replace(".", ",") == "0,0" || txbPolo1.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 1 \n";
            if (txbPolo2.Text.Replace(".", ",") == "") errores += "- Campo Polo 2 Vacío \n";
            if (txbPolo2.Text.Replace(".", ",") == "0" || txbPolo2.Text.Replace(".", ",") == "0,0" || txbPolo2.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el polo 2 \n";
            if (txbIntegral.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Integral Vacío \n";
            if (txbIntegral.Text.Replace(".", ",") == "0" || txbIntegral.Text.Replace(".", ",") == "0,0" || txbIntegral.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Integral \n";
            if (txbDerivativo.Text.Replace(".", ",") == "") errores += "- Campo Tiempo Derivativo Vacío \n";
            if (txbDerivativo.Text.Replace(".", ",") == "0" || txbDerivativo.Text.Replace(".", ",") == "0,0" || txbDerivativo.Text.Replace(".", ",") == "0,00") errores += "- No se puede ingresar 0 en el Tiempo Derivativo \n";

            a = validarNumeroBienEscrito(txbPolo1.Text.Replace(".", ","));
            if (a != "")
            {
                errores += "- Polo 1 no es numérico \n";
            }
            b = validarNumeroBienEscrito(txbPolo2.Text.Replace(".", ","));
            if (b != "")
            {
                errores += "- Polo 2 no es numérico \n";
            }
            c = validarNumeroBienEscrito(txbDerivativo.Text.Replace(".", ","));
            if (c != "")
            {
                errores += "- Tiempo Derivativo no es numérico \n";
            }
            d = validarNumeroBienEscrito(txbIntegral.Text.Replace(".", ","));
            if (d != "")
            {
                errores += "- Tiempo Integral no es numérico \n";
            }

            return errores;

        }

        public string validarNumeroBienEscrito(string numero)
        {
            string errores = "";

            Regex rx = new Regex("^-{0,1}[0-9]+[,]{0,1}[0-9]*$");

            if (rx.IsMatch(numero))
            {
                errores = "";
            }
            else
            {
                errores = "Numero Ingresado Incorrecto";
            }

            return errores;
        }

    //validacion para que solo se pueda ingresar numeros
       private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
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
               e.Handled = false;
           }
           else
           {
               e.Handled = true;
           }

           if (!char.IsControl(e.KeyChar))
           {
               TextBox textBox = (TextBox)sender;

               if (textBox.Text.IndexOf(',') > -1 && textBox.Text.Substring(textBox.Text.IndexOf(',')).Length >= 3)
               {
                   e.Handled = true;
               }

               if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
               {
                   e.Handled = true;
               }
              
           }
           
        }

       //validacion para que solo se pueda ingresar numeros en el tiempo integral
       private void soloNumerosParaTiempos_KeyPress(object sender, KeyPressEventArgs e)
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
           //else if (e.KeyChar == '-')
           //{
           //    e.Handled = false;
           //}
           else
           {
               e.Handled = true;
           }

           if (!char.IsControl(e.KeyChar))
           {
               TextBox textBox = (TextBox)sender;

               if (textBox.Text.IndexOf(',') > -1 && textBox.Text.Substring(textBox.Text.IndexOf(',')).Length >= 3)
               {
                   e.Handled = true;
               }

               if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
               {
                   e.Handled = true;
               }

           }

       }



       private void txbPolo1_TextChanged(object sender, EventArgs e)
       {
           ingresoPolo1 = true;
           comprobarIngreso();
       }

       private void txbPolo2_TextChanged(object sender, EventArgs e)
       {
           ingresoPolo2 = true;
           comprobarIngreso();
       }

       public void comprobarIngreso()
       {
           if (primerOrden.Checked)
           {
               menuSensor.Enabled = true;
           }
           else if (segundoOrden.Checked)
           {
               if (ingresoPolo1 && ingresoPolo2)
               {
                   menuSensor.Enabled = true;
               }
           }
       }
    }
}
