using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Controladores
{
    public partial class frmControladores : Form
    {
        #region ATRIBUTOS
        Grafica grafica=null;
        List<Grafica> listaGraficas = new List<Grafica>();
        //List<String> lista = new List<string>();
        #endregion

        public frmControladores()
        {
            //Seteo la cultura para utilizar el punto como separador decimal
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            listBox1.DataSource = generarLista();
        }

        public frmControladores(IPropiedadesGrafica cont)
        {
            //Seteo la cultura para utilizar el punto como separador decimal
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            listBox1.DataSource = generarLista();

            iniciarComponentesGrafica(cont);
            agregarComponentes();
        }

        private void agregarComponentes()
        {
            panel2.Show();
            panel3.Show();
            panel1.Show();
            imgControlador.Show();
            imgSalida.Show();
            imgError.Show();
            this.Controls.Add(grafica.zedGraphControl);
            this.Controls.Add(grafica.zedGraphControl_2);
            panel1.Controls.Add(grafica.dataGrid);
            acomodarElementos();

        }

        public void iniciarComponentesGrafica(IPropiedadesGrafica funcion)
        {            
            if (grafica != null)
            {
                guardarGrafica();
                //remuevo los componentes anteriores antes de instanciar los nuevos.
                quitarComponentes();
            }

            grafica = new Grafica(funcion);
            grafica.setTitulo();
            txtTitulo.Text = grafica.titulo;

            //guido
            seleccionarImagenControlador(funcion);
            imgSalida.Visible = true;
            imgSalida.Image = null;
            imgError.Visible = true;
            imgError.Image = null;
            imgControlador.Visible = true;

        }

        private void guardarGrafica()
        {
            
            if (grafica != null)
            {
                grafica.hideFrmMedidas();

                grafica.titulo = txtTitulo.Text;

                if (!listaGraficas.Contains(grafica))
                {
                    listaGraficas.Add(grafica);
                }
            }

            listBox1.DataSource = null;
            listBox1.DataSource = generarLista();
        }

        private List<String> generarLista()
        {
            List<String> lista = new List<string>();
            foreach (Grafica g in listaGraficas)
            {
                lista.Add(g.getNombre());
            }
            return lista;
        }

        private void cambiaGrafica()
        {
            String graficaSelect = (string)listBox1.SelectedItem;
            guardarGrafica();
            foreach (Grafica g in listaGraficas)
            {
                if (graficaSelect == g.getNombre())
                {
                    quitarComponentes();
                    grafica = g;
                    agregarComponentes();
                    txtTitulo.Text = grafica.titulo;
                    seleccionarImagenControlador(g.funcion);
                    seleccionarImagenesGraficas(g.funcion, g.tipo_error);
                    listBox1.ClearSelected();                
                }
            }
        }

        private void eliminarGrafica()
        {
            if (grafica != null)
            {
                listaGraficas.Remove(grafica);
                txtTitulo.Text = "";
                grafica.hideFrmMedidas();
                
            }
            quitarComponentes();
            listBox1.DataSource = null;
            listBox1.DataSource = generarLista();
            grafica = null;

            if (listaGraficas.Count() == 0)
            {
                panel2.Hide();
                panel3.Hide();
            }

        }
        
        private void acomodarElementos()
        {
            int altoBarraMenu = 28;

            int altoVentana = this.Height-50;
            int anchoVentana = this.Width;

            int anchoDataGrid = 670;
            int altoDataGrid = 50;

            int anchoBotonera = panel3.Size.Width;

            int altoImagenControlador = 80;
            int anchoImagenControlador = /*500*/ anchoVentana-(anchoDataGrid+anchoBotonera+20);

            int altoPanel = altoImagenControlador;
            int anchoPanel = anchoVentana;

            int altoImagenesGraficas = 60;
            int anchoImagenesGraficas = anchoVentana;

            int altoGrafica = (int) ((altoVentana - altoBarraMenu -altoPanel - 2 * altoImagenesGraficas)/2);
            int anchoGrafica = anchoVentana - 18;

            int altoGrafica_2 = altoGrafica;
            int anchoGrafica_2 = anchoVentana - 18;


            

            if (grafica != null)
            {
                grafica.zedGraphControl.Size = new System.Drawing.Size(anchoImagenControlador+anchoDataGrid, altoGrafica);
                grafica.zedGraphControl.Location = new Point(0, altoBarraMenu + altoPanel + altoImagenesGraficas);

                grafica.zedGraphControl_2.Size = new System.Drawing.Size(anchoImagenControlador+anchoDataGrid, altoGrafica_2);
                grafica.zedGraphControl_2.Location = new Point(0, altoBarraMenu + altoPanel + altoGrafica + 2 * altoImagenesGraficas);
                               
                imgControlador.Size = new System.Drawing.Size(anchoImagenControlador, altoImagenControlador);
                imgControlador.Location = new Point(0, 0);

                imgSalida.Size = new System.Drawing.Size(anchoImagenControlador+anchoDataGrid, altoImagenesGraficas);
                imgSalida.Location = new Point(0, altoBarraMenu + altoPanel);

                imgError.Size = new System.Drawing.Size(anchoImagenControlador + anchoDataGrid, altoImagenesGraficas);
                imgError.Location = new Point(0, altoBarraMenu + altoPanel + altoImagenesGraficas + altoGrafica);                

                grafica.dataGrid.Size = new System.Drawing.Size(anchoDataGrid, altoDataGrid);
                grafica.dataGrid.Location = new Point(anchoImagenControlador, 0);

            }

            panel1.Size = new System.Drawing.Size(anchoPanel, altoPanel);
            panel1.Location = new Point(0, 28);
    
            panel3.Location = new Point(anchoImagenControlador + anchoDataGrid + 5, 26);
            panel2.Location = new Point(anchoImagenControlador + anchoDataGrid, 130);


        }

        private void quitarComponentes()
        {
            if (grafica != null)
            {
                this.Controls.Remove(grafica.zedGraphControl);
                this.Controls.Remove(grafica.zedGraphControl_2);
                panel1.Controls.Remove(grafica.dataGrid);
                imgControlador.Hide();
                imgSalida.Hide();
                imgError.Hide();
            }
        }

        private void limpiarDataGrid()
        {
            if (grafica != null)
            {
                grafica.hideFrmMedidas();
                panel1.Controls.Remove(grafica.dataGrid);
                grafica.iniciarDataGrid();
                agregarComponentes();
                grafica.graficar();
                imgSalida.Image = null;
                imgError.Image = null;

                //lo pongo en cero para que cuando limpio la grafica y siga guardada
                //me muestre las imagenes de salida y error en blanco
                grafica.tipo_error = 0;
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

        #region EVENTOS

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            acomodarElementos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //eliminarGrafica();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cambiaGrafica();
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            guardarGrafica();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cambiaGrafica();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarGrafica();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarGrafica();
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
                grafica.graficar();
                grafica.hideFrmMedidas();
                //(guido)
                seleccionarImagenesGraficas(grafica.funcion, grafica.tipo_error);
            }

        }

        private void btnEjemplos1_Click(object sender, EventArgs e)
        {
            rellenarValores();
        }

        private void btnLimpiar1_Click_1(object sender, EventArgs e)
        {
            limpiarDataGrid();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void proporcionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new Proporcional());
            agregarComponentes();
        }

        private void proporcionalIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new ProporcionalIntegralDerivativo());
            agregarComponentes();
        }

        private void proporcionalDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new ProporcionalDerivativo());
            agregarComponentes();
        }

        private void proporcionalIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciarComponentesGrafica(new ProporcionalIntegral());
            agregarComponentes();
        }

        #endregion

        private void graficaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seleccionarImagenControlador(IPropiedadesGrafica controlador)
        {
            //se invoca en iniciarComponentesGrafica
            if (controlador.GetType() == typeof(Proporcional)) imgControlador.Image = Controladores.Properties.Resources.controlador_proporcional;
            else if (controlador.GetType() == typeof(ProporcionalDerivativo)) imgControlador.Image = Controladores.Properties.Resources.controlador_proporcional_derivativo;
            else if (controlador.GetType() == typeof(ProporcionalIntegral)) imgControlador.Image = Controladores.Properties.Resources.controlador_proporcional_integral;
            else if (controlador.GetType() == typeof(ProporcionalIntegralDerivativo)) imgControlador.Image = Controladores.Properties.Resources.controlador_proporcional_integral_derivativo;
        }

        private void seleccionarImagenesGraficas(IPropiedadesGrafica controlador, int error)
        {
            if(controlador.GetType() == typeof(Proporcional))
            {                
                switch (error)
                {
                    case 1: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_escalon;
                            imgError.Image = Controladores.Properties.Resources.error_escalon;
                            break;
                    case 2: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_rampa;
                            imgError.Image = Controladores.Properties.Resources.error_rampa;
                            break;
                    case 3: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_cuadratico;
                            imgError.Image = Controladores.Properties.Resources.error_cuadratico;
                            break;
                    default:imgSalida.Image = null;
                            imgError.Image = null;
                            break;
                }
            }

            if (controlador.GetType() == typeof(ProporcionalDerivativo))
            {
                switch (error)
                {
                    case 1: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_derivativo_escalon;
                            imgError.Image = Controladores.Properties.Resources.error_escalon;
                            break;
                    case 2: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_derivativo_rampa;
                            imgError.Image = Controladores.Properties.Resources.error_rampa;
                            break;
                    case 3: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_derivativo_cuadratico;
                            imgError.Image = Controladores.Properties.Resources.error_cuadratico;
                            break;
                    default: imgSalida.Image = null;
                             imgError.Image = null;
                             break;
                }
            }

            if (controlador.GetType() == typeof(ProporcionalIntegral))
            {
                switch (error)
                {
                    case 1: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_integral_escalon;
                            imgError.Image = Controladores.Properties.Resources.error_escalon;
                            break;
                    case 2: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_integral_rampa;
                            imgError.Image = Controladores.Properties.Resources.error_rampa;
                            break;
                    case 3: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_integral_cuadratico;
                            imgError.Image = Controladores.Properties.Resources.error_cuadratico;
                            break;
                    default: imgSalida.Image = null;
                             imgError.Image = null;
                             break;
                }
            }

            if (controlador.GetType() == typeof(ProporcionalIntegralDerivativo))
            {
                switch (error)
                {
                    case 1: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_integral_derivativo_escalon;
                            imgError.Image = Controladores.Properties.Resources.error_escalon;
                            break;
                    case 2: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_integral_derivativo_rampa;
                            imgError.Image = Controladores.Properties.Resources.error_rampa;
                            break;
                    case 3: imgSalida.Image = Controladores.Properties.Resources.controlador_proporcional_integral_derivativo_cuadratico;
                            imgError.Image = Controladores.Properties.Resources.error_cuadratico;
                            break;
                    default: imgSalida.Image = null;
                             imgError.Image = null;
                             break;
                }
            }

        }
























    }
}
