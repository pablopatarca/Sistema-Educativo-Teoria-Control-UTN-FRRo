using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TeoriaDeControl
{
    class Grafica
    {
        #region ATRIBUTOS
        public IPropiedadesGrafica funcion;
        public ZedGraph.ZedGraphControl zedGraphControl;
        public DataGridView dataGrid = new DataGridView();
        public List<double> listaInicioY = new List<double>();
        public List<double> listaFinY = new List<double>();
        public List<double> listaInicioX = new List<double>();
        public List<double> listaFinX = new List<double>();
        public bool verEntrada = true;
        public bool chkGrReferencias = false;     //verifica si está checkeado Referencias
        public bool chkGrTpoAsentamiento = false; //verifica si está checkeado Tiempo de Asentamiento
        public bool chkGrTpoSubida = false;       //verifica si está checkeado Tiempo de Subida
        public bool chkGrPendienteOrigen = false; //verifica si está checkeado Pendiente en el Origen
        public String titulo;

        private int numeroColorActual;
        private Color[] colores = new Color[6];
        static int ID = 1;
        private int id;
        private bool esSenoidal;
        private bool clickeado = false;
        public frmMedidas ventanaMedidas;

        #endregion

        public IPropiedadesGrafica Funcion
        {
            get
            {
                return funcion;
            }
        }

        public Grafica(IPropiedadesGrafica funcion)
        {
            this.funcion = funcion;
            colores[0] = Color.Red;
            colores[1] = Color.Green;
            colores[2] = Color.Orange;
            colores[3] = Color.DarkViolet;
            colores[4] = Color.SaddleBrown;
            colores[5] = Color.LightCoral;
            id = ID;
            ID++;
            ventanaMedidas = new frmMedidas();
            esSenoidal = false;
            iniciarDataGrid();
            
            zedGraphControl = new ZedGraph.ZedGraphControl();

            //Establece el título del gráfico.
            zedGraphControl.GraphPane.Title.Text = "";
            //Damos nombre a los ejes.
            zedGraphControl.GraphPane.XAxis.Title.Text = "";
            zedGraphControl.GraphPane.YAxis.Title.Text = "";
            //Muestra los valores mientras pasamos por la curva
            zedGraphControl.IsShowPointValues = true;
            zedGraphControl.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            zedGraphControl.IsShowContextMenu = false;
            // Cambia la letra del zedgraphcontrol y el tamaño. NO FUNCIONA!!!
            zedGraphControl.Font = new Font("Times New Roman", 20.0f);

            //Muestro siempre el valor base en la senoidal de segundo orden
            if (funcion.GetType() == typeof(EntradaSenoidalOrden2))
            {
                chkGrReferencias = true;
            }
        }

        public void iniciarDataGrid()
        {
            dataGrid = new DataGridView();
            //establezco el evento del dataGrid para que manejar los tabs
            this.dataGrid.CellEnter +=new DataGridViewCellEventHandler(dataGrid_CellEnter);
            //validar entrada de datos numéricos
            this.dataGrid.CellValidating+=new DataGridViewCellValidatingEventHandler(dataGrid_CellValidating);
            this.dataGrid.Click += new EventHandler(dataGrid_Click);

            //Agrego la columna del color
            addColumnaValor("Color", "");
            dataGrid.Columns[0].Width = 25;

            dataGrid.Columns[0].ReadOnly = true;

            dataGrid.AllowUserToDeleteRows = false;

            //agrego la columna de los parametros
            for (int i = 0; i < funcion.NombreParametros.Length; i++)
            {
                addColumnaValor(funcion.NombreParametros[i], funcion.NombreParametros[i]);
            }

            //Evaluo si son senos
            if (funcion.GetType() == typeof(EntradaSenoidalOrden2) || funcion.GetType() == typeof(EntradaSenoidalOrden1))
            {
                dataGrid.Rows.Add();
            }
            else
            {
                dataGrid.Rows.Add(5);
            }

            dataGrid.AllowUserToAddRows = false;

            dataGrid.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Transparent;

            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        public Color color
        {
            set { }
            get 
            {
                return colores[numeroColorActual];
            }
        }

        public void cambiaColor()
        {
            numeroColorActual++;
            if (numeroColorActual > 5)
            {
                numeroColorActual = 0;
            }
        }

        /// <summary>
        /// Limpia las listas, limpia la coleccion de curvas, quita las referencia de los ejes, quita el titulo y pone en 0 el contador de colores.
        /// </summary>
        public void restart()
        {
            listaFinX.Clear();
            listaFinY.Clear();
            listaInicioX.Clear();
            listaInicioY.Clear();
            numeroColorActual = 0;
            zedGraphControl.GraphPane.CurveList.Clear();
            zedGraphControl.GraphPane.Title.Text = "";
            zedGraphControl.GraphPane.XAxis.Title.Text = "";
            zedGraphControl.GraphPane.YAxis.Title.Text = "";
        }

        public void addColumnaValor(String nombre, String cabecera)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.HeaderText = cabecera;
            columna.Name = nombre;
            columna.Width = 80;
            this.dataGrid.Columns.Add(columna);
        }

        /// <summary>
        /// Grafica el contenido del datagrid.
        /// </summary>
        public void graficar()
        {
            bool parametrosCorrectos = true;
            List<PointPairList> lista;
            
            double relActual;
            int relPermite = -1;
            const double relacion = 50; //relacion entre amplitud y constante de tiempo

            //Quito las filas de la ventana de medidas
            ventanaMedidas.quitarFilas();

            restart();

            //for (int i = 0; i < dataGrid.RowCount - 1; i++)
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                double[] parametros = new double[20];
                ZedGraph.GraphPane miPanel = null;
                relPermite = -1; //si no se permite por relación indica la fila que no tiene la relación indicada

                //obtengo el panel de la grafica destino
                miPanel = zedGraphControl.GraphPane;

                //obtengo los datos del DataGridView y los almaceno en el arreglo parametros[]
                //La columna 0 contiene el color, por eso no la recorro
                for (int k = 1; k < dataGrid.ColumnCount; k++)
                {
                    try
                    {
                        parametros[k - 1] = Double.Parse(dataGrid[k, i].Value.ToString().Replace(',', '.'));
                    }
                    catch (NullReferenceException e)
                    {
                        parametrosCorrectos = false;
                    }
                    catch (FormatException e)
                    {
                        parametrosCorrectos = false;
                    }

                    if (parametros[0] < 0)
                    {
                        //el valor base puede llegar a ser 0 pero no menor
                        parametrosCorrectos = false;
                    }
                    else if ((parametros[k - 1] < 0.001) && (k!=1))
                    {
                        parametrosCorrectos = false;
                    }
                }

                //vaildo la relación entre amplitud y cte de tiempo
                //si es función senoidal se ponen en otro índice de parametros la amplitud y la cte de tiempo
                switch (funcion.GetType().ToString())
                {
                    case("TeoriaDeControl.EntradaSenoidalOrden1"):
                    case ("TeoriaDeControl.EntradaSenoidalOrden2"):
                        relActual = parametros[1] / parametros[3];
                        break;
                    default:
                        relActual = parametros[0] / parametros[1];
                        break;
                }
                    
                if ((relActual < (1 / relacion)) || (relActual > relacion))
                {
                    parametrosCorrectos = false;
                    relPermite = i+1;
                }

                //Valido si hay algun casillero vacio en el dataGrid
                if (parametrosCorrectos)
                {

                    //Obtengo la lista de listas de puntos
                    lista = funcion.generarPuntos(parametros);

                    if (verEntrada)
                    {
                        dibujarCurva(lista[1], miPanel, funcion.Titulos[1], Color.Blue);
                    }

                    //Dibujo la salida
                    dibujarCurva(lista[0], miPanel, funcion.Titulos[0], color);

                    dataGrid.Rows[i].Cells[0].Style.BackColor = color;                        

                    if (chkGrReferencias)
                    {
                        dibujarCurva(lista[2], miPanel, funcion.Titulos[2], Color.Green);
                    }


                    if (chkGrTpoSubida && i==0)
                    {
                        for (int j = 4; j < 7; j++)
                        {
                            dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Gray);
                        }
                    }

                    if (chkGrPendienteOrigen)
                    {
                        if (funcion.GetType().ToString() == "TeoriaDeControl.EntradaEscalonOrden1")
                        {
                            dibujarCurva(lista[7], miPanel, funcion.Titulos[7], Color.Black); 
                        }
                        else if (funcion.GetType().ToString() == "TeoriaDeControl.EntradaImpulsoOrden1")
                        {
                            dibujarCurva(lista[4], miPanel, funcion.Titulos[4], Color.Black);
                        }
                    }

                    //recorro el arreglo de listas y grafico el resto de las curvas
                    if (chkGrTpoAsentamiento)
                    {
                        for (int j = 1; j < lista.Count; j++)
                        {
                            if (lista[j] != null)
                            {
                                switch (j)
                                {
                                    case 1:
                                        //dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Blue);
                                        break;
                                    case 2:
                                        //dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Gray);
                                        break;
                                    case 3:
                                        dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Orange);
                                        break;
                                    case 4:
                                        if ((funcion.GetType().ToString() == "TeoriaDeControl.EntradaEscalonOrden2") || (funcion.GetType().ToString() == "TeoriaDeControl.EntradaImpulsoOrden2"))
                                            dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Orange); //Bandas
                                        else
                                            if (funcion.GetType().ToString() != "TeoriaDeControl.EntradaEscalonOrden1" && funcion.GetType().ToString() != "TeoriaDeControl.EntradaImpulsoOrden1")
                                            dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Black);  //Tiempo de solapamiento
                                        break;
                                    case 5:
                                        if (funcion.GetType().ToString() != "TeoriaDeControl.EntradaEscalonOrden1")
                                        dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Purple);
                                        break;
                                    case 6:
                                        if (funcion.GetType().ToString() != "TeoriaDeControl.EntradaEscalonOrden1")
                                        dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Fuchsia);
                                        break;
                                    case 7:
                                        //dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Brown);
                                        break;
                                    case 8:
                                        dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.Coral);
                                        break;
                                    case 9:
                                        dibujarCurva(lista[j], miPanel, funcion.Titulos[j], Color.DarkTurquoise);
                                        break;
                                }
                            }
                        }
                    }
                    //Agrego las medidas a el datagrid del frmMedidas

                    ventanaMedidas.addLineaDatos(funcion.Titulos[0], funcion.Medidas, funcion.Amortiguacion);
                    ventanaMedidas.ocultarColumnas(); //Oculto las columnas que no uso
                    ventanaMedidas.dgvMedidas.Rows[i].Cells[0].Style.BackColor = color;

                    //Evaluo si son senos, completo la tabla de Retraso
                    if (funcion.GetType() == typeof(EntradaSenoidalOrden2))
                    {
                        ventanaMedidas.addLineaFrecuencias(funcion.Titulos[0], ((EntradaSenoidalOrden2)funcion).FrecGrados, color);
                    }

                    if (funcion.GetType() == typeof(EntradaSenoidalOrden1))
                    {
                        //La funcion senoidal1orden siempre devuelve el valor base en la posicion 5
                        dibujarCurva(lista[5], miPanel, funcion.Titulos[5], Color.Purple);

                        ventanaMedidas.addLineaFrecuencias2(funcion.Titulos[0], ((EntradaSenoidalOrden1)funcion).FrecGrados, color);
                    }


                    cambiaColor();

                    //Agrega las referencias a los ejes de coordenadas
                    miPanel.XAxis.Title.Text = funcion.NombreEjeX;
                    miPanel.YAxis.Title.Text = funcion.NombreEjeY;

                    //Toma los datos de la interfaz para establecer los limites de los ejes de coordenadas               

                    listaInicioY.Add(funcion.InicioEjeY);
                    listaFinY.Add(funcion.FinEjeY);
                    listaInicioX.Add(funcion.InicioEjeX);
                    listaFinX.Add(funcion.FinEjeX);

                    /*
                    //Agrego los maximos y minimos de la salida de la Senoidal2Orden para analizar en el inicio y fin de ejes
                    if (funcion.GetType() == typeof(Senoidal2ordenLu))
                    {
                        listaFinY.Add((double)funcion.Medidas[13]*1.1);
                        listaInicioY.Add((double)funcion.Medidas[14]*1.1);
                    }
                    */


                    miPanel.YAxis.Scale.Min = listaInicioY.Min();
                    miPanel.YAxis.Scale.Max = listaFinY.Max();
                    miPanel.XAxis.Scale.Min = listaInicioX.Min();
                    miPanel.XAxis.Scale.Max = listaFinX.Max();

                    miPanel.XAxis.Scale.MinorStepAuto = true;
                    miPanel.XAxis.Scale.MajorStepAuto = true;

                }
                else
                {
                    if (relPermite!=-1)
                    {
                        MessageBox.Show("La relación entre la Amplitud y la Cte de tiempo de la " + relPermite + " fila es mayor a 50 veces", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }//fin if(parametrosCorrectos)
            }//fin for que recorre las filas del datagrid

            zedGraphControl.AxisChange();
            zedGraphControl.Refresh();
    }

        public void dibujarCurva(PointPairList listaPuntos, GraphPane miPanel, String nombre, Color color)
        {
            LineItem curva = miPanel.AddCurve(nombre, listaPuntos, color, SymbolType.None);
            if(nombre=="Entrada Impulso")
                curva.Line.Width = 5;
            if (nombre == "Tiempo de subida")
            {
                curva.Line.Width = 10;
            }
            if (nombre == "Pendiente en el origen")
            {
                curva.Line.Style = System.Drawing.Drawing2D.DashStyle.Custom;
                curva.Line.DashOn = 20;
                curva.Line.DashOff = 5;
            }

            if (!(funcion.GetType() == typeof(EntradaSenoidalOrden2) || funcion.GetType() == typeof(EntradaSenoidalOrden1)))
            {
                nombre = "";
            }

            curva.Line.IsAntiAlias = true;
            curva.Line.IsSmooth = true;
            curva.Line.SmoothTension = 0.00001f;
            //curva.Line.SmoothTension = 1.0f;
        }

        public String getNombre()
        {
            return titulo;
        }

        public void showFrmMedidas()
        {
            ventanaMedidas.Show();
            ventanaMedidas.dgvMedidas.ClearSelection();
            ventanaMedidas.dgvRetardoFase.ClearSelection();
            ventanaMedidas.retardoEsVisible(esSenoidal);
        }

        public void hideFrmMedidas()
        {
            ventanaMedidas.Hide();
        }

        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
        {
            //Obtiene el par de puntos que está bajo el mouse.
            PointPair pt = curve[iPt];

            return curve.Label.Text + ": " + "Y(t): " + pt.Y.ToString("f2") + "; t: " + pt.X.ToString("f2");
        }

        public void setTitulo()
        {
            switch (funcion.GetType().ToString())
            {
                case ("TeoriaDeControl.EntradaEscalonOrden1"):
                    titulo = "Escalon1ºOrden [" + id+"]";
                    esSenoidal = false;
                    break;
                case ("TeoriaDeControl.EntradaImpulsoOrden1"):
                    titulo = "Impulso1ºOrden [" + id + "]";
                    esSenoidal = false;
                    break;
                case ("TeoriaDeControl.EntradaImpulsoOrden2"):
                    titulo = "Impulso2ºOrden [" + id + "]";
                    esSenoidal = false;
                    break;
                case ("TeoriaDeControl.EntradaRampaOrden1"):
                    titulo = "Rampa1ºOrden [" + id + "]";
                    esSenoidal = false;
                    break;
                case ("TeoriaDeControl.EntradaSenoidalOrden1"):
                    titulo = "Senoidal1ºOrden [" + id + "]";
                    esSenoidal = true;
                    break;
                case ("TeoriaDeControl.EntradaEscalonOrden2"):
                    titulo = "Escalon2ºOrden [" + id + "]";
                    esSenoidal = false;
                    break;
                case ("TeoriaDeControl.EntradaSenoidalOrden2"):
                    titulo = "Senoidal2ºOrden [" + id + "]";
                    esSenoidal = true;
                    break;
                default:
                    break;
            }
        }

        private void dataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //si la celda es de solo lectura, realizar un tab (para pasar a la siguiente celda, salteando la de color)
            if ((dataGrid.CurrentRow.Cells[e.ColumnIndex].ReadOnly) && (clickeado))
            {
                SendKeys.Send("{tab}");
            }
        }

        private bool validarCeldaNumerica(string cad)
        {
            //formato 1.12123123 es decir número y si se quiere nº.nºnºnºnºnºnº se puede usar coma(,) o punto(.)
            string patternNum = @"^([0-9]+((\.|,)[0-9]+)?)?$";

            return Regex.IsMatch(cad, patternNum);
        }

        private bool validarTpoAsent(string cad)
        {
            //valido que %tiempo de asentamiento sea un entero entre 1 y 5
            string patternNum = @"^[1-5]$";

            return Regex.IsMatch(cad, patternNum);
        }

        private void dataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string celda = e.FormattedValue.ToString();

            //si la celda tiene valor
            if (celda != "")
            {
                //si no cumple con la expresión regular
                if (!validarCeldaNumerica(celda))
                {
                       MessageBox.Show("Ingrese un valor válido", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                       e.Cancel = true;
                }
                //si es la columna de %tiempo de asentamiento y no cumple con la expresión regular
                else if (dataGrid.Columns[e.ColumnIndex].HeaderText == "% Tiempo Asent." && !validarTpoAsent(celda))
                {
                    MessageBox.Show("Ingrese un valor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        void dataGrid_Click(object sender, EventArgs e)
        {
            //para corregir el error que cambie de foco de celda al principio
            clickeado = true;
        }

        internal void setTituloMedidas(string titulo)
        {
            this.ventanaMedidas.Text = titulo;
        }
    }
}
