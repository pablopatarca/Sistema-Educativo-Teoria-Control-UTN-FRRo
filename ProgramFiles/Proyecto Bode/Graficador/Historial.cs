using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Data;
using System.Windows.Forms;
using Util;

namespace DiagramasBode
{
    public class Historial
    {       
        int posActual;     
        public Formula[] formulas;        
        public List<DataTable> tablas;        
        
        public Historial()
        {
            //Inicializa las tablas
            tablas = new List<DataTable>();
            for (int i = 0; i < 2; i++)
            {
                DataTable tab = new DataTable();                
                tab.Columns.Add("Datos", typeof(string));
                tab.Columns.Add("Valor", typeof(string));

                tablas.Add(tab);
            }         

            //Inicializa la lista de graficas
            formulas = new Formula[2];

            this.posActual = 0;

        }
        
        public void addGrafica(Util.Formula f, DataTable dt)
        {            
            tablas[posActual] = dt;
            formulas[posActual] = f;

            aumentarPos();
        }
        
        private void aumentarPos()
        {
            posActual++;
            if (posActual == 2)
                posActual = 0;
        }
        
        public Util.Formula getGrafica(int i)
        {
            try 
	        {	        
	            return formulas[i];	
	        }
	        catch (Exception)
	        {
                return null;
	        }
        }
    }
}
