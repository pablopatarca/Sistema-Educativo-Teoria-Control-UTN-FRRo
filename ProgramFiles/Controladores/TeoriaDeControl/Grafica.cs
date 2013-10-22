using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;
using System.Windows.Forms;

namespace Controladores
{
    class Grafica
    {
        #region ATRIBUTOS
        public IPropiedadesGrafica funcion;
        public ZedGraph.ZedGraphControl zedGraphControl;
        public ZedGraph.ZedGraphControl zedGraphControl_2;
        public DataGridView dataGrid = new DataGridView();
        public List<double> listaInicioY = new List<double>();
        public List<double> listaFinY = new List<double>();
        public List<double> listaInicioX = new List<double>();
        public List<double> listaFinX = new List<double>();
        public bool verEntrada = true;
        public bool check1 = false;
        public bool check2 = false;
        public String titulo;

        private int numeroColorActual;
        private Color[] colores = new Color[6];
        static int ID = 1;
        private int id;
        frmMedidas ventanaMedidas;

        public int tipo_error;


        #endregion

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
            iniciarDataGrid();
            
            zedGraphControl = new ZedGraph.ZedGraphControl();

            zedGraphControl_2 = new ZedGraph.ZedGraphControl();

            this.dataGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGrid_RowsAdded);

            //Establece el título del gráfico.
            zedGraphControl.GraphPane.Title.Text = "";
            //Damos nombre a los ejes.
            zedGraphControl.GraphPane.XAxis.Title.Text = "";
            zedGraphControl.GraphPane.YAxis.Title.Text = "";
            //Muestra los valores mientras pasamos por la curva
            zedGraphControl.IsShowPointValues = true;
            zedGraphControl.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            zedGraphControl.IsShowContextMenu = false;



            //Establece el título del gráfico.
            zedGraphControl_2.GraphPane.Title.Text = "";
            //Damos nombre a los ejes.
            zedGraphControl_2.GraphPane.XAxis.Title.Text = "";
            zedGraphControl_2.GraphPane.YAxis.Title.Text = "";
            //Muestra los valores mientras pasamos por la curva
            zedGraphControl_2.IsShowPointValues = true;
            zedGraphControl_2.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler2);

            zedGraphControl_2.IsShowContextMenu = false;


        }

        public void iniciarDataGrid()
        {
            dataGrid = new DataGridView();

            //Agrego la columna del color
            addColumnaValor("Color", "");
            dataGrid.Columns[0].Width = 25;
            dataGrid.Columns[0].ReadOnly = true;

            dataGrid.AllowUserToDeleteRows = false;


            //agrego la columna combobox del error
            DataGridViewComboBoxColumn ColumnaCombo = new DataGridViewComboBoxColumn();
            ColumnaCombo.HeaderText = funcion.NombreParametros[0];
            ColumnaCombo.DataPropertyName = funcion.NombreParametros[0];
            ColumnaCombo.Items.AddRange("Escalón", "Rampa", "Cuadrático");
            ColumnaCombo.DefaultCellStyle.NullValue = "Escalón";
            dataGrid.Columns.Add(ColumnaCombo);


            //agrego la columna de los parametros
            for (int i = 1; i < funcion.NombreParametros.Length; i++)
            {
                addColumnaValor(funcion.NombreParametros[i], funcion.NombreParametros[i]);
            }

            dataGrid.Rows.Add();


            dataGrid.AllowUserToAddRows = false;

            dataGrid.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Transparent;

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

            //(guido)limpio el segundo panel
            zedGraphControl_2.GraphPane.CurveList.Clear();
            zedGraphControl_2.GraphPane.Title.Text = "";
            zedGraphControl_2.GraphPane.XAxis.Title.Text = "";
            zedGraphControl_2.GraphPane.YAxis.Title.Text = "";

        }

        public void addColumnaValor(String nombre, String cabecera)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.HeaderText = cabecera;
            columna.Name = nombre;
            this.dataGrid.Columns.Add(columna);
        }

        /// <summary>
        /// Grafica el contenido del datagrid.
        /// </summary>
        public void graficar()
        {
            bool parametrosCorrectos = true;
            List<PointPairList> lista;
            //Quito las filas de la ventana de medidas
            ventanaMedidas.quitarFilas();
            
            
            restart();

            //for (int i = 0; i < dataGrid.RowCount - 1; i++)
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                double[] parametros = new double[20];
                ZedGraph.GraphPane miPanel = null;
                ZedGraph.GraphPane miPanel_2 = null;
                IPropiedadesGrafica error = null;


                //obtengo el panel de la grafica destino
                miPanel = zedGraphControl.GraphPane;
                miPanel_2 = zedGraphControl_2.GraphPane;


                //obtengo el tipo de error seleccionado en el combobox
                parametros[0] = obtenerTipoError((string)dataGrid.CurrentRow.Cells[1].Value);

                //obtengo los datos del DataGridView y los almaceno el el arreglo parametros[]
                //La columna 0 contiene el color y la 1 el error, por eso no las recorro
                for (int k = 2; k < dataGrid.ColumnCount; k++)
                {
                    try
                    {
                        parametros[k-1] = Double.Parse(dataGrid[k, i].Value.ToString().Replace(',','.'));
                    }
                    catch (NullReferenceException e)
                    {
                        parametrosCorrectos = false;

                    }
                    catch (FormatException)
                    {
                        parametrosCorrectos = false;
                        MessageBox.Show("Se ingresaron parámetros incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                //Valido si hay algun casillero vacio en el dataGrid
                if (parametrosCorrectos)
                {

                    //Obtengo la lista de listas de puntos
                    lista = funcion.generarPuntos(parametros);

                    //Dibujo la salida
                    dibujarCurva(lista[0], miPanel, funcion.Titulos[0], Color.Red);

                    dataGrid.Rows[i].Cells[0].Style.BackColor = color;

                    //Eje Y
                    dibujarCurva(lista[1], miPanel, funcion.Titulos[1], Color.Black);


                    switch ((int)parametros[0])
                    {
                        case 1:
                            error = new ErrorEscalon();
                            break;
                        case 2:
                            error = new ErrorRampa();
                            break;
                        case 3:
                            error = new ErrorCuadratico();
                            break;
                    }


                    lista = error.generarPuntos(parametros);
                    //Curva del error
                    dibujarCurva(lista[0], miPanel_2, funcion.Titulos[0], Color.Blue);
                    //Eje Y
                    dibujarCurva(lista[1], miPanel_2, funcion.Titulos[1], Color.Black);


                    cambiaColor();

                    //Agrega las referencias a los ejes de coordenadas
                    miPanel.XAxis.Title.Text = funcion.NombreEjeX;
                    miPanel.YAxis.Title.Text = funcion.NombreEjeY;
                    miPanel_2.XAxis.Title.Text = error.NombreEjeX;
                    miPanel_2.YAxis.Title.Text = error.NombreEjeY;

                    //Toma los datos de la interfaz para establecer los limites de los ejes de coordenadas               

                    listaInicioY.Add(funcion.InicioEjeY);
                    listaFinY.Add(funcion.FinEjeY);
                    listaInicioX.Add(funcion.InicioEjeX);
                    listaFinX.Add(funcion.FinEjeX);

                    //GRAFICA 1
                    miPanel.YAxis.Scale.Min = listaInicioY.Min();
                    miPanel.YAxis.Scale.Max = listaFinY.Max();
                    miPanel.XAxis.Scale.Min = listaInicioX.Min();
                    miPanel.XAxis.Scale.Max = listaFinX.Max();

                    miPanel.XAxis.Scale.MinorStepAuto = true;
                    miPanel.XAxis.Scale.MajorStepAuto = true;

                    //GRAFICA 2
                    miPanel_2.YAxis.Scale.Min = error.InicioEjeY;
                    miPanel_2.YAxis.Scale.Max = error.FinEjeY;
                    miPanel_2.XAxis.Scale.Min = listaInicioX.Min();
                    miPanel_2.XAxis.Scale.Max = listaFinX.Max();

                    miPanel_2.XAxis.Scale.MinorStepAuto = true;
                    miPanel_2.XAxis.Scale.MajorStepAuto = true;

                }//fin if(parametrosCorrectos)

                //(guido)
                tipo_error = (int)parametros[0];

            }//fin for que recorre las filas del datagrid


            zedGraphControl.AxisChange();
            zedGraphControl.Refresh();
            
            zedGraphControl_2.AxisChange();
            zedGraphControl_2.Refresh();
    }

        public void dibujarCurva(PointPairList listaPuntos, GraphPane miPanel, String nombre, Color color)
        {

            LineItem curva = miPanel.AddCurve(nombre, listaPuntos, color, SymbolType.None);

            curva.Line.IsAntiAlias = true;
            curva.Line.IsSmooth = true;
            curva.Line.SmoothTension = 0.00001f;


        }

        public String getNombre()
        {
            return titulo;
        }

        public void showFrmMedidas()
        {
            ventanaMedidas.Show();
            ventanaMedidas.dataGridView1.ClearSelection();
            ventanaMedidas.dataGridView2.ClearSelection();
        }

        public void hideFrmMedidas()
        {
            ventanaMedidas.Hide();

        }

        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
        {
            //Obtiene el par de puntos que está bajo el mouse.
            PointPair pt = curve[iPt];
            return curve.Label.Text + ": " + "p(t): " + pt.Y.ToString("f2") + "; t: " + pt.X.ToString("f2");
        }

        private string MyPointValueHandler2(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
        {
            //Obtiene el par de puntos que está bajo el mouse.
            PointPair pt = curve[iPt];
            return curve.Label.Text + ": " + "e(t): " + pt.Y.ToString("f2") + "; t: " + pt.X.ToString("f2");
        }

        private void dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGrid.Rows.Count == 5)
            {
                //dataGrid.AllowUserToAddRows = false;
            }
        }

        public void setTitulo()
        {
            switch (funcion.GetType().ToString())
            {
                case ("Controladores.Proporcional"):
                    titulo = "Proporcional [" + id + "]";
                    break;
                case ("Controladores.ProporcionalDerivativo"):
                    titulo = "Proporcional_Derivativo [" + id + "]";
                    break;
                case ("Controladores.ProporcionalIntegral"):
                    titulo = "Proporcional_Integral [" + id + "]";
                    break;
                case ("Controladores.ProporcionalIntegralDerivativo"):
                    titulo = "Proporcional_Integral_Derivativo [" + id + "]";
                    break;


            }
        }

        public double obtenerTipoError(string seleccionado)
        {
            double error = 0;

            if (seleccionado == "Escalón" || seleccionado == null) error = 1;
            else if (seleccionado == "Rampa") error = 2;
            else if (seleccionado == "Cuadrático") error = 3;

            return error;
        }
    }
}
