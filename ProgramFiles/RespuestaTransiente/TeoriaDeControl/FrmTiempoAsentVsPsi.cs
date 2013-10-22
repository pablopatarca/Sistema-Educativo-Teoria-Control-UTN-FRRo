using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace TeoriaDeControl
{
    public partial class FrmTiempoAsentVsPsi : Form
    {
        double douCteTiempo;
        double douTamañoDelPaso = 0.01;
        double valorMaximoAAlcanzar = 1;

        public FrmTiempoAsentVsPsi(double cteTiempo)
        {
            InitializeComponent();
            this.douCteTiempo = cteTiempo;
            establecerPropiedadesDelZedGraph();
            graficarFunción();
            zgcTiempoAsentVsPsi.AxisChange();
            zgcTiempoAsentVsPsi.Invalidate();
        }

        private void graficarFunción()
        {
            try
            {
                //Creamos un PointPairList

                PointPairList curva2Porciento = new PointPairList();
                
                LineItem lineaCurva2Porciento = zgcTiempoAsentVsPsi.GraphPane.AddCurve("Criterio del 2%", curva2Porciento, Color.Purple);

                lineaCurva2Porciento.Label.IsVisible = true;
                lineaCurva2Porciento.Symbol.Type = SymbolType.None;
                lineaCurva2Porciento.Line.IsAntiAlias = true;
                lineaCurva2Porciento.Line.IsSmooth = true;
                lineaCurva2Porciento.Line.SmoothTension = 0.05F;
                lineaCurva2Porciento.Line.Width = 1.90f;

                PointPairList curva5Porciento = new PointPairList();

                LineItem lineaCurva5Porciento = zgcTiempoAsentVsPsi.GraphPane.AddCurve("Criterio del 5%", curva5Porciento, Color.Orange);

                lineaCurva5Porciento.Label.IsVisible = true;
                lineaCurva5Porciento.Symbol.Type = SymbolType.None;
                lineaCurva5Porciento.Line.IsAntiAlias = true;
                lineaCurva5Porciento.Line.IsSmooth = true;
                lineaCurva5Porciento.Line.SmoothTension = 0.05F;
                lineaCurva5Porciento.Line.Width = 1.90f;

                //Por medio del for calculamos cada punto (t e y:la función escalón evaluada en t) y lo agregamos a la curvaEscalón
                for (double psi = 0.00; psi <= valorMaximoAAlcanzar; psi = Math.Round(psi + douTamañoDelPaso, 2))
                {
                    curva2Porciento.Add(psi, calcularEntrada2Porciento(psi));
                    curva5Porciento.Add(psi, calcularEntrada5Porciento(psi));
                }

                zgcTiempoAsentVsPsi.Invalidate();
            }
            catch { }
        }

        private double calcularEntrada2Porciento(double psi)
        {
            return 4/(psi*(1/this.douCteTiempo));
        }


        private double calcularEntrada5Porciento(double psi)
        {
            return 3 / (psi * (1 / this.douCteTiempo));
        }

        private void establecerPropiedadesDelZedGraph()
        {
            this.zgcTiempoAsentVsPsi.GraphPane.Title.Text = "";

            this.zgcTiempoAsentVsPsi.GraphPane.XAxis.Title.Text = "Coeficiente de Amortiguamiento";

            this.zgcTiempoAsentVsPsi.GraphPane.YAxis.Title.Text = "Tiempo de Asentamiento";

            this.zgcTiempoAsentVsPsi.GraphPane.XAxis.Scale.Max = valorMaximoAAlcanzar;
            this.zgcTiempoAsentVsPsi.GraphPane.XAxis.Scale.Min = 0;

            this.zgcTiempoAsentVsPsi.GraphPane.YAxis.Scale.Min = 0;
        }
    }
}
