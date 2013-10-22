using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

using ZedGraph;
using BodePlot;
using Util;

namespace DiagramasBode
{
    public partial class FrmCompara : Form
    {
        TableLayoutPanel p;
        Historial h;
        ZedGraphControl zedMax;
        List<ZedGraphControl> controles;

        private bool graficaDobleActiva = true;

        #region Constantes
        /// <summary>
        /// Grosor de las curvas individuales.
        /// </summary>
        private const float GROSOR_CURVA_INDIVIDUAL = 1.5f;

        /// <summary>
        /// Grosor de las curvas parciales.
        /// </summary>
        private const float GROSOR_CURVA_PARCIAL = 3.0f;

        #endregion

        #region Atributos gráficos

        /// <summary>
        /// Colores para las curvas individuales.
        /// </summary>
        private  Color[] coloresCurvasIndividuales = new Color[] { Color.LightBlue, Color.Orange, Color.Yellow, 
            Color.LightGreen, Color.Blue, Color.Pink, Color.Green, Color.DarkBlue, Color.DarkRed };

        /// <summary>
        /// Color de las curvas parciales.
        /// </summary>
        private Color colorCurvaParcial = Color.Black;

        #endregion



        #region Atributos de Formula1
        /// <summary>
        /// Objeto de dibujo para la gráfica de magnitud.
        /// </summary>
        private GraphPane gpMagnitud1;

        /// <summary>
        /// Objeto de dibujo para la gráfica de fase.
        /// </summary>
        private GraphPane gpFase1;

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, individuales de magnitud.
        /// </summary>
        private List<LineItem> lineItemsCurvasIndividualesMagnitud1 = new List<LineItem>();

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, individuales de fase.
        /// </summary>
        private List<LineItem> lineItemsCurvasIndividualesFase1 = new List<LineItem>();

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, parciales de magnitud.
        /// </summary>
        private List<LineItem> lineItemsCurvasParcialesMagnitud1 = new List<LineItem>();

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, parciales de fase.
        /// </summary>
        private List<LineItem> lineItemsCurvasParcialesFase1 = new List<LineItem>();

        /// <summary>
        /// Lista de puntos de corte de ZedGraph.
        /// </summary>
        private List<LineItem> lineItemsPuntosCorte1 = new List<LineItem>();

        /// <summary>
        /// Lista de puntos de cruce de ganancia de ZedGraph.
        /// </summary>
        private List<LineItem> lineItemsPuntosCruceGanancia1 = new List<LineItem>();

        /// <summary>
        /// Lista de puntos de cruce de fase de ZedGraph.
        /// </summary>
        private List<LineItem> lineItemsPuntosCruceFase1 = new List<LineItem>();

        /// <summary>
        /// Determina si actualmente se están visualizando las gráficas de magnitud y fase simultáneamente.
        /// </summary>
        //private bool graficaDobleActiva = true;

        #endregion

        #region Atributos no gráficos de Formula1

        /// <summary>
        /// Controlador que contiene todos los valores matemáticos calculados, que son
        /// necesarios para la graficación de las curvas.
        /// </summary>
        private ControladorBode controladorBode1;

        /// <summary>
        /// Fórmula que está siendo graficada.
        /// </summary>
        private Formula _Formula1;
        public Formula Formula1
        {
            get
            {
                return _Formula1;
            }
            set
            {
                _Formula1 = value;
            }
        }

        /// <summary>
        /// Determina si nos encontramos actualmente en el primer paso de la ejecución
        /// de una gráfica.
        /// </summary>
        private bool primeraEjecucion1 = true;

        /// <summary>
        /// Índice que determina la curva individual que el usuario está visualizando.
        /// </summary>
        private int indiceCurvaActual1 = -1;


        #endregion

        #region Metodos para Formula1

        private List<LineItem> generarLineItemsCurvasIndividualesMagnitud1()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode1.CurvasIndividuales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode1.CurvasIndividuales[indiceCurva].PuntosMagnitud.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode1.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][0],
                        this.controladorBode1.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][1]);

                LineItem lineItem = this.gpMagnitud1.AddCurve(this.controladorBode1.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                    this.coloresCurvasIndividuales[indiceCurva], SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_INDIVIDUAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }
        /// <summary>
        /// Genera una lista de líneas de ZedGraph, para las curvas individuales de fase.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para las curvas individuales de fase.</returns>
        private List<LineItem> generarlineItemsCurvasIndividualesFase1()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode1.CurvasIndividuales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode1.CurvasIndividuales[indiceCurva].PuntosFase.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode1.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][0],
                        this.controladorBode1.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][1]);

                LineItem lineItem = this.gpFase1.AddCurve(this.controladorBode1.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                    this.coloresCurvasIndividuales[indiceCurva], SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_INDIVIDUAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de líneas de ZedGraph, para las curvas parciales de magnitud.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para las curvas parciales de magnitud.</returns>
        private List<LineItem> generarlineItemsCurvasParcialesMagnitud1()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode1.CurvasParciales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode1.CurvasParciales[indiceCurva].PuntosMagnitud.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode1.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][0],
                        this.controladorBode1.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][1]);

                string nombre = "";

                if (indiceCurva + 1 == this.controladorBode1.CurvasParciales.Count)
                {
                    nombre = "Curva Final";
                }
                else
                {
                    nombre = this.controladorBode1.CurvasParciales[indiceCurva].Nombre;
                }

                LineItem lineItem = this.gpMagnitud1.AddCurve(nombre, pointPairList, this.colorCurvaParcial, SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_PARCIAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;


                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de líneas de ZedGraph, para las curvas parciales de fase.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para las curvas parciales de fase.</returns>
        private List<LineItem> generarlineItemsCurvasParcialesFase1()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode1.CurvasParciales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode1.CurvasParciales[indiceCurva].PuntosFase.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode1.CurvasParciales[indiceCurva].PuntosFase[indicePunto][0],
                        this.controladorBode1.CurvasParciales[indiceCurva].PuntosFase[indicePunto][1]);

                string nombre = "";

                if (indiceCurva + 1 == this.controladorBode1.CurvasParciales.Count)
                {
                    nombre = "Curva Final";
                }
                else
                {
                    nombre = this.controladorBode1.CurvasParciales[indiceCurva].Nombre;
                }

                LineItem lineItem = this.gpFase1.AddCurve(nombre, pointPairList, this.colorCurvaParcial, SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_PARCIAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de línea de ZedGraph, para los puntos de corte.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para los puntos de corte.</returns>
        private List<LineItem> generarlineItemsPuntosCorte1()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada punto de corte creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode1.CurvasIndividuales.Count; indiceCurva++)
            {
                //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
                if (this.controladorBode1.CurvasIndividuales[indiceCurva].PuntoCorte != null)
                {
                    PointPairList pointPairList = new PointPairList();
                    pointPairList.Add(this.controladorBode1.CurvasIndividuales[indiceCurva].PuntoCorte[0], this.controladorBode1.CurvasIndividuales[indiceCurva].PuntoCorte[1]);

                    LineItem lineItem = this.gpMagnitud1.AddCurve("Punto de corte: " + this.controladorBode1.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                        Color.Black, SymbolType.Diamond);
                    lineItem.IsVisible = false;
                    lineItem.Label.IsVisible = false;

                    lineItem.Symbol.Fill = new Fill(this.coloresCurvasIndividuales[indiceCurva]);
                    lineItem.Symbol.Border.Color = Color.Black;
                    lineItem.Symbol.Border.Width = 1.0f;
                    lineItem.Symbol.Size = 17.0f;
                    lineItem.Symbol.IsAntiAlias = true;

                    lineItems.Add(lineItem);
                }
                else
                {
                    //Debemos saber cuál punto de corte pertenece a cuál curva, así
                    //que debemos mantener una referencia.
                    lineItems.Add(null);
                }
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de línea de ZedGraph, para los cruces de ganancia.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para los cruces de ganancia.</returns>
        private List<LineItem> generarlineItemsPuntosCruceGanancia1()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (this.controladorBode1.CruceGanancia[0, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode1.CruceGanancia[0, 0], (double)this.controladorBode1.CruceGanancia[0, 1]);

                LineItem lineItem = this.gpMagnitud1.AddCurve("Cruce de Ganancia", pointPairList, Color.Black, SymbolType.Triangle);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Symbol.Fill = new Fill(Color.Yellow);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            if (this.controladorBode1.CruceGanancia[1, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode1.CruceGanancia[1, 0], (double)this.controladorBode1.CruceGanancia[1, 1]);

                LineItem lineItem = this.gpFase1.AddCurve("Margen de Fase", pointPairList, Color.Black, SymbolType.Square);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;
                lineItem.Symbol.Fill = new Fill(Color.Yellow);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);

                //Agregamos una línea desde la marca del margen de fase hasta la línea de -180 grados.
                PointPairList ppl = new PointPairList();
                ppl.Add((double)this.controladorBode1.CruceGanancia[1, 0], (double)this.controladorBode1.CruceGanancia[1, 1]);
                ppl.Add((double)this.controladorBode1.CruceGanancia[1, 0], -180);
                LineItem li = this.gpFase1.AddCurve("", ppl, Color.Black, SymbolType.None);
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                li.Line.Width = 2f;
                li.IsVisible = false;
                li.Label.IsVisible = false;

                lineItems.Add(li);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de línea de ZedGraph, para los cruces de fase.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para los cruces de fase.</returns>
        private List<LineItem> generarlineItemsPuntosCruceFase1()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (this.controladorBode1.CruceFase[0, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode1.CruceFase[0, 0], (double)this.controladorBode1.CruceFase[0, 1]);

                LineItem lineItem = this.gpFase1.AddCurve("Cruce de Fase", pointPairList,
                    Color.Black, SymbolType.Triangle);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Symbol.Fill = new Fill(Color.White);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (this.controladorBode1.CruceFase[1, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode1.CruceFase[1, 0], (double)this.controladorBode1.CruceFase[1, 1]);

                LineItem lineItem = this.gpMagnitud1.AddCurve("Margen de Ganancia", pointPairList, Color.Black, SymbolType.Square);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;
                lineItem.Symbol.Fill = new Fill(Color.White);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);

                //Agregamos una línea desde la marca del margen de ganancia hasta la línea de 0 decibeles.
                PointPairList ppl = new PointPairList();
                ppl.Add((double)this.controladorBode1.CruceFase[1, 0], (double)this.controladorBode1.CruceFase[1, 1]);
                ppl.Add((double)this.controladorBode1.CruceFase[1, 0], 0);
                LineItem li = this.gpMagnitud1.AddCurve("", ppl, Color.Black, SymbolType.None);
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                li.Line.Width = 2f;
                li.IsVisible = false;
                li.Label.IsVisible = false;

                lineItems.Add(li);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            return lineItems;
        }

        /// <summary>
        /// Muestra las curvas individuales y parciales, los puntos de corte y los cruces de 
        /// magnitud y fase hasta aquella curva que indique el índice de la curva actual.
        /// </summary>
        private void mostrarCurvas1()
        {
            //Curvas individuales.

            //Mostramos las curvas hasta el índice actual, y ocultamos las restantes.
            int cantidadCurvasIndividuales = this.controladorBode1.CurvasIndividuales.Count;
            for (int i = 0; i < cantidadCurvasIndividuales; i++)
            {
                if (i <= this.indiceCurvaActual1)
                {
                    this.lineItemsCurvasIndividualesMagnitud1[i].IsVisible = true;
                    this.lineItemsCurvasIndividualesMagnitud1[i].Label.IsVisible = true;
                    this.lineItemsCurvasIndividualesFase1[i].IsVisible = true;
                    this.lineItemsCurvasIndividualesFase1[i].Label.IsVisible = true;
                }
                else
                {
                    this.lineItemsCurvasIndividualesMagnitud1[i].IsVisible = false;
                    this.lineItemsCurvasIndividualesMagnitud1[i].Label.IsVisible = false;
                    this.lineItemsCurvasIndividualesFase1[i].IsVisible = false;
                    this.lineItemsCurvasIndividualesFase1[i].Label.IsVisible = false;
                }
            }

            //Puntos de corte.
            //Mostramos los puntos del índice actual, y ocultamos los demás. Tener en
            //cuenta que una curva puede no tener punto de corte.
            int cantidadPuntosCorte = this.controladorBode1.CurvasIndividuales.Count;
            for (int i = 0; i < cantidadPuntosCorte; i++)
            {
                if (this.lineItemsPuntosCorte1[i] != null)
                {
                    if (i == this.indiceCurvaActual1)
                        this.lineItemsPuntosCorte1[i].IsVisible = true;
                    else
                        this.lineItemsPuntosCorte1[i].IsVisible = false;
                }
            }


            //Curvas parciales.
            //Mostramos las curvas del índice actual, y ocultamos las demás.
            int cantidadCurvasParciales = this.controladorBode1.CurvasParciales.Count;
            for (int i = 0; i < cantidadCurvasParciales; i++)
            {
                if (i == this.indiceCurvaActual1)
                {
                    this.lineItemsCurvasParcialesMagnitud1[i].IsVisible = true;
                    this.lineItemsCurvasParcialesMagnitud1[i].Label.IsVisible = true;
                    this.lineItemsCurvasParcialesFase1[i].IsVisible = true;
                    this.lineItemsCurvasParcialesFase1[i].Label.IsVisible = true;
                }
                else
                {
                    this.lineItemsCurvasParcialesMagnitud1[i].IsVisible = false;
                    this.lineItemsCurvasParcialesMagnitud1[i].Label.IsVisible = false;
                    this.lineItemsCurvasParcialesFase1[i].IsVisible = false;
                    this.lineItemsCurvasParcialesFase1[i].Label.IsVisible = false;
                }
            }

            //Muestra los puntos de cruce de fase y magnitud solo en la última gráfica.
            if ((cantidadCurvasParciales - 1) == indiceCurvaActual1)
            {
                if (lineItemsPuntosCruceGanancia1[0] != null)
                {
                    this.lineItemsPuntosCruceGanancia1[0].IsVisible = true;
                    this.lineItemsPuntosCruceGanancia1[0].Label.IsVisible = true;
                }

                if (lineItemsPuntosCruceGanancia1[1] != null)
                {
                    this.lineItemsPuntosCruceGanancia1[1].IsVisible = true;
                    this.lineItemsPuntosCruceGanancia1[1].Label.IsVisible = true;

                    //Si hay un cruce de ganancia, significa que hay margen de fase.
                    this.lineItemsPuntosCruceGanancia1[2].IsVisible = true;
                }

                if (lineItemsPuntosCruceFase1[0] != null)
                {
                    this.lineItemsPuntosCruceFase1[0].IsVisible = true;
                    this.lineItemsPuntosCruceFase1[0].Label.IsVisible = true;
                }

                if (lineItemsPuntosCruceFase1[1] != null)
                {
                    this.lineItemsPuntosCruceFase1[1].IsVisible = true;
                    this.lineItemsPuntosCruceFase1[1].Label.IsVisible = true;

                    //Si hay un cruce de fase, significa que hay margen de ganancia.
                    this.lineItemsPuntosCruceFase1[2].IsVisible = true;
                }


                //Declaramos un datatable para poder guardar los datos obtenidos del datagridview

                //Mostramos el margen de ganancia.
                //if (this.controladorBode1.MargenGanancia != null)
                //{
                //    dgvDatos.Rows.Add("GANANCIA", this.controladorBode1.MargenGanancia.ToString() + " dB");

                //    if (this.controladorBode1.MargenGanancia >= 0)
                //    {
                //        dgvDatos[1, 0].Style.BackColor = Color.LightBlue;
                //    }
                //    else
                //    {
                //        dgvDatos[1, 0].Style.BackColor = Color.LightPink;
                //    }
                //}
                //else
                //{
                //    dgvDatos.Rows.Add("GANANCIA", "INFINITO");
                //}

                ////Mostramos el margen de fase.
                //if (this.controladorBode1.MargenFase != null)
                //{
                //    dgvDatos.Rows.Add("FASE", this.controladorBode1.MargenFase.ToString() + " °");

                //    if (this.controladorBode1.MargenFase >= 0)
                //    {
                //        dgvDatos[1, 1].Style.BackColor = Color.LightBlue;
                //    }
                //    else
                //    {
                //        dgvDatos[1, 1].Style.BackColor = Color.LightPink;
                //    }
                //}
                //else
                //{
                //    dgvDatos.Rows.Add("FASE", "INFINITO");
                //}

            }
            //Quita los puntos de cruce de Fase y Magnitud si no se esta en la ULTIMA gráfica
            else
            {
                if (lineItemsPuntosCruceGanancia1[0] != null)
                {
                    this.lineItemsPuntosCruceGanancia1[0].IsVisible = false;
                    this.lineItemsPuntosCruceGanancia1[0].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceGanancia1[1] != null)
                {
                    this.lineItemsPuntosCruceGanancia1[1].IsVisible = false;
                    this.lineItemsPuntosCruceGanancia1[1].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceFase1[0] != null)
                {
                    this.lineItemsPuntosCruceFase1[0].IsVisible = false;
                    this.lineItemsPuntosCruceFase1[0].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceFase1[1] != null)
                {
                    this.lineItemsPuntosCruceFase1[1].IsVisible = false;
                    this.lineItemsPuntosCruceFase1[1].Label.IsVisible = false;
                }

            }

            reestablecerEscala1();

            //Habilita el boton Adelante hasta que se dibuja la ultima curva

        }

        private void establecerPropiedadesPrimarias1()
        {
            //Gráfica de magnitud.
            this.gpMagnitud1.Title.Text = "Sistema 1 - Gráfica de Magnitud";

            this.gpMagnitud1.XAxis.Title.Text = "Frecuencia (rad/s)";
            this.gpMagnitud1.XAxis.Type = AxisType.Log;
            this.gpMagnitud1.XAxis.Scale.MinAuto = true;
            this.gpMagnitud1.XAxis.Scale.MaxAuto = true;
            this.gpMagnitud1.XAxis.MajorGrid.IsVisible = true;

            //Legend es lo que hace aparecer o desaparecer los aclaraciones sobre cada curva.
            this.gpMagnitud1.Legend.IsVisible = false;

            this.gpMagnitud1.YAxis.Title.Text = "Magnitud(db)";
            this.gpMagnitud1.YAxis.Scale.MinAuto = true;
            this.gpMagnitud1.YAxis.Scale.MaxAuto = true;
            this.gpMagnitud1.YAxis.MajorGrid.IsVisible = true;

            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

            zedGraphControl1.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            zedGraphControl1.AxisChange();

            //Gráfica de fase.
            this.gpFase1.Title.Text = "Sistema 1 - Gráfica de Fase";

            this.gpFase1.XAxis.Title.Text = "Frecuencia (rad/s)";
            this.gpFase1.XAxis.Type = AxisType.Log;
            this.gpFase1.XAxis.Scale.MinAuto = true;
            this.gpFase1.XAxis.Scale.MaxAuto = true;
            this.gpFase1.XAxis.MajorGrid.IsVisible = true;

            this.gpFase1.Legend.IsVisible = false;

            this.gpFase1.YAxis.Title.Text = "Fase (grados)";
            this.gpFase1.YAxis.Scale.MinAuto = true;
            this.gpFase1.YAxis.Scale.MaxAuto = true;
            this.gpFase1.YAxis.MajorGrid.IsVisible = true;

            zedGraphControl2.IsShowPointValues = true;
            zedGraphControl2.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

            zedGraphControl2.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            zedGraphControl2.AxisChange();
        }

        private void reestablecerEscala1()
        {
            //Reestablecemos la escala de las gráficas.
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl2.AxisChange();

            //Reestablecemos los valores mínimos y máximos de las gráficas.
            this.gpMagnitud1.YAxis.Scale.Min = this.controladorBode1.InicioEjeYMagnitud;
            this.gpMagnitud1.YAxis.Scale.Max = this.controladorBode1.FinEjeYMagnitud;

            this.gpMagnitud1.XAxis.Scale.Min = this.controladorBode1.InicioEjeX;
            this.gpMagnitud1.XAxis.Scale.Max = this.controladorBode1.FinEjeX;

            this.gpFase1.YAxis.Scale.Min = this.controladorBode1.InicioEjeYFase;
            this.gpFase1.YAxis.Scale.Max = this.controladorBode1.FinEjeYFase;

            this.gpFase1.XAxis.Scale.Min = this.controladorBode1.InicioEjeX;
            this.gpFase1.XAxis.Scale.Max = this.controladorBode1.FinEjeX;

            //Refrescamos las gráficas.
            this.zedGraphControl1.Invalidate();
            this.zedGraphControl2.Invalidate();
        }

        private void metodoBtnSig_Click1()
        {
            if (this.primeraEjecucion1)
            {

                //Indicamos que se están ejecutando los cálculos.
                this.Cursor = Cursors.WaitCursor;

                //Generamos el controlador, que tiene las curvas individuales, parciales y puntos de corte.
                this.controladorBode1 = new ControladorBode(this.Formula1.K, this.Formula1.N1, this.Formula1.T1, this.Formula1.T2,
                    this.Formula1.Td, this.Formula1.N2, this.Formula1.T3, this.Formula1.T4, this.Formula1.Wn, this.Formula1.Psi);

                //Generamos todos los LineItem de las curvas individuales y parciales.
                //Luego los iremos mostrando y ocultando a medida que sea necesario.
                if (this.controladorBode1.CurvasIndividuales.Count > 0 && this.controladorBode1.CurvasParciales.Count > 0)
                {
                    this.lineItemsCurvasIndividualesMagnitud1 = generarLineItemsCurvasIndividualesMagnitud1();
                    this.lineItemsCurvasIndividualesFase1 = generarlineItemsCurvasIndividualesFase1();
                    this.lineItemsCurvasParcialesMagnitud1 = generarlineItemsCurvasParcialesMagnitud1();
                    this.lineItemsCurvasParcialesFase1 = generarlineItemsCurvasParcialesFase1();

                    this.lineItemsPuntosCorte1 = generarlineItemsPuntosCorte1();

                    this.lineItemsPuntosCruceGanancia1 = generarlineItemsPuntosCruceGanancia1();
                    this.lineItemsPuntosCruceFase1 = generarlineItemsPuntosCruceFase1();
                }

                //Resaltamos la gráfica de magnitud en magnitud = 0, y la gráfica de
                //fase en fase = -180,.
                PointPairList pplResaltadoMagnitud = new PointPairList();
                pplResaltadoMagnitud.Add(this.controladorBode1.InicioEjeX, 0);
                pplResaltadoMagnitud.Add(this.controladorBode1.FinEjeX, 0);
                LineItem liResaltadoMagnitud = this.gpMagnitud1.AddCurve("", pplResaltadoMagnitud, Color.Red, SymbolType.None);
                liResaltadoMagnitud.Line.Width = 2f;
                liResaltadoMagnitud.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                PointPairList pplResaltadoFaseSuperior = new PointPairList();
                pplResaltadoFaseSuperior.Add(this.controladorBode1.InicioEjeX, 180);
                pplResaltadoFaseSuperior.Add(this.controladorBode1.FinEjeX, 180);
                LineItem liFaseResaltadoSuperior = this.gpFase1.AddCurve("", pplResaltadoFaseSuperior, Color.Red, SymbolType.None);
                liFaseResaltadoSuperior.Line.Width = 2f;
                liFaseResaltadoSuperior.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                PointPairList pplResaltadoFase = new PointPairList();
                pplResaltadoFase.Add(this.controladorBode1.InicioEjeX, -180);
                pplResaltadoFase.Add(this.controladorBode1.FinEjeX, -180);
                LineItem liFaseResaltado = this.gpFase1.AddCurve("", pplResaltadoFase, Color.Red, SymbolType.None);
                liFaseResaltado.Line.Width = 2f;
                liFaseResaltado.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                this.primeraEjecucion1 = false;

                //Indicamos que los cálculos finalizaron.
                this.Cursor = Cursors.Default;

                reestablecerEscala1();
            }

            if (this.controladorBode1.CurvasIndividuales.Count > 0 && this.controladorBode1.CurvasParciales.Count > 0)
                for (int i = 0; i < this.controladorBode1.CurvasParciales.Count; i++)
                {
                    this.indiceCurvaActual1++;
                    mostrarCurvas1();
                }
        }

        #endregion



        #region Atributos de Formula2

        private GraphPane gpMagnitud;

        /// <summary>
        /// Objeto de dibujo para la gráfica de fase.
        /// </summary>
        private GraphPane gpFase;

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, individuales de magnitud.
        /// </summary>
        private List<LineItem> lineItemsCurvasIndividualesMagnitud = new List<LineItem>();

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, individuales de fase.
        /// </summary>
        private List<LineItem> lineItemsCurvasIndividualesFase = new List<LineItem>();

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, parciales de magnitud.
        /// </summary>
        private List<LineItem> lineItemsCurvasParcialesMagnitud = new List<LineItem>();

        /// <summary>
        /// Lista de curvas gráficas de ZedGraph, parciales de fase.
        /// </summary>
        private List<LineItem> lineItemsCurvasParcialesFase = new List<LineItem>();

        /// <summary>
        /// Lista de puntos de corte de ZedGraph.
        /// </summary>
        private List<LineItem> lineItemsPuntosCorte = new List<LineItem>();

        /// <summary>
        /// Lista de puntos de cruce de ganancia de ZedGraph.
        /// </summary>
        private List<LineItem> lineItemsPuntosCruceGanancia = new List<LineItem>();

        /// <summary>
        /// Lista de puntos de cruce de fase de ZedGraph.
        /// </summary>
        private List<LineItem> lineItemsPuntosCruceFase = new List<LineItem>();

        #endregion

        #region Atributos no gráficos de Formula2

        /// <summary>
        /// Controlador que contiene todos los valores matemáticos calculados, que son
        /// necesarios para la graficación de las curvas.
        /// </summary>
        private ControladorBode controladorBode;

        /// <summary>
        /// Fórmula que está siendo graficada.
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

        /// <summary>
        /// Determina si nos encontramos actualmente en el primer paso de la ejecución
        /// de una gráfica.
        /// </summary>
        private bool primeraEjecucion = true;

        /// <summary>
        /// Índice que determina la curva individual que el usuario está visualizando.
        /// </summary>
        private int indiceCurvaActual = -1;

        #endregion

        #region Metodos para Formula2

        /// <summary>
        /// Genera una lista de líneas de ZedGraph, para las curvas individuales de magnitud.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para las curvas individuales de magnitud.</returns>
        private List<LineItem> generarLineItemsCurvasIndividualesMagnitud()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode.CurvasIndividuales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode.CurvasIndividuales[indiceCurva].PuntosMagnitud.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][0],
                        this.controladorBode.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][1]);

                LineItem lineItem = this.gpMagnitud.AddCurve(this.controladorBode.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                    this.coloresCurvasIndividuales[indiceCurva], SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_INDIVIDUAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de líneas de ZedGraph, para las curvas individuales de fase.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para las curvas individuales de fase.</returns>
        private List<LineItem> generarLineItemsCurvasIndividualesFase()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode.CurvasIndividuales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode.CurvasIndividuales[indiceCurva].PuntosFase.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][0],
                        this.controladorBode.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][1]);

                LineItem lineItem = this.gpFase.AddCurve(this.controladorBode.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                    this.coloresCurvasIndividuales[indiceCurva], SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_INDIVIDUAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de líneas de ZedGraph, para las curvas parciales de magnitud.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para las curvas parciales de magnitud.</returns>
        private List<LineItem> generarLineItemsCurvasParcialesMagnitud()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode.CurvasParciales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode.CurvasParciales[indiceCurva].PuntosMagnitud.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][0],
                        this.controladorBode.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][1]);

                string nombre = "";

                if (indiceCurva + 1 == this.controladorBode.CurvasParciales.Count)
                {
                    nombre = "Curva Final";
                }
                else
                {
                    nombre = this.controladorBode.CurvasParciales[indiceCurva].Nombre;
                }

                LineItem lineItem = this.gpMagnitud.AddCurve(nombre, pointPairList, this.colorCurvaParcial, SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_PARCIAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;


                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de líneas de ZedGraph, para las curvas parciales de fase.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para las curvas parciales de fase.</returns>
        private List<LineItem> generarLineItemsCurvasParcialesFase()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode.CurvasParciales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < this.controladorBode.CurvasParciales[indiceCurva].PuntosFase.Count; indicePunto++)
                    pointPairList.Add(this.controladorBode.CurvasParciales[indiceCurva].PuntosFase[indicePunto][0],
                        this.controladorBode.CurvasParciales[indiceCurva].PuntosFase[indicePunto][1]);

                string nombre = "";

                if (indiceCurva + 1 == this.controladorBode.CurvasParciales.Count)
                {
                    nombre = "Curva Final";
                }
                else
                {
                    nombre = this.controladorBode.CurvasParciales[indiceCurva].Nombre;
                }

                LineItem lineItem = this.gpFase.AddCurve(nombre, pointPairList, this.colorCurvaParcial, SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_PARCIAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de línea de ZedGraph, para los puntos de corte.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para los puntos de corte.</returns>
        private List<LineItem> generarLineItemsPuntosCorte()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada punto de corte creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < this.controladorBode.CurvasIndividuales.Count; indiceCurva++)
            {
                //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
                if (this.controladorBode.CurvasIndividuales[indiceCurva].PuntoCorte != null)
                {
                    PointPairList pointPairList = new PointPairList();
                    pointPairList.Add(this.controladorBode.CurvasIndividuales[indiceCurva].PuntoCorte[0], this.controladorBode.CurvasIndividuales[indiceCurva].PuntoCorte[1]);

                    LineItem lineItem = this.gpMagnitud.AddCurve("Punto de corte: " + this.controladorBode.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                        Color.Black, SymbolType.Diamond);
                    lineItem.IsVisible = false;
                    lineItem.Label.IsVisible = false;

                    lineItem.Symbol.Fill = new Fill(this.coloresCurvasIndividuales[indiceCurva]);
                    lineItem.Symbol.Border.Color = Color.Black;
                    lineItem.Symbol.Border.Width = 1.0f;
                    lineItem.Symbol.Size = 17.0f;
                    lineItem.Symbol.IsAntiAlias = true;

                    lineItems.Add(lineItem);
                }
                else
                {
                    //Debemos saber cuál punto de corte pertenece a cuál curva, así
                    //que debemos mantener una referencia.
                    lineItems.Add(null);
                }
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de línea de ZedGraph, para los cruces de ganancia.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para los cruces de ganancia.</returns>
        private List<LineItem> generarLineItemsPuntosCruceGanancia()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (this.controladorBode.CruceGanancia[0, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode.CruceGanancia[0, 0], (double)this.controladorBode.CruceGanancia[0, 1]);

                LineItem lineItem = this.gpMagnitud.AddCurve("Cruce de Ganancia", pointPairList, Color.Black, SymbolType.Triangle);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Symbol.Fill = new Fill(Color.Yellow);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            if (this.controladorBode.CruceGanancia[1, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode.CruceGanancia[1, 0], (double)this.controladorBode.CruceGanancia[1, 1]);

                LineItem lineItem = this.gpFase.AddCurve("Margen de Fase", pointPairList, Color.Black, SymbolType.Square);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;
                lineItem.Symbol.Fill = new Fill(Color.Yellow);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);

                //Agregamos una línea desde la marca del margen de fase hasta la línea de -180 grados.
                PointPairList ppl = new PointPairList();
                ppl.Add((double)this.controladorBode.CruceGanancia[1, 0], (double)this.controladorBode.CruceGanancia[1, 1]);
                ppl.Add((double)this.controladorBode.CruceGanancia[1, 0], -180);
                LineItem li = this.gpFase.AddCurve("", ppl, Color.Black, SymbolType.None);
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                li.Line.Width = 2f;
                li.IsVisible = false;
                li.Label.IsVisible = false;

                lineItems.Add(li);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            return lineItems;
        }

        /// <summary>
        /// Genera una lista de línea de ZedGraph, para los cruces de fase.
        /// </summary>
        /// <returns>Lista de líneas de ZedGraph, para los cruces de fase.</returns>
        private List<LineItem> generarLineItemsPuntosCruceFase()
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (this.controladorBode.CruceFase[0, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode.CruceFase[0, 0], (double)this.controladorBode.CruceFase[0, 1]);

                LineItem lineItem = this.gpFase.AddCurve("Cruce de Fase", pointPairList,
                    Color.Black, SymbolType.Triangle);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Symbol.Fill = new Fill(Color.White);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (this.controladorBode.CruceFase[1, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)this.controladorBode.CruceFase[1, 0], (double)this.controladorBode.CruceFase[1, 1]);

                LineItem lineItem = this.gpMagnitud.AddCurve("Margen de Ganancia", pointPairList, Color.Black, SymbolType.Square);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;
                lineItem.Symbol.Fill = new Fill(Color.White);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);

                //Agregamos una línea desde la marca del margen de ganancia hasta la línea de 0 decibeles.
                PointPairList ppl = new PointPairList();
                ppl.Add((double)this.controladorBode.CruceFase[1, 0], (double)this.controladorBode.CruceFase[1, 1]);
                ppl.Add((double)this.controladorBode.CruceFase[1, 0], 0);
                LineItem li = this.gpMagnitud.AddCurve("", ppl, Color.Black, SymbolType.None);
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                li.Line.Width = 2f;
                li.IsVisible = false;
                li.Label.IsVisible = false;

                lineItems.Add(li);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            return lineItems;
        }

        /// <summary>
        /// Muestra las curvas individuales y parciales, los puntos de corte y los cruces de 
        /// magnitud y fase hasta aquella curva que indique el índice de la curva actual.
        /// </summary>
        private void mostrarCurvas()
        {
            //Curvas individuales.
                //Mostramos las curvas hasta el índice actual, y ocultamos las restantes.
                int cantidadCurvasIndividuales = this.controladorBode.CurvasIndividuales.Count;
                for (int i = 0; i < cantidadCurvasIndividuales; i++)
                {
                    if (i <= this.indiceCurvaActual)
                    {
                        this.lineItemsCurvasIndividualesMagnitud[i].IsVisible = true;
                        this.lineItemsCurvasIndividualesMagnitud[i].Label.IsVisible = true;
                        this.lineItemsCurvasIndividualesFase[i].IsVisible = true;
                        this.lineItemsCurvasIndividualesFase[i].Label.IsVisible = true;
                    }
                    else
                    {
                        this.lineItemsCurvasIndividualesMagnitud[i].IsVisible = false;
                        this.lineItemsCurvasIndividualesMagnitud[i].Label.IsVisible = false;
                        this.lineItemsCurvasIndividualesFase[i].IsVisible = false;
                        this.lineItemsCurvasIndividualesFase[i].Label.IsVisible = false;
                    }
                }

                //Puntos de corte.
                //Mostramos los puntos del índice actual, y ocultamos los demás. Tener en
                //cuenta que una curva puede no tener punto de corte.
                int cantidadPuntosCorte = this.controladorBode.CurvasIndividuales.Count;
                for (int i = 0; i < cantidadPuntosCorte; i++)
                {
                    if (this.lineItemsPuntosCorte[i] != null)
                    {
                        if (i == this.indiceCurvaActual)
                            this.lineItemsPuntosCorte[i].IsVisible = true;
                        else
                            this.lineItemsPuntosCorte[i].IsVisible = false;
                    }
                }

            //Curvas parciales.
            //Mostramos las curvas del índice actual, y ocultamos las demás.
            int cantidadCurvasParciales = this.controladorBode.CurvasParciales.Count;
            for (int i = 0; i < cantidadCurvasParciales; i++)
            {
                if (i == this.indiceCurvaActual)
                {
                    this.lineItemsCurvasParcialesMagnitud[i].IsVisible = true;
                    this.lineItemsCurvasParcialesMagnitud[i].Label.IsVisible = true;
                    this.lineItemsCurvasParcialesFase[i].IsVisible = true;
                    this.lineItemsCurvasParcialesFase[i].Label.IsVisible = true;
                }
                else
                {
                    this.lineItemsCurvasParcialesMagnitud[i].IsVisible = false;
                    this.lineItemsCurvasParcialesMagnitud[i].Label.IsVisible = false;
                    this.lineItemsCurvasParcialesFase[i].IsVisible = false;
                    this.lineItemsCurvasParcialesFase[i].Label.IsVisible = false;
                }
            }

            //Muestra los puntos de cruce de fase y magnitud solo en la última gráfica.
            if ((cantidadCurvasParciales - 1) == indiceCurvaActual)
            {
                if (lineItemsPuntosCruceGanancia[0] != null)
                {
                    this.lineItemsPuntosCruceGanancia[0].IsVisible = true;
                    this.lineItemsPuntosCruceGanancia[0].Label.IsVisible = true;
                }

                if (lineItemsPuntosCruceGanancia[1] != null)
                {
                    this.lineItemsPuntosCruceGanancia[1].IsVisible = true;
                    this.lineItemsPuntosCruceGanancia[1].Label.IsVisible = true;

                    //Si hay un cruce de ganancia, significa que hay margen de fase.
                    this.lineItemsPuntosCruceGanancia[2].IsVisible = true;
                }

                if (lineItemsPuntosCruceFase[0] != null)
                {
                    this.lineItemsPuntosCruceFase[0].IsVisible = true;
                    this.lineItemsPuntosCruceFase[0].Label.IsVisible = true;
                }

                if (lineItemsPuntosCruceFase[1] != null)
                {
                    this.lineItemsPuntosCruceFase[1].IsVisible = true;
                    this.lineItemsPuntosCruceFase[1].Label.IsVisible = true;

                    //Si hay un cruce de fase, significa que hay margen de ganancia.
                    this.lineItemsPuntosCruceFase[2].IsVisible = true;
                }

                //Mostramos el margen de ganancia.
                //if (this.controladorBode.MargenGanancia != null)
                //{
                //    dgvMargenes.Rows.Add("GANANCIA", this.controladorBode.MargenGanancia.ToString() + " dB");
                //    this.dat.Rows.Add("GANANCIA", this.controladorBode.MargenGanancia.ToString() + " dB");

                //    if (this.controladorBode.MargenGanancia >= 0)
                //    {
                //        dgvMargenes[1, 0].Style.BackColor = Color.LightBlue;
                //    }
                //    else
                //    {
                //        dgvMargenes[1, 0].Style.BackColor = Color.LightPink;
                //    }
                //}
                //else
                //{
                //    dgvMargenes.Rows.Add("GANANCIA", "INFINITO");
                //    this.dat.Rows.Add("GANANCIA", "INFINITO");
                //}

                ////Mostramos el margen de fase.
                //if (this.controladorBode.MargenFase != null)
                //{
                //    dgvMargenes.Rows.Add("FASE", this.controladorBode.MargenFase.ToString() + " °");
                //    this.dat.Rows.Add("FASE", this.controladorBode.MargenFase.ToString() + " º");

                //    if (this.controladorBode.MargenFase >= 0)
                //    {
                //        dgvMargenes[1, 1].Style.BackColor = Color.LightBlue;
                //    }
                //    else
                //    {
                //        dgvMargenes[1, 1].Style.BackColor = Color.LightPink;
                //    }
                //}
                //else
                //{
                //    dgvMargenes.Rows.Add("FASE", "INFINITO");
                //    this.dat.Rows.Add("FASE", "INFINITO");
                //}
            }
            //Quita los puntos de cruce de Fase y Magnitud si no se esta en la ULTIMA gráfica
            else
            {
                if (lineItemsPuntosCruceGanancia[0] != null)
                {
                    this.lineItemsPuntosCruceGanancia[0].IsVisible = false;
                    this.lineItemsPuntosCruceGanancia[0].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceGanancia[1] != null)
                {
                    this.lineItemsPuntosCruceGanancia[1].IsVisible = false;
                    this.lineItemsPuntosCruceGanancia[1].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceFase[0] != null)
                {
                    this.lineItemsPuntosCruceFase[0].IsVisible = false;
                    this.lineItemsPuntosCruceFase[0].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceFase[1] != null)
                {
                    this.lineItemsPuntosCruceFase[1].IsVisible = false;
                    this.lineItemsPuntosCruceFase[1].Label.IsVisible = false;
                }

            }

            reestablecerEscala();
        }

        private void establecerPropiedadesPrimarias()
        {
            //Gráfica de magnitud.
            this.gpMagnitud.Title.Text = "Sistema 2 - Gráfica de Magnitud";

            this.gpMagnitud.XAxis.Title.Text = "Frecuencia (rad/s)";
            this.gpMagnitud.XAxis.Type = AxisType.Log;
            this.gpMagnitud.XAxis.Scale.MinAuto = true;
            this.gpMagnitud.XAxis.Scale.MaxAuto = true;
            this.gpMagnitud.XAxis.MajorGrid.IsVisible = true;

            this.gpMagnitud.Legend.IsVisible = false;

            this.gpMagnitud.YAxis.Title.Text = "Magnitud(db)";
            this.gpMagnitud.YAxis.Scale.MinAuto = true;
            this.gpMagnitud.YAxis.Scale.MaxAuto = true;
            this.gpMagnitud.YAxis.MajorGrid.IsVisible = true;

            zedGraphControl3.IsShowPointValues = true;
            zedGraphControl3.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

            zedGraphControl3.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            zedGraphControl3.AxisChange();

            //Gráfica de fase.
            this.gpFase.Title.Text = "Sistema 2 - Gráfica de Fase";

            this.gpFase.XAxis.Title.Text = "Frecuencia (rad/s)";
            this.gpFase.XAxis.Type = AxisType.Log;
            this.gpFase.XAxis.Scale.MinAuto = true;
            this.gpFase.XAxis.Scale.MaxAuto = true;
            this.gpFase.XAxis.MajorGrid.IsVisible = true;

            this.gpFase.Legend.IsVisible = false;

            this.gpFase.YAxis.Title.Text = "Fase (grados)";
            this.gpFase.YAxis.Scale.MinAuto = true;
            this.gpFase.YAxis.Scale.MaxAuto = true;
            this.gpFase.YAxis.MajorGrid.IsVisible = true;

            zedGraphControl4.IsShowPointValues = true;
            zedGraphControl4.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

            zedGraphControl4.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            zedGraphControl4.AxisChange();
        }

        private void reestablecerEscala()
        {
            //Reestablecemos la escala de las gráficas.
            this.zedGraphControl3.AxisChange();
            this.zedGraphControl4.AxisChange();

            //Reestablecemos los valores mínimos y máximos de las gráficas.
            this.gpMagnitud.YAxis.Scale.Min = this.controladorBode.InicioEjeYMagnitud;
            this.gpMagnitud.YAxis.Scale.Max = this.controladorBode.FinEjeYMagnitud;

            this.gpMagnitud.XAxis.Scale.Min = this.controladorBode.InicioEjeX;
            this.gpMagnitud.XAxis.Scale.Max = this.controladorBode.FinEjeX;

            this.gpFase.YAxis.Scale.Min = this.controladorBode.InicioEjeYFase;
            this.gpFase.YAxis.Scale.Max = this.controladorBode.FinEjeYFase;

            this.gpFase.XAxis.Scale.Min = this.controladorBode.InicioEjeX;
            this.gpFase.XAxis.Scale.Max = this.controladorBode.FinEjeX;

            //Refrescamos las gráficas.
            this.zedGraphControl3.Invalidate();
            this.zedGraphControl4.Invalidate();
        }

        private void metodoBtnSig_Click()
        {
                //Indicamos que se están ejecutando los cálculos.
                this.Cursor = Cursors.WaitCursor;

                //Generamos el controlador, que tiene las curvas individuales, parciales y puntos de corte.
                this.controladorBode = new ControladorBode(this.Formula.K, this.Formula.N1, this.Formula.T1, this.Formula.T2,
                    this.Formula.Td, this.Formula.N2, this.Formula.T3, this.Formula.T4, this.Formula.Wn, this.Formula.Psi);

                //Generamos todos los LineItem de las curvas individuales y parciales.
                //Luego los iremos mostrando y ocultando a medida que sea necesario.
                if (this.controladorBode.CurvasIndividuales.Count > 0 && this.controladorBode.CurvasParciales.Count > 0)
                {
                    this.lineItemsCurvasIndividualesMagnitud = generarLineItemsCurvasIndividualesMagnitud();
                    this.lineItemsCurvasIndividualesFase = generarLineItemsCurvasIndividualesFase();
                    this.lineItemsCurvasParcialesMagnitud = generarLineItemsCurvasParcialesMagnitud();
                    this.lineItemsCurvasParcialesFase = generarLineItemsCurvasParcialesFase();

                    this.lineItemsPuntosCorte = generarLineItemsPuntosCorte();

                    this.lineItemsPuntosCruceGanancia = generarLineItemsPuntosCruceGanancia();
                    this.lineItemsPuntosCruceFase = generarLineItemsPuntosCruceFase();
                }

                //Resaltamos la gráfica de magnitud en magnitud = 0, y la gráfica de
                //fase en fase = -180,.
                PointPairList pplResaltadoMagnitud = new PointPairList();
                pplResaltadoMagnitud.Add(this.controladorBode.InicioEjeX, 0);
                pplResaltadoMagnitud.Add(this.controladorBode.FinEjeX, 0);
                LineItem liResaltadoMagnitud = this.gpMagnitud.AddCurve("", pplResaltadoMagnitud, Color.Red, SymbolType.None);
                liResaltadoMagnitud.Line.Width = 2f;
                liResaltadoMagnitud.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                PointPairList pplResaltadoFaseSuperior = new PointPairList();
                pplResaltadoFaseSuperior.Add(this.controladorBode.InicioEjeX, 180);
                pplResaltadoFaseSuperior.Add(this.controladorBode.FinEjeX, 180);
                LineItem liFaseResaltadoSuperior = this.gpFase.AddCurve("", pplResaltadoFaseSuperior, Color.Red, SymbolType.None);
                liFaseResaltadoSuperior.Line.Width = 2f;
                liFaseResaltadoSuperior.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                PointPairList pplResaltadoFase = new PointPairList();
                pplResaltadoFase.Add(this.controladorBode.InicioEjeX, -180);
                pplResaltadoFase.Add(this.controladorBode.FinEjeX, -180);
                LineItem liFaseResaltado = this.gpFase.AddCurve("", pplResaltadoFase, Color.Red, SymbolType.None);
                liFaseResaltado.Line.Width = 2f;
                liFaseResaltado.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                this.primeraEjecucion = false;

                //Indicamos que los cálculos finalizaron.
                this.Cursor = Cursors.Default;

                reestablecerEscala();

                if (this.controladorBode.CurvasIndividuales.Count > 0 && this.controladorBode.CurvasParciales.Count > 0)
                    for (int i = 0; i < this.controladorBode.CurvasParciales.Count; i++)
                    {
                        this.indiceCurvaActual++;
                        mostrarCurvas();
                    }
        }

        #endregion



        public FrmCompara(Historial his)
        {
            InitializeComponent();
            //Para que la tabla ocupe dos columnas
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel1.GetControlFromPosition(0, 2), 2);
            
            //Lista de los controles zedGraph
            controles = new List<ZedGraphControl>();
            controles.Add(zedGraphControl1);
            controles.Add(zedGraphControl2);
            controles.Add(zedGraphControl3);
            controles.Add(zedGraphControl4);
            
            //Historial - Apunta al historial del form ppal
            h = his;
        }

        private void FrmCompara_Load(object sender, EventArgs e)
        {
            //Se crea un panel y un ZGC no visibles, para la maximizacion
            p = new TableLayoutPanel();
            p.Dock = DockStyle.Fill;
            p.ColumnCount = 1;
            p.Location = new System.Drawing.Point(0, 0);
            p.Name = "p";
            p.RowCount = 2;
            p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent,100F));
            p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute,110F));
            
            zedMax = new ZedGraphControl();            
            zedMax.Anchor = AnchorStyles.Top;
            zedMax.Dock = DockStyle.Fill;
            zedMax.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(Zoom);
            //zedMax.PointValueEvent += new ZedGraphControl.PointValueHandler(infoPunto);
            zedMax.DoubleClick += new System.EventHandler(minimizar);

            dgvDatos.Rows.Add(2);

            this.gpMagnitud1 = zedGraphControl1.GraphPane;
            this.gpFase1 = zedGraphControl2.GraphPane;

            this.gpMagnitud = zedGraphControl3.GraphPane;
            this.gpFase = zedGraphControl4.GraphPane;

            establecerPropiedadesPrimarias1();

            establecerPropiedadesPrimarias();

            Formula1 = h.formulas[0];

            Formula = h.formulas[1];

            if (Formula1 != null)
                this.metodoBtnSig_Click1();

            if (Formula != null)
                this.metodoBtnSig_Click();

            for (int i = 0; i < 2; i++)
                this.rellenarFilaTabla(i);

            foreach (DataGridViewRow fila in dgvDatos.Rows)
                fila.Selected = false;

            ////Instancia la tabla de datos
            //dgvDatos.Rows.Add(2);

            ////Da formato a los zedGraphControls y a la tabla.
            //int cont = 0;
            //int x=0;
            //for(int i=0;i<controles.Count;i=i+2)
            //{
            //    if (i == 0)
            //    {
            //        this.gpMagnitud1 = controles[i].GraphPane;
            //        this.gpFase1 = controles[i + 1].GraphPane;
            //    }
            //    else
            //    {
            //        this.gpMagnitud2 = controles[i].GraphPane;
            //        this.gpFase2 = controles[i + 1].GraphPane;
            //    }
            //    this.rellenarFilaTabla(cont);

            //    //formatoZed(z, cont);
            //    //z.PointValueEvent += new ZedGraphControl.PointValueHandler(infoPunto);
            //    controles[i].ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(Zoom);
            //    //controles[i].DoubleClick += new System.EventHandler(maximizar);

            //    controles[i + 1].ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(Zoom);
            //    //controles[i + 1].DoubleClick += new System.EventHandler(maximizar);

            //    if(i==0)
            //        x=0;
            //    else
            //        x=1;

            //    asignarGrafica(controles[i],controles[i+1],h.formulas[x], cont++); // Se asignan las gráficas del historial
                
            //    refresh(controles[i]);
            //    refresh(controles[i+1]);

            //    if(i==0)
            //    {
            //    controles[i].ZoomOutAll(this.gpMagnitud1);
            //    controles[i+1].ZoomOutAll(this.gpFase1);
            //    }
            //    else
            //    {
            //    controles[i].ZoomOutAll(this.gpMagnitud2);
            //    controles[i+1].ZoomOutAll(this.gpFase2);
            //    }
            //}

            //foreach (DataGridViewRow fila in dgvDatos.Rows)
            //    fila.Selected = false;
        }

        //Obsoleto
        //private void formatoZed(ZedGraphControl zedC,int nro)
        //{
        //    //zedC.GraphPane.XAxis.Title.Text = "Frecuencia (rad/s)";
        //    //zedC.GraphPane.XAxis.Type = AxisType.Log;
        //    //zedC.GraphPane.XAxis.Scale.MinAuto = true;
        //    //zedC.GraphPane.XAxis.Scale.MaxAuto = true;
        //    //zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;

        //    //zedC.GraphPane.YAxis.Title.Text = "Magnitud(db)";
        //    //zedC.GraphPane.YAxis.Scale.MinAuto = true;
        //    //zedC.GraphPane.YAxis.Scale.MaxAuto = true;
        //    //zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;

        //    //zedC.IsShowPointValues = true;

        //    //zedC.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

        //    //zedC.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

        //    //zedC.IsShowPointValues = true;
        //    //zedC.GraphPane.XAxis.Scale.MinGrace = 0;
        //    //zedC.GraphPane.XAxis.Scale.MaxGrace = 0;

        //    //zedC.GraphPane.XAxis.IsVisible = true;
        //    //zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;
        //    //zedC.GraphPane.XAxis.MajorGrid.IsZeroLine = false;

        //    //zedC.GraphPane.YAxis.IsVisible = true;
        //    //zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;
        //    //zedC.GraphPane.YAxis.MajorGrid.IsZeroLine = false;

        //    //zedC.GraphPane.XAxis.Title.IsVisible = false;
        //    //zedC.GraphPane.YAxis.Title.IsVisible = false;
        //    //zedC.GraphPane.Chart.Border.IsVisible = false;

        //    //zedC.GraphPane.Title.IsVisible = true;
            
        //    if (nro == 0)
        //    {
        //    zedC.GraphPane.Title.Text = "Gráfica 1 - Magnitud";
        //    zedC.GraphPane.XAxis.Title.Text = "Frecuencia (rad/s)";
        //    zedC.GraphPane.XAxis.Type = AxisType.Log;
        //    zedC.GraphPane.XAxis.Scale.MinAuto = true;
        //    zedC.GraphPane.XAxis.Scale.MaxAuto = true;
        //    zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;

        //    zedC.GraphPane.YAxis.Title.Text = "Magnitud(db)";
        //    zedC.GraphPane.YAxis.Scale.MinAuto = true;
        //    zedC.GraphPane.YAxis.Scale.MaxAuto = true;
        //    zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;

        //    zedC.IsShowPointValues = true;

        //    zedC.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

        //    zedC.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);
        //    }
        //    if (nro == 1)
        //    {
        //        zedC.GraphPane.Title.Text = "Gráfica 1 - Fase";
        //        zedC.GraphPane.XAxis.Title.Text = "Frecuencia (rad/s)";
        //        zedC.GraphPane.XAxis.Type = AxisType.Log;
        //        zedC.GraphPane.XAxis.Scale.MinAuto = true;
        //        zedC.GraphPane.XAxis.Scale.MaxAuto = true;
        //        zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;

        //        zedC.GraphPane.YAxis.Title.Text = "Magnitud(db)";
        //        zedC.GraphPane.YAxis.Scale.MinAuto = true;
        //        zedC.GraphPane.YAxis.Scale.MaxAuto = true;
        //        zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;

        //        zedC.IsShowPointValues = true;

        //        zedC.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

        //        zedC.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);
        //    }
        //    if (nro == 2)
        //    {
        //        zedC.GraphPane.Title.Text = "Gráfica 2 - Magnitud";
        //        zedC.GraphPane.XAxis.Title.Text = "Frecuencia (rad/s)";
        //        zedC.GraphPane.XAxis.Type = AxisType.Log;
        //        zedC.GraphPane.XAxis.Scale.MinAuto = true;
        //        zedC.GraphPane.XAxis.Scale.MaxAuto = true;
        //        zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;

        //        zedC.GraphPane.YAxis.Title.Text = "Magnitud(db)";
        //        zedC.GraphPane.YAxis.Scale.MinAuto = true;
        //        zedC.GraphPane.YAxis.Scale.MaxAuto = true;
        //        zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;

        //        zedC.IsShowPointValues = true;

        //        zedC.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

        //        zedC.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);
        //    }
        //    if (nro == 3)
        //    {
        //        zedC.GraphPane.Title.Text = "Gráfica 2 - Fase";
        //        zedC.GraphPane.XAxis.Title.Text = "Frecuencia (rad/s)";
        //        zedC.GraphPane.XAxis.Type = AxisType.Log;
        //        zedC.GraphPane.XAxis.Scale.MinAuto = true;
        //        zedC.GraphPane.XAxis.Scale.MaxAuto = true;
        //        zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;

        //        zedC.GraphPane.YAxis.Title.Text = "Magnitud(db)";
        //        zedC.GraphPane.YAxis.Scale.MinAuto = true;
        //        zedC.GraphPane.YAxis.Scale.MaxAuto = true;
        //        zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;

        //        zedC.IsShowPointValues = true;

        //        zedC.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

        //        zedC.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);
        //    }
           
        //    //zedC.GraphPane.Title.FontSpec.Size = 12F;

        //    //zedC.GraphPane.Border.IsVisible = false;
        //    //zedC.GraphPane.Legend.IsVisible = false;

        //    //zedC.AxisChange();
        //}

        //private void reestablecerEscala()
        //{
        //    //Reestablecemos la escala de las gráficas.
        //    this.zgcMagnitud.AxisChange();
        //    this.zgcFase.AxisChange();

        //    //Reestablecemos los valores mínimos y máximos de las gráficas.
        //    this.gpMagnitud.YAxis.Scale.Min = this.controladorBode.InicioEjeYMagnitud;
        //    this.gpMagnitud.YAxis.Scale.Max = this.controladorBode.FinEjeYMagnitud;

        //    this.gpMagnitud.XAxis.Scale.Min = this.controladorBode.InicioEjeX;
        //    this.gpMagnitud.XAxis.Scale.Max = this.controladorBode.FinEjeX;

        //    this.gpFase.YAxis.Scale.Min = this.controladorBode.InicioEjeYFase;
        //    this.gpFase.YAxis.Scale.Max = this.controladorBode.FinEjeYFase;

        //    this.gpFase.XAxis.Scale.Min = this.controladorBode.InicioEjeX;
        //    this.gpFase.XAxis.Scale.Max = this.controladorBode.FinEjeX;

        //    //Refrescamos las gráficas.
        //    this.zgcMagnitud.Invalidate();
        //    this.zgcFase.Invalidate();
        //}

        private void refresh(ZedGraphControl zedC)
        {
            zedC.AxisChange();
            zedC.RestoreScale(zedC.GraphPane);
            zedC.Refresh();
        }

        private void asignarGrafica(ZedGraphControl zedCMagnitud,ZedGraphControl zedCFase,Formula formula, int cont)
        {
            establecerPropiedadesPrimarias(zedCMagnitud,zedCFase,cont);

            if(formula!=null)
                this.metodoBtnAvanzarClick(zedCMagnitud,zedCFase,formula);
        
        }

        public void metodoBtnAvanzarClick(ZedGraphControl zedCMagnitud, ZedGraphControl zedCFase, Formula formula)
        {

                List<LineItem> lineItemsCurvasIndividualesMagnitud = new List<LineItem>();

                List<LineItem> lineItemsCurvasIndividualesFase = new List<LineItem>();

                List<LineItem> lineItemsCurvasParcialesMagnitud = new List<LineItem>();

                List<LineItem> lineItemsCurvasParcialesFase = new List<LineItem>();

                List<LineItem> lineItemsPuntosCorte = new List<LineItem>();
        
                List<LineItem> lineItemsPuntosCruceGanancia = new List<LineItem>();

                List<LineItem> lineItemsPuntosCruceFase = new List<LineItem>();

                ControladorBode controladorBode;
                //Indicamos que se están ejecutando los cálculos.
                this.Cursor = Cursors.WaitCursor;

                //Generamos el controlador, que tiene las curvas individuales, parciales y puntos de corte.
                controladorBode = new ControladorBode(formula.K, formula.N1, formula.T1, formula.T2,
                    formula.Td, formula.N2, formula.T3, formula.T4, formula.Wn, formula.Psi);

                //Generamos todos los LineItem de las curvas individuales y parciales.
                //Luego los iremos mostrando y ocultando a medida que sea necesario.
                if (controladorBode.CurvasIndividuales.Count > 0 && controladorBode.CurvasParciales.Count > 0)
                {
                    lineItemsCurvasIndividualesMagnitud = generarLineItemsCurvasIndividualesMagnitud(controladorBode,zedCMagnitud);
                    lineItemsCurvasIndividualesFase = generarLineItemsCurvasIndividualesFase(controladorBode,zedCFase);
                    lineItemsCurvasParcialesMagnitud = generarLineItemsCurvasParcialesMagnitud(controladorBode,zedCMagnitud);
                    lineItemsCurvasParcialesFase = generarLineItemsCurvasParcialesFase(controladorBode,zedCFase);

                    lineItemsPuntosCorte = generarLineItemsPuntosCorte(controladorBode, zedCMagnitud);

                    lineItemsPuntosCruceGanancia = generarLineItemsPuntosCruceGanancia(controladorBode, zedCMagnitud, zedCFase);
                    lineItemsPuntosCruceFase = generarLineItemsPuntosCruceFase(controladorBode, zedCMagnitud, zedCFase);
                }

                //Resaltamos la gráfica de magnitud en magnitud = 0, y la gráfica de
                //fase en fase = -180,.
                PointPairList pplResaltadoMagnitud = new PointPairList();
                pplResaltadoMagnitud.Add(controladorBode.InicioEjeX, 0);
                pplResaltadoMagnitud.Add(controladorBode.FinEjeX, 0);
                LineItem liResaltadoMagnitud = zedCMagnitud.GraphPane.AddCurve("", pplResaltadoMagnitud, Color.Red, SymbolType.None);
                liResaltadoMagnitud.Line.Width = 2f;
                liResaltadoMagnitud.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                PointPairList pplResaltadoFaseSuperior = new PointPairList();
                pplResaltadoFaseSuperior.Add(controladorBode.InicioEjeX, 180);
                pplResaltadoFaseSuperior.Add(controladorBode.FinEjeX, 180);
                LineItem liFaseResaltadoSuperior = zedCFase.GraphPane.AddCurve("", pplResaltadoFaseSuperior, Color.Red, SymbolType.None);
                liFaseResaltadoSuperior.Line.Width = 2f;
                liFaseResaltadoSuperior.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                PointPairList pplResaltadoFase = new PointPairList();
                pplResaltadoFase.Add(controladorBode.InicioEjeX, -180);
                pplResaltadoFase.Add(controladorBode.FinEjeX, -180);
                LineItem liFaseResaltado = zedCFase.GraphPane.AddCurve("", pplResaltadoFase, Color.Red, SymbolType.None);
                liFaseResaltado.Line.Width = 2f;
                liFaseResaltado.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                //Indicamos que los cálculos finalizaron.
                this.Cursor = Cursors.Default;

                reestablecerEscala(controladorBode,zedCMagnitud,zedCFase);

                for (int indiceCurvaActual = 0; indiceCurvaActual < controladorBode.CurvasIndividuales.Count;indiceCurvaActual++ )
                {
                    mostrarCurvas(controladorBode, indiceCurvaActual, lineItemsCurvasIndividualesMagnitud, lineItemsCurvasIndividualesFase, lineItemsCurvasParcialesMagnitud, lineItemsCurvasParcialesFase, lineItemsPuntosCorte, lineItemsPuntosCruceGanancia, lineItemsPuntosCruceFase,zedCMagnitud,zedCFase);
                }
        }

        private void establecerPropiedadesPrimarias(ZedGraphControl zedCMagnitud, ZedGraphControl zedCFase,int cont)
        {
            //Gráfica de magnitud.
            //zedCMagnitud.GraphPane.Title.Text = "";

            //zedCMagnitud.GraphPane.XAxis.Title.Text = "Frecuencia (rad/s)";
            //zedCMagnitud.GraphPane.XAxis.Type = AxisType.Log;
            //zedCMagnitud.GraphPane.XAxis.Scale.MinAuto = true;
            //zedCMagnitud.GraphPane.XAxis.Scale.MaxAuto = true;
            //zedCMagnitud.GraphPane.XAxis.MajorGrid.IsVisible = true;

            //zedCMagnitud.GraphPane.YAxis.Title.Text = "Magnitud(db)";
            //zedCMagnitud.GraphPane.YAxis.Scale.MinAuto = true;
            //zedCMagnitud.GraphPane.YAxis.Scale.MaxAuto = true;
            //zedCMagnitud.GraphPane.YAxis.MajorGrid.IsVisible = true;

            ////Gráfica de fase.
            //zedCFase.GraphPane.Title.Text = "";

            //zedCFase.GraphPane.XAxis.Title.Text = "Frecuencia (rad/s)";
            //zedCFase.GraphPane.XAxis.Type = AxisType.Log;
            //zedCFase.GraphPane.XAxis.Scale.MinAuto = true;
            //zedCFase.GraphPane.XAxis.Scale.MaxAuto = true;
            //zedCFase.GraphPane.XAxis.MajorGrid.IsVisible = true;

            //zedCFase.GraphPane.YAxis.Title.Text = "Fase (grados)";
            //zedCFase.GraphPane.YAxis.Scale.MinAuto = true;
            //zedCFase.GraphPane.YAxis.Scale.MaxAuto = true;
            //zedCFase.GraphPane.YAxis.MajorGrid.IsVisible = true;

            

            //añadido Magnitud
                zedCMagnitud.IsShowPointValues = true;
                zedCMagnitud.GraphPane.XAxis.Scale.MinGrace = 0;
                zedCMagnitud.GraphPane.XAxis.Scale.MaxGrace = 0;
                //zedCMagnitud.GraphPane.X2Axis.Scale.MinGrace = 0;
                //zedCMagnitud.GraphPane.X2Axis.Scale.MaxGrace = 0;

                zedCMagnitud.GraphPane.XAxis.Type = AxisType.Log;
                zedCMagnitud.GraphPane.XAxis.IsVisible = true;
                zedCMagnitud.GraphPane.XAxis.MajorGrid.IsVisible = true;
                zedCMagnitud.GraphPane.XAxis.MajorGrid.IsZeroLine = false;

                //zedCMagnitud.GraphPane.X2Axis.Type = AxisType.Log;
                //zedCMagnitud.GraphPane.X2Axis.IsVisible = true;
                //zedCMagnitud.GraphPane.X2Axis.MajorGrid.IsVisible = true;
                //zedCMagnitud.GraphPane.X2Axis.MajorGrid.IsZeroLine = false;

                zedCMagnitud.GraphPane.YAxis.IsVisible = true;
                zedCMagnitud.GraphPane.YAxis.MajorGrid.IsVisible = true;
                zedCMagnitud.GraphPane.YAxis.MajorGrid.IsZeroLine = false;

                //zedCMagnitud.GraphPane.Y2Axis.IsVisible = true;
                //zedCMagnitud.GraphPane.Y2Axis.MajorGrid.IsVisible = true;
                //zedCMagnitud.GraphPane.Y2Axis.MajorGrid.IsZeroLine = false;

                zedCMagnitud.GraphPane.XAxis.Title.IsVisible = false;
                zedCMagnitud.GraphPane.YAxis.Title.IsVisible = false;
                //zedCMagnitud.GraphPane.X2Axis.Title.IsVisible = false;
                //zedCMagnitud.GraphPane.Y2Axis.Title.IsVisible = false;
                zedCMagnitud.GraphPane.Chart.Border.IsVisible = false;

                zedCMagnitud.GraphPane.Title.IsVisible = true;
                if (cont == 0)
                {
                    zedCMagnitud.GraphPane.Title.Text = "Gráfica 1 - Magnitud";
                }
                else
                {
                    zedCMagnitud.GraphPane.Title.Text = "Gráfica 2 - Magnitud";
                }
                zedCMagnitud.GraphPane.Title.FontSpec.Size = 12F;

                zedCMagnitud.GraphPane.Border.IsVisible = false;
                zedCMagnitud.GraphPane.Legend.IsVisible = false;

                zedCMagnitud.IsShowPointValues = true;
                zedCMagnitud.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

                zedCMagnitud.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

                zedCMagnitud.AxisChange();

                zedCMagnitud.AxisChange();

            //Añadido Fase

                zedCFase.IsShowPointValues = true;
                zedCFase.GraphPane.XAxis.Scale.MinGrace = 0;
                zedCFase.GraphPane.XAxis.Scale.MaxGrace = 0;
                //zedCFase.GraphPane.X2Axis.Scale.MinGrace = 0;
                //zedCFase.GraphPane.X2Axis.Scale.MaxGrace = 0;

                zedCFase.GraphPane.XAxis.Type = AxisType.Log;
                zedCFase.GraphPane.XAxis.IsVisible = true;
                zedCFase.GraphPane.XAxis.MajorGrid.IsVisible = true;
                zedCFase.GraphPane.XAxis.MajorGrid.IsZeroLine = false;

                //zedCFase.GraphPane.X2Axis.Type = AxisType.Log;
                //zedCFase.GraphPane.X2Axis.IsVisible = true;
                //zedCFase.GraphPane.X2Axis.MajorGrid.IsVisible = true;
                //zedCFase.GraphPane.X2Axis.MajorGrid.IsZeroLine = false;

                zedCFase.GraphPane.YAxis.IsVisible = true;
                zedCFase.GraphPane.YAxis.MajorGrid.IsVisible = true;
                zedCFase.GraphPane.YAxis.MajorGrid.IsZeroLine = false;

                //zedCFase.GraphPane.Y2Axis.IsVisible = true;
                //zedCFase.GraphPane.Y2Axis.MajorGrid.IsVisible = true;
                //zedCFase.GraphPane.Y2Axis.MajorGrid.IsZeroLine = false;

                zedCFase.GraphPane.XAxis.Title.IsVisible = false;
                zedCFase.GraphPane.YAxis.Title.IsVisible = false;
                //zedCFase.GraphPane.X2Axis.Title.IsVisible = false;
                //zedCFase.GraphPane.Y2Axis.Title.IsVisible = false;
                zedCFase.GraphPane.Chart.Border.IsVisible = false;

                zedCFase.GraphPane.Title.IsVisible = true;
                if (cont == 0)
                {
                    zedCFase.GraphPane.Title.Text = "Gráfica 1 - Fase";
                }
                else
                {
                    zedCFase.GraphPane.Title.Text = "Gráfica 2 - Fase";
                }
                zedCFase.GraphPane.Title.FontSpec.Size = 12F;

                zedCFase.GraphPane.Border.IsVisible = false;
                zedCFase.GraphPane.Legend.IsVisible = false;

                zedCFase.IsShowPointValues = true;
                zedCFase.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

                zedCFase.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

                zedCFase.AxisChange();
        }

        private void rellenarFilaTabla(int fil)
        { 
            DataTable t = h.tablas[fil];
            try
            {
                dgvDatos.Rows[fil].Cells[0].Value = "" + (fil + 1); //Grafica

                dgvDatos.Rows[fil].Cells[1].Value = "" + t.Rows[0][1]; //Ganancia

                dgvDatos.Rows[fil].Cells[2].Value = "" + t.Rows[1][1]; //Fase
            }
            catch
            { }
        }

        private void Zoom(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            sender.GraphPane.XAxis.CrossAuto = false;
            sender.GraphPane.YAxis.CrossAuto = false;

            if ((sender.GraphPane.XAxis.Scale.Max - sender.GraphPane.XAxis.Scale.Min) < 0.2)
            {
                sender.ZoomOut(sender.GraphPane);
            }
        }

        //private void maximizar(object sender, EventArgs e)
        //{
        //    //Identifica que gráfica generó el evento
        //    int nro = controles.IndexOf((ZedGraphControl)sender);

        //    //Oculta el formulario visible
        //    tableLayoutPanel1.Hide();

        //    zedMax = controles[nro];

        //    zedMax.GraphPane = controles[nro].GraphPane;
        //    if (nro == 0)
        //        zedMax.GraphPane = gpMagnitud1.Clone();
        //    if (nro == 1)
        //        zedMax.GraphPane = gpFase1.Clone();
        //    if (nro == 2)
        //        zedMax.GraphPane = gpMagnitud2.Clone();
        //    if (nro == 3)
        //        zedMax.GraphPane = gpFase2.Clone();
        //    //Crea un nuevo ZedGraphControl con la misma gráfica que el control en donde se hizo doble clic
        //    //formatoZed(zedMax, nro);
        //    //asignarGrafica(zedMax, nro);           
        //    refresh(zedMax);

        //    //Se agregan las referencias para las curvas
        //    zedMax.GraphPane.Legend.IsVisible = true;
        //    zedMax.GraphPane.Legend.IsShowLegendSymbols = true;
        //    zedMax.GraphPane.Legend.Border.IsVisible = false;

        //    foreach (CurveItem curva in zedMax.GraphPane.CurveList)
        //        curva.Label.IsVisible = false;

        //    //try{
        //    //zedMax.GraphPane.CurveList["Polos"].Label.IsVisible = true;
        //    //zedMax.GraphPane.CurveList["Ceros"].Label.IsVisible = true;
        //    //zedMax.GraphPane.CurveList["Root Locus"].Label.IsVisible = true;
        //    //zedMax.GraphPane.CurveList["Punto de Ruptura"].Label.IsVisible = true;
        //    //zedMax.GraphPane.CurveList["Asintotas"].Label.IsVisible = true;
        //    //}
        //    //catch{ }

        //    try
        //    {
        //        if (nro == 0 || nro == 1)
        //            nro = 0;
        //        if (nro == 2 || nro == 3)
        //            nro = 1;
        //        dgvDatos.Rows[nro].Selected = true;
        //        p.Controls.Add(zedMax, 0, 0);
        //        p.Controls.Add(dgvDatos, 0, 1);
        //        this.Controls.Add(p);
        //    }
        //    catch { }
        //}
        
        private void minimizar(object sender, EventArgs e)
        {
            //Vacía el panel y se lo quita del form
            for (int i = 0; i < p.Controls.Count; i++)
                p.Controls.RemoveAt(i);

            this.Controls.Remove(p);
            
            //Vuelve a hacer visible el form comun
            foreach (DataGridViewRow fila in dgvDatos.Rows)
                fila.Selected = false;

            tableLayoutPanel1.Controls.Add(dgvDatos, 0, 2);
            tableLayoutPanel1.Show();
        }

        /*public double calculaK(PointPair ptoLG)
        {
            double valorPolos = 1;
            double valorCeros = 1;

            foreach (PointPair p in polos)
            {
                Vector vec = new Vector(Math.Round(ptoLG.X - p.X, 5), Math.Round(ptoLG.Y - p.Y, 5));
                valorPolos = valorPolos * vec.Length;
            }
            if (!(ceros.Count == 0)) // condicion para verificar que haya ceros, sino hay el valor por defecto de valorceros es 1 y no altera la division 
            {
                foreach (PointPair z in ceros)
                {
                    Vector vec = new Vector(Math.Round(ptoLG.X - z.X, 5), Math.Round(ptoLG.Y - z.Y, 5));
                    valorCeros = valorCeros * vec.Length;
                }
            }

            return Math.Round(valorPolos / valorCeros, 2);
        }
        */

        private string infoPunto(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pto = curve[iPt];
            string respuesta = "X: " + Math.Round(pto.X, 3) + "\r\nY: " + Math.Round(pto.Y, 3) + "\r\nValor K: " + pto.Z;

            return respuesta;
        }

        /*void btnDatos_Click(object sender, EventArgs e)
        {
            ToolStripDropDown popup = new ToolStripDropDown();
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;

            ToolStripControlHost host = new ToolStripControlHost(h.dgv);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            popup.Items.Add(host);
            popup.Show(this, new Point(15, 15));
        }
        */

        private void MyContextMenuBuilder(ZedGraphControl control, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            for (int i = 0; i < menuStrip.Items.Count; i++)
            {
                if ((string)menuStrip.Items[i].Tag == "set_default" || (string)menuStrip.Items[i].Tag == "show_val")
                    menuStrip.Items.RemoveAt(i);
            }
        }

        private string MiPuntoHandler(ZedGraphControl zgc, GraphPane gp, CurveItem curve, int iPt)
        {
            //Obtenemos el punto.
            PointPair punto = curve[iPt];

            //Devolvemos una cadena que muestra información del punto.
            return curve.Label.Text + "\n (" + punto.X.ToString("f2") + " ; " + punto.Y.ToString("f1") + ")";
        }

        private List<LineItem> generarLineItemsCurvasIndividualesMagnitud(ControladorBode controladorBode,ZedGraphControl zedCMagnitud)
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < controladorBode.CurvasIndividuales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < controladorBode.CurvasIndividuales[indiceCurva].PuntosMagnitud.Count; indicePunto++)
                    pointPairList.Add(controladorBode.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][0],
                        controladorBode.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][1]);

                LineItem lineItem = zedCMagnitud.GraphPane.AddCurve(controladorBode.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                    this.coloresCurvasIndividuales[indiceCurva], SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_INDIVIDUAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        private List<LineItem> generarLineItemsCurvasIndividualesFase(ControladorBode controladorBode, ZedGraphControl zedCFase)
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < controladorBode.CurvasIndividuales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < controladorBode.CurvasIndividuales[indiceCurva].PuntosFase.Count; indicePunto++)
                    pointPairList.Add(controladorBode.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][0],
                        controladorBode.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][1]);

                LineItem lineItem = zedCFase.GraphPane.AddCurve(controladorBode.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                    this.coloresCurvasIndividuales[indiceCurva], SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_INDIVIDUAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        private List<LineItem> generarLineItemsCurvasParcialesMagnitud(ControladorBode controladorBode, ZedGraphControl zedCMagnitud)
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < controladorBode.CurvasParciales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < controladorBode.CurvasParciales[indiceCurva].PuntosMagnitud.Count; indicePunto++)
                    pointPairList.Add(controladorBode.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][0],
                        controladorBode.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][1]);

                string nombre = "";

                if (indiceCurva + 1 == controladorBode.CurvasParciales.Count)
                {
                    nombre = "Curva Final";
                }
                else
                {
                    nombre = controladorBode.CurvasParciales[indiceCurva].Nombre;
                }

                LineItem lineItem = zedCMagnitud.GraphPane.AddCurve(nombre, pointPairList, this.colorCurvaParcial, SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_PARCIAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;


                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        private List<LineItem> generarLineItemsCurvasParcialesFase(ControladorBode controladorBode, ZedGraphControl zedCFase)
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada curva creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < controladorBode.CurvasParciales.Count; indiceCurva++)
            {
                PointPairList pointPairList = new PointPairList();
                for (int indicePunto = 0; indicePunto < controladorBode.CurvasParciales[indiceCurva].PuntosFase.Count; indicePunto++)
                    pointPairList.Add(controladorBode.CurvasParciales[indiceCurva].PuntosFase[indicePunto][0],
                        controladorBode.CurvasParciales[indiceCurva].PuntosFase[indicePunto][1]);

                string nombre = "";

                if (indiceCurva + 1 == controladorBode.CurvasParciales.Count)
                {
                    nombre = "Curva Final";
                }
                else
                {
                    nombre = controladorBode.CurvasParciales[indiceCurva].Nombre;
                }

                LineItem lineItem = zedCFase.GraphPane.AddCurve(nombre, pointPairList, this.colorCurvaParcial, SymbolType.None);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Line.Width = GROSOR_CURVA_PARCIAL;
                lineItem.Line.IsAntiAlias = true;
                lineItem.Line.IsSmooth = true;
                lineItem.Line.SmoothTension = 0.05f;

                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        private List<LineItem> generarLineItemsPuntosCorte(ControladorBode controladorBode, ZedGraphControl zedCMagnitud)
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Por cada punto de corte creamos un LineItem, lo agregamos al gráfico y enseguida lo ocultamos.
            for (int indiceCurva = 0; indiceCurva < controladorBode.CurvasIndividuales.Count; indiceCurva++)
            {
                //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
                if (controladorBode.CurvasIndividuales[indiceCurva].PuntoCorte != null)
                {
                    PointPairList pointPairList = new PointPairList();
                    pointPairList.Add(controladorBode.CurvasIndividuales[indiceCurva].PuntoCorte[0], controladorBode.CurvasIndividuales[indiceCurva].PuntoCorte[1]);

                    LineItem lineItem = zedCMagnitud.GraphPane.AddCurve("Punto de corte: " + controladorBode.CurvasIndividuales[indiceCurva].Nombre, pointPairList,
                         Color.Black, SymbolType.Diamond);
                    lineItem.IsVisible = false;
                    lineItem.Label.IsVisible = false;

                    lineItem.Symbol.Fill = new Fill(this.coloresCurvasIndividuales[indiceCurva]);
                    lineItem.Symbol.Border.Color = Color.Black;
                    lineItem.Symbol.Border.Width = 1.0f;
                    lineItem.Symbol.Size = 17.0f;
                    lineItem.Symbol.IsAntiAlias = true;

                    lineItems.Add(lineItem);
                }
                else
                {
                    //Debemos saber cuál punto de corte pertenece a cuál curva, así
                    //que debemos mantener una referencia.
                    lineItems.Add(null);
                }
            }

            return lineItems;
        }

        private void reestablecerEscala(ControladorBode controladorBode, ZedGraphControl zedCMagnitud, ZedGraphControl zedCFase)
        {

                zedCMagnitud.AxisChange();
                zedCFase.AxisChange();

            //Reestablecemos los valores mínimos y máximos de las gráficas.
            zedCMagnitud.GraphPane.YAxis.Scale.Min = controladorBode.InicioEjeYMagnitud;
            zedCMagnitud.GraphPane.YAxis.Scale.Max = controladorBode.FinEjeYMagnitud;

            zedCMagnitud.GraphPane.XAxis.Scale.Min = controladorBode.InicioEjeX;
            zedCMagnitud.GraphPane.XAxis.Scale.Max = controladorBode.FinEjeX;

            zedCFase.GraphPane.YAxis.Scale.Min = controladorBode.InicioEjeYFase;
            zedCFase.GraphPane.YAxis.Scale.Max = controladorBode.FinEjeYFase;

            zedCFase.GraphPane.XAxis.Scale.Min = controladorBode.InicioEjeX;
            zedCFase.GraphPane.XAxis.Scale.Max = controladorBode.FinEjeX;

                zedCMagnitud.Invalidate();
                zedCFase.Invalidate();

        }

        private List<LineItem> generarLineItemsPuntosCruceGanancia(ControladorBode controladorBode, ZedGraphControl zedCMagnitud,ZedGraphControl zedCFase)
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (controladorBode.CruceGanancia[0, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)controladorBode.CruceGanancia[0, 0], (double)controladorBode.CruceGanancia[0, 1]);

                LineItem lineItem = zedCMagnitud.GraphPane.AddCurve("Cruce de Ganancia", pointPairList, Color.Black, SymbolType.Triangle);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Symbol.Fill = new Fill(Color.Yellow);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            if (controladorBode.CruceGanancia[1, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)controladorBode.CruceGanancia[1, 0], (double)controladorBode.CruceGanancia[1, 1]);

                LineItem lineItem = zedCFase.GraphPane.AddCurve("Margen de Fase", pointPairList, Color.Black, SymbolType.Square);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;
                lineItem.Symbol.Fill = new Fill(Color.Yellow);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);

                //Agregamos una línea desde la marca del margen de fase hasta la línea de -180 grados.
                PointPairList ppl = new PointPairList();
                ppl.Add((double)controladorBode.CruceGanancia[1, 0], (double)controladorBode.CruceGanancia[1, 1]);
                ppl.Add((double)controladorBode.CruceGanancia[1, 0], -180);
                LineItem li = zedCFase.GraphPane.AddCurve("", ppl, Color.Black, SymbolType.None);
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                li.Line.Width = 2f;
                li.IsVisible = false;
                li.Label.IsVisible = false;

                lineItems.Add(li);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            return lineItems;
        }

        private List<LineItem> generarLineItemsPuntosCruceFase(ControladorBode controladorBode, ZedGraphControl zedCMagnitud,ZedGraphControl zedCFase)
        {
            List<LineItem> lineItems = new List<LineItem>();

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (controladorBode.CruceFase[0, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)controladorBode.CruceFase[0, 0], (double)controladorBode.CruceFase[0, 1]);

                LineItem lineItem = zedCFase.GraphPane.AddCurve("Cruce de Fase", pointPairList,
                    Color.Black, SymbolType.Triangle);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;

                lineItem.Symbol.Fill = new Fill(Color.White);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            //Algunas curvas pueden no tener punto de corte, por lo que no habrá que dibujar nada.
            if (controladorBode.CruceFase[1, 0] != null)
            {
                PointPairList pointPairList = new PointPairList();
                pointPairList.Add((double)controladorBode.CruceFase[1, 0], (double)controladorBode.CruceFase[1, 1]);

                LineItem lineItem = zedCMagnitud.GraphPane.AddCurve("Margen de Ganancia", pointPairList, Color.Black, SymbolType.Square);
                lineItem.IsVisible = false;
                lineItem.Label.IsVisible = false;
                lineItem.Symbol.Fill = new Fill(Color.White);
                lineItem.Symbol.Border.Color = Color.Black;
                lineItem.Symbol.Border.Width = 1.0f;
                lineItem.Symbol.Size = 17.0f;
                lineItem.Symbol.IsAntiAlias = true;

                lineItems.Add(lineItem);

                //Agregamos una línea desde la marca del margen de ganancia hasta la línea de 0 decibeles.
                PointPairList ppl = new PointPairList();
                ppl.Add((double)controladorBode.CruceFase[1, 0], (double)controladorBode.CruceFase[1, 1]);
                ppl.Add((double)controladorBode.CruceFase[1, 0], 0);
                LineItem li = zedCMagnitud.GraphPane.AddCurve("", ppl, Color.Black, SymbolType.None);
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                li.Line.Width = 2f;
                li.IsVisible = false;
                li.Label.IsVisible = false;

                lineItems.Add(li);
            }
            else
            {
                //Debemos saber cuál punto de corte pertenece a cuál curva, así
                //que debemos mantener una referencia.
                lineItems.Add(null);
            }

            return lineItems;
        }

        private void mostrarCurvas(ControladorBode controladorBode, int indiceCurvaActual, List<LineItem> lineItemsCurvasIndividualesMagnitud, List<LineItem> lineItemsCurvasIndividualesFase, List<LineItem> lineItemsCurvasParcialesMagnitud, List<LineItem> lineItemsCurvasParcialesFase, List<LineItem> lineItemsPuntosCorte, List<LineItem> lineItemsPuntosCruceGanancia, List<LineItem> lineItemsPuntosCruceFase, ZedGraphControl zedCMagnitud, ZedGraphControl zedCFase)
        {
            //Curvas individuales.
                //Mostramos las curvas hasta el índice actual, y ocultamos las restantes.
                int cantidadCurvasIndividuales = controladorBode.CurvasIndividuales.Count;
                for (int i = 0; i < cantidadCurvasIndividuales; i++)
                {
                    if (i <= indiceCurvaActual)
                    {
                        lineItemsCurvasIndividualesMagnitud[i].IsVisible = true;
                        lineItemsCurvasIndividualesMagnitud[i].Label.IsVisible = true;
                        lineItemsCurvasIndividualesFase[i].IsVisible = true;
                        lineItemsCurvasIndividualesFase[i].Label.IsVisible = true;
                    }
                    else
                    {
                        lineItemsCurvasIndividualesMagnitud[i].IsVisible = false;
                        lineItemsCurvasIndividualesMagnitud[i].Label.IsVisible = false;
                        lineItemsCurvasIndividualesFase[i].IsVisible = false;
                        lineItemsCurvasIndividualesFase[i].Label.IsVisible = false;
                    }
                }

                //Puntos de corte.
                //Mostramos los puntos del índice actual, y ocultamos los demás. Tener en
                //cuenta que una curva puede no tener punto de corte.
                int cantidadPuntosCorte = controladorBode.CurvasIndividuales.Count;
                for (int i = 0; i < cantidadPuntosCorte; i++)
                {
                    if (lineItemsPuntosCorte[i] != null)
                    {
                        if (i == indiceCurvaActual)
                            lineItemsPuntosCorte[i].IsVisible = true;
                        else
                            lineItemsPuntosCorte[i].IsVisible = false;
                    }
                }

            //Curvas parciales.
            //Mostramos las curvas del índice actual, y ocultamos las demás.
            int cantidadCurvasParciales = controladorBode.CurvasParciales.Count;
            for (int i = 0; i < cantidadCurvasParciales; i++)
            {
                if (i == indiceCurvaActual)
                {
                    lineItemsCurvasParcialesMagnitud[i].IsVisible = true;
                    lineItemsCurvasParcialesMagnitud[i].Label.IsVisible = true;
                    lineItemsCurvasParcialesFase[i].IsVisible = true;
                    lineItemsCurvasParcialesFase[i].Label.IsVisible = true;
                }
                else
                {
                    lineItemsCurvasParcialesMagnitud[i].IsVisible = false;
                    lineItemsCurvasParcialesMagnitud[i].Label.IsVisible = false;
                    lineItemsCurvasParcialesFase[i].IsVisible = false;
                    lineItemsCurvasParcialesFase[i].Label.IsVisible = false;
                }
            }

            //Muestra los puntos de cruce de fase y magnitud solo en la última gráfica.
            if ((cantidadCurvasParciales - 1) == indiceCurvaActual)
            {
                if (lineItemsPuntosCruceGanancia[0] != null)
                {
                    lineItemsPuntosCruceGanancia[0].IsVisible = true;
                    lineItemsPuntosCruceGanancia[0].Label.IsVisible = true;
                }

                if (lineItemsPuntosCruceGanancia[1] != null)
                {
                    lineItemsPuntosCruceGanancia[1].IsVisible = true;
                    lineItemsPuntosCruceGanancia[1].Label.IsVisible = true;

                    //Si hay un cruce de ganancia, significa que hay margen de fase.
                    lineItemsPuntosCruceGanancia[2].IsVisible = true;
                }

                if (lineItemsPuntosCruceFase[0] != null)
                {
                    lineItemsPuntosCruceFase[0].IsVisible = true;
                    lineItemsPuntosCruceFase[0].Label.IsVisible = true;
                }

                if (lineItemsPuntosCruceFase[1] != null)
                {
                    lineItemsPuntosCruceFase[1].IsVisible = true;
                    lineItemsPuntosCruceFase[1].Label.IsVisible = true;

                    //Si hay un cruce de fase, significa que hay margen de ganancia.
                    lineItemsPuntosCruceFase[2].IsVisible = true;
                }


                //Declaramos un datatable para poder guardar los datos obtenidos del datagridview
                //this.dat = new DataTable();
                //this.dat.Columns.Add(new DataColumn("Margen", typeof(string)));
                //this.dat.Columns.Add(new DataColumn("Valor", typeof(string)));

                ////Mostramos el margen de ganancia.
                //if (this.controladorBode.MargenGanancia != null)
                //{
                //    dgvMargenes.Rows.Add("GANANCIA", this.controladorBode.MargenGanancia.ToString() + " dB");
                //    this.dat.Rows.Add("GANANCIA", this.controladorBode.MargenGanancia.ToString() + " dB");

                //    if (this.controladorBode.MargenGanancia >= 0)
                //    {
                //        dgvMargenes[1, 0].Style.BackColor = Color.LightBlue;
                //    }
                //    else
                //    {
                //        dgvMargenes[1, 0].Style.BackColor = Color.LightPink;
                //    }
                //}
                //else
                //{
                //    dgvMargenes.Rows.Add("GANANCIA", "INFINITO");
                //    this.dat.Rows.Add("GANANCIA", "INFINITO");
                //}

                ////Mostramos el margen de fase.
                //if (this.controladorBode.MargenFase != null)
                //{
                //    dgvMargenes.Rows.Add("FASE", this.controladorBode.MargenFase.ToString() + " °");
                //    this.dat.Rows.Add("FASE", this.controladorBode.MargenFase.ToString() + " º");

                //    if (this.controladorBode.MargenFase >= 0)
                //    {
                //        dgvMargenes[1, 1].Style.BackColor = Color.LightBlue;
                //    }
                //    else
                //    {
                //        dgvMargenes[1, 1].Style.BackColor = Color.LightPink;
                //    }
                //}
                //else
                //{
                //    dgvMargenes.Rows.Add("FASE", "INFINITO");
                //    this.dat.Rows.Add("FASE", "INFINITO");
                //}

            }
            //Quita los puntos de cruce de Fase y Magnitud si no se esta en la ULTIMA gráfica
            else
            {
                if (lineItemsPuntosCruceGanancia[0] != null)
                {
                    lineItemsPuntosCruceGanancia[0].IsVisible = false;
                    lineItemsPuntosCruceGanancia[0].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceGanancia[1] != null)
                {
                    lineItemsPuntosCruceGanancia[1].IsVisible = false;
                    lineItemsPuntosCruceGanancia[1].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceFase[0] != null)
                {
                    lineItemsPuntosCruceFase[0].IsVisible = false;
                    lineItemsPuntosCruceFase[0].Label.IsVisible = false;
                }

                if (lineItemsPuntosCruceFase[1] != null)
                {
                    lineItemsPuntosCruceFase[1].IsVisible = false;
                    lineItemsPuntosCruceFase[1].Label.IsVisible = false;
                }

            }

            reestablecerEscala(controladorBode, zedCMagnitud, zedCFase);

            ////Habilita el boton Adelante hasta que se dibuja la ultima curva
            //if (this.indiceCurvaActual == this.controladorBode.CurvasIndividuales.Count - 1)
            //{
            //    this.btnAvanzar.Enabled = false;
            //    btnGuardar.Enabled = true;
            //}
            //else
            //{
            //    this.btnAvanzar.Enabled = true;
            //}

            ////Habilita el boton Atras hasta que se dibuja la primera curva
            //if (this.indiceCurvaActual == 0)
            //{
            //    this.btnRetroceder.Enabled = false;
            //}
            //else
            //{
            //    this.btnRetroceder.Enabled = true;
            //}
        }

        private void zedGraphControl1_DoubleClick(object sender, EventArgs e)
        {
            if (this.graficaDobleActiva)
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.ColumnCount = 1;

                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[0].Height = 80;

                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.AutoSize;

                tableLayoutPanel1.Controls.Add(zedGraphControl1,0,0);
                zedGraphControl1.Dock=DockStyle.Fill ;
                tableLayoutPanel1.Controls.Add(dgvDatos,0,1);

                //zedGraphControl1.GraphPane.Legend.IsVisible = true;

                dgvDatos.Rows[0].Selected = true;

                this.graficaDobleActiva = false;
            }
            else
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.ColumnCount = 2;

                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[0].Height = 40;

                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[1].Height = 40;

                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.AutoSize;
                
                tableLayoutPanel1.Controls.Add(this.controles[0], 0, 0);
                tableLayoutPanel1.Controls.Add(this.controles[1], 0, 1);
                tableLayoutPanel1.Controls.Add(this.controles[2], 1, 0);
                tableLayoutPanel1.Controls.Add(this.controles[3], 1, 1);
                tableLayoutPanel1.Controls.Add(dgvDatos, 0, 2);

                //zedGraphControl1.GraphPane.Legend.IsVisible = false;

                dgvDatos.Rows[0].Selected = false ;

                this.graficaDobleActiva = true;
            }
        }

        private void zedGraphControl2_DoubleClick(object sender, EventArgs e)
        {
            if (this.graficaDobleActiva)
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.ColumnCount = 1;

                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[0].Height = 80;

                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.AutoSize;

                tableLayoutPanel1.Controls.Add(zedGraphControl2, 0, 0);
                zedGraphControl2.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(dgvDatos, 0, 1);

                //zedGraphControl2.GraphPane.Legend.IsVisible = true;

                dgvDatos.Rows[0].Selected = true;

                this.graficaDobleActiva = false;
            }
            else
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.ColumnCount = 2;

                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[0].Height = 40;

                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[1].Height = 40;

                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.AutoSize;

                tableLayoutPanel1.Controls.Add(this.controles[0], 0, 0);
                tableLayoutPanel1.Controls.Add(this.controles[1], 0, 1);
                tableLayoutPanel1.Controls.Add(this.controles[2], 1, 0);
                tableLayoutPanel1.Controls.Add(this.controles[3], 1, 1);
                tableLayoutPanel1.Controls.Add(dgvDatos, 0, 2);

                //zedGraphControl2.GraphPane.Legend.IsVisible = false;

                dgvDatos.Rows[0].Selected = false; ;

                this.graficaDobleActiva = true;
            }
        }

        private void zedGraphControl3_DoubleClick(object sender, EventArgs e)
        {
            if (zedGraphControl3.GraphPane.CurveList.Count != 0)
            {
                if (this.graficaDobleActiva)
                {
                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.RowCount = 2;
                    tableLayoutPanel1.ColumnCount = 1;

                    tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[0].Height = 80;

                    tableLayoutPanel1.RowStyles[1].SizeType = SizeType.AutoSize;

                    tableLayoutPanel1.Controls.Add(zedGraphControl3, 0, 0);
                    zedGraphControl3.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(dgvDatos, 0, 1);

                    //zedGraphControl3.GraphPane.Legend.IsVisible = true;

                    dgvDatos.Rows[1].Selected = true;

                    this.graficaDobleActiva = false;
                }
                else
                {
                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.RowCount = 2;
                    tableLayoutPanel1.ColumnCount = 2;

                    tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[0].Height = 40;

                    tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[1].Height = 40;

                    tableLayoutPanel1.RowStyles[2].SizeType = SizeType.AutoSize;

                    tableLayoutPanel1.Controls.Add(this.controles[0], 0, 0);
                    tableLayoutPanel1.Controls.Add(this.controles[1], 0, 1);
                    tableLayoutPanel1.Controls.Add(this.controles[2], 1, 0);
                    tableLayoutPanel1.Controls.Add(this.controles[3], 1, 1);
                    tableLayoutPanel1.Controls.Add(dgvDatos, 0, 2);

                    //zedGraphControl3.GraphPane.Legend.IsVisible = false;

                    dgvDatos.Rows[1].Selected = false;

                    this.graficaDobleActiva = true;
                }
            }
        }

        private void zedGraphControl4_DoubleClick(object sender, EventArgs e)
        {
            if (zedGraphControl4.GraphPane.CurveList.Count!= 0)
            {
                if (this.graficaDobleActiva)
                {
                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.RowCount = 2;
                    tableLayoutPanel1.ColumnCount = 1;

                    tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[0].Height = 80;

                    tableLayoutPanel1.RowStyles[1].SizeType = SizeType.AutoSize;

                    tableLayoutPanel1.Controls.Add(zedGraphControl4, 0, 0);
                    zedGraphControl4.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(dgvDatos, 0, 1);

                    //zedGraphControl4.GraphPane.Legend.IsVisible = true;

                    dgvDatos.Rows[1].Selected = true;

                    this.graficaDobleActiva = false;
                }
                else
                {
                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.RowCount = 2;
                    tableLayoutPanel1.ColumnCount = 2;

                    tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[0].Height = 40;

                    tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[1].Height = 40;

                    tableLayoutPanel1.RowStyles[2].SizeType = SizeType.AutoSize;

                    tableLayoutPanel1.Controls.Add(this.controles[0], 0, 0);
                    tableLayoutPanel1.Controls.Add(this.controles[1], 0, 1);
                    tableLayoutPanel1.Controls.Add(this.controles[2], 1, 0);
                    tableLayoutPanel1.Controls.Add(this.controles[3], 1, 1);
                    tableLayoutPanel1.Controls.Add(dgvDatos, 0, 2);

                    //zedGraphControl4.GraphPane.Legend.IsVisible = false;

                    dgvDatos.Rows[1].Selected = false;

                    this.graficaDobleActiva = true;
                }
            }
        }
    }
}
