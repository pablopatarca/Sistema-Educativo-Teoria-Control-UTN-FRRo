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
using TeoriaDeControl;

namespace Ejemplos
{
    public partial class FrmEscalónSegundoOrdenAvion : Form
    {
        //Variables necesarias para la gráfica en el ZedGraphControl
        double douAmplitud = 1;
        double douConstanteDeTiempo;
        double douTamañoDelPaso = 0.01;
        double douTiempoAsentamiento = 0.1;
        double douCoeficienteDeAmortiguamiento;
        double douValorLímite;
        EntradaEscalonOrden2 entradaEscalonOrden2;
        double tamañoTramo = 0.05;
        
        //Variables necesarias para el control visual
        double douValorAlturaAvion;

        double douValorAAlcanzar = 0;
        double douValorDeInicio = 0;

        int posicionYAvion = 180;
        int posicionXAvion = 3;

        
        string resp;

        public FrmEscalónSegundoOrdenAvion()
        {
            InitializeComponent();

            establecerPropiedadesInicialesDelZedGraph();

            iniciarPropiedadesDeControlesVisuales();
        }

        private void iniciarPropiedadesDeControlesVisuales()
        {
            this.pbxAvion.Location = new Point(posicionXAvion, posicionYAvion);

            altitud.Value = 0;

            douValorAlturaAvion = 0;
        }

        //Función escalon, donde coefAmort < 1
        private double YCoefAmortMenorAUno(double t)
        {
            return (1 - (1 / Math.Sqrt(1 - (douCoeficienteDeAmortiguamiento * douCoeficienteDeAmortiguamiento))) *
                Math.Pow(Math.E, (-douCoeficienteDeAmortiguamiento * t) / douConstanteDeTiempo) *
                Math.Sin(Math.Sqrt(1 - douCoeficienteDeAmortiguamiento * douCoeficienteDeAmortiguamiento) * (t / douConstanteDeTiempo)
                    + Math.Atan(Math.Sqrt(1 - douCoeficienteDeAmortiguamiento * douCoeficienteDeAmortiguamiento) / douCoeficienteDeAmortiguamiento))) * douAmplitud;
        }

        //Función escalon, donde coefAmort = 1
        private double YCoefAmortIgualAUno(double t)
        {
            return (1 - (1 + t / douConstanteDeTiempo) * Math.Pow(Math.E, -t / douConstanteDeTiempo)) * douAmplitud;
        }

        //Función escalon, donde coefAmort > 1
        private double YCoefAmortMayorAUno(double t)
        {
            return (1 - Math.Pow(Math.E, (-douCoeficienteDeAmortiguamiento * t) / douConstanteDeTiempo)
                * (Math.Cosh(Math.Sqrt(douCoeficienteDeAmortiguamiento * douCoeficienteDeAmortiguamiento - 1)
                * (t / douConstanteDeTiempo)) + douCoeficienteDeAmortiguamiento / (Math.Sqrt(douCoeficienteDeAmortiguamiento * douCoeficienteDeAmortiguamiento - 1))
                * Math.Sinh(Math.Sqrt(douCoeficienteDeAmortiguamiento * douCoeficienteDeAmortiguamiento - 1) * (t / douConstanteDeTiempo)))) * douAmplitud;
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

                entradaEscalonOrden2= new EntradaEscalonOrden2();

                double[] parametros = new double[4];

                parametros[0] = douAmplitud;
                parametros[1] = douConstanteDeTiempo;
                parametros[2] = douCoeficienteDeAmortiguamiento;
                parametros[3] = douTiempoAsentamiento;

                entradaEscalonOrden2.generarPuntos(parametros);

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
                douConstanteDeTiempo = double.Parse(this.txtConstanteDeTiempo.Text.Replace(",","."), System.Globalization.CultureInfo.InvariantCulture);

                douValorAAlcanzar = double.Parse(this.txtValorFinal.Text.Replace(",","."),System.Globalization.CultureInfo.InvariantCulture);
                douAmplitud = Math.Abs(douValorDeInicio - douValorAAlcanzar);

                douCoeficienteDeAmortiguamiento = double.Parse(this.txtCoeficienteDeAmortiguamiento.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

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
            this.zgcEscalon.GraphPane.XAxis.Scale.Max = Math.Round(entradaEscalonOrden2.FinEjeX, 1)*1.14;
            this.zgcEscalon.GraphPane.XAxis.Scale.Min = 0;

            this.zgcEscalon.GraphPane.YAxis.Scale.Max = entradaEscalonOrden2.FinEjeY;
            this.zgcEscalon.GraphPane.YAxis.Scale.Min = 0;
        }

        private void graficarFunción()
        {
            try
            {
                douValorLímite = Math.Round(entradaEscalonOrden2.FinEjeX, 1);

                //Creamos un PointPairList que simplemente contiene una línea recta que marca la Amplitud que debe alcanzar el Escalón
                PointPairList curvaAmplitud = new PointPairList();

                //Agregamos los 2 puntos necesarios para graficar la recta de Amplitud
                curvaAmplitud.Add(0, douAmplitud);
                curvaAmplitud.Add(douValorLímite, douAmplitud);

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

                int u = 1;

                if (douCoeficienteDeAmortiguamiento == 1)
                {
                    for (double t = 0; t <= douValorLímite; t = Math.Round(t+douTamañoDelPaso,2))
                    {
                        t = Math.Round(t, 2);
                        double Y;
                        Y = YCoefAmortIgualAUno(t);
                        curvaEscalón.Add(t, Y);
                        actualizarControlesVisualesCoefAmortIgualAUno(Y);

                        if (Math.Round(u * tamañoTramo,2) == t)
                        {
                            zgcEscalon.Invalidate();
                            WaitForMilliseconds(0);
                            u++;
                        }
                    }
                }
                else
                    if (douCoeficienteDeAmortiguamiento < 1)
                    {
                        for (double t = 0; t <= douValorLímite; t = Math.Round(t + douTamañoDelPaso, 2))
                        {
                            t = Math.Round(t, 2);
                            double Y;
                            Y = YCoefAmortMenorAUno(t);
                            curvaEscalón.Add(t, Y);
                            actualizarControlesVisualesCoefAmortMenorAUno(Y);

                            if (Math.Round(u * tamañoTramo, 2) == t)
                            {
                                zgcEscalon.Invalidate();
                                WaitForMilliseconds(0);
                                u++;
                            }
                        }
                    }
                    else
                    {
                        for (double t = 0; t <= douValorLímite; t = Math.Round(t + douTamañoDelPaso, 2))
                        {
                            t = Math.Round(t, 2);
                            double Y;
                            Y = YCoefAmortMayorAUno(t);
                            curvaEscalón.Add(t, Y);
                            actualizarControlesVisualesCoefAmortMayorAUno(Y);

                            if (Math.Round(u * tamañoTramo, 2) == t)
                            {
                                zgcEscalon.Invalidate();
                                WaitForMilliseconds(0);
                                u++;
                            }
                        }
                    }

                zgcEscalon.Invalidate();

                //for (double t = 0; t <= douValorLímite; t += douTamañoDelPaso)
                //{
                //    t = Math.Round(t, 2);

                //    double Y;

                //    if (douCoeficienteDeAmortiguamiento == 1)
                //    {
                //        Y = Math.Round(YCoefAmortIgualAUno(t), 2);
                //    }
                //    else
                //        if (douCoeficienteDeAmortiguamiento < 1)
                //        {
                //            Y = Math.Round(YCoefAmortMenorAUno(t), 2);
                //        }
                //        else
                //        {
                //            Y = Math.Round(YCoefAmortMayorAUno(t), 2);
                //        }

                //    curvaEscalón.Add(t,Y);
                //    actualizarControlesVisuales(Y);

                //    zgcEscalon.Invalidate();
                //    WaitForMilliseconds(0);
                //}
            }
            catch { }
        }

        private void actualizarControlesVisualesCoefAmortMayorAUno(double valorActualYDeT)
        {
            douValorAlturaAvion = valorActualYDeT / YCoefAmortMayorAUno(douValorLímite);

            pbxAvion.Location = new Point(posicionXAvion, posicionYAvion - Convert.ToInt32(douValorDeInicio + (((douValorAAlcanzar/100) - douValorDeInicio) * douValorAlturaAvion)));

            altitud.Value = (float)Math.Round(Convert.ToSingle(douValorDeInicio + ((douValorAAlcanzar - douValorDeInicio) * douValorAlturaAvion)), 2);
        }

        private void actualizarControlesVisualesCoefAmortMenorAUno(double valorActualYDeT)
        {
            douValorAlturaAvion = valorActualYDeT / YCoefAmortMenorAUno(douValorLímite);

            pbxAvion.Location = new Point(posicionXAvion, posicionYAvion - Convert.ToInt32(douValorDeInicio + (((douValorAAlcanzar / 100) - douValorDeInicio) * douValorAlturaAvion)));

            altitud.Value = (float)Math.Round(Convert.ToSingle(douValorDeInicio + ((douValorAAlcanzar - douValorDeInicio) * douValorAlturaAvion)), 2);
        }

        private void actualizarControlesVisualesCoefAmortIgualAUno(double valorActualYDeT)
        {
            douValorAlturaAvion = valorActualYDeT / YCoefAmortIgualAUno(douValorLímite);

            pbxAvion.Location = new Point(posicionXAvion, posicionYAvion - Convert.ToInt32(douValorDeInicio + (((douValorAAlcanzar / 100) - douValorDeInicio) * douValorAlturaAvion)));

            altitud.Value = (float)Math.Round(Convert.ToSingle(douValorDeInicio + ((douValorAAlcanzar - douValorDeInicio) * douValorAlturaAvion)), 2);
        }

        private void actualizarControlesVisuales(double valorActualYDeT)
        {

            if (douCoeficienteDeAmortiguamiento == 1)
                douValorAlturaAvion = valorActualYDeT / Math.Round(YCoefAmortIgualAUno(douValorLímite),2);
            else
                if (douCoeficienteDeAmortiguamiento < 1)
                    douValorAlturaAvion = valorActualYDeT / Math.Round(YCoefAmortMenorAUno(douValorLímite),2);
                else
                    douValorAlturaAvion = valorActualYDeT / Math.Round(YCoefAmortMayorAUno(douValorLímite),2);

            pbxAvion.Location = new Point(posicionXAvion, posicionYAvion - Convert.ToInt32(douValorDeInicio + (((douValorAAlcanzar / 100) - douValorDeInicio) * douValorAlturaAvion)));

            altitud.Value = (float)Math.Round(Convert.ToSingle(douValorDeInicio + ((douValorAAlcanzar - douValorDeInicio) * douValorAlturaAvion)), 2);
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
            this.btnInicio.Enabled = valorBooleano;
            this.btnLimpiar.Enabled = valorBooleano;
            this.txtCoeficienteDeAmortiguamiento.Enabled = valorBooleano;
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
            bool validoValFinal, validoConstTiempo, validoCoefAmort;

            if (douValorAAlcanzar < 100 || douValorAAlcanzar > 10000)
            {
                resp += "El valor de altitud final debe estar entre 100 y 10000 metros.\n";
                validoValFinal = false;
            }
            else
            {
                validoValFinal = true;
            }

            if (douConstanteDeTiempo <= 0 || douConstanteDeTiempo > 10)
            {
                resp += "El valor de la constante de tiempo debe estar entre 0 y 10.\n";
                validoConstTiempo = false;
            }
            else
            {
                validoConstTiempo = true;
            }

            if (douCoeficienteDeAmortiguamiento <= 0 || douCoeficienteDeAmortiguamiento > 5)
            {
                resp += "El valor del coeficiente de amortiguamiento debe estar entre 0 y 5.\n";
                validoCoefAmort = false;
            }
            else
            {
                validoCoefAmort = true;
            }

            if (validoConstTiempo && validoValFinal && validoCoefAmort)
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
