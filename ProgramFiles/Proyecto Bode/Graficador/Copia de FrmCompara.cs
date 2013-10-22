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

namespace DiagramasBode
{
    public partial class FrmCompara : Form
    {
        TableLayoutPanel p;
        Historial h;
        ZedGraphControl zedMax;
        List<ZedGraphControl> controles;

        public FrmCompara(Historial his)
        {
            InitializeComponent();
            //Para que la tabla ocupe dos columnas
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel1.GetControlFromPosition(0, 2), 2);
            
            //Lista de los controles zedGraph
            controles = new List<ZedGraphControl>();
            controles.Add(zedGraphControl1);
            controles.Add(zedGraphControl2);
            controles.Add(zedGraphControl3);
            controles.Add(zedGraphControl4);
            
            //Historial - Apunta al historial del form ppal
            h = his;
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
            p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent,100F));
            p.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute,110F));
            
            zedMax = new ZedGraphControl();            
            zedMax.Anchor = AnchorStyles.Top;
            zedMax.Dock = DockStyle.Fill;
            zedMax.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(Zoom);
            zedMax.PointValueEvent += new ZedGraphControl.PointValueHandler(infoPunto);
            zedMax.DoubleClick += new System.EventHandler(minimizar);            

            //Instancia la tabla de datos
            dgvDatos.Rows.Add(2);

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
            }

            foreach (DataGridViewRow fila in dgvDatos.Rows)
                fila.Selected = false;
        }

        private void formatoZed(ZedGraphControl zedC,int nro)
        {
            zedC.IsShowPointValues = true;
            zedC.GraphPane.XAxis.Scale.MinGrace = 0;
            zedC.GraphPane.XAxis.Scale.MaxGrace = 0;

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
            zedC.GraphPane.Title.Text = "Gráfica "+ (nro+1);
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
                z.GraphPane.CurveList = g;            
        }        
        
        private void rellenarFilaTabla(int fil)
        { 
            DataTable t = h.tablas[fil];
            try
            {
                dgvDatos.Rows[fil].Cells[0].Value = "" + (fil + 1);
                dgvDatos.Rows[fil].Cells[1].Value = "" + t.Rows[0][1];
                //dgvDatos.Rows[fil].Cells[2].Value = "" + t.Rows[1][1];
                //dgvDatos.Rows[fil].Cells[3].Value = "" + t.Rows[2][1];
                //dgvDatos.Rows[fil].Cells[4].Value = "" + t.Rows[3][1];
                //dgvDatos.Rows[fil].Cells[5].Value = "" + t.Rows[4][1];
                //dgvDatos.Rows[fil].Cells[6].Value = "" + t.Rows[5][1];
                //dgvDatos.Rows[fil].Cells[7].Value = "" + t.Rows[7][1];
                //dgvDatos.Rows[fil].Cells[8].Value = "" + t.Rows[8][1];
            }
            catch
            { }
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

            try{
            zedMax.GraphPane.CurveList["Polos"].Label.IsVisible = true;
            zedMax.GraphPane.CurveList["Ceros"].Label.IsVisible = true;
            zedMax.GraphPane.CurveList["Root Locus"].Label.IsVisible = true;
            zedMax.GraphPane.CurveList["Punto de Ruptura"].Label.IsVisible = true;
            zedMax.GraphPane.CurveList["Asintotas"].Label.IsVisible = true;
            }
            catch{ }


            dgvDatos.Rows[nro].Selected = true;
            p.Controls.Add(zedMax,0,0);
            p.Controls.Add(dgvDatos,0,1);            
            this.Controls.Add(p);
        }
        
        private void minimizar(object sender, EventArgs e)
        {
            //Vacía el panel y se lo quita del form
            for (int i = 0; i < p.Controls.Count; i++)
                p.Controls.RemoveAt(i);

            this.Controls.Remove(p);
            
            //Vuelve a hacer visible el form comun
            foreach (DataGridViewRow fila in dgvDatos.Rows)
                fila.Selected = false;

            tableLayoutPanel1.Controls.Add(dgvDatos, 0, 2);
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
            string respuesta = "X: " + Math.Round(pto.X, 3) + "\r\nY: " + Math.Round(pto.Y, 3) + "\r\nValor K: " + pto.Z;

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
