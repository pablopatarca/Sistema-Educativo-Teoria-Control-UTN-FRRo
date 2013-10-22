using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;


namespace Ejemplos
{
    public partial class FrmEscalónPrimerOrdenTermómetro : Form
    {
        //Variables necesarias para la gráfica en el ZedGraphControl
        double douAmplitud;
        double douConstateDeTiempo;
        double douPorcentajeDeError=0.001;
        double douTamañoDelPaso = 0.01;

        //Variables necesarias para el control visual
        //double douValorAnteriorYDeT;
        double douValorTermómetro;
        double douValorAAlcanzar;
        double douValorDeInicio = 35;

        string resp;

        public FrmEscalónPrimerOrdenTermómetro()
        {
            InitializeComponent();

            establecerPropiedadesInicialesDelZedGraph();

            iniciarPropiedadesDeControlesVisuales();
        }

        private void iniciarPropiedadesDeControlesVisuales()
        {
            douValorTermómetro = douValorDeInicio;

            //Valor inicial del termómetro
            termometro.Value = (float)douValorDeInicio;
            contador.Text = douValorDeInicio.ToString();
        }

        //Simplemente calcula Y(t) para una entrada Escalón para cada valor de t que ingresa
        private double calcularEntrada(double t)
        {
            return douAmplitud*(1-Math.Pow(Math.E,-t/douConstateDeTiempo));
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            metodoBtnInicio_Click();
        }

        private void metodoBtnInicio_Click()
        {
            establecerPropiedadesInicialesDelZedGraph();
            iniciarPropiedadesDeControlesVisuales();

            if (tomarValoresDelForm())
            {
                habilitarODeshabilitarElementosDeInterfaz(false);

                establecerPropiedadesDelZedGraph();

                graficarFunción();

                habilitarODeshabilitarElementosDeInterfaz(true);
            }
            else
            {
                MessageBox.Show(resp, "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool tomarValoresDelForm()
        {
            try
            {
                douConstateDeTiempo = double.Parse(txtConstanteDeTiempo.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                douValorDeInicio = double.Parse(txtValorInicial.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                douValorAAlcanzar = double.Parse(txtValorFinal.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                douAmplitud = Math.Abs(douValorDeInicio - douValorAAlcanzar);

                return validar();
            }
            catch
            {
               resp += "Debe ingresar todos los campos.\n";

                return false;
            }
        }

        private void establecerPropiedadesDelZedGraph()
        {
            this.zgcEscalon.GraphPane.XAxis.Scale.Max = Math.Round(calculoValorLímite(), 2);
            this.zgcEscalon.GraphPane.XAxis.Scale.Min = 0;

            this.zgcEscalon.GraphPane.YAxis.Scale.Max = 1.1 * douAmplitud;
            this.zgcEscalon.GraphPane.YAxis.Scale.Min = 0;
        }

        private void graficarFunción()
        {
            try
            {
                //Creamos un PointPairList que simplemente contiene una línea recta que marca la Amplitud que debe alcanzar el Escalón
                PointPairList curvaAmplitud = new PointPairList();

                //Agregamos los 2 puntos necesarios para graficar la recta
                curvaAmplitud.Add(0, douAmplitud);
                curvaAmplitud.Add(Math.Round(calculoValorLímite(), 2), douAmplitud);

                //Agregamos el PointPairList al ZedGraphControl y seteamos ciertas propiedades
                LineItem rectaAmplitud = zgcEscalon.GraphPane.AddCurve("", curvaAmplitud, Color.Orange);

                rectaAmplitud.Label.IsVisible = true;
                rectaAmplitud.Symbol.Type = SymbolType.None;
                rectaAmplitud.Line.IsAntiAlias = true;
                rectaAmplitud.Line.IsSmooth = true;
                rectaAmplitud.Line.SmoothTension = 0.05F;
                rectaAmplitud.Line.Width = 1.70f;

                //Finalmente ajustamos el ZedGraphControl para que enfoque la recta completa
                zgcEscalon.AxisChange();
                zgcEscalon.Invalidate();

                //Creamos un PointPairList

                PointPairList curvaEscalón = new PointPairList();

                LineItem lineaEscalón = zgcEscalon.GraphPane.AddCurve("", curvaEscalón, Color.Red);
                lineaEscalón.Label.IsVisible = true;
                lineaEscalón.Symbol.Type = SymbolType.None;
                lineaEscalón.Line.IsAntiAlias = true;
                lineaEscalón.Line.IsSmooth = true;
                lineaEscalón.Line.SmoothTension = 0.05F;
                lineaEscalón.Line.Width = 1.70f;

                double douValorLímite = Math.Round(calculoValorLímite(), 2);

                //Por medio del for calculamos cada punto (t e y:la función escalón evaluada en t) y lo agregamos a la curvaEscalón
                for (double t = 0; t <= douValorLímite; t = Math.Round(t + douTamañoDelPaso, 2))
                {
                    t = Math.Round(t, 2);
                    curvaEscalón.Add(t, calcularEntrada(t));
                    zgcEscalon.Invalidate();
                    WaitForMilliseconds(0);
                    actualizarControlesVisuales(calcularEntrada(t));
                }
            }
            catch { }
        }

        private void actualizarControlesVisuales(double valorActualT)
        {
            douValorTermómetro =valorActualT / calcularEntrada(Math.Round(calculoValorLímite(),2));

            //Asignamos valores al termómetro
            termometro.Value = System.Convert.ToSingle(douValorDeInicio + ((douValorAAlcanzar - douValorDeInicio) * douValorTermómetro));
            contador.Text = Math.Round(System.Convert.ToSingle(douValorDeInicio + ((douValorAAlcanzar - douValorDeInicio) * douValorTermómetro)), 2).ToString();
        }

        private double calculoValorLímite()
        {
            //La curvaEscalón sólo alcanza la Amplitud en el infinito, por lo que establecemos un valor límite t que se obtiene despejando la t de la fórmula de escalón unitario
            return (-douConstateDeTiempo * Math.Log(this.douPorcentajeDeError));
        }

        private void establecerPropiedadesInicialesDelZedGraph()
        {
            this.zgcEscalon.GraphPane.CurveList.Clear();

            this.zgcEscalon.GraphPane.Title.Text = "Entrada Escalón";

            this.zgcEscalon.GraphPane.XAxis.Title.Text = "Tiempo";
            this.zgcEscalon.GraphPane.XAxis.Scale.MinAuto = true;
            this.zgcEscalon.GraphPane.XAxis.Scale.MaxAuto = true;
            this.zgcEscalon.GraphPane.XAxis.MajorGrid.IsVisible = true;

            this.zgcEscalon.GraphPane.YAxis.Title.Text = "Y(t)";
            this.zgcEscalon.GraphPane.YAxis.Scale.MinAuto = true;
            this.zgcEscalon.GraphPane.YAxis.Scale.MaxAuto = true;
            this.zgcEscalon.GraphPane.YAxis.MajorGrid.IsVisible = true;

            this.zgcEscalon.Invalidate();
        }

        //Habilita o deshabilita los botones y el TextBox 
        private void habilitarODeshabilitarElementosDeInterfaz(bool valorBooleano)
        {
            this.txtConstanteDeTiempo.Enabled = valorBooleano;
            this.txtValorFinal.Enabled = valorBooleano;
            this.txtValorInicial.Enabled = valorBooleano;
            this.btnInicio.Enabled = valorBooleano;
            this.btnLimpiar.Enabled = valorBooleano;
        }

        private void WaitForMilliseconds(int ms)
        {
            Application.DoEvents();
            Thread.Sleep(ms);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            establecerPropiedadesInicialesDelZedGraph();
            iniciarPropiedadesDeControlesVisuales();
        }

        private bool validar()
        {
            resp = "";
            bool validoValInicio, validoValFinal, validoConstTiempo, validoIgual;

            if (douValorDeInicio < 35 || douValorDeInicio > 42)
            {
                resp += "El valor inicial de la temperatura debe estar entre 35 ºC y 42 ºC.\n";
                validoValInicio = false;
            }
            else
            {
                validoValInicio = true;
            }

            if (douValorAAlcanzar < 35 || douValorAAlcanzar > 42)
            {
                resp += "El valor final de la temperatura debe estar entre 35 ºC y 42 ºC.\n";
                validoValFinal = false;
            }
            else
            {
                validoValFinal = true;
            }

            if (douValorAAlcanzar == douValorDeInicio)
            {
                resp += "El valor inicial de la temperatura no puede ser igual al valor final.\n";
                validoIgual = false;
            }
            else
            {
                validoIgual = true;
            }

            if (douConstateDeTiempo <= 0 || douConstateDeTiempo > 30)
            {
                resp += "El valor de la constante de tiempo debe estar entre 1 y 30.\n";
                validoConstTiempo = false;
            }
            else
            {
                validoConstTiempo = true;
            }

            if (validoConstTiempo && validoValFinal && validoValInicio && validoIgual)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtValidar_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
