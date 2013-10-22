using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using ZedGraph;

namespace Root_Locus
{
    public partial class FrmRespuestaEntradaImpulso : Form
    {
        enum TipoCaso
        {
            Caso1,
            Caso2,
            Caso3,
            Caso4,
            Caso5,
            Caso6,
        };

        //Datos constantes.
        private const double precisionEje = 0.06; //Defino la precisión con la que se va a tomar el click sobre el eje.
        private const int tamanioPanel = 140; //Defino el tamaño del panel cuadrado donde se va a mostrar la gráfica.
        private const int cantPuntosGraficaPunto = 4000; //Defino la cantidad de puntos que tendrá la gráfica del panel.
        private const double tamanioPaso = 0.001; //Defino el paso que tendrá la gráfica del panel.
        private float grosorCurva = 2.0F; //Defino el grosor de la curva que tendrá la gráfica del panel.
        private Color colorEstable = Color.Aquamarine;
        private Color colorInestable = Color.Red;
        private Color colorMarginalmenteEstable = Color.Orange;
        
        public FrmRespuestaEntradaImpulso()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
            InitializeComponent();
        }

        private void FrmRespuestaEntradaImpulso_Load(object sender, EventArgs e)
        {
            this.zgPlanoComplejo.IsShowPointValues = true;
            this.zgPlanoComplejo.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            //Agrego espacios en blanco al título del eje x para que me lo muestre a la derecha.
            this.zgPlanoComplejo.GraphPane.XAxis.Title.Text = "";
            for (int i = 0; i < 42; i++)
            {
                this.zgPlanoComplejo.GraphPane.XAxis.Title.Text += "    "; 
            }
            this.zgPlanoComplejo.GraphPane.XAxis.Title.Text += "Eje real";
            this.zgPlanoComplejo.GraphPane.XAxis.Title.IsVisible = true;
            this.zgPlanoComplejo.GraphPane.XAxis.Title.IsTitleAtCross = false;
            this.zgPlanoComplejo.GraphPane.YAxis.Title.Text = "Eje imaginario";
            this.zgPlanoComplejo.GraphPane.YAxis.Title.IsVisible = true;
            this.zgPlanoComplejo.GraphPane.YAxis.Title.IsTitleAtCross = false;

            this.zgPlanoComplejo.GraphPane.XAxis.Scale.Min = -4;
            this.zgPlanoComplejo.GraphPane.XAxis.Scale.Max = 4;
            this.zgPlanoComplejo.GraphPane.YAxis.Scale.Min = -2;
            this.zgPlanoComplejo.GraphPane.YAxis.Scale.Max = 10;

            this.zgPlanoComplejo.GraphPane.XAxis.Scale.MinorStep = 1.0;
            this.zgPlanoComplejo.GraphPane.XAxis.Scale.MajorStep = 1.0;
            this.zgPlanoComplejo.GraphPane.YAxis.Scale.MinorStep = 1.0;
            this.zgPlanoComplejo.GraphPane.YAxis.Scale.MajorStep = 1.0;

            this.zgPlanoComplejo.GraphPane.XAxis.Cross = 0;
            this.zgPlanoComplejo.GraphPane.YAxis.Cross = 0;

            this.zgPlanoComplejo.GraphPane.XAxis.IsVisible = true;
            this.zgPlanoComplejo.GraphPane.XAxis.MajorGrid.IsVisible = true;
            this.zgPlanoComplejo.GraphPane.XAxis.MajorGrid.IsZeroLine = false;
            this.zgPlanoComplejo.GraphPane.YAxis.IsVisible = true;
            this.zgPlanoComplejo.GraphPane.YAxis.MajorGrid.IsVisible = true;
            this.zgPlanoComplejo.GraphPane.YAxis.MajorGrid.IsZeroLine = false;

            this.zgPlanoComplejo.GraphPane.Title.IsVisible = false;
            this.zgPlanoComplejo.GraphPane.Chart.Border.IsVisible = false;
            this.zgPlanoComplejo.GraphPane.Border.IsVisible = false;
            this.zgPlanoComplejo.GraphPane.Legend.IsVisible = false;

            //Creo la lista de puntos donde voy a almacenar los puntos que se van clickeando sobre
            //el plano complejo para poder graficarlos.
            PointPairList listaPuntosPlanoComplejo = new PointPairList();
            LineItem curvaPuntosPlanoComplejo = zgPlanoComplejo.GraphPane.AddCurve("", listaPuntosPlanoComplejo, Color.Black, SymbolType.Circle);
            curvaPuntosPlanoComplejo.Symbol.Fill = new Fill(Color.Black);
            curvaPuntosPlanoComplejo.Line.IsVisible = false;

            this.zgPlanoComplejo.Invalidate();
        }

        private void zedC_MouseClick(object sender, MouseEventArgs e)
        {
            int index = 0;
            object nearestObject = null;
            PointF clickedPoint = new PointF(e.X, e.Y);
            zgPlanoComplejo.GraphPane.FindNearestObject(clickedPoint, this.CreateGraphics(), out nearestObject, out index);

            double x;
            double y;
            zgPlanoComplejo.GraphPane.ReverseTransform(clickedPoint, out x, out y);

            if (x >= zgPlanoComplejo.GraphPane.XAxis.Scale.Min && x <= zgPlanoComplejo.GraphPane.XAxis.Scale.Max &&
                y >= zgPlanoComplejo.GraphPane.YAxis.Scale.Min && y <= zgPlanoComplejo.GraphPane.YAxis.Scale.Max)
            {
                this.Graficar(x, y, e.X, e.Y);
            }
        }

        private void Graficar(double xPlano, double yPlano, int xContenedor, int yContenedor)
        {
            if (yPlano > -precisionEje && yPlano < precisionEje)
            {
                if (xPlano < -precisionEje)
                {
                    //Caso 1: semieje negativo real.
                    GraficarCaso(xPlano, 0, xContenedor, yContenedor, TipoCaso.Caso1);
                }
                else
                {
                    if (xPlano > precisionEje)
                    {
                        //Caso 2: semieje positivo real.
                        GraficarCaso(xPlano, 0, xContenedor, yContenedor, TipoCaso.Caso2);
                    }
                    else
                    {
                        //Caso 6: origen de coordenadas.
                        GraficarCaso(0, 0, xContenedor, yContenedor, TipoCaso.Caso6);
                    }
                }
            }
            else
            {
                if (xPlano < -precisionEje)
                {
                    //Caso 3: semiplano a la izquierda del eje imaginario.
                    GraficarCaso(xPlano, yPlano, xContenedor, yContenedor, TipoCaso.Caso3);
                }
                else
                {
                    if (xPlano > precisionEje)
                    {
                        //Caso 4: semiplano a la derecha del eje imaginario.
                        GraficarCaso(xPlano, yPlano, xContenedor, yContenedor, TipoCaso.Caso4);
                    }
                    else
                    {
                        //Caso 5: eje imaginario.
                        GraficarCaso(0, yPlano, xContenedor, yContenedor, TipoCaso.Caso5);
                    }
                }
            }
        }

        //Para cada caso, grafico punto sobre el plano y grafico respuesta en un panel.
        private void GraficarCaso(double xPlano, double yPlano, int xContenedor, int yContenedor, TipoCaso tipoCaso)
        {
            //Agrego punto a la lista de puntos del plano complejo.
            LineItem curvaPuntos = zgPlanoComplejo.GraphPane.CurveList[0] as LineItem;
            IPointListEdit listaPuntosPlanoComplejo = curvaPuntos.Points as IPointListEdit;
            PointPair puntoPlano = new PointPair(xPlano, yPlano);
            listaPuntosPlanoComplejo.Add(puntoPlano);
            this.zgPlanoComplejo.Invalidate();
            
            //Defino panel, seteo sus propiedades, lo agrego al formulario y lo traigo al frente.
            PanelGraficaPunto panelGraficaPunto = new PanelGraficaPunto();
            panelGraficaPunto.PuntoPlano = puntoPlano;
            panelGraficaPunto.Size = new Size(tamanioPanel, tamanioPanel);
            panelGraficaPunto.Location = new Point(xContenedor - tamanioPanel / 2, yContenedor - tamanioPanel - 10);
            panelGraficaPunto.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panelGraficaPunto);
            panelGraficaPunto.BringToFront();

            //Defino un ZedGraphControl, le agrego el evento Click, seteo sus propiedades y lo agrego al panel.
            ZedGraphControl zgGraficaPunto = new ZedGraphControl();
            zgGraficaPunto.Click += new EventHandler(zgGraficaPunto_Click);
            zgGraficaPunto.Dock = DockStyle.Fill;
            zgGraficaPunto.IsEnableWheelZoom = false;
            zgGraficaPunto.IsEnableHZoom = false;
            zgGraficaPunto.IsEnableVZoom = false;
            zgGraficaPunto.GraphPane.Title.IsVisible = false;
            zgGraficaPunto.GraphPane.XAxis.Title.Text = "";
            zgGraficaPunto.GraphPane.YAxis.Title.Text = "";
            panelGraficaPunto.Controls.Add(zgGraficaPunto);

            //Creo lista de puntos para agregar puntos a la gráfica del panel según cada caso.
            PointPairList listaPuntosGraficaPunto = new PointPairList();

            if (tipoCaso == TipoCaso.Caso1)
            {
                //Defino mínimo y máximo de la escala y el paso de la gráfica.
                zgGraficaPunto.GraphPane.XAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.XAxis.Scale.Max = 4;
                zgGraficaPunto.GraphPane.YAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.YAxis.Scale.Max = 1;
                zgGraficaPunto.GraphPane.XAxis.Scale.MinorStep = 0.4;
                zgGraficaPunto.GraphPane.XAxis.Scale.MajorStep = 0.4;
                zgGraficaPunto.GraphPane.YAxis.Scale.MinorStep = 0.1;
                zgGraficaPunto.GraphPane.YAxis.Scale.MajorStep = 0.1;

                for (int i = 0; i < cantPuntosGraficaPunto; i++)
                {
                    double t = (double)i * tamanioPaso;
                    double y = yImpulso1Orden(xPlano, t);
                    listaPuntosGraficaPunto.Add(t, y);
                }

                LineItem curvaRespuesta = zgGraficaPunto.GraphPane.AddCurve("", listaPuntosGraficaPunto, colorEstable, SymbolType.None);
                curvaRespuesta.Line.Width = grosorCurva;
            }
            else if (tipoCaso == TipoCaso.Caso2)
            {
                //Defino mínimo y máximo de la escala y el paso de la gráfica.
                zgGraficaPunto.GraphPane.XAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.XAxis.Scale.Max = 4;
                zgGraficaPunto.GraphPane.YAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.YAxis.Scale.Max = 100;
                zgGraficaPunto.GraphPane.XAxis.Scale.MinorStep = 0.4;
                zgGraficaPunto.GraphPane.XAxis.Scale.MajorStep = 0.4;
                zgGraficaPunto.GraphPane.YAxis.Scale.MinorStep = 10;
                zgGraficaPunto.GraphPane.YAxis.Scale.MajorStep = 10;

                for (int i = 0; i < cantPuntosGraficaPunto; i++)
                {
                    double t = (double)i * tamanioPaso;
                    double y = yImpulso1Orden(xPlano, t);
                    listaPuntosGraficaPunto.Add(t, y);
                }

                LineItem curvaRespuesta = zgGraficaPunto.GraphPane.AddCurve("", listaPuntosGraficaPunto, colorInestable, SymbolType.None);
                curvaRespuesta.Line.Width = grosorCurva;
            }
            else if (tipoCaso == TipoCaso.Caso6)
            {
                //Defino mínimo y máximo de la escala y el paso de la gráfica.
                zgGraficaPunto.GraphPane.XAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.XAxis.Scale.Max = 4;
                zgGraficaPunto.GraphPane.YAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.YAxis.Scale.Max = 2;
                zgGraficaPunto.GraphPane.XAxis.Scale.MinorStep = 0.4;
                zgGraficaPunto.GraphPane.XAxis.Scale.MajorStep = 0.4;
                zgGraficaPunto.GraphPane.YAxis.Scale.MinorStep = 0.2;
                zgGraficaPunto.GraphPane.YAxis.Scale.MajorStep = 0.2;

                for (int i = 0; i < cantPuntosGraficaPunto; i++)
                {
                    double t = (double)i * tamanioPaso;
                    double y = yImpulso1Orden(xPlano, t);
                    listaPuntosGraficaPunto.Add(t, y);
                }

                LineItem curvaRespuesta = zgGraficaPunto.GraphPane.AddCurve("", listaPuntosGraficaPunto, colorMarginalmenteEstable, SymbolType.None);
                curvaRespuesta.Line.Width = grosorCurva;
            }
            else if (tipoCaso == TipoCaso.Caso3)
            {
                //Defino mínimo y máximo de la escala y el paso de la gráfica.
                zgGraficaPunto.GraphPane.XAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.XAxis.Scale.Max = 4;
                zgGraficaPunto.GraphPane.YAxis.Scale.Min = -3;
                zgGraficaPunto.GraphPane.YAxis.Scale.Max = 5;
                zgGraficaPunto.GraphPane.XAxis.Scale.MinorStep = 0.4;
                zgGraficaPunto.GraphPane.XAxis.Scale.MajorStep = 0.4;
                zgGraficaPunto.GraphPane.YAxis.Scale.MinorStep = 0.8;
                zgGraficaPunto.GraphPane.YAxis.Scale.MajorStep = 0.8;

                //Calculo omega (distancia del punto al origen de coordenadas) y psi.
                double omega = Math.Sqrt(xPlano * xPlano + yPlano * yPlano);
                double psi = Math.Abs(xPlano) / omega;

                for (int i = 0; i < cantPuntosGraficaPunto; i++)
                {
                    double t = (double)i * tamanioPaso;
                    double y = yImpulso2OrdenEstable(1 / omega, psi, t);
                    listaPuntosGraficaPunto.Add(t, y);
                }

                LineItem curvaRespuesta = zgGraficaPunto.GraphPane.AddCurve("", listaPuntosGraficaPunto, colorEstable, SymbolType.None);
                curvaRespuesta.Line.Width = grosorCurva;
            }
            else if (tipoCaso == TipoCaso.Caso4)
            {
                //Divido la coordenada x del punto por el extremo derecho de la escala del plano.
                //Lo que estoy haciendo en realidad es graficar entre 0 y 1 del eje real, ya que
                //de esta forma se visualizan gráficas inestables más adecuadas a los fines educativos.
                xPlano = xPlano / this.zgPlanoComplejo.GraphPane.XAxis.Scale.Max;

                //Calculo omega (distancia del punto al origen de coordenadas) y psi.                
                double omega = Math.Sqrt(xPlano * xPlano + yPlano * yPlano);
                double psi = Math.Abs(xPlano) / omega;

                //Grafico respuesta impulso entre -rangoEjeYMax y +rangoEjeYMax.
                int rangoEjeYMax = 10000;
                int i = -1;
                do
                {
                    i++;
                    double t = (double)i * 0.01;
                    double y = yImpulso2OrdenInestable(1 / omega, psi, t);
                    listaPuntosGraficaPunto.Add(t, y);

                } while (listaPuntosGraficaPunto[listaPuntosGraficaPunto.Count - 1].Y > -rangoEjeYMax && listaPuntosGraficaPunto[listaPuntosGraficaPunto.Count - 1].Y < rangoEjeYMax);

                //Defino mínimo y máximo de la escala.
                zgGraficaPunto.GraphPane.XAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.XAxis.Scale.Max = listaPuntosGraficaPunto[listaPuntosGraficaPunto.Count - 1].X;
                zgGraficaPunto.GraphPane.YAxis.Scale.Min = -rangoEjeYMax;
                zgGraficaPunto.GraphPane.YAxis.Scale.Max = rangoEjeYMax;

                //Defino el paso de la gráfica.
                double pasoX = Math.Round((zgGraficaPunto.GraphPane.XAxis.Scale.Max - zgGraficaPunto.GraphPane.XAxis.Scale.Min) / 10, 2);
                double pasoY = Math.Round((zgGraficaPunto.GraphPane.YAxis.Scale.Max - zgGraficaPunto.GraphPane.YAxis.Scale.Min) / 10, 2);
                zgGraficaPunto.GraphPane.XAxis.Scale.MinorStep = pasoX;
                zgGraficaPunto.GraphPane.XAxis.Scale.MajorStep = pasoX;
                zgGraficaPunto.GraphPane.YAxis.Scale.MinorStep = pasoY;
                zgGraficaPunto.GraphPane.YAxis.Scale.MajorStep = pasoY;
                
                LineItem curvaRespuesta = zgGraficaPunto.GraphPane.AddCurve("", listaPuntosGraficaPunto, colorInestable, SymbolType.None);
                curvaRespuesta.Line.Width = grosorCurva;
            }
            else if (tipoCaso == TipoCaso.Caso5)
            {
                //Defino mínimo y máximo de la escala y el paso de la gráfica.
                zgGraficaPunto.GraphPane.XAxis.Scale.Min = 0;
                zgGraficaPunto.GraphPane.XAxis.Scale.Max = 4;
                zgGraficaPunto.GraphPane.YAxis.Scale.Min = -4;
                zgGraficaPunto.GraphPane.YAxis.Scale.Max = 4;
                zgGraficaPunto.GraphPane.XAxis.Scale.MinorStep = 0.4;
                zgGraficaPunto.GraphPane.XAxis.Scale.MajorStep = 0.4;
                zgGraficaPunto.GraphPane.YAxis.Scale.MinorStep = 0.8;
                zgGraficaPunto.GraphPane.YAxis.Scale.MajorStep = 0.8;

                for (int i = 0; i < cantPuntosGraficaPunto; i++)
                {
                    double t = (double)i * tamanioPaso;
                    double y = yImpulso2OrdenMarginalmenteEstable(1 / Math.Abs(yPlano), t);
                    listaPuntosGraficaPunto.Add(t, y);
                }

                LineItem curvaRespuesta = zgGraficaPunto.GraphPane.AddCurve("", listaPuntosGraficaPunto, colorMarginalmenteEstable, SymbolType.None);
                curvaRespuesta.Line.Width = grosorCurva;
            }

            //Para los casos 3 y 5, controlo que entre la gráfica y la ajusto.
            if (tipoCaso == TipoCaso.Caso3 || tipoCaso == TipoCaso.Caso5)
            {
                //Calculo máximo y mínimo.
                double yMaximo = listaPuntosGraficaPunto[0].Y;
                double yMinimo = listaPuntosGraficaPunto[0].Y;

                foreach (PointPair punto in listaPuntosGraficaPunto)
                {
                    if (punto.Y > yMaximo)
                    {
                        yMaximo = punto.Y;
                    }
                    if (punto.Y < yMinimo)
                    {
                        yMinimo = punto.Y;
                    }
                }

                //Ajusto los valores de la escala Y para que entre la gráfica.
                if (yMaximo > zgGraficaPunto.GraphPane.YAxis.Scale.Max)
                {
                    zgGraficaPunto.GraphPane.YAxis.Scale.Max = yMaximo + 1;
                }
                if (yMinimo < zgGraficaPunto.GraphPane.YAxis.Scale.Min)
                {
                    zgGraficaPunto.GraphPane.YAxis.Scale.Min = yMinimo - 1;
                }
                
                double paso = Math.Round((zgGraficaPunto.GraphPane.YAxis.Scale.Max - zgGraficaPunto.GraphPane.YAxis.Scale.Min) / 10, 2);
                zgGraficaPunto.GraphPane.YAxis.Scale.MinorStep = paso;
                zgGraficaPunto.GraphPane.YAxis.Scale.MajorStep = paso;
            }

            zgGraficaPunto.Invalidate();
        }

        private double yImpulso1Orden(double inversaTau, double t)
        {
            return Math.Pow(Math.E, inversaTau * t);
        }

        private double yImpulso2OrdenEstable(double tau, double psi, double t)
        {
            return (1 / tau) * (1 / Math.Sqrt(1 - psi * psi)) *
                   Math.Pow(Math.E, -psi * t / tau) *
                   Math.Sin(Math.Sqrt(1 - psi * psi) * t / tau);
        }

        private double yImpulso2OrdenInestable(double tau, double psi, double t)
        {
            return (1 / tau) * (1 / Math.Sqrt(1 - psi * psi)) *
                   Math.Pow(Math.E, psi * t / tau) *
                   Math.Sin(Math.Sqrt(1 - psi * psi) * t / tau);
        }

        private double yImpulso2OrdenMarginalmenteEstable(double tau, double t)
        {
            return (1 / tau) * Math.Sin(t / tau);
        }

        /// <summary>
        /// Muestra tooltip con formato cuando el mouse pasa sobre el punto
        /// </summary>
        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
        {
            // Get the PointPair that is under the mouse
            PointPair pt = curve[iPt];

            //Muestro coordenadas del punto.
            string datos = "( " + pt.X.ToString("f2") + " ; " + pt.Y.ToString("f2") + " )";
            
            double omega = Math.Sqrt(pt.X * pt.X + pt.Y * pt.Y);
            if (omega != 0)
            {
                //Muestro cte. de tiempo.
                datos += "\nCte. Tiempo: " + (1 / omega).ToString("f2");

                //Si el punto no está sobre el eje real, la respuesta es un impulso de segundo orden,
                //por lo que muestro también el coeficiente de amortiguamiento y la frecuencia natural de oscilación.
                if (pt.Y != 0)
                {
                    datos += "\nCoef. Amort.: " + (Math.Abs(pt.X) / omega).ToString("f2") +
                             "\nFrec. Nat. Oscilación: " + omega.ToString("f2");
                } 
            }

            return datos;
        }

        void zgGraficaPunto_Click(object sender, EventArgs e)
        {
            ZedGraphControl zgGraficaPunto = (ZedGraphControl)sender;

            LineItem curvaPuntos = zgPlanoComplejo.GraphPane.CurveList[0] as LineItem;
            IPointListEdit listaPuntosPlanoComplejo = curvaPuntos.Points as IPointListEdit;

            PointPair puntoPlano = ((PanelGraficaPunto)zgGraficaPunto.Parent).PuntoPlano;

            //Busco el punto del panel en la lista de puntos del plano complejo y lo borro.
            for (int i = 0; i < listaPuntosPlanoComplejo.Count; i++)
            {
                if (listaPuntosPlanoComplejo[i].Equals(puntoPlano))
                {
                    curvaPuntos.RemovePoint(i);
                    this.zgPlanoComplejo.Invalidate();
                    break;
                }
            }

            //Borro el panel.
            zgGraficaPunto.Parent.Dispose();
        }
    }
}
