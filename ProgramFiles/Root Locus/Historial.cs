using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Data;
using System.Windows.Forms;

namespace Root_Locus
{
    public class Historial
    {       
        int posActual;     
        public List<ZedGraph.CurveList> graficas;        
        public List<DataTable> tablas;        
        
        public Historial()
        {
            //Inicializa las tablas
            tablas = new List<DataTable>();
            for (int i = 0; i < 4; i++)
            {
                DataTable tab = new DataTable();                
                tab.Columns.Add("Datos", typeof(string));
                tab.Columns.Add("Valor", typeof(string));

                tablas.Add(tab);
            }         

            //Inicializa la lista de graficas
            graficas = new List<CurveList>();
            for (int i = 0; i < 4; i++)
                graficas.Add(new CurveList());
            
            posActual = 0;
        }
        
        public void addGrafica(CurveList g, DataTable dt)
        {            
            tablas[posActual] = dt;
            graficas[posActual] = g.Clone();

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
