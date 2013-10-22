using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BodePlot;
using ZedGraph;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using Util;
using System.Threading;


namespace DiagramasBode
{
    public partial class FrmPrincipal : Form
    {
        FrmDiagramaDeBloques frmDiagramaBloques;
        Historial h;
        DataTable dat;

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

        /// <summary>
        /// Objeto de dibujo para la gráfica de magnitud.
        /// </summary>
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

        /// <summary>
        /// Determina si actualmente se están visualizando las gráficas de magnitud y fase simultáneamente.
        /// </summary>
        private bool graficaDobleActiva = true;

        #endregion

        #region Atributos no gráficos

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

        #region Eventos

        private void FrmBode_Load(object sender, EventArgs e)
        {
            this.gpMagnitud = zgcMagnitud.GraphPane;
            this.gpFase = zgcFase.GraphPane;

            btnRetroceder.Enabled = false;
            btnAvanzar.Enabled = false;
            btnLimpiar.Enabled = false;

            establecerPropiedadesPrimarias();

            frmDiagramaBloques = new FrmDiagramaDeBloques();
            h = new Historial();

            //Invisibilizamos todo lo que está dentro de la fórmula.
            pbLineaDivisoria.Visible = false;
            pbCT1CS.Visible = false;
            pbCT1PS.Visible = false;
            pbCT2CS.Visible = false;
            pbCT2PS.Visible = false;
            pbFNACA.Visible = false;
            pbOrdenCeroOrigen.Visible = false;
            pbOrdenPoloOrigen.Visible = false;
            pbRetardoTiempo.Visible = false;
            lblN1.Visible = false;
            lblN2.Visible = false;
            lblOrdenPoloOrigen.Visible = false;
            lblT1.Visible = false;
            lblT2.Visible = false;
            lblT3.Visible = false;
            lblT4.Visible = false;
            lblTd.Visible = false;
            lblWn1.Visible = false;
            lblWn2.Visible = false;
            lblWn3.Visible = false;
            lblPsi.Visible = false;

            pbFuncionG.Visible = false;
            lblK.Visible = false;
        }

        private void zgcMagnitud_DoubleClick(object sender, EventArgs e)
        {
            if (this.graficaDobleActiva)
            {
                tlpDiagramas.Controls.Clear();
                tlpDiagramas.RowCount = 1;
                tlpDiagramas.Controls.Add(zgcMagnitud, 0, 0);

                this.graficaDobleActiva = false;
            }
            else
            {
                tlpDiagramas.Controls.Clear();
                tlpDiagramas.RowCount = 2;
                tlpDiagramas.Controls.Add(zgcMagnitud, 0, 0);
                tlpDiagramas.Controls.Add(zgcFase, 0, 1);

                this.graficaDobleActiva = true;
            }
        }

        private void zgcFase_DoubleClick(object sender, EventArgs e)
        {
            if (this.graficaDobleActiva)
            {
                tlpDiagramas.Controls.Clear();
                tlpDiagramas.RowCount = 1;
                tlpDiagramas.Controls.Add(zgcFase, 0, 0);

                this.graficaDobleActiva = false;
            }
            else
            {
                tlpDiagramas.Controls.Clear();
                tlpDiagramas.RowCount = 2;
                tlpDiagramas.Controls.Add(zgcMagnitud, 0, 0);
                tlpDiagramas.Controls.Add(zgcFase, 0, 1);

                this.graficaDobleActiva = true;
            }
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            if (this.controladorBode.CurvasIndividuales.Count > 0 && this.controladorBode.CurvasParciales.Count > 0)
                retroceder();
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            if (this.primeraEjecucion)
            {
                //deshabilitamos los ejemplos
                tsmnuEjemplos.Enabled = false;

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
                //pplResaltadoFaseSuperior.Add(this.controladorBode.InicioEjeX, 180);
                //pplResaltadoFaseSuperior.Add(this.controladorBode.FinEjeX, 180);
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
            }

            if (this.controladorBode.CurvasIndividuales.Count > 0 && this.controladorBode.CurvasParciales.Count > 0)
                avanzar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            tsmnuEjemplos.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void btnEjemplos_Click(object sender, EventArgs e)
        {
            FrmFormulas frmEjemplos = new FrmFormulas();
            frmEjemplos.ShowDialog();

            if (frmEjemplos.FormulaSeleccionada != null)
            {
                //Limpiamos todo lo que puede haber en el formulario.
                limpiar();

                //Tratamos a los ejemplos como fórmulas.
                this.Formula = frmEjemplos.FormulaSeleccionada;
                establecerFormula();

                //Habilitamos los botones que correspondan.
                btnAvanzar.Enabled = true;
                btnLimpiar.Enabled = true;
            }
        }

        private void btnFormula_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;

            FrmIngresoFormula frmIngresoFormula = new FrmIngresoFormula();
            frmIngresoFormula.ShowDialog();

            if (frmIngresoFormula.Formula != null)
            {
                //Limpiamos cualquier fórmula que pudo haber quedado graficada.
                limpiar();

                this.Formula = frmIngresoFormula.Formula;

                //Establecemos los valores de los parámetros y cambiamos su color.
                establecerFormula();                

                //Habilitamos los botones que correspondan.
                btnAvanzar.Enabled = true;
                btnLimpiar.Enabled = true;
            }
        }

        private void cbOcultarTerminosIndividuales_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOcultarTerminosIndividuales.Checked)
                ocultarCurvasIndividuales();
            else
                mostrarCurvasIndividuales();
        }

        #endregion

        public FrmPrincipal()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
            InitializeComponent();
        }

        private string MiPuntoHandler(ZedGraphControl zgc, GraphPane gp, CurveItem curve, int iPt)
        {
            //Obtenemos el punto.
            PointPair punto = curve[iPt];

            //Devolvemos una cadena que muestra información del punto.
            return curve.Label.Text + "\n (" + punto.X.ToString("f2") + " ; " + punto.Y.ToString("f1") + ")";
        }

        private void MyContextMenuBuilder(ZedGraphControl control, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            for (int i = 0; i < menuStrip.Items.Count; i++)
            {
                if ((string)menuStrip.Items[i].Tag == "set_default" || (string)menuStrip.Items[i].Tag == "show_val")
                    menuStrip.Items.RemoveAt(i);
            }
        }

        /// <summary>
        /// Establece las propiedades fijas de las gráficas: nombre de ejes, escalas, enrejillado, etc.
        /// </summary>
        private void establecerPropiedadesPrimarias()
        {
            //Gráfica de magnitud.
            this.gpMagnitud.Title.Text = "";

            this.gpMagnitud.XAxis.Title.Text = "Frecuencia (rad/s)";
            this.gpMagnitud.XAxis.Type = AxisType.Log;
            this.gpMagnitud.XAxis.Scale.MinAuto = true;
            this.gpMagnitud.XAxis.Scale.MaxAuto = true;
            this.gpMagnitud.XAxis.MajorGrid.IsVisible = true;

            this.gpMagnitud.YAxis.Title.Text = "Magnitud(db)";
            this.gpMagnitud.YAxis.Scale.MinAuto = true;
            this.gpMagnitud.YAxis.Scale.MaxAuto = true;
            this.gpMagnitud.YAxis.MajorGrid.IsVisible = true;

            zgcMagnitud.IsShowPointValues = true;
            zgcMagnitud.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

            zgcMagnitud.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            zgcMagnitud.AxisChange();

            //Gráfica de fase.
            this.gpFase.Title.Text = "";

            this.gpFase.XAxis.Title.Text = "Frecuencia (rad/s)";
            this.gpFase.XAxis.Type = AxisType.Log;
            this.gpFase.XAxis.Scale.MinAuto = true;
            this.gpFase.XAxis.Scale.MaxAuto = true;
            this.gpFase.XAxis.MajorGrid.IsVisible = true;

            this.gpFase.YAxis.Title.Text = "Fase (grados)";
            this.gpFase.YAxis.Scale.MinAuto = true;
            this.gpFase.YAxis.Scale.MaxAuto = true;
            this.gpFase.YAxis.MajorGrid.IsVisible = true;

            zgcFase.IsShowPointValues = true;
            zgcFase.PointValueEvent += new ZedGraphControl.PointValueHandler(MiPuntoHandler);

            zgcFase.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            zgcFase.AxisChange();
        }

        /// <summary>
        /// Avanza en el dibujado de la siguiente curva individual.
        /// </summary>
        private void avanzar()
        {
            if (this.indiceCurvaActual < this.controladorBode.CurvasIndividuales.Count - 1)
            {
                this.indiceCurvaActual++;
                mostrarCurvas();
            }
        }

        /// <summary>
        /// Retrocede en el dibujado de la siguiente curva individual.
        /// </summary>
        private void retroceder()
        {
            if (this.indiceCurvaActual > 0)
            {
                this.indiceCurvaActual--;
                mostrarCurvas();
            }
        }

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
            if (!cbOcultarTerminosIndividuales.Checked)
            {
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

                //Declaramos un datatable para poder guardar los datos obtenidos del datagridview
                this.dat = new DataTable();
                this.dat.Columns.Add(new DataColumn("Margen", typeof(string)));
                this.dat.Columns.Add(new DataColumn("Valor", typeof(string)));  

                //Mostramos el margen de ganancia.
                if (this.controladorBode.MargenGanancia != null)
                {
                    dgvMargenes.Rows.Add("GANANCIA", this.controladorBode.MargenGanancia.ToString() + " dB");
                    this.dat.Rows.Add("GANANCIA", this.controladorBode.MargenGanancia.ToString() + " dB");

                    if (this.controladorBode.MargenGanancia >= 0)
                    {
                        dgvMargenes[1, 0].Style.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        dgvMargenes[1, 0].Style.BackColor = Color.LightPink;
                    }
                }
                else
                {
                    dgvMargenes.Rows.Add("GANANCIA", "INFINITO");
                    this.dat.Rows.Add("GANANCIA", "INFINITO");
                }
                                
                //Mostramos el margen de fase.
                if (this.controladorBode.MargenFase != null)
                {
                    dgvMargenes.Rows.Add("FASE", this.controladorBode.MargenFase.ToString() + " °" );
                    this.dat.Rows.Add("FASE", this.controladorBode.MargenFase.ToString() + " º");
                    
                    if (this.controladorBode.MargenFase >= 0)
                    {
                        dgvMargenes[1, 1].Style.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        dgvMargenes[1, 1].Style.BackColor = Color.LightPink;
                    }
                }
                else
                {
                    dgvMargenes.Rows.Add("FASE", "INFINITO") ;
                    this.dat.Rows.Add("FASE", "INFINITO");
                }
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

            //Habilita el boton Adelante hasta que se dibuja la ultima curva
            if (this.indiceCurvaActual == this.controladorBode.CurvasIndividuales.Count - 1)
            {
                this.btnAvanzar.Enabled = false;
                btnGuardar.Enabled = true;
            }
            else
            {
                this.btnAvanzar.Enabled = true;
            }

            //Habilita el boton Atras hasta que se dibuja la primera curva
            if (this.indiceCurvaActual == 0)
            {
                this.btnRetroceder.Enabled = false;
            }
            else
            {
                this.btnRetroceder.Enabled = true;
            }
        }

        /// <summary>
        /// Muestra las curvas individuales, hasta aquella curva que indique el índice de la curva actual.
        /// </summary>
        private void mostrarCurvasIndividuales()
        {
            //Mostramos solamente hasta el índice actual.
            if (this.controladorBode != null)
            {
                //Curvas individuales de magnitud.
                for (int indiceLineItem = 0; indiceLineItem <= this.indiceCurvaActual; indiceLineItem++)
                {
                    this.lineItemsCurvasIndividualesMagnitud[indiceLineItem].IsVisible = true;
                    this.lineItemsCurvasIndividualesMagnitud[indiceLineItem].Label.IsVisible = true;
                }

                //Curvas individuales de fase.
                for (int indiceLineItem = 0; indiceLineItem <= this.indiceCurvaActual; indiceLineItem++)
                {
                    this.lineItemsCurvasIndividualesFase[indiceLineItem].IsVisible = true;
                    this.lineItemsCurvasIndividualesFase[indiceLineItem].Label.IsVisible = true;
                }

                //Último punto de corte.
                if (this.lineItemsPuntosCorte[this.indiceCurvaActual] != null)
                    this.lineItemsPuntosCorte[this.indiceCurvaActual].IsVisible = true;

                reestablecerEscala(); 
            }
        }

        /// <summary>
        /// Oculta las curvas individuales, hasta aquella curva que indique el índice de la curva actual.
        /// </summary>
        private void ocultarCurvasIndividuales()
        {
            //Ocultamos todo excepto la curva parcial actual.
            if (this.controladorBode != null)
            {
                //Curvas individuales de magnitud.
                for (int indiceLineItem = 0; indiceLineItem < this.lineItemsCurvasIndividualesMagnitud.Count; indiceLineItem++)
                {
                    this.lineItemsCurvasIndividualesMagnitud[indiceLineItem].IsVisible = false;
                    this.lineItemsCurvasIndividualesMagnitud[indiceLineItem].Label.IsVisible = false;
                }

                //Curvas individuales de fase.
                for (int indiceLineItem = 0; indiceLineItem < this.lineItemsCurvasIndividualesFase.Count; indiceLineItem++)
                {
                    this.lineItemsCurvasIndividualesFase[indiceLineItem].IsVisible = false;
                    this.lineItemsCurvasIndividualesFase[indiceLineItem].Label.IsVisible = false;
                }

                //Puntos de corte.
                for (int indicePuntoCorte = 0; indicePuntoCorte < this.lineItemsPuntosCorte.Count; indicePuntoCorte++)
                {
                    if (this.lineItemsPuntosCorte[indicePuntoCorte] != null)
                        this.lineItemsPuntosCorte[indicePuntoCorte].IsVisible = false;  
                }

                reestablecerEscala();
            }
        }

        /// <summary>
        /// Limpia las gráficas de magnitud y fase, la fórmula mostrada, y reestablece todos los
        /// atributos gráficos y no gráficos.
        /// </summary>
        private void limpiar()
        {
            //Reestablecemos todos los atributos gráficos.
            this.lineItemsCurvasIndividualesMagnitud.Clear();
            this.lineItemsCurvasIndividualesFase.Clear();
            this.lineItemsCurvasParcialesMagnitud.Clear();
            this.lineItemsCurvasParcialesFase.Clear();
            this.lineItemsPuntosCorte.Clear();
            this.lineItemsPuntosCruceGanancia.Clear();
            this.lineItemsPuntosCruceFase.Clear();
            this.graficaDobleActiva = true;

            //Reestablecemos los atributos no gráficos.
            this.controladorBode = null;
            this.Formula = null;
            this.primeraEjecucion = true;
            this.indiceCurvaActual = -1;
            
            //Reestablecemos la interfaz de usuario.
            this.btnAvanzar.Enabled = false;
            this.btnRetroceder.Enabled = false;
            establecerFormula();
            dgvMargenes.Rows.Clear();
            

            //Limpiamos las gráficas.
            this.gpMagnitud.CurveList.Clear();
            this.gpFase.CurveList.Clear();
            
            //Refrescamos las gráficas.
            this.zgcMagnitud.Invalidate();
            this.zgcFase.Invalidate();
        }

        /// <summary>
        /// Se actualiza la escala de las gráficas de magnitud y fase, luego de
        /// agregar o quitar una curva.
        /// </summary>
        private void reestablecerEscala()
        {
            //Reestablecemos la escala de las gráficas.
            this.zgcMagnitud.AxisChange();
            this.zgcFase.AxisChange();

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
            this.zgcMagnitud.Invalidate();
            this.zgcFase.Invalidate();
        }

        /// <summary>
        /// Establece los valores de la fórmula en el panel de fórmula visible.
        /// </summary>
        private void establecerFormula()
        {
            int posCentroH = 310, anchoTotalPb = DiagramasBode.Properties.Resources.FuncionGs.Width, anchoNumerador, posPb=0;
            int bajar = 10; //cantidad de pixeles a bajar el numerador en caso de que no haya denominador

            //fijamos condiciones iniciales
            pbLineaDivisoria.Visible = false;
            pbCT1CS.Visible = false;
            pbCT1PS.Visible = false;
            pbCT2CS.Visible = false;
            pbCT2PS.Visible = false;
            pbFNACA.Visible = false;
            pbOrdenCeroOrigen.Visible = false;
            pbOrdenPoloOrigen.Visible = false;
            pbRetardoTiempo.Visible = false;
            lblN1.Visible = false;
            lblN2.Visible = false;
            lblOrdenPoloOrigen.Visible = false;
            lblT1.Visible = false;
            lblT2.Visible = false;
            lblT3.Visible = false;
            lblT4.Visible = false;
            lblTd.Visible = false;
            lblWn1.Visible = false;
            lblWn2.Visible = false;
            lblWn3.Visible = false;
            lblPsi.Visible = false;
            lblK.Location = new Point(70, 9);
            pbOrdenCeroOrigen.Location = new Point(98, -1);
            lblN1.Location = new Point(136, 0);
            pbCT1CS.Location = new Point(171, -1);
            lblT1.Location = new Point(216, 5);
            pbCT2CS.Location = new Point(279, -1);
            lblT2.Location = new Point(328, 6);
            pbRetardoTiempo.Location = new Point(393, 2);
            lblTd.Location = new Point(430, -1);

            //Establecemos los valores de cada parámetro en la fórmula, y cambiamos el color del label.
            if (this.Formula != null)
            {
                //cambiamos el fondo
                pbFuncionEntrada.Image = DiagramasBode.Properties.Resources.formula_funcion_entrada_vacia;
                //ponemos en visible la imagen  "G(s)= "
                pbFuncionG.Visible = true;
                //ponemos en visible lblK
                lblK.Visible = true;

                //mostramos los productos y los centramos iterativo, en primera instancia se ve cuáles son los controles a mostrar
                //y en 2º instancia se los centra.
                for (int i = 0; i < 2; i++)
                {
                    if (i == 1)
                    {
                        pbFuncionG.Location = new Point(posPb, pbFuncionG.Location.Y);
                        posPb += pbFuncionG.Width;
                    }
                    if (Formula.K != null)
                    {
                        if (i == 0)
                        {
                            lblK.Text = Formula.K.ToString();
                            lblK.ForeColor = Color.Red;
                            anchoTotalPb += lblK.Width;
                        }
                        else
                        {
                            lblK.Location = new Point(posPb, lblK.Location.Y);
                            posPb += lblK.Width;
                        }
                    }
                    else //el valor por defecto es 1 pero hay que trasladarlo para centrarlo
                    {
                        if (i == 0)
                            anchoTotalPb += lblK.Width;
                        else
                        {
                            lblK.Location = new Point(posPb, lblK.Location.Y);
                            posPb += lblK.Width;
                        }
                    }

                    if (Formula.N1 != null)
                    {
                        if (i == 0)
                        {
                            lblN1.Text = Formula.N1.ToString();
                            lblN1.ForeColor = Color.Red;
                            anchoTotalPb += pbOrdenCeroOrigen.Width;
                        }
                        else
                        {
                            lblN1.Visible = true;
                            pbOrdenCeroOrigen.Visible = true;
                            pbOrdenCeroOrigen.Location = new Point(posPb, pbOrdenCeroOrigen.Location.Y);
                            lblN1.Location = new Point(posPb+38, lblN1.Location.Y);
                            posPb += pbOrdenCeroOrigen.Width;
                            
                        }
                    }

                    if (Formula.T1 != null)
                    {
                        if (i == 0)
                        {
                            lblT1.Text = Formula.T1.ToString();
                            lblT1.ForeColor = Color.Red;
                            anchoTotalPb += pbCT1CS.Width;
                        }
                        else
                        {
                            pbCT1CS.Visible = true;
                            pbCT1CS.Location = new Point(posPb, pbCT1CS.Location.Y);
                            lblT1.Visible = true;
                            lblT1.Location = new Point(posPb+45, lblT1.Location.Y);
                            posPb += pbCT1CS.Width;
                        }
                    }

                    if (Formula.T2 != null)
                    {
                        if (i == 0)
                        {
                            lblT2.Text = Formula.T2.ToString();
                            lblT2.ForeColor = Color.Red;
                            anchoTotalPb += pbCT2CS.Width;
                        }
                        else
                        {
                            pbCT2CS.Visible = true;
                            pbCT2CS.Location = new Point(posPb, pbCT2CS.Location.Y);
                            lblT2.Visible = true;
                            lblT2.Location = new Point(posPb + 49, lblT2.Location.Y);
                            posPb += pbCT2CS.Width;
                        }
                    }

                    if (Formula.Td != null)
                    {
                        if (i == 0)
                        {
                            lblTd.Text = Formula.Td.ToString();
                            lblTd.ForeColor = Color.Red;
                            anchoTotalPb += pbRetardoTiempo.Width;
                        }
                        else
                        {
                            pbRetardoTiempo.Visible = true;
                            pbRetardoTiempo.Location = new Point(posPb, pbRetardoTiempo.Location.Y);
                            lblTd.Visible = true;
                            lblTd.Location = new Point(posPb + 37, lblTd.Location.Y);
                            posPb += pbRetardoTiempo.Width;
                        }
                    }
                    if (i == 0)
                    {
                        posPb = posCentroH - (anchoTotalPb/2);
                    }
                }

                //Hacemos lo mismo para el denominador considerando la línea divisoria
                anchoNumerador = anchoTotalPb - pbFuncionG.Width;
                anchoTotalPb = 0;

                for (int i = 0; i < 2; i++)
                {
                    if (Formula.N2 != null)
                    {
                        if (i == 0)
                        {
                            lblN2.Text = Formula.N2.ToString();
                            lblN2.ForeColor = Color.Red;
                            anchoTotalPb += pbOrdenPoloOrigen.Width;
                        }
                        else
                        {
                            lblN2.Visible = true;
                            lblN2.Location = new Point(posPb + 10, lblN2.Location.Y);
                            pbOrdenPoloOrigen.Visible = true;
                            pbOrdenPoloOrigen.Location = new Point(posPb, pbOrdenPoloOrigen.Location.Y);
                            posPb += pbOrdenPoloOrigen.Width;
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            anchoTotalPb += lblOrdenPoloOrigen.Width;
                        }
                        if (i == 1)
                        {
                            lblOrdenPoloOrigen.Visible = true;
                            lblOrdenPoloOrigen.Location = new Point(posPb, lblOrdenPoloOrigen.Location.Y);
                            posPb += lblOrdenPoloOrigen.Width;
                        }
                    }

                    if (Formula.T3 != null)
                    {
                        if (i == 0)
                        {
                            lblT3.Text = Formula.T3.ToString();
                            lblT3.ForeColor = Color.Red;
                            anchoTotalPb += pbCT1PS.Width;
                        }
                        else
                        {
                            pbCT1PS.Visible = true;
                            pbCT1PS.Location = new Point(posPb, pbCT1PS.Location.Y);
                            lblT3.Visible = true;
                            lblT3.Location = new Point(posPb + 50, lblT3.Location.Y);
                            posPb += pbCT1PS.Width;
                        }
                    }

                    if (Formula.T4 != null)
                    {
                        if (i == 0)
                        {
                            lblT4.Text = Formula.T4.ToString();
                            lblT4.ForeColor = Color.Red;
                            anchoTotalPb += pbCT2PS.Width;
                        }
                        else
                        {
                            pbCT2PS.Visible = true;
                            pbCT2PS.Location = new Point(posPb, pbCT2PS.Location.Y);
                            lblT4.Visible = true;
                            lblT4.Location = new Point(posPb + 43, lblT4.Location.Y);
                            posPb += pbCT2PS.Width;
                        }
                    }

                    if (Formula.Wn != null && Formula.Psi != null)
                    {
                        if (i == 0)
                        {
                            lblWn1.Text = Formula.Wn.ToString();
                            lblWn2.Text = Formula.Wn.ToString();
                            lblWn3.Text = Formula.Wn.ToString();
                            lblWn1.ForeColor = Color.Red;
                            lblWn2.ForeColor = Color.Red;
                            lblWn3.ForeColor = Color.Red;

                            lblPsi.Text = Formula.Psi.ToString(); ;
                            lblPsi.ForeColor = Color.Red;
                            anchoTotalPb += pbFNACA.Width;
                        }
                        else
                        {
                            pbFNACA.Visible = true;
                            pbFNACA.Location = new Point(posPb, pbFNACA.Location.Y);
                            lblWn1.Visible = true;
                            lblWn1.Location = new Point(posPb + 88, lblWn1.Location.Y);
                            lblWn2.Visible = true;
                            lblPsi.Location = new Point(posPb + 67, lblPsi.Location.Y);
                            lblPsi.Visible = true;
                            lblWn2.Location = new Point(posPb + 115, lblWn2.Location.Y);
                            lblWn3.Visible = true;
                            lblWn3.Location = new Point(posPb + 186, lblWn3.Location.Y);
                            posPb += pbFNACA.Width;
                        }
                    }
                    if (i == 0)
                    {
                        anchoTotalPb+= DiagramasBode.Properties.Resources.FuncionGs.Width;
                        posPb = posCentroH - (anchoTotalPb / 2) + 35;
                        anchoTotalPb-= DiagramasBode.Properties.Resources.FuncionGs.Width;
                    }
                }

                if (anchoTotalPb == lblOrdenPoloOrigen.Width)
                {
                    //si no hay denominador bajar todo el numerador
                    lblK.Location = new Point(lblK.Location.X, lblK.Location.Y + bajar);
                    pbOrdenCeroOrigen.Location = new Point(pbOrdenCeroOrigen.Location.X, pbOrdenCeroOrigen.Location.Y + bajar);
                    lblN1.Location = new Point(lblN1.Location.X, lblN1.Location.Y + bajar);
                    pbCT1CS.Location = new Point(pbCT1CS.Location.X, pbCT1CS.Location.Y + bajar);
                    lblT1.Location = new Point(lblT1.Location.X, lblT1.Location.Y + bajar);
                    pbCT2CS.Location = new Point(pbCT2CS.Location.X, pbCT2CS.Location.Y + bajar);
                    lblT2.Location = new Point(lblT2.Location.X, lblT2.Location.Y + bajar);
                    pbRetardoTiempo.Location = new Point(pbRetardoTiempo.Location.X, pbRetardoTiempo.Location.Y + bajar);
                    lblTd.Location = new Point(lblTd.Location.X, lblTd.Location.Y + bajar);
                    lblOrdenPoloOrigen.Visible = false;
                }
                else
                {
                    //si hay denominador poner la linea divisoria
                    pbLineaDivisoria.Visible = true;
                    if (anchoNumerador > anchoTotalPb)
                        anchoTotalPb = anchoNumerador;
                    pbLineaDivisoria.Width = anchoTotalPb;
                    posPb = posCentroH - (anchoTotalPb / 2) + 10;
                    pbLineaDivisoria.Location = new Point(posPb, pbLineaDivisoria.Location.Y);

                    //reposicionar la función G(s)
                    if ((pbFuncionG.Location.X + pbFuncionG.Width) > pbLineaDivisoria.Location.X)
                    {
                        posPb = pbLineaDivisoria.Location.X - pbFuncionG.Width - 5;
                        pbFuncionG.Location = new Point(posPb, pbFuncionG.Location.Y);
                    }
                }
            }
            //Si la fórmula es nula, reestablecemos todos los parámetros.
            else
            {
                lblK.Text = "1";
                lblN1.Text = "0";
                lblT1.Text = "0";
                lblT2.Text = "0";
                lblTd.Text = "0";
                lblN2.Text = "0";
                lblT3.Text = "0";
                lblT4.Text = "0";
                lblWn1.Text = "0";
                lblPsi.Text = "0";
                lblWn2.Text = "0";
                lblWn3.Text = "0";

                lblK.ForeColor = Color.Black;
                lblN1.ForeColor = Color.Black;
                lblT1.ForeColor = Color.Black;
                lblT2.ForeColor = Color.Black;
                lblTd.ForeColor = Color.Black;
                lblN2.ForeColor = Color.Black;
                lblT3.ForeColor = Color.Black;
                lblT4.ForeColor = Color.Black;
                lblWn1.ForeColor = Color.Black;
                lblPsi.ForeColor = Color.Black;
                lblWn2.ForeColor = Color.Black;
                lblWn3.ForeColor = Color.Black;

                //pbFuncionEntrada.Image = DiagramasBode.Properties.Resources.formula_funcion_entrada;
                inicializarControles();
            }
        }

        private void inicializarControles()
        {
            //setear todos los controles en sus posiciones de inicio y visibilidad true
            pbFuncionG.Visible = false;
            pbLineaDivisoria.Visible = false;
            pbCT1CS.Visible = false;
            pbCT1PS.Visible = false;
            pbCT2CS.Visible = false;
            pbCT2PS.Visible = false;
            pbFNACA.Visible = false;
            pbOrdenCeroOrigen.Visible = false;
            pbOrdenPoloOrigen.Visible = false;
            pbRetardoTiempo.Visible = false;
            lblN1.Visible = false;
            lblN2.Visible = false;
            lblOrdenPoloOrigen.Visible = false;
            lblT1.Visible = false;
            lblT2.Visible = false;
            lblT3.Visible = false;
            lblT4.Visible = false;
            lblTd.Visible = false;
            lblWn1.Visible = false;
            lblWn2.Visible = false;
            lblWn3.Visible = false;
            lblPsi.Visible = false;
            lblK.Visible = false;
            //Numerador
            lblK.Location = new Point(70, 9);
            pbOrdenCeroOrigen.Location = new Point(98, -1);
            lblN1.Location = new Point(136, 0);
            pbCT1CS.Location = new Point(171, -1);
            lblT1.Location = new Point(216, 5);
            pbCT2CS.Location = new Point(279, -1);
            lblT2.Location = new Point(328, 6);
            pbRetardoTiempo.Location = new Point(393, 2);
            lblTd.Location = new Point(430, -1);
            //Denominador
            pbOrdenPoloOrigen.Location = new Point(54,36);
            lblOrdenPoloOrigen.Location = new Point(60,46);
            lblN2.Location = new Point(64,37);
            pbCT1PS.Location = new Point(98,38);
            lblT3.Location = new Point(148,45);
            pbCT2PS.Location = new Point(217,38);
            lblT4.Location = new Point(260,45);
            pbFNACA.Location = new Point(335,36);
            lblWn1.Location = new Point(423,38);
            lblPsi.Location = new Point(402,59);
            lblWn2.Location = new Point(450,59);
            lblWn3.Location = new Point(521,60);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ejemplo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formula formulaNueva = new Formula();
            formulaNueva.K = 0.2;
            formulaNueva.T3 = 1;
            formulaNueva.T4 = 0.2;
            this.Formula = formulaNueva;
            establecerFormula();

            //Habilitamos los botones que correspondan.
            btnAvanzar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void ejemplo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formula formulaNueva = new Formula();
            formulaNueva.K = 10;
            formulaNueva.T1 = 0.5;
            formulaNueva.Td = 0.1;
            formulaNueva.T3 = 1;
            formulaNueva.T4 = 0.1;
            this.Formula = formulaNueva;
            establecerFormula();

            //Habilitamos los botones que correspondan.
            btnAvanzar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void ejemplo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formula formulaNueva = new Formula();
            formulaNueva.K = 1;
            formulaNueva.Td = 0.5;
            formulaNueva.T3 = 1;
            formulaNueva.T4 = 2;
            this.Formula = formulaNueva;
            establecerFormula();

            //Habilitamos los botones que correspondan.
            btnAvanzar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            h.addGrafica(_Formula, dat.Copy());

            btnComparar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            //Se llama al formulario de Comparacion. 
            FrmCompara comp = new FrmCompara(h);
            comp.ShowDialog();
        }
    }
}