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
    public partial class frmRespuestaTransienteLocus : Form
    {
        Historial h;
        DataTable dat;

        #region ATRIBUTOS
        Grafica grafica=null;
        List<Grafica> listaGraficas = new List<Grafica>();
        persGraficaMySql persRespuestas;
        String respTransiente;
        double _coefAmort;
        double _constTiempo;
        //List<String> lista = new List<string>();

        public double coefAmort
        {
            get
            {
                return _coefAmort;
            }
            set
            {
                _coefAmort = value;
            }
        }

        public double constTiempo
        {
            get
            {
                return _constTiempo;
            }
            set
            {
                _constTiempo = value;
            }
        }

        #endregion

        public frmRespuestaTransienteLocus() 
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

        public frmRespuestaTransienteLocus(String respTr)
        {
            //Seteo la cultura para utilizar el punto como separador decimal
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            pnlAcciones.Hide();
            respTransiente = respTr;

            //h = new Historial();
            //this.h = his;
            
            CurveList g = new CurveList();

            //g = h.getGrafica(0);

            //if (g.Count != 0)
            //    this.btnComparar.Enabled = true;
            //else
            //    this.btnComparar.Enabled = false;

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
            //Tamibén setea la imagen con la fórmula correspondiente en cada caso
            if (respTransiente.Equals("Escalon1")) {
                this.Text = this.Text + ", Sistemas de Primer Orden, Entrada Escalón";
                iniciarComponentesGrafica(new EntradaEscalonOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon1Orden;
            }
            else if (respTransiente.Equals("Impulso1")) {
                this.Text = this.Text + ", Sistemas de Primer Orden, Entrada Impulso";
                iniciarComponentesGrafica(new EntradaImpulsoOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso1Orden;
            }
            else if (respTransiente.Equals("Senoidal1"))
            {
                this.Text = this.Text + ", Sistemas de Primer Orden, Entrada Senoidal";
                iniciarComponentesGrafica(new EntradaSenoidalOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaSenoidal1Orden;
            }
            else if (respTransiente.Equals("Rampa1"))
            {
                this.Text = this.Text + ", Sistemas de Primer Orden, Entrada Rampa";
                iniciarComponentesGrafica(new EntradaRampaOrden1());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaRampa1Orden;
            }
            else if (respTransiente.Equals("Escalon2"))
            {
                this.Text = this.Text + ", Sistemas de Segundo Orden, Entrada Escalón";
                iniciarComponentesGrafica(new EntradaEscalonOrden2());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden1;
            }
            else if (respTransiente.Equals("Impulso2"))
            {
                this.Text = this.Text + ", Sistemas de Segundo Orden, Entrada Impulso";
                iniciarComponentesGrafica(new EntradaImpulsoOrden2());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaImpulso2Orden1;
            }
            else if (respTransiente.Equals("Senoidal2"))
            {
                this.Text = this.Text + ", Sistemas de Segundo Orden, Entrada Senoidal";
                iniciarComponentesGrafica(new EntradaSenoidalOrden2());
                agregarComponentes();
                pbFormula.Image = TeoriaDeControl.Properties.Resources.FormulaSenoidal2Orden1;
            }
            this.Text += "                         ";
        }

        public void agregarDatos()
        {
            grafica.dataGrid[1, 0].Value = 1;
            grafica.dataGrid[2, 0].Value = Math.Round(constTiempo, 3);
            grafica.dataGrid[3, 0].Value = Math.Round(coefAmort, 3);
            grafica.dataGrid[4, 0].Value = 5;

            while (grafica.dataGrid.Rows.Count != 1)
            {
                grafica.dataGrid.Rows.RemoveAt(1);
            }

            grafica.dataGrid.Enabled = false;
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

            int anchoDataGrid = 570;//(int)(anchoPanel * 0.5);
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
            if (grafica != null)
            {
                grafica.verEntrada = chkEntrada.Checked;
                chkReferencias.Checked = grafica.chkGrReferencias;
                chkTpoAsentamiento.Checked = grafica.chkGrTpoAsentamiento;
                grafica.graficar();

                //maneja el evento click del datagrid para luego establecer la correspondiente fórmula
                grafica.dataGrid.Click += new EventHandler(grafica_dataGrid_Click);
                grafica.dataGrid.ClearSelection();
                //-----------------

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

                grafica.hideFrmMedidas();
                this.btnGuardar.Enabled = true;
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

        private void frmRespuestaTransienteLocus_Load(object sender, EventArgs e)
        {
            btnGraficar1.PerformClick();
            btnGraficar1.Visible = false;
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

            for (int i = 0; i < grafica.dataGrid.Rows.Count; i++)
            {
                DataRow dRow = dat.NewRow();
                bool banderaVacío = true;

                for (int j = 1; j < grafica.dataGrid.Rows[i].Cells.Count; j++)
                {
                    if (grafica.dataGrid.Rows[i].Cells[j].Value != null)
                    {
                        dRow[grafica.dataGrid.Rows[i].Cells[j].ColumnIndex - 1] = grafica.dataGrid.Rows[i].Cells[j].Value;
                        banderaVacío = false;
                    }
                }
                if (banderaVacío == false)
                    dat.Rows.Add(dRow);

            }


            //for (int i = 0; i < grafica.ventanaMedidas.dgvMedidas.Columns.Count; i++)
            //    if (grafica.ventanaMedidas.dgvMedidas.Columns[i].HeaderText != "")
            //        dat.Rows.Add(grafica.ventanaMedidas.dgvMedidas.Rows[0].Cells[i].Value);

            h.addGrafica(grafica.zedGraphControl.GraphPane.CurveList.Clone(), grafica.listaFinX.Max(), grafica.listaFinY.Max(), grafica.listaInicioX.Max(), grafica.listaInicioY.Max(), dat.Copy());
            this.btnComparar.Enabled = true;

        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            FrmCompara comp = new FrmCompara(h);
            comp.ShowDialog();
        }
    }
}
