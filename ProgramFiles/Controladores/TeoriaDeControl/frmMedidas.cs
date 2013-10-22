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

        //};


        String[] medidas =
        {

            "Overshoot",
            "Overshoot (%)", 
            "Tiempo de Subida",
            "Tiempo de asentamiento",
            "Razon de caida",
            "Periodo de Oscilacion",
            "Retardo de fase (tiempo)",
            "Retardo de fase (radianes)",
            "Retardo de fase (grados)",
            "Relación de Amplitud (AR)",
            "Tiempo 1º Pico",
            "Max. valor de entrada",
            "Min. valor de entrada",
            "Max. valor de salida",
            "Min. valor de salida",
            "Separacion Entrada Salida",
            "Tiempo de solapamiento",
            "1 Cte. Tiempo",
            "2 Cte. Tiempo",
            "3 Cte. Tiempo",
            "4 Cte. Tiempo"

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
            addColumna("", "", dataGridView1);


            for (int i = 0; i < medidas.Length; i++)
            {
                addColumna(medidas[i], medidas[i], dataGridView1);
            }
            this.Closing += new CancelEventHandler(Form2_Closing);

            dataGridView1.Columns[0].Width = 25;

            //Tabla de Frecuencias
            addColumna("", "", dataGridView2);
            dataGridView2.Columns[0].Width = 25;

            for (int i = 0; i < valoresFreq.Length; i++)
            {
                addColumna(valoresFreq[i], valoresFreq[i], dataGridView2);
                dataGridView2.Columns[i + 1].Width = 50;
            }

            dataGridView2.Hide();

            this.Height = 210;


            //Seteo el color de seleccion para la columna de los colores como transparente
            dataGridView1.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView2.Columns[0].DefaultCellStyle.SelectionBackColor = Color.Transparent;
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
            dataGridView1.DataSource = datos;
        }

        public void addLineaDatos(String funcion, List<Nullable<double>> listaMedidas)
        {
            dataGridView1.Rows.Add(1);
            int row = dataGridView1.Rows.Count - 1;

            dataGridView1[0, row].Value = "";
            dataGridView1[0, row].ReadOnly = true;

            //Empiezo desde uno porque la columna 0 contiene el nombre de la funcion
            for (int i = 1; i <= listaMedidas.Count; i++)
            {
                dataGridView1[i, row].ReadOnly = true;

                if (listaMedidas[i - 1] != null)
                {
                    //Es para rellenar los parametros que pertenecen a una grafica pero en un caso determinado no se deben mostrar
                    if (listaMedidas[i - 1] == 999999999)
                    {
                        dataGridView1[i, row].Value = "-";
                    }
                    else
                    {
                        dataGridView1[i, row].Value = listaMedidas[i - 1];


                        if (i-1 == 9)
                        {
                            string numero = dataGridView1[i, row].Value.ToString();
                            int posicionPunto = numero.IndexOf(".");
                            numero = numero.Substring(0, posicionPunto + 4);
                            dataGridView1[i, row].Value = numero;
                        }
                        else
                        {
                            //Ver otra manera de hacer esto
                            dataGridView1[i, row].Value = Math.Round(double.Parse(dataGridView1[i, row].Value.ToString()), 2);
                        }


                    }
                }

            }
            


        }

        public void quitarFilas()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        public void ocultarColumnas()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1[i, 0].Value == null)
                {
                    dataGridView1.Columns[i].Visible = false;
                }

            }

        }

        public void addLineaFrecuencias(String funcion, List<double> listaFrec, Color color)
        {
            dataGridView2.Rows.Add(1);
            int row = dataGridView2.Rows.Count - 1;

            dataGridView2[0, row].Value = "";
            dataGridView2[0, row].ReadOnly = true;

            dataGridView2[0, row].Style.BackColor = color;

            //Empiezo desde uno porque la columna 0 contiene el nombre de la funcion
            for (int i = 1; i <= listaFrec.Count; i++)
            {
                dataGridView2[i, row].ReadOnly = true;
                dataGridView2[i, row].Value = Math.Round(listaFrec[i - 1], 2);
            }

            dataGridView2[7, row].Value = -180;

            this.Height = 367;

            dataGridView2.Show();
        }

        public void addLineaFrecuencias2(String funcion, List<double> listaFrec, Color color)
        {
            dataGridView2.Rows.Add(1);
            int row = dataGridView2.Rows.Count - 1;

            dataGridView2[0, row].Value = "";
            dataGridView2[0, row].ReadOnly = true;

            dataGridView2[0, row].Style.BackColor = color;

            //Empiezo desde uno porque la columna 0 contiene el nombre de la funcion
            for (int i = 1; i <= listaFrec.Count; i++)
            {
                dataGridView2[i, row].ReadOnly = true;
                dataGridView2[i, row].Value = Math.Round(listaFrec[i - 1], 2);
            }

            dataGridView2[7, row].Value = -90;

            dataGridView2.Show();

            this.Height = 367;
        }

    }


}
