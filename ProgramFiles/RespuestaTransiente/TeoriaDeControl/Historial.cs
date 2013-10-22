using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Data;
using System.Windows.Forms;

namespace TeoriaDeControl
{
    public class Historial
    {       
        int posActual;     
        public List<ZedGraph.CurveList> graficas;        
        public double[] finX;
        public double[] finY;
        public double[] inicioX;
        public double[] inicioY;
        public List<DataTable> tablas;        

        public Historial()
        {
            //Inicializa las tablas
            tablas = new List<DataTable>();
            for (int i = 0; i < 4; i++)
            {
                DataTable tab = new DataTable();
                tablas.Add(tab);
            }  
 
            //Inicializa la lista de graficas
            graficas = new List<CurveList>();
            for (int i = 0; i < 4; i++)
                graficas.Add(new CurveList());

            this.finX = new double[4];
            this.finY = new double[4];
            this.inicioX = new double[4];
            this.inicioY = new double[4];

            posActual = 0;
        }

        public void addGrafica(CurveList g, double finX, double finY, double inicioX, double inicioY, DataTable dt)
        {
            tablas[posActual] = dt;

            graficas[posActual] = g.Clone();
            this.finX[posActual] = finX;
            this.finY[posActual] = finY;
            this.inicioX[posActual] = inicioX;
            this.inicioY[posActual] = inicioY;
            aumentarPos();
        }
        
        private void aumentarPos()
        {
            posActual++;
            if (posActual == 4)
                posActual = 0;
        }
        
        public CurveList getGrafica(int i)
        {
            try 
	        {	        
	            return graficas[i];	
	        }
	        catch (Exception)
	        {
                return null;
	        }
        }
    }
}
