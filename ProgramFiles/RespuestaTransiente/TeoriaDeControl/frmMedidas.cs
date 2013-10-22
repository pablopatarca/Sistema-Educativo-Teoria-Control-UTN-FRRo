using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeoriaDeControl
{
    public partial class frmMedidas : Form
    {
        //String[] medidas =
        //{
        //    "Overshoot",
        //    "Razon de caida",
        //    "Tiempo de Subida",
        //    "Tiempo de asentamiento",
        //    "Periodo de Oscilacion",
        //    "Desplazamiento",
        //    "Periodo",
        //    "Max. valor de salida",
        //    "Retardo (radianes)",
        //    "Retardo (grados)",
        //    "Relacion de Amplitud",
        //    "Tiempo 1º Pico",
        //    "Max. valor de entrada",
        //    "Min. valor de entrada",
        //    "Max. valor de salida",
        //    "Min. valor de salida",
        //    "Separacion Entrada Salida"
        //    "Amortiguación" indica si la salida es sub, crítica o sobreamortiguada

        //};


        String[] medidas =
        {

            "Overshoot",
            "Overshoot (%)", 
            "Tiempo de Subida",
            "Tiempo de asentamiento",
            "Razón de caída",
            "Periodo de Oscilacion",
            "Retardo de fase (tiempo)",
            "Retardo de fase (radianes)",
            "Retardo de fase (grados)",
            "Relación de Amplitud (AR)",
            "Tiempo 1º Pico",
            "Max. valor de salida",
            "Max. valor de entrada",
            "Min. valor de salida",
            "Min. valor de entrada",
            "Separacion Entrada Salida",
            "Tiempo de solapamiento",
            "1 Cte. Tiempo",
            "2 Cte. Tiempo",
            "3 Cte. Tiempo",
            "4 Cte. Tiempo",
            "5 Cte. Tiempo",
            "Razón de caída (%)",
            "3º Cte. Tiempo",
            "Amortiguación",
            "Nro. Oscilaciones",
            "Delta",
            "1 * Delta Cte. Tiempo",
            "2 * Delta Cte. Tiempo",
            "3 * Delta Cte. Tiempo",
            "4 * Delta Cte. Tiempo",
            "5 * Delta Cte. Tiempo"
        };

        String[] valoresFreq =
        {
            "0","1","2","10","100","1000","Inf"
        };

        //List<String> linea;
        List<List<String>> lista = new List<List<String>>();

        public frmMedidas()
        {
            InitializeComponent();
            Inicio();
        }

        private void Inicio()
        {
            //Tabla de medidas
            addColumna("", "", dgvMedidas);


            for (int i = 0; i < medidas.Length; i++)
            {
                addColumna(medidas[i], medidas[i], dgvMedidas);
            }
            this.Closing += new CancelEventHandler(Form2_Closing);

            dgvMedidas.Columns[0].Width = 25;

            //Tabla de Frecuencias
            addColumna("", "", dgvRetardoFase);
            dgvRetardoFase.Columns[0].Width = 25;

            for (int i = 0; i < valoresFreq.Length; i++)
            {
                addColumna(valoresFreq[i], valoresFreq[i], dgvRetardoFase);
                dgvRetardoFase.Columns[i + 1].Width = 50;
            }

            dgvRetardoFase.Hide();

            this.Height = 210;


            //Seteo el color de seleccion para la columna de los colores como transparente
            dgvMedidas.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvRetardoFase.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Transparent;
        }

        void Form2_Closing(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void addColumna(String nombre, String cabecera, DataGridView dataGrid)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.HeaderText = cabecera;
            columna.Name = nombre;
            dataGrid.Columns.Add(columna);
        }

        public void setDatos(String[] datos)
        {
            dgvMedidas.DataSource = datos;
        }

        public void addLineaDatos(String funcion, List<Nullable<double>> listaMedidas, String amortiguacion)
        {
            dgvMedidas.Rows.Add(1);
            int row = dgvMedidas.Rows.Count - 1;

            dgvMedidas[0, row].Value = "";
            dgvMedidas[0, row].ReadOnly = true;

            //Indica si la función es sub, crit o sobreamortiguada
            if (amortiguacion!="")
            {
                dgvMedidas.Rows[row].HeaderCell.Value = amortiguacion;
                dgvMedidas.RowHeadersWidth = 70;
            }

            //Empiezo desde uno porque la columna 0 contiene el nombre de la funcion
            for (int i = 1; i <= listaMedidas.Count; i++)
            {
                dgvMedidas[i, row].ReadOnly = true;

                if (listaMedidas[i - 1] != null)
                {
                    //Es para rellenar los parametros que pertenecen a una grafica pero en un caso determinado no se deben mostrar
                    if (listaMedidas[i - 1] == 999999999)
                    {
                        dgvMedidas[i, row].Value = "-";
                    }
                    else
                    {
                        dgvMedidas[i, row].Value = listaMedidas[i - 1];


                        if (i-1 == 9)
                        {
                            string numero = dgvMedidas[i, row].Value.ToString();
                            int posicionPunto = numero.IndexOf(".");
                            int cantDecimales = numero.Length - posicionPunto-1;
                            if (cantDecimales > 4)
                            {
                                numero = numero.Substring(0, posicionPunto + 5);

                            }
                            dgvMedidas[i, row].Value = numero;
                        }
                        else
                        {
                            //Ver otra manera de hacer esto
                            //guarda el valor con la presición indicada
                            if (listaMedidas.Count > 4)
                            {
                                if ((listaMedidas[4] != null) && (i == 5))
                                    dgvMedidas[i, row].Value = Math.Round(double.Parse(dgvMedidas[i, row].Value.ToString()), 3);
                                else
                                    dgvMedidas[i, row].Value = Math.Round(double.Parse(dgvMedidas[i, row].Value.ToString()), 2);
                            }
                            else
                                dgvMedidas[i, row].Value = Math.Round(double.Parse(dgvMedidas[i, row].Value.ToString()), 2);
                        }
                    }
                }
            }
        }

        public void quitarFilas()
        {
            dgvMedidas.Rows.Clear();
            dgvRetardoFase.Rows.Clear();
        }

        private void resizeDvgMedidas()
        {
            int anchoMed = 0, altoMed = 0;
            //acomoda el ancho del control respecto a las columnas visibles
            for (int i = 0; i < dgvMedidas.Columns.Count; i++)
            {
                if (dgvMedidas.Columns[i].Visible)
                    anchoMed += dgvMedidas.Columns[i].Width;
            }
            dgvMedidas.Width = anchoMed + 10 + dgvMedidas.RowHeadersWidth;

            //acomoda el alto del control respecto a las filas
            for (int i = 0; i < dgvMedidas.Rows.Count; i++)
            {
                if (dgvMedidas.Rows[i].Visible)
                    altoMed += dgvMedidas.Rows[i].Height;
            }
            dgvMedidas.Height = altoMed + dgvMedidas.ColumnHeadersHeight * 2 - 10;
        }

        public void ocultarColumnas()
        {
            for (int i = 0; i < dgvMedidas.Columns.Count; i++)
            {
                if (dgvMedidas[i, 0].Value == null)
                {
                    dgvMedidas.Columns[i].Visible = false;
                }
            }

            resizeDvgMedidas();
        }

        public void retardoEsVisible(bool esSenoidal)
        {
            if (esSenoidal)
            {
                lblRetardoDeFase.Visible = true;
                dgvRetardoFase.Visible = true;
            }
            else
            {
                lblRetardoDeFase.Visible = false;
                dgvRetardoFase.Visible = false;
            }
        }

        public void addLineaFrecuencias(String funcion, List<double> listaFrec, Color color)
        {
            dgvRetardoFase.Rows.Add(1);
            int row = dgvRetardoFase.Rows.Count - 1;

            dgvRetardoFase[0, row].Value = "";
            dgvRetardoFase[0, row].ReadOnly = true;

            dgvRetardoFase[0, row].Style.BackColor = color;

            //Empiezo desde uno porque la columna 0 contiene el nombre de la funcion
            for (int i = 1; i <= listaFrec.Count; i++)
            {
                dgvRetardoFase[i, row].ReadOnly = true;
                dgvRetardoFase[i, row].Value = Math.Round(listaFrec[i - 1], 2);
            }

            dgvRetardoFase[7, row].Value = -180;

            this.Height = 367;

            dgvRetardoFase.Show();
        }

        public void addLineaFrecuencias2(String funcion, List<double> listaFrec, Color color)
        {
            dgvRetardoFase.Rows.Add(1);
            int row = dgvRetardoFase.Rows.Count - 1;

            dgvRetardoFase[0, row].Value = "";
            dgvRetardoFase[0, row].ReadOnly = true;

            dgvRetardoFase[0, row].Style.BackColor = color;

            //Empiezo desde uno porque la columna 0 contiene el nombre de la funcion
            for (int i = 1; i <= listaFrec.Count; i++)
            {
                dgvRetardoFase[i, row].ReadOnly = true;
                dgvRetardoFase[i, row].Value = Math.Round(listaFrec[i - 1], 2);
            }

            dgvRetardoFase[7, row].Value = -90;

            dgvRetardoFase.Show();

            this.Height = 367;
        }

        private void lblRetardoDeFase_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }


}
