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

namespace TeoriaDeControl
{
    public partial class FrmCompara : Form
    {
        TableLayoutPanel p;
        Historial h;
        ZedGraphControl zedMax;
        List<ZedGraphControl> controles;
        GraphPane gp1, gp2, gp3, gp4, gp5;
        int contadorFilas = 0;

        public FrmCompara(Historial his)
        {
            InitializeComponent();
            //Para que la tabla ocupe dos columnas

            gp1 = zedGraphControl1.GraphPane;
            gp2 = zedGraphControl2.GraphPane;
            gp3 = zedGraphControl3.GraphPane;
            gp4 = zedGraphControl4.GraphPane;


            //Lista de los controles zedGraph
            controles = new List<ZedGraphControl>();
            controles.Add(zedGraphControl1);
            controles.Add(zedGraphControl2);
            controles.Add(zedGraphControl3);
            controles.Add(zedGraphControl4);

            //Historial - Apunta al historial del form ppal
            h = his;

            //dgvDatos.Columns.Add("Graficas", "Graficas");

            //for (int i = 0; i < h.tablas[0].Columns.Count; i++)
            //    dgvDatos.Columns.Add(h.tablas[0].Columns[i].ColumnName, h.tablas[0].Columns[i].ColumnName);
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
            p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));

            zedMax = new ZedGraphControl();
            gp5 = zedMax.GraphPane;
            zedMax.Anchor = AnchorStyles.Top;
            zedMax.Dock = DockStyle.Fill;
            zedMax.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(Zoom);
            zedMax.PointValueEvent += new ZedGraphControl.PointValueHandler(infoPunto);
            zedMax.DoubleClick += new System.EventHandler(minimizar);

            //Instancia la tabla de datos

            for (int i = 0; i < h.tablas.Count; i++)
            {
                if (i == 0 && h.tablas[i].Rows.Count != 0)
                    dgvDatos1.Rows.Add(h.tablas[i].Rows.Count);
                if (i == 1 && h.tablas[i].Rows.Count!=0)
                    dgvDatos2.Rows.Add(h.tablas[i].Rows.Count);
                if (i == 2 && h.tablas[i].Rows.Count != 0)
                    dgvDatos3.Rows.Add(h.tablas[i].Rows.Count);
                if (i == 3 && h.tablas[i].Rows.Count != 0)
                    dgvDatos4.Rows.Add(h.tablas[i].Rows.Count);
            }


            //Da formato a los zedGraphControls y a la tabla.
            int cont = 0;
            foreach (ZedGraphControl z in controles)
            {
                rellenarFilaTabla(cont);

                formatoZed(z, cont);
                z.PointValueEvent += new ZedGraphControl.PointValueHandler(infoPunto);
                z.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(Zoom);
                z.DoubleClick += new System.EventHandler(maximizar);
                asignarGrafica(z, cont++); // Se asignan las gráficas del historial
                refresh(z);
                if (z.GraphPane.CurveList.Count != 0 && cont - 1 == 0)
                    z.ZoomOutAll(gp1);

                if (z.GraphPane.CurveList.Count != 0 && cont - 1 == 1)
                    z.ZoomOutAll(gp2);

                if (z.GraphPane.CurveList.Count != 0 && cont - 1 == 2)
                    z.ZoomOutAll(gp3);

                if (z.GraphPane.CurveList.Count != 0 && cont - 1 == 3)
                    z.ZoomOutAll(gp4);
            }

            foreach (DataGridViewRow fila in dgvDatos1.Rows)
                fila.Selected = false;

            foreach (DataGridViewRow fila in dgvDatos2.Rows)
                fila.Selected = false;

            foreach (DataGridViewRow fila in dgvDatos3.Rows)
                fila.Selected = false;

            foreach (DataGridViewRow fila in dgvDatos4.Rows)
                fila.Selected = false;

            ocultarColumnasVacías();
        }

        private void ocultarColumnasVacías()
        {
            for (int i = 0; i < dgvDatos1.Columns.Count; i++)
            {
                if (i != 1)
                {
                    bool banderaVacio = false;
                    for (int j = 0; j < dgvDatos1.Rows.Count; j++)
                    {
                        if (dgvDatos1.Rows[j].Cells[i].Value != null)
                        {
                            banderaVacio = true;
                            break;
                        }
                    }
                    if (banderaVacio == false)
                        dgvDatos1.Columns[i].Visible = false;

                    banderaVacio = false;
                    for (int j = 0; j < dgvDatos2.Rows.Count; j++)
                    {
                        if (dgvDatos2.Rows[j].Cells[i].Value != null)
                        {
                            banderaVacio = true;
                            break;
                        }
                    }
                    if (banderaVacio == false)
                        dgvDatos2.Columns[i].Visible = false;

                    banderaVacio = false;
                    for (int j = 0; j < dgvDatos3.Rows.Count; j++)
                    {
                        if (dgvDatos3.Rows[j].Cells[i].Value != null)
                        {
                            banderaVacio = true;
                            break;
                        }
                    }
                    if (banderaVacio == false)
                        dgvDatos3.Columns[i].Visible = false;

                    banderaVacio = false;
                    for (int j = 0; j < dgvDatos4.Rows.Count; j++)
                    {
                        if (dgvDatos4.Rows[j].Cells[i].Value != null)
                        {
                            banderaVacio = true;
                            break;
                        }
                    }
                    if (banderaVacio == false)
                        dgvDatos4.Columns[i].Visible = false;
                }

            }
        }

        private void rellenarFilaTabla(int fil)
        {
            DataTable t = h.tablas[fil];
            try
            {
                if (fil == 0 && h.tablas[fil].Rows.Count != 0)
                {
                    dgvDatos1.Rows[0].Cells[0].Value = "" + (fil + 1);

                    int contadorColor = 0;

                    for (int i = 0; i < h.tablas[fil].Rows.Count; i++)
                    {
                        if (i == 0)
                            dgvDatos1.Rows[contadorColor].Cells[1].Style.BackColor = Color.Red;
                        if (i == 1)
                            dgvDatos1.Rows[contadorColor].Cells[1].Style.BackColor = Color.Green;
                        if (i == 2)
                            dgvDatos1.Rows[contadorColor].Cells[1].Style.BackColor = Color.Orange;
                        if (i == 3)
                            dgvDatos1.Rows[contadorColor].Cells[1].Style.BackColor = Color.Violet;
                        if (i == 4)
                            dgvDatos1.Rows[contadorColor].Cells[1].Style.BackColor = Color.Brown;

                        contadorColor++;
                    }

                    contadorColor = 0;

                    foreach (DataRow dr in h.tablas[fil].Rows)
                    {
                        foreach (DataColumn dt in dr.Table.Columns)
                            for (int k = 0; k < dgvDatos1.Columns.Count; k++)
                            {
                                if (dt.ColumnName == this.dgvDatos1.Columns[k].HeaderText)
                                {
                                    dgvDatos1.Rows[contadorColor].Cells[k].Value = dr[dt.ColumnName];
                                    break;
                                }
                            }
                        contadorColor++;
                    }
                }

                if (fil == 1 && h.tablas[fil].Rows.Count!=0)
                {
                    dgvDatos2.Rows[0].Cells[0].Value = "" + (fil + 1);

                    int contadorColor = 0;

                    for (int i = 0; i < h.tablas[fil].Rows.Count; i++)
                    {
                        if (i == 0)
                            dgvDatos2.Rows[contadorColor].Cells[1].Style.BackColor = Color.Red;
                        if (i == 1)
                            dgvDatos2.Rows[contadorColor].Cells[1].Style.BackColor = Color.Green;
                        if (i == 2)
                            dgvDatos2.Rows[contadorColor].Cells[1].Style.BackColor = Color.Orange;
                        if (i == 3)
                            dgvDatos2.Rows[contadorColor].Cells[1].Style.BackColor = Color.Violet;
                        if (i == 4)
                            dgvDatos2.Rows[contadorColor].Cells[1].Style.BackColor = Color.Brown;

                        contadorColor++;
                    }

                    contadorColor = 0;

                    foreach (DataRow dr in h.tablas[fil].Rows)
                    {
                        foreach (DataColumn dt in dr.Table.Columns)
                            for (int k = 0; k < dgvDatos2.Columns.Count; k++)
                            {
                                if (dt.ColumnName == this.dgvDatos2.Columns[k].HeaderText)
                                {
                                    dgvDatos2.Rows[contadorColor].Cells[k].Value = dr[dt.ColumnName];
                                    break;
                                }
                            }
                        contadorColor++;
                    }
                }

                if (fil == 2 && h.tablas[fil].Rows.Count != 0)
                {
                    dgvDatos3.Rows[0].Cells[0].Value = "" + (fil + 1);

                    int contadorColor = 0;

                    for (int i = 0; i < h.tablas[fil].Rows.Count; i++)
                    {
                        if (i == 0)
                            dgvDatos3.Rows[contadorColor].Cells[1].Style.BackColor = Color.Red;
                        if (i == 1)
                            dgvDatos3.Rows[contadorColor].Cells[1].Style.BackColor = Color.Green;
                        if (i == 2)
                            dgvDatos3.Rows[contadorColor].Cells[1].Style.BackColor = Color.Orange;
                        if (i == 3)
                            dgvDatos3.Rows[contadorColor].Cells[1].Style.BackColor = Color.Violet;
                        if (i == 4)
                            dgvDatos3.Rows[contadorColor].Cells[1].Style.BackColor = Color.Brown;

                        contadorColor++;
                    }

                    contadorColor = 0;

                    foreach (DataRow dr in h.tablas[fil].Rows)
                    {
                        foreach (DataColumn dt in dr.Table.Columns)
                            for (int k = 0; k < dgvDatos3.Columns.Count; k++)
                            {
                                if (dt.ColumnName == this.dgvDatos3.Columns[k].HeaderText)
                                {
                                    dgvDatos3.Rows[contadorColor].Cells[k].Value = dr[dt.ColumnName];
                                    break;
                                }
                            }
                        contadorColor++;
                    }
                }

                if (fil == 3 && h.tablas[fil].Rows.Count != 0)
                {
                    dgvDatos4.Rows[0].Cells[0].Value = "" + (fil + 1);

                    int contadorColor = 0;

                    for (int i = 0; i < h.tablas[fil].Rows.Count; i++)
                    {
                        if (i == 0)
                            dgvDatos4.Rows[contadorColor].Cells[1].Style.BackColor = Color.Red;
                        if (i == 1)
                            dgvDatos4.Rows[contadorColor].Cells[1].Style.BackColor = Color.Green;
                        if (i == 2)
                            dgvDatos4.Rows[contadorColor].Cells[1].Style.BackColor = Color.Orange;
                        if (i == 3)
                            dgvDatos4.Rows[contadorColor].Cells[1].Style.BackColor = Color.Violet;
                        if (i == 4)
                            dgvDatos4.Rows[contadorColor].Cells[1].Style.BackColor = Color.Brown;

                        contadorColor++;
                    }

                    contadorColor = 0;

                    foreach (DataRow dr in h.tablas[fil].Rows)
                    {
                        foreach (DataColumn dt in dr.Table.Columns)
                            for (int k = 0; k < dgvDatos4.Columns.Count; k++)
                            {
                                if (dt.ColumnName == this.dgvDatos4.Columns[k].HeaderText)
                                {
                                    dgvDatos4.Rows[contadorColor].Cells[k].Value = dr[dt.ColumnName];
                                    break;
                                }
                            }
                        contadorColor++;
                    }
                }
            }
            catch
            { }
        }

        private void formatoZed(ZedGraphControl zedC, int nro)
        {
            zedC.IsShowPointValues = true;
            zedC.GraphPane.XAxis.Scale.MinGrace = 0;
            zedC.GraphPane.XAxis.Scale.MaxGrace = 0;

            zedC.GraphPane.XAxis.Scale.Min = h.inicioX[nro];
            zedC.GraphPane.XAxis.Scale.Max = h.finX[nro];
            zedC.GraphPane.YAxis.Scale.Min = h.inicioY[nro];
            zedC.GraphPane.YAxis.Scale.Max = h.finY[nro];

            zedC.GraphPane.XAxis.IsVisible = true;
            zedC.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedC.GraphPane.XAxis.MajorGrid.IsZeroLine = false;

            zedC.GraphPane.YAxis.IsVisible = true;
            zedC.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zedC.GraphPane.YAxis.MajorGrid.IsZeroLine = false;

            zedC.GraphPane.XAxis.Title.IsVisible = false;
            zedC.GraphPane.YAxis.Title.IsVisible = false;
            zedC.GraphPane.Chart.Border.IsVisible = false;

            zedC.GraphPane.Title.IsVisible = true;
            zedC.GraphPane.Title.Text = "Gráfica " + (nro + 1);
            zedC.GraphPane.Title.FontSpec.Size = 12F;

            zedC.GraphPane.Border.IsVisible = false;
            zedC.GraphPane.Legend.IsVisible = false;
        }
        private void refresh(ZedGraphControl zedC)
        {
            zedC.AxisChange();
            zedC.RestoreScale(zedC.GraphPane);
            zedC.Refresh();
        }
        private void asignarGrafica(ZedGraphControl z, int i)
        {
            CurveList g = new CurveList();

            g = h.getGrafica(i);

            if (g != null)
            {
                z.GraphPane.CurveList = g;
                z.Invalidate();
                z.Refresh();
            }
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

        private void maximizar(object sender, EventArgs e)
        {
            //Identifica que gráfica generó el evento
            int nro = controles.IndexOf((ZedGraphControl)sender);

            if (h.getGrafica(nro).Count != 0)
            {
                //Oculta el formulario visible
                tableLayoutPanel1.Hide();

                //Crea un nuevo ZedGraphControl con la misma gráfica que el control en donde se hizo doble clic
                formatoZed(zedMax, nro);
                asignarGrafica(zedMax, nro);
                refresh(zedMax);

                //Se agregan las referencias para las curvas
                zedMax.GraphPane.Legend.IsVisible = true;
                zedMax.GraphPane.Legend.IsShowLegendSymbols = true;
                zedMax.GraphPane.Legend.Border.IsVisible = false;

                foreach (CurveItem curva in zedMax.GraphPane.CurveList)
                    curva.Label.IsVisible = false;

                //dgvDatos.Rows[nro].Selected = true;


                p.RowCount = 2;
                p.Controls.Add(zedMax, 0, 0);

                if(nro==0)
                    p.Controls.Add(dgvDatos1, 0, 1);
                if(nro==1)
                    p.Controls.Add(dgvDatos2, 0, 1);
                if (nro == 2)
                    p.Controls.Add(dgvDatos3, 0, 1);
                if (nro == 3)
                    p.Controls.Add(dgvDatos4, 0, 1);

                p.RowStyles[0].SizeType = SizeType.Percent;
                p.RowStyles[0].Height = 80;

                p.RowStyles[1].SizeType = SizeType.AutoSize;

                this.Controls.Add(p);

                zedMax.ZoomOutAll(gp5);
            }
        }

        private void minimizar(object sender, EventArgs e)
        {
            //Vacía el panel y se lo quita del form
            for (int i = 0; i < p.Controls.Count; i++)
                p.Controls.RemoveAt(i);

            this.Controls.Remove(p);

            //Vuelve a hacer visible el form comun
            foreach (DataGridViewRow fila in dgvDatos1.Rows)
                fila.Selected = false;

            foreach (DataGridViewRow fila in dgvDatos2.Rows)
                fila.Selected = false;

            foreach (DataGridViewRow fila in dgvDatos3.Rows)
                fila.Selected = false;

            foreach (DataGridViewRow fila in dgvDatos4.Rows)
                fila.Selected = false;

            tableLayoutPanel1.Controls.Add(dgvDatos1, 0, 2);
            tableLayoutPanel1.Controls.Add(dgvDatos2, 1, 2);
            tableLayoutPanel1.Controls.Add(dgvDatos3, 0, 3);
            tableLayoutPanel1.Controls.Add(dgvDatos4, 1, 3);
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
            string respuesta = "Y(t): " + Math.Round(pto.Y, 3) + " t: " + Math.Round(pto.X, 3);

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

    }
}
