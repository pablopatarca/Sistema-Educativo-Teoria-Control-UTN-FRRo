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
    public partial class frmRespuestaTransienteMain : Form
    {
        Historial h;
        DataTable dat;

        #region ATRIBUTOS
        Grafica grafica=null;
        List<Grafica> listaGraficas = new List<Grafica>();
        persGraficaMySql persRespuestas;
        String respTransiente;
        //List<String> lista = new List<string>();
        #endregion

        public frmRespuestaTransienteMain() 
        {
            //Seteo la cultura para utilizar el punto como separador decimal
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            pnlAcciones.Hide();
            //lstArchivos.DataSource = generarLista();

            //Desactivo las opciones no permitidas
            guardarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = false;
        }

        public frmRespuestaTransienteMain(String respTr,Historial his)
        {
            //Seteo la cultura para utilizar el punto como separador decimal
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            pnlAcciones.Hide();
            respTransiente = respTr;

            h = new Historial();
            this.h = his;
            
            CurveList g = new CurveList();

            g = h.getGrafica(0);

            if (g.Count != 0)
                this.btnComparar.Enabled = true;
            else
                this.btnComparar.Enabled = false;

            //--------------DB---------------//
            persRespuestas = new persGraficaMySql(respTransiente);
            //--------------DB---------------//

            //lstArchivos.DataSource = generarLista();
            //generarLista(lstArchivos);

            //Desactivo las opciones no permitidas
            guardarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = false;

            //Se inicializa la Respuesta Transiente correspondiente según corresponda con el parámetro respTransiente
            //Además, se setea el título de la ventana correspondiente a la función seleccionada
            //También setea la imagen con la fórmula correspondiente en cada caso
            if (respTransiente.Equals("Escalon1")) {
                this.Text = this.Text + ", Sistemas de Primer Orden, Entrada Escalón";
                iniciarComponentesGrafica(new EntradaEscalonOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                gbxAsentamientoVsPsi.Visible = false;
                gbxOvershootVsPsi.Visible = false;
                btnTiempoAsentVSPsi.Visible = false;
                btnOvershootVsPsi.Visible = false;
                pbxFormulaEstandar.Visible = false;
                gbxFormulaEstandar.Visible = false;
                chkTpoSubida.Visible = true;
                groupBox1.Height = 81;
                chkPendienteOrigen.Visible = true;
            }
            else if (respTransiente.Equals("Impulso1")) {
                this.Text = this.Text + ", Sistemas de Primer Orden, Entrada Impulso";
                iniciarComponentesGrafica(new EntradaImpulsoOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                gbxAsentamientoVsPsi.Visible = false;
                gbxOvershootVsPsi.Visible = false;
                btnTiempoAsentVSPsi.Visible = false;
                btnOvershootVsPsi.Visible = false;
                pbxFormulaEstandar.Visible = false;
                gbxFormulaEstandar.Visible = false;
                chkTpoSubida.Visible = false;
                groupBox1.Height = 81;
                chkPendienteOrigen.Visible = true;
            }
            else if (respTransiente.Equals("Senoidal1"))
            {
                this.Text = "Sistemas de Primer Orden, Entrada Senoidal";
                iniciarComponentesGrafica(new EntradaSenoidalOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                gbxAsentamientoVsPsi.Visible = false;
                gbxOvershootVsPsi.Visible = false;
                btnTiempoAsentVSPsi.Visible = false;
                btnOvershootVsPsi.Visible = false;
                pbxFormulaEstandar.Visible = false;
                gbxFormulaEstandar.Visible = false;
                chkTpoSubida.Visible = false;
                chkPendienteOrigen.Visible = false;
            }
            else if (respTransiente.Equals("Rampa1"))
            {
                this.Text = this.Text + ", Sistemas de Primer Orden, Entrada Rampa";
                iniciarComponentesGrafica(new EntradaRampaOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                gbxAsentamientoVsPsi.Visible = false;
                gbxOvershootVsPsi.Visible = false;
                btnTiempoAsentVSPsi.Visible = false;
                btnOvershootVsPsi.Visible = false;
                pbxFormulaEstandar.Visible = false;
                gbxFormulaEstandar.Visible = false;
                chkTpoSubida.Visible = false;
                chkPendienteOrigen.Visible = false;
            }
            else if (respTransiente.Equals("Escalon2"))
            {
                this.Text = this.Text + ", Sistemas de Segundo Orden, Entrada Escalón";
                iniciarComponentesGrafica(new EntradaEscalonOrden2());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                gbxAsentamientoVsPsi.Visible = true;
                gbxOvershootVsPsi.Visible = true;
                btnTiempoAsentVSPsi.Visible = true;
                btnOvershootVsPsi.Visible = true;
                pbxFormulaEstandar.Visible = true;
                gbxFormulaEstandar.Visible = true;
                chkTpoSubida.Visible = false;
                chkPendienteOrigen.Visible = false;
            }
            else if (respTransiente.Equals("Impulso2"))
            {
                this.Text = this.Text + ", Sistemas de Segundo Orden, Entrada Impulso";
                iniciarComponentesGrafica(new EntradaImpulsoOrden2());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                gbxAsentamientoVsPsi.Visible = true;
                gbxOvershootVsPsi.Visible = true;
                btnTiempoAsentVSPsi.Visible = true;
                btnOvershootVsPsi.Visible = true;
                pbxFormulaEstandar.Visible = true;
                gbxFormulaEstandar.Visible = true;
                chkTpoSubida.Visible = false;
                chkPendienteOrigen.Visible = false;
            }
            else if (respTransiente.Equals("Senoidal2"))
            {
                this.Text = "Sistemas de Segundo Orden, Entrada Senoidal";
                iniciarComponentesGrafica(new EntradaSenoidalOrden2());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                gbxAsentamientoVsPsi.Visible = false;
                gbxOvershootVsPsi.Visible = false;
                btnTiempoAsentVSPsi.Visible = false;
                btnOvershootVsPsi.Visible = false;
                pbxFormulaEstandar.Visible = true;
                gbxFormulaEstandar.Visible = true;
                chkTpoSubida.Visible = false;
                chkPendienteOrigen.Visible = false;
            }
            else if (respTransiente.Equals("Rampa2"))
            {
                this.Text = this.Text + ", Sistemas de Segundo Orden, Entrada Rampa";
                iniciarComponentesGrafica(new EntradaRampaOrden2());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                
                //Agrando el tamaño del cuadro donde se muestra la fórmula,
                //corro el groupBox de la fórmula estándar más a la derecha y
                //agrando el panel que los contiene para que se puedan visualizar.
                pbFormula.Size = new System.Drawing.Size(400, 61);
                gbxFormulaEstandar.Location = new Point(626, 5);
                pnlAcciones.Size = new System.Drawing.Size(887, 161);
                
                gbxAsentamientoVsPsi.Visible = false;
                gbxOvershootVsPsi.Visible = false;
                btnTiempoAsentVSPsi.Visible = false;
                btnOvershootVsPsi.Visible = false;
                pbxFormulaEstandar.Visible = true;
                gbxFormulaEstandar.Visible = true;
                chkTpoSubida.Visible = false;
                chkPendienteOrigen.Visible = false;
            }
            this.Text += "                         ";


        }

        private void agregarComponentes()
        {

            pnlAcciones.Show();
            this.Controls.Add(grafica.zedGraphControl);
            pnlDatosGrafica.Controls.Add(grafica.dataGrid);
            acomodarElementos();

            //Habilito las opciones del menu
            guardarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem.Enabled = true;
        }

        private void iniciarComponentesGrafica(IPropiedadesGrafica funcion)
        {            
            if (grafica != null)
            {
                //guardarGrafica();
                //remuevo los componentes anteriores antes de instanciar los nuevos.
                quitarComponentes();
            }

            grafica = new Grafica(funcion);
            grafica.setTitulo();
            chkEntrada.Checked = grafica.verEntrada;
            chkReferencias.Checked = grafica.chkGrReferencias;
            chkTpoAsentamiento.Checked = grafica.chkGrTpoAsentamiento;
            txtTitulo.Text = grafica.titulo;

            //Asigno los textos de los checkBoton
            if (grafica.funcion.Botones[0] != "")
            {
                chkReferencias.Text = grafica.funcion.Botones[0];
                chkReferencias.Visible = true;
            }
            else
            {
                chkReferencias.Visible = false;
            }

            if (grafica.funcion.Botones[1] != "")
            {
                chkTpoAsentamiento.Text = grafica.funcion.Botones[1];
                chkTpoAsentamiento.Visible = true;
            }
            else
            {
                chkTpoAsentamiento.Visible = false;
            }
                

        }

        private void guardarGrafica()
        {
            if (grafica != null)
            {
                grafica.hideFrmMedidas();

                grafica.titulo = txtTitulo.Text;

                /*if (!listaGraficas.Contains(grafica))
                {
                    listaGraficas.Add(grafica);
                }*/

                //persistencia
                persRespuestas.nuevaGrafica(grafica);
                if (persRespuestas.aplicarCambios(txtTitulo.Text))
                {
                    lstArchivos.Items.Add(txtTitulo.Text);
                }
                //persistencia
            }
        }

        private void generarLista(ListBox lb)
        {
            //List<String> lista = new List<string>();
            List<String> lista = persRespuestas.getTitulos();

            foreach (String l in lista)
            {
                lb.Items.Add(l);
            }
        }

        private List<String> generarLista()
        {
            //List<String> lista = new List<string>();
            List<String> lista = persRespuestas.getTitulos();
            
            /*foreach (Grafica g in listaGraficas)
            {
                lista.Add(g.getNombre());
            }*/
            return lista;
        }

        private void cambiaGrafica()
        {
            String graficaSelect = (string)lstArchivos.SelectedItem;
            //grafica.dataGrid
            persRespuestas.getGrafica(graficaSelect, grafica.dataGrid);
            grafica.graficar();

            //-----
            grafica.dataGrid.Click += new EventHandler(grafica_dataGrid_Click);
            grafica.dataGrid.ClearSelection();
            //----
            guardarGrafica();
            foreach (Grafica g in listaGraficas)
            {
                if (graficaSelect == g.getNombre())
                {
                    quitarComponentes();
                    grafica = g;
                    agregarComponentes();
                    chkEntrada.Checked = grafica.verEntrada;
                    chkReferencias.Checked = grafica.chkGrReferencias;
                    chkTpoAsentamiento.Checked = grafica.chkGrTpoAsentamiento;
                    txtTitulo.Text = grafica.titulo;
                    lstArchivos.ClearSelected();

                    //Asigno los textos de los checkBoton
                    if (grafica.funcion.Botones[0] != "")
                    {
                        chkReferencias.Text = grafica.funcion.Botones[0];
                        chkReferencias.Visible = true;
                    }
                    else
                    {
                        chkReferencias.Visible = false;
                    }

                    if (grafica.funcion.Botones[1] != "")
                    {
                        chkTpoAsentamiento.Text = grafica.funcion.Botones[1];
                        chkTpoAsentamiento.Visible = true;
                    }
                    else
                    {
                        chkTpoAsentamiento.Visible = false;
                    }
                }
            }

            this.btnGuardar.Enabled = true;
            this.btnOvershootVsPsi.Enabled = true;
            this.btnTiempoAsentVSPsi.Enabled = true;
        }

        private void eliminarGrafica()
        {
            if (grafica != null)
            {
                listaGraficas.Remove(grafica);
                txtTitulo.Text = "";
                chkReferencias.Hide();
                chkTpoAsentamiento.Hide();
                grafica.hideFrmMedidas();

                //Desactivo las opciones no permitidas
                guardarToolStripMenuItem.Enabled = false;
                eliminarToolStripMenuItem.Enabled = false;
                
            }
            quitarComponentes();
            //lstArchivos.DataSource = null;
            //lstArchivos.DataSource = generarLista();
            grafica = null;

        }
        
        private void acomodarElementos()
        {
            int altoVentana = this.Height-50;
            int anchoVentana = this.Width;

            int altoPanel = 155;//(int)(altoVentana * 0.2);
            int altoGrafica = altoVentana - altoPanel;

            int anchoGrafica = anchoVentana;
            int anchoPanel = anchoVentana;

            int anchoDataGrid = 500;//(int)(anchoPanel * 0.5);
            int altoDataGrid = altoPanel; //(int)(altoPanel * 0.9);

            if (grafica != null)
            {
                grafica.zedGraphControl.Size = new System.Drawing.Size(anchoGrafica, altoGrafica);
                grafica.zedGraphControl.Location = new Point(0, altoPanel + 20);
                grafica.dataGrid.Size = new System.Drawing.Size(anchoDataGrid, altoDataGrid);
            }

            pnlDatosGrafica.Size = new System.Drawing.Size(anchoPanel, altoPanel);
            pnlDatosGrafica.Location = new Point(0, 25);

            pnlAcciones.Location = new Point(anchoDataGrid, 0);

        }

        private void quitarComponentes()
        {
            if (grafica != null)
            {
                this.Controls.Remove(grafica.zedGraphControl);
                pnlDatosGrafica.Controls.Remove(grafica.dataGrid);
                pnlAcciones.Visible = false;
            }
        }

        private void limpiarDataGrid()
        {
            if (grafica != null)
            {
                grafica.hideFrmMedidas();
                pnlDatosGrafica.Controls.Remove(grafica.dataGrid);
                grafica.iniciarDataGrid();
                agregarComponentes();
                grafica.graficar();

                pbFormula.Image = TeoriaDeControl.Properties.Resources.Blanco;
                btnGuardar.Enabled = false;
                btnOvershootVsPsi.Enabled = false;
                btnTiempoAsentVSPsi.Enabled = false;
                cuadroBlanco1.Visible = false;
                cuadroBlanco2.Visible = false;
                cuadroBlanco3.Visible = false;
                lblNumerador.Visible = false;
                lblDenominador2Termino.Visible = false;
                lblDenominador3Termino.Visible = false;
            }
        }

        private void rellenarValores()
        {
            double valor;
            if (grafica != null)
            {

                grafica.hideFrmMedidas();

                for (int i = 1; i < grafica.dataGrid.ColumnCount; i++)
                {
                    if (grafica.dataGrid[i, 0].Value != null)
                    {
                        valor = Double.Parse(grafica.dataGrid[i, 0].Value.ToString().Replace(',', '.'));

                        for (int j = 1; j < grafica.dataGrid.RowCount; j++)
                        {
                            grafica.dataGrid[i, j].Value = valor;
                        }
                    }
                }
            }
        }

        private void repetirUltimaFila()
        {
            int filaActual;  //Indica la fila que está actualmente seleccionada
            if (grafica != null)
            {

                grafica.hideFrmMedidas();

                //Obtenemos la fila seleccionada
                filaActual = grafica.dataGrid.CurrentCell.RowIndex;
                //Si la fila seleccionada no es la última, se copia la fila a la posterior seleccionando esta última
                if (filaActual != grafica.dataGrid.RowCount - 1)
                {
                    copiarFila(filaActual, filaActual + 1);
                    grafica.dataGrid.Rows[grafica.dataGrid.CurrentCell.RowIndex + 1].Selected = true;
                    grafica.dataGrid.CurrentCell = grafica.dataGrid.Rows[grafica.dataGrid.CurrentCell.RowIndex + 1].Cells[0];
                }
                else
                {
                    MessageBox.Show("No se puede repetir dicha fila ya que es la última", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void copiarFila(int filaOrigen, int filaDestino)
        {
            string valor;
            //Si estamos en filas válidas (no menor a la primera (en el caso del origen) ni mayor a la última(en el destino))
            if ((filaOrigen >= 0) && (filaDestino < grafica.dataGrid.RowCount))
            {
                //se copia el contenido de la filaOrigen a la Destino
                for (int i = 1; i < grafica.dataGrid.ColumnCount; i++)
                {
                    if (grafica.dataGrid[i, filaOrigen].Value != null)
                    {
                        valor = grafica.dataGrid[i, filaOrigen].Value.ToString().Replace(',', '.');
                        grafica.dataGrid[i, filaDestino].Value = valor;
                    }
                }
            }
            
        }

        #region EVENTOS

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            acomodarElementos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eliminarGrafica();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //cambiaGrafica();
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            //guardarGrafica();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //cambiaGrafica();
        }

        private void checkRef_CheckedChanged(object sender, EventArgs e)
        {
            //referencias o overshoot
            if (grafica != null)
            {
                grafica.chkGrReferencias = chkReferencias.Checked;
                grafica.graficar();
            }
        }

        private void checkEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (grafica != null)
            {
                grafica.verEntrada = chkEntrada.Checked;
                grafica.graficar();
            }
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            //tpo asentamiento o bandas
            if (grafica != null)
            {
                grafica.chkGrTpoAsentamiento = chkTpoAsentamiento.Checked;
                grafica.graficar();
            }
        }

        private void chkTpoSubida_CheckedChanged(object sender, EventArgs e)
        {
            if (grafica != null)
            {
                grafica.chkGrTpoSubida = chkTpoSubida.Checked;
                grafica.graficar();
            }
        }

        private void chkPendienteOrigen_CheckedChanged(object sender, EventArgs e)
        {
            if (grafica != null)
            {
                grafica.chkGrPendienteOrigen = chkPendienteOrigen.Checked;
                grafica.graficar();
            }
        }

        private void escalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new EntradaEscalonOrden1());
            agregarComponentes();
        }

        private void impulsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new EntradaImpulsoOrden1());
            agregarComponentes();
        }

        private void senoidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new EntradaSenoidalOrden1());
            agregarComponentes();
        }

        private void rampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new EntradaRampaOrden1());
            agregarComponentes();
        }

        private void escalonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new EntradaEscalonOrden2());
            agregarComponentes();
        }

        private void impulsoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new EntradaImpulsoOrden2());
            agregarComponentes();
        }

        private void senoidalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new EntradaSenoidalOrden2());
            agregarComponentes();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarGrafica();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //guardarGrafica();
        }

        private void btnMedidas_Click_1(object sender, EventArgs e)
        {
            if (grafica != null)
            {
                grafica.showFrmMedidas();
            }
        }

        private void btnGraficar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (grafica != null)
                {
                    grafica.verEntrada = chkEntrada.Checked;
                    chkReferencias.Checked = grafica.chkGrReferencias;
                    chkTpoAsentamiento.Checked = grafica.chkGrTpoAsentamiento;
                    chkTpoSubida.Checked = grafica.chkGrTpoSubida;
                    grafica.graficar();

                    //maneja el evento click del datagrid para luego establecer la correspondiente fórmula
                    grafica.dataGrid.Click += new EventHandler(grafica_dataGrid_Click);
                    grafica.dataGrid.ClearSelection();
                    //-----------------

                    //Seteo el título de la ventana de medidas según el caso.
                    if (respTransiente.Equals("Rampa2"))
                    {
                        grafica.setTituloMedidas("Medidas de Desempeño - Separación Entrada Salida");
                    }
                    
                    grafica.hideFrmMedidas();
                    this.btnGuardar.Enabled = true;

                    //Si la respuesta es de segundo orden
                    if (respTransiente.Equals("Escalon2") || respTransiente.Equals("Impulso2") || respTransiente.Equals("Senoidal2") || respTransiente.Equals("Rampa2"))
                    {
                        double coefAmort = double.Parse(grafica.dataGrid["Coef. Amort.", 0].Value.ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);

                        //Desactivo los botones btnOvershootVsPsi y btnTiempoAsentVSPsi si coef. de amortiguamiento >= 1
                        //caso contrario, los activo
                        if (coefAmort >= 1)
                        {
                            this.btnOvershootVsPsi.Enabled = false;
                            this.btnTiempoAsentVSPsi.Enabled = false;
                        }
                        else
                        {
                            this.btnOvershootVsPsi.Enabled = true;
                            this.btnTiempoAsentVSPsi.Enabled = true;
                        }

                        //Establece la fórmula correcta para cada caso.
                        if (respTransiente.Equals("Escalon2"))
                        {
                            if (coefAmort < 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden1;
                            }
                            else if (coefAmort == 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden2;
                            }
                            else if (coefAmort > 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden3;
                            }
                        }
                        else if (respTransiente.Equals("Impulso2"))
                        {
                            if (coefAmort < 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso2Orden1;
                            }
                            else if (coefAmort == 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso2Orden2;
                            }
                            else if (coefAmort > 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso2Orden3;
                            }
                        }
                        else if (respTransiente.Equals("Senoidal2"))
                        {
                            if (coefAmort < 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaSenoidal2Orden1;
                            }
                            else if (coefAmort == 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaSenoidal2Orden2;
                            }
                            else if (coefAmort > 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaSenoidal2Orden3;
                            }
                        }
                        else if (respTransiente.Equals("Rampa2"))
                        {
                            if (coefAmort < 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaRampa2Orden1;
                            }
                            else if (coefAmort == 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaRampa2Orden2;
                            }
                            else if (coefAmort > 1)
                            {
                                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaRampa2Orden3;
                            }
                        }
                    }

                    //Establece la fórmula correcta para cualquier caso que no sea de segundo orden
                    else if (grafica.Funcion.Formula != null)
                    {
                        pbFormula.Image = grafica.Funcion.Formula;
                    }

                    double psi = 0;
                    double tau = 0;

                    //for (int i = 0; i < grafica.dataGrid.Columns.Count; i++)
                    //{
                    //    if (grafica.dataGrid.Columns[i].HeaderText == "Cte. Tiempo")
                    //        tau = double.Parse(grafica.dataGrid.Rows[0].Cells[i].Value.ToString());
                    //    if (grafica.dataGrid.Columns[i].HeaderText == "Coef. Amort.")
                    //        psi = double.Parse(grafica.dataGrid.Rows[0].Cells[i].Value.ToString());
                    //}

                    for (int i = 0; i < grafica.dataGrid.Columns.Count; i++)
                    {
                        if (grafica.dataGrid.Columns[i].HeaderText == "Cte. Tiempo")
                            tau = double.Parse(grafica.dataGrid.Rows[0].Cells[i].Value.ToString().Replace(",", "."));
                        if (grafica.dataGrid.Columns[i].HeaderText == "Coef. Amort.")
                            psi = double.Parse(grafica.dataGrid.Rows[0].Cells[i].Value.ToString().Replace(",", "."));
                    }

                    if (respTransiente == "Senoidal1" || respTransiente == "Senoidal2")
                    {
                        this.grafica.zedGraphControl.GraphPane.Legend.IsVisible = true;
                        this.grafica.zedGraphControl.Refresh();
                    }
                    else
                    {
                        this.grafica.zedGraphControl.GraphPane.Legend.IsVisible = false;
                        this.grafica.zedGraphControl.Refresh();
                    }

                    //lblNumerador.Text = Math.Round(1 / (tau*tau), 4).ToString();
                    //lblDenominador2Termino.Text = Math.Round(2 * psi * (1/tau), 4).ToString();
                    //lblDenominador3Termino.Text = Math.Round(1 / (tau * tau), 4).ToString();

                    double frecuenciaNaturalAmortiguada = 0;
                    double franco = 2 * psi * (1 / tau);

                    frecuenciaNaturalAmortiguada = 1 / (tau * tau);

                    lblNumerador.Text = Math.Round(frecuenciaNaturalAmortiguada, 3).ToString();
                    lblDenominador2Termino.Text = Math.Round(franco, 3).ToString();
                    lblDenominador3Termino.Text = Math.Round(frecuenciaNaturalAmortiguada, 3).ToString();

                    lblNumerador.Visible = true;
                    lblDenominador3Termino.Visible = true;
                    lblDenominador2Termino.Visible = true;
                    cuadroBlanco1.Visible = true;
                    cuadroBlanco2.Visible = true;
                    cuadroBlanco3.Visible = true;
                }
            }
            catch
            {
                btnGuardar.Enabled = false;
            }
        }

        private void btnLimpiar1_Click(object sender, EventArgs e)
        {
            limpiarDataGrid();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRepetirUltimaFila1_Click(object sender, EventArgs e)
        {
            repetirUltimaFila();
        }


        #endregion

        private void frmRespuestaTransienteMain_Load(object sender, EventArgs e)
        {

        }

        private void lblFormula_Click(object sender, EventArgs e)
        {

        }

        private void pbFormula_Click(object sender, EventArgs e)
        {
            FormulaEscala frmFormulaEscala = new FormulaEscala(pbFormula.Image);
            frmFormulaEscala.Show();
        }

        //---------------------
        /// <summary>
        /// Cada vez que se clickea en el DataGrid de Grafica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void grafica_dataGrid_Click(object sender, EventArgs e)
        {
            //Actualiza la imagen de la fórmula según la celda clickeada
            //if ((grafica.funcion.Amortiguacion != "") && (grafica.dataGrid.CurrentRow.Cells[3].Value!=""))
            //{
            //    double amort = Double.Parse(grafica.dataGrid.CurrentRow.Cells[3].Value.ToString().Replace(",", "."));

            //    if (amort < 1)
            //    {
            //        if (grafica.funcion.GetType().ToString() == "TeoriaDeControl.EntradaEscalonOrden2")
            //            pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden1;
            //        else
            //            pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso2Orden1;
            //    }
            //    else if (amort == 1)
            //    {
            //        if (grafica.funcion.GetType().ToString() == "TeoriaDeControl.EntradaEscalonOrden2")
            //            pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden2;
            //        else
            //            pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso2Orden2;
            //    }
            //    else
            //    {
            //        if (grafica.funcion.GetType().ToString() == "TeoriaDeControl.EntradaEscalonOrden2")
            //            pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden3;
            //        else
            //            pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso2Orden3;
            //    }
            //}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            this.btnGuardar.Enabled = false;

            //dat = new DataTable();
            //    for (int i = 0; i < grafica.ventanaMedidas.dgvMedidas.Columns.Count; i++)
            //        if (grafica.ventanaMedidas.dgvMedidas.Columns[i].HeaderText != "")
            //            dat.Columns.Add(new DataColumn(grafica.ventanaMedidas.dgvMedidas.Columns[i].HeaderText, typeof(string)));

                 dat = new DataTable();

                for (int i = 1; i < grafica.dataGrid.Columns.Count; i++)
                {
                    dat.Columns.Add(grafica.dataGrid.Columns[i].HeaderText);
                }

                for(int i=0;i<grafica.dataGrid.Rows.Count;i++)
                {
                    DataRow dRow = dat.NewRow();
                    bool banderaVacío=true;

                    for(int j=1;j<grafica.dataGrid.Rows[i].Cells.Count;j++)
                    {
                        if (grafica.dataGrid.Rows[i].Cells[j].Value != null)
                        {
                            dRow[grafica.dataGrid.Rows[i].Cells[j].ColumnIndex - 1] = grafica.dataGrid.Rows[i].Cells[j].Value;
                            banderaVacío = false;
                        }
                    }
                    if(banderaVacío==false)
                    dat.Rows.Add(dRow);

                }


            //for (int i = 0; i < grafica.ventanaMedidas.dgvMedidas.Columns.Count; i++)
            //    if (grafica.ventanaMedidas.dgvMedidas.Columns[i].HeaderText != "")
            //        dat.Rows.Add(grafica.ventanaMedidas.dgvMedidas.Rows[0].Cells[i].Value);


            h.addGrafica(grafica.zedGraphControl.GraphPane.CurveList.Clone(), grafica.listaFinX.Max(),grafica.listaFinY.Max(),grafica.listaInicioX.Max(),grafica.listaInicioY.Max(),dat.Copy());
            this.btnComparar.Enabled = true;
        }

        

        private void btnComparar_Click(object sender, EventArgs e)
        {
            FrmCompara comp = new FrmCompara(h);
            comp.ShowDialog();
        }

        private void btnTiempoAsentVSPsi_Click(object sender, EventArgs e)
        {
            double douCteTiempo=0;

            for (int i = 1; i < grafica.dataGrid.Columns.Count; i++)
            {
                if (grafica.dataGrid.Columns[i].HeaderText == "Cte. Tiempo")
                {
                    douCteTiempo = double.Parse(grafica.dataGrid.Rows[0].Cells[i].Value.ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            
            FrmTiempoAsentVsPsi tiempoAsent = new FrmTiempoAsentVsPsi(douCteTiempo);
            tiempoAsent.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmOvershootVsPsi overshootVsPsi = new frmOvershootVsPsi();
            overshootVsPsi.ShowDialog();
        }
               
    }
}
