using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;
using System.Globalization;


namespace Root_Locus
{
    public partial class FormRootLocus : Form
    {
        RootLocus rl;
        Historial h;
        DataTable dat;
        PointPairList polos;
        PointPairList ceros;
        int cantAsint = 0; // para no reaizar varios llamados al metodo asintotas de la clase RootLocus
        
        //double ultimoK = 20;
        //int cantPtos = 500;

        //El paso actual indica en que estado esta el formulario (Introduccion, regla1, regla2, etc) 
        int pasoActual;

        //Estas banderas indican si las curvas a dibujar ya estan calculadas
        bool rectas1;
        bool rectas2;
        bool rectas3;
        bool rectas4;
        bool rectas5;

        public FormRootLocus()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.zedC.IsShowPointValues = true;
            this.zedC.GraphPane.XAxis.Scale.MinGrace = 0;
            this.zedC.GraphPane.XAxis.Scale.MaxGrace = 0;

            this.zedC.GraphPane.XAxis.Title.Text = "Eje real";
            this.zedC.GraphPane.XAxis.Title.IsTitleAtCross = false;
            this.zedC.GraphPane.XAxis.Title.IsVisible = true;

            this.zedC.GraphPane.YAxis.Title.Text = "                                                      Eje imaginario";
            this.zedC.GraphPane.YAxis.Title.IsTitleAtCross = false;
            this.zedC.GraphPane.YAxis.Title.IsVisible = true;

            this.zedC.GraphPane.XAxis.IsVisible = true;
            this.zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;
            this.zedC.GraphPane.XAxis.MajorGrid.IsZeroLine = false;

            this.zedC.GraphPane.YAxis.IsVisible = true;
            this.zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;
            this.zedC.GraphPane.YAxis.MajorGrid.IsZeroLine = false;
            this.zedC.GraphPane.YAxis.Scale.IsSkipCrossLabel = true;

            this.zedC.GraphPane.Title.IsVisible = false;
            this.zedC.GraphPane.Chart.Border.IsVisible = false;
            this.zedC.GraphPane.Border.IsVisible = false;

            this.zedC.GraphPane.Legend.IsVisible = true;
            this.zedC.GraphPane.Legend.IsShowLegendSymbols = true;
            this.zedC.GraphPane.Legend.Border.IsVisible = false;

            polos = new PointPairList();
            ceros = new PointPairList();
            h = new Historial();

            cargarGrilla();

            //Se muestra la pantalla de introduccion
            pasoActual = 0;
            manejadorBotones();
            btnCompara.Enabled = false;
            btnGuardar.Enabled = false;

            //Provisorio
            limpiar();

            //this.ingresoDatos();
        }
                
        private void limpiar()
        {
            rl = new RootLocus();
            polos.Clear();
            ceros.Clear();
            zedC.GraphPane.CurveList.Clear();
            zedC.RestoreScale(zedC.GraphPane);

            //Se indica que ninguna curva esta en memoria
            rectas1 = false;
            rectas2 = false;
            rectas3 = false;
            rectas4 = false;
            rectas5 = false;

            //Se limpia la grilla
            foreach (DataRow fila in dat.Rows)
                fila[1] = "";            
        }
        private void cargarGrilla()
        {
            dat = new DataTable();
            dat.Columns.Add(new DataColumn("Datos", typeof(string)));
            dat.Columns.Add(new DataColumn("Valores", typeof(string)));

            dat.Rows.Add(new Object[] { "Cantidad Polos", "" });
            dat.Rows.Add(new Object[] { "Polos", "" });
            dat.Rows.Add(new Object[] { "Cantidad Ceros", "" });
            dat.Rows.Add(new Object[] { "Ceros", "" });
            dat.Rows.Add(new Object[] { "Ramas", "" });
            dat.Rows.Add(new Object[] { "Centro de Gravedad", "" });
            dat.Rows.Add(new Object[] { "Ang. de Asíntotas", "" });
            dat.Rows.Add(new Object[] { "Pto. de Ruptura", "" });
            dat.Rows.Add(new Object[] { "K crítico", "" });

            dgvDatos.DataSource = dat;
            dgvDatos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            /*
            dgvDatos.Rows.Add(7);
            
            dgvDatos.Rows[0].Cells[0].Value = "Polos";
            dgvDatos.Rows[1].Cells[0].Value = "Ceros";
            dgvDatos.Rows[2].Cells[0].Value = "Cantidad Polos";
            dgvDatos.Rows[3].Cells[0].Value = "Cantidad Ceros";
            dgvDatos.Rows[4].Cells[0].Value = "Ramas";
            dgvDatos.Rows[5].Cells[0].Value = "Centro de Gravedad";
            dgvDatos.Rows[6].Cells[0].Value = "Pto. de Ruptura";
            dgvDatos.Rows[7].Cells[0].Value = "Ángulo de Ruptura";                     
             * */
        }                       
        private void manejadorBotones()
        {
            switch (pasoActual)
            {
                case 0: pantallaIntro(); break;
                case 1: pantalla1(); break;
                case 2: pantalla2(); break;
                case 3: pantalla3(); break;
                case 4: pantalla4(); break;
                case 5: pantalla5(); break;
                 
                default: break;
            }

            //Provisorio
            zedC.AxisChange();
            zedC.Refresh();        
        }

        private void pantallaIntro()
        {
            btnAtras.Enabled = false;
            btnSig.Enabled = false;
            btnDatos.Enabled = true;
            cbReferencias.Visible = false;
            cbLineasAmortCte.Visible = false;

            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("Root_Locus.Resources.pantIntro.rtf");
            rtbxInfo.LoadFile(stream, RichTextBoxStreamType.RichText);
        }
        private void pantalla1()
        {
            zedC.RestoreScale(zedC.GraphPane);

            btnAtras.Enabled = false;
            btnSig.Enabled = true;
            cbReferencias.Visible = false;
            cbLineasAmortCte.Visible = false;


            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("Root_Locus.Resources.pant1.rtf");
            rtbxInfo.LoadFile(stream, RichTextBoxStreamType.RichText);


            //Se habilitan SOLO las rectas de este paso. Si no estan calculadas se dibujan
            if (rectas1)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        zedC.GraphPane.CurveList["Root Locus"].Label.IsVisible = false;
                        zedC.GraphPane.CurveList["Root Locus"].IsVisible = false;
                        zedC.GraphPane.CurveList["Eje" + i].IsVisible = false;
                    }
                    catch (Exception)
                    { if (i > 0)break; }
                }

            }
            else
            {
                //Completa Grilla
                foreach (PointPair p in polos)
                    dat.Rows[1][1] += ("(" + p.X + ")  ");

                if (rl.conImaginarios)
                {
                    dat.Rows[3][1] += ("(" + ceros[0].X + " + " + ceros[0].Y + " j)  ");
                    dat.Rows[3][1] += ("(" + ceros[0].X + " - " + ceros[0].Y + " j)  ");
                }
                else
                {
                    foreach (PointPair c in ceros)
                        dat.Rows[3][1] += ("(" + c.X + ")  ");
                }
                dat.Rows[0][1] = ("" + rl.n);
                dat.Rows[2][1] = ("" + rl.m);
                dat.Rows[4][1] = ("" + rl.n);

                //Graficar por unica vez
                graficarRectas1();
                rectas1 = true;
            }

            rl.resize();
            this.zedC.GraphPane.XAxis.Scale.Min = (rl.InicioEjeX);
            this.zedC.GraphPane.XAxis.Scale.Max = (rl.FinEjeX);
        }
        private void pantalla2()
        {
            btnAtras.Enabled = true;
            btnSig.Enabled = true;
            cbReferencias.Visible = false;
            cbLineasAmortCte.Visible = false;

            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("Root_Locus.Resources.pant2.rtf");
            rtbxInfo.LoadFile(stream, RichTextBoxStreamType.RichText);

            //Se habilitan SOLO las rectas de este paso. Si no estan calculadas se dibujan
            if (rectas2)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        zedC.GraphPane.CurveList["Root Locus"].Label.IsVisible = true;
                        zedC.GraphPane.CurveList["Root Locus"].IsVisible = true; 
                        zedC.GraphPane.CurveList["Eje" + i].IsVisible = true;
                    }
                    catch (Exception)
                    { if (i > 0)break; }
                }
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        zedC.GraphPane.CurveList["Asintotas"].Label.IsVisible = false;
                        zedC.GraphPane.CurveList["Asintotas"].IsVisible = false;
                        zedC.GraphPane.CurveList["Asi" + i].IsVisible = false; }
                    catch (Exception)
                    {if(i>0)break;}
                }             
            }
            else
            {
                btnDatos.Enabled = false;
                graficarRectas2();
                rectas2 = true;
            }
        }
        private void pantalla3()
        {
            btnAtras.Enabled = true;
            btnSig.Enabled = true;
            cbReferencias.Visible = false;
            cbLineasAmortCte.Visible = false;
                       
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("Root_Locus.Resources.pant3.rtf");
            rtbxInfo.LoadFile(stream, RichTextBoxStreamType.RichText);            

            //Se habilitan SOLO las rectas de este paso. Si no estan calculadas se dibujan
            if (rectas3)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    { zedC.GraphPane.CurveList["Asintotas"].Label.IsVisible = true;
                      zedC.GraphPane.CurveList["Asintotas"].IsVisible = true;
                      zedC.GraphPane.CurveList["Asi" + i].IsVisible = true;
                    }
                    catch (Exception)
                    { if (i > 0)break; }
                }
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        zedC.GraphPane.CurveList["Punto de Ruptura"].IsVisible = false;
                        zedC.GraphPane.CurveList["Punto de Ruptura"].Label.IsVisible = false;
                        zedC.GraphPane.CurveList["PtoRup" + i].IsVisible = false;
                    }
                    catch (Exception)
                    { if (i > 0)break; }
                }                         
            }
            else
            { 
                
                graficarRectas3();
                rectas3 = true;

                //Completa Grilla
                if(!double.IsNaN(rl.cg) && !double.IsInfinity(rl.cg))
                    dat.Rows[5][1] = ("" + rl.cg);
                else
                    dat.Rows[5][1] = "No hay centro de gravedad";

                foreach (double ang in rl.angAsintotas)
                {
                    double grad = Math.Round(ang/Math.PI*180,1);
                    dat.Rows[6][1] += "("+grad+"°)  ";                    
                }

            }           
        }
        private void pantalla4()
        {
            btnAtras.Enabled = true;
            btnSig.Enabled = true;
            cbReferencias.Visible = false;
            cbLineasAmortCte.Visible = false;
            cbReferencias.Checked = false;//tiene que estar porque cuando se presiona "ocultar asintotas" queda seteado en true y si se vuelve atars no aparecen

            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("Root_Locus.Resources.pant4.rtf");
            rtbxInfo.LoadFile(stream, RichTextBoxStreamType.RichText);

            //Se habilitan SOLO las rectas de este paso. Si no estan calculadas se dibujan
            if (rectas4)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        zedC.GraphPane.CurveList["Punto de Ruptura"].Label.IsVisible = true;
                        zedC.GraphPane.CurveList["Punto de Ruptura"].IsVisible = true; 
                        zedC.GraphPane.CurveList["PtoRup" + i].IsVisible = true;
                    }
                    catch (Exception)
                    { if (i > 0)break; }
                }
              
                for (int i = 0; i < 10; i++)
                {
                    try
                    { 
                        zedC.GraphPane.CurveList["Rl" + i].IsVisible = false;                        
                    }
                    catch (Exception)
                    { break; }
                }

                MostrarLineasAmortCte(false);
            }

            else
            {
                rectas4 = true;
                if (rl.PuntoRuptura())
                {
                    graficarRectas4();
                    foreach (PointPair p in rl.liPtoRuptura)
                    {
                        dat.Rows[7][1] += ("(" + Math.Round(p.X,3) + ";0)  ");
                    }
                }
                else
                {
                    dat.Rows[7][1] += "No Encontrado";
                    //Provisorio
                    /*
                    //Si no hay punto de ruptura no se grafica las ramas del root locus porque no hay
                    rectas5 = true;
                    //No existe un k Critico porque no se cruza el eje X
                    dat.Rows[7][1] += "No Encontrado";
                     * */
                }
            }            
        }
        private void pantalla5()
        {
            btnAtras.Enabled = true;
            btnSig.Enabled = false;
            btnDatos.Enabled = true;
            if (cantAsint != 0)
            {
                cbReferencias.Visible = true;
            }
            cbLineasAmortCte.Visible = true;
            cbLineasAmortCte.Checked = false;

            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("Root_Locus.Resources.pant5.rtf");
            rtbxInfo.LoadFile(stream, RichTextBoxStreamType.RichText);

            //Se habilitan SOLO las rectas de este paso. Si no estan calculadas se dibujan
            if (rectas5)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    { zedC.GraphPane.CurveList["Rl" + i].IsVisible = true; }
                    catch (Exception)
                    { break; }
                }

                MostrarLineasAmortCte(cbLineasAmortCte.Checked);
            }
            else
            {
                btnDatos.Enabled = true;
                btnGuardar.Enabled = true;
                graficarRectas5();
                
                //Calcula el k critico
                if (rl.calculaKCritico())
                {
                    foreach (double valorK in rl.kCritico)
                    {
                        dat.Rows[8][1] += "(" + valorK + ")  ";
                    }
                }
                else
                {
                    dat.Rows[8][1] += "No Encontrado";
                }
                rectas5 = true;                
            }

        }

        private void graficarRectas1()
        {
            //Aqui se agregan los polos(X) u los ceros(O) al eje real
            LineItem liPolos = zedC.GraphPane.AddCurve("Polos", polos, Color.Black);
            liPolos.Line.Fill.Type = FillType.None;
            liPolos.Symbol.Type = SymbolType.XCross;
            liPolos.Symbol.Size = 8F;
            liPolos.Line.IsAntiAlias = true;
            liPolos.Line.IsSmooth = true;
            liPolos.Line.SmoothTension = 0.05F;

            foreach (PointPair c in ceros)
            {
                PointPairList curva = new PointPairList();
                curva.Add(c);
                LineItem liCeros = zedC.GraphPane.AddCurve("Ceros", curva, Color.Black);
                liCeros.Line.Fill.Type = FillType.None;
                liCeros.Symbol.Type = SymbolType.Circle;
                liCeros.Symbol.Size = 8F;
                liCeros.Line.IsAntiAlias = true;
                liCeros.Line.IsSmooth = true;
                liCeros.Line.SmoothTension = 0.05F;
            }
            if(ceros.Count>1)
                zedC.GraphPane.CurveList["Ceros"].Label.IsVisible = false;

            //Para que haya polos y ceros multiples con otro color
            List<double> valoresPolos = new List<double>();
            foreach (PointPair polo in polos)
                valoresPolos.Add(polo.X);

            double poloAgregado = -111;
            int cont = 0;
            for (int i = 0; i < valoresPolos.Count-1; i++)
            {
                if (valoresPolos[i] == valoresPolos[i + 1] && valoresPolos[i]!=poloAgregado)
                {
                    PointPairList curva = new PointPairList();
                    curva.Add(new PointPair(valoresPolos[i],0));
                    LineItem l = zedC.GraphPane.AddCurve("Polos Multiples", curva, Color.Blue);
                    l.Symbol.Type = SymbolType.Star;
                    l.Symbol.Size = 14F;

                    poloAgregado = valoresPolos[i];
                    cont++;
                }                
            }
            if (cont == 2)
                zedC.GraphPane.CurveList["Polos Multiples"].Label.IsVisible = false;

            List<double> valoresCeros = new List<double>();
            foreach (PointPair cero in ceros)
                valoresCeros.Add(cero.X);

            //bool bandera = false;
            for (int i = 0; i < valoresCeros.Count-1; i++)
            {
                if (valoresCeros[i] == valoresCeros[i + 1] && ceros[0].Y==0)
                {
                    PointPairList curva = new PointPairList();
                    curva.Add(new PointPair(valoresCeros[i], 0));
                    LineItem l = zedC.GraphPane.AddCurve("Ceros Multiples", curva, Color.Black);
                    l.Symbol.Type = SymbolType.Circle;
                    l.Symbol.Size = 14F;

                    //bandera = true;
                }
            }
        }
        private void graficarRectas2()
        {
            //Se marca con rojo la parte del eje real que pertenece al root locus
            List<PointPairList> rectasEjeReal = rl.rectasEjeReal();

            for (int i = 0; i < rectasEjeReal.Count; i++)
            {
                LineItem li = zedC.GraphPane.AddCurve("Eje" + i, rectasEjeReal[i], Color.Red);
                li.Label.IsVisible = false;
                li.Symbol.Type = SymbolType.None;
                li.Line.Width = 3f;

                li.Line.IsAntiAlias = true;
                li.Line.IsSmooth = true;
                li.Line.SmoothTension = 0.05F;
            }
            zedC.GraphPane.CurveList["Eje0"].Label.IsVisible = true;
            zedC.GraphPane.CurveList["Eje0"].Label.Text = "LGR";
        }
        private void graficarRectas3()
        {
            //Se agregan las asintotas a la grafica
            List<PointPairList> asintotas = rl.asintotas();
            cantAsint = asintotas.Count;
            for (int i = 0; i < cantAsint; i++)
            {
                LineItem li = zedC.GraphPane.AddCurve("Asi" + i, asintotas[i], Color.LimeGreen);
                li.Label.IsVisible = false;
                li.Symbol.Type = SymbolType.None;
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                li.Line.Width = 3f;                
            }
            try { zedC.GraphPane.CurveList["Asi0"].Label.Text = "Asintotas";
                  zedC.GraphPane.CurveList["Asintotas"].Label.IsVisible = true; }
            catch{}
        }
        private void graficarRectas4()
        {
            
            for(int i = 0; i< rl.liPtoRuptura.Count ;i++)
            {
                PointPairList ptoRup = new PointPairList();
                ptoRup.Add(rl.liPtoRuptura[i]);
                LineItem liPtoRup = zedC.GraphPane.AddCurve("PtoRup"+i, ptoRup, Color.Blue);
                liPtoRup.Label.IsVisible = false;
                liPtoRup.Line.Fill.Type = FillType.None;
                liPtoRup.Symbol.Type = SymbolType.Diamond;
                liPtoRup.Symbol.Size = 8F;
                liPtoRup.Symbol.Fill.Color = Color.Cyan;
                liPtoRup.Symbol.Fill.Type = FillType.Solid;
                liPtoRup.Line.IsAntiAlias = true;
                liPtoRup.Line.IsSmooth = true;
                liPtoRup.Line.SmoothTension = 1F;
            }
            try
            {
                zedC.GraphPane.CurveList["PtoRup0"].Label.Text = "Punto de Ruptura";
                zedC.GraphPane.CurveList["Punto de Ruptura"].Label.IsVisible = true;
            }
            catch { }
        }
        private void graficarRectas5()
        {
            //List<PointPairList> curvas = rl.rectasLocus(1);
            List<PointPairList> curvas = rl.rectasLocus();

            for (int i = 0; i < curvas.Count; i++)
            {
                LineItem li = zedC.GraphPane.AddCurve("RL" + i, curvas[i], Color.Red);
                li.Label.IsVisible = false;
                li.Symbol.Type = SymbolType.None;
                li.Line.IsAntiAlias = true;
                li.Line.IsSmooth = true;
                li.Line.SmoothTension = 0.05F;
                li.Line.Width = 1.70f;
            }

            //Se agregan las líneas de amortiguación constante.
            List<PointPairList> lineasAmortiguacionCte = rl.lineasAmortiguacionCte();
            for (int i = 0; i < lineasAmortiguacionCte.Count; i++)
            {
                LineItem li = zedC.GraphPane.AddCurve("Coef. Amort.= " + (0.2 * i + 0.1), lineasAmortiguacionCte[i], Color.Black);
                li.IsVisible = false;
                li.Label.IsVisible = false;
                li.Symbol.Type = SymbolType.None;
                li.Line.Style = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                //li.Line.DashOn = 10;
                //li.Line.DashOff = 5;
                li.Line.Width = 1f;
            }

            LineItem lineaLegenda = zedC.GraphPane.AddCurve("Líneas de Amortiguación Cte", null, Color.Black);
            lineaLegenda.Label.IsVisible = false;
            lineaLegenda.Symbol.Type = SymbolType.None;
            lineaLegenda.Line.Style = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            //lineaLegenda.Line.DashOn = 10;
            //lineaLegenda.Line.DashOff = 5;
            lineaLegenda.Line.Width = 1f;            
        }

        private void MostrarLineasAmortCte(bool mostrar)
        {
            try
            {
                //Activo o desactivo las líneas de amortiguación constante.
                for (int i = 0; i < 5; i++)
                {
                    zedC.GraphPane.CurveList["Coef. Amort.= " + (0.2 * i + 0.1)].IsVisible = mostrar;
                }
                //Activo o desactivo la leyenda de las líneas de amortiguación constante.
                zedC.GraphPane.CurveList["Líneas de Amortiguación Cte"].Label.IsVisible = mostrar;
            }
            catch { }
        }
        
        private void btnAtras_Click(object sender, EventArgs e)
        {
            pasoActual--;
            manejadorBotones();
        }
        private void btnSig_Click(object sender, EventArgs e)
        {
            //Indicamos que se están ejecutando los cálculos.
            this.Cursor = Cursors.WaitCursor;
            
            pasoActual++;
            manejadorBotones();

            //Indicamos que los cálculos finalizaron.
            this.Cursor = Cursors.Default;
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            IngresoDatos();
        }

        private void IngresoDatos()
        {
            limpiar();

            //Se llama al formulario de Datos. Por parametro se setean los polos y ceros
            FrmDatos dat = new FrmDatos(polos, ceros, rl);
            dat.ShowDialog();

            rl.Polos = polos;
            rl.Ceros = ceros;

            //rl.generarPolinomio();
            try //Si se cierra la ventana sin ingresar nada da error. Por eso el try/catch
            {
                //El tamaño de la gráfica se determina en base a los valores ingresados
                rl.ordenarPolosYCeros();
                rl.resize();
            }
            catch { }

            //Se activa la primer pantalla de reglas (si se ingresaron datos)
            int cant = 0;
            foreach (PointPair p in polos)
                cant += 1;
            if (cant == 0)
                pasoActual = 0;
            else
                pasoActual = 1;
            manejadorBotones();

            //Se deshabilita el boton guardar
            btnGuardar.Enabled = false;
        }

        private void btnCompara_Click(object sender, EventArgs e)
        {
            //Se llama al formulario de Comparacion. 
            FrmCompara comp = new FrmCompara(h);
            comp.ShowDialog();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Se guardan la grafica y la tabla de datos en el historial
            h.addGrafica(zedC.GraphPane.CurveList.Clone(), dat.Copy());

            btnCompara.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void zedC_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            sender.GraphPane.XAxis.CrossAuto = false;
            sender.GraphPane.YAxis.CrossAuto = false;

            if ((sender.GraphPane.XAxis.Scale.Max - sender.GraphPane.XAxis.Scale.Min) < 0.2)
            {
                sender.ZoomOut(sender.GraphPane);
            }
            if ((sender.GraphPane.XAxis.Scale.Min) < rl.InicioEjeX)
            {
                sender.GraphPane.XAxis.Scale.Min = rl.InicioEjeX;             
            }            
        }
        private string zedC_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pto = curve[iPt];
            string respuesta;

            if (curve == zedC.GraphPane.CurveList["Coef. Amort.= " + 0.1] || curve == zedC.GraphPane.CurveList["Coef. Amort.= " + 0.3] ||
                curve == zedC.GraphPane.CurveList["Coef. Amort.= " + 0.5] || curve == zedC.GraphPane.CurveList["Coef. Amort.= " + 0.7] ||
                curve == zedC.GraphPane.CurveList["Coef. Amort.= " + 0.9])
            {
                double coeficienteAmortiguado = Math.Cos(Math.PI - Math.Acos((pto.X / Math.Sqrt(Math.Pow(pto.X, 2) + Math.Pow(pto.Y, 2)))));
                respuesta = "Coef. Amort.: " + Math.Round(coeficienteAmortiguado, 3);
            }
            else
            {
                respuesta = "X: " + Math.Round(pto.X, 3) + "\r\nY: " + Math.Round(pto.Y, 3) + "\r\nValor K: " + pto.Z;
            }

            return respuesta;
        }

        private void cbReferencias_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReferencias.Checked)
            {
                try
                {
                    zedC.GraphPane.CurveList["Asintotas"].Label.IsVisible = false;
                    zedC.GraphPane.CurveList["Asintotas"].IsVisible = false;
                    for (int i = 1; i < cantAsint; i++)
                        zedC.GraphPane.CurveList["Asi" + i].IsVisible = false;
                }
                catch { }
                zedC.Refresh();
            }
            if(!cbReferencias.Checked)
            {
                try
                {
                    zedC.GraphPane.CurveList["Asintotas"].Label.IsVisible = true;
                    zedC.GraphPane.CurveList["Asintotas"].IsVisible = true;
                    for (int i = 1; i < cantAsint; i++)
                        zedC.GraphPane.CurveList["Asi" + i].IsVisible = true;
                }
                catch { }
                zedC.Refresh();
            }
                    

            
                 
        }

        private void cbLineasAmortCte_CheckedChanged(object sender, EventArgs e)
        {
            MostrarLineasAmortCte(cbLineasAmortCte.Checked);
            zedC.Refresh();            
        }
    }
}
