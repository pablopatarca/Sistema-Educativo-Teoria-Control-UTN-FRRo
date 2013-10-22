using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace TeoriaDeControl
{

    public class EntradaEscalonOrden1 : IPropiedadesGrafica
    {

        #region Mis Atributos
        private double amplitud;
        private double cteTiempo;
        private double pasoEntrePuntos = 0.01;
        private List<string> _Titulos = new List<string>();
        private List<Nullable<double>> _Medidas = new List<Nullable<double>>();
        private Image _formula = TeoriaDeControl.Properties.Resources.FormulaEscalon1Orden;
        #endregion

        #region Implementacion de IPropiedadesGrafica
        public List<string> Titulos
        {
            get
            {
                return _Titulos;
            }
            set
            {
                _Titulos = value;
            }
        }

        public string NombreEjeX
        {
            get
            {
                return "Tiempo";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string NombreEjeY
        {
            get
            {
                return "Y(t)";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool LogEjeX
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool LogEjeY
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string[] NombreParametros
        {
            get
            {
                return new string[] { "Amplitud", "Cte. Tiempo" };
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double InicioEjeX
        {
            get
            {
                return 0.0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double InicioEjeY
        {
            get
            {
                return 0.0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double FinEjeX
        {
            get
            {
                return 5 * this.cteTiempo;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double FinEjeY
        {
            get
            {
                return this.amplitud * 1.1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public String[] Botones
        {
            get
            {
                return new string[] { "63% Rta. Final", "Tpo. Asentamiento" };
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<Nullable<double>> Medidas
        {

            get
            {
                return _Medidas;
            }
            set
            {
                _Medidas = value;
            }
        }

        public String Amortiguacion
        {
            get
            {
                return "";
            }
        }

        public Image Formula 
        { 
            get
            {
                return _formula;
            }
        }

        /// <summary>
        /// Calcula los puntos de las curvas para una funcion Impulso de primer orden.
        /// </summary>
        /// <param name="parametros">parámetros de la función Impulso de primer orden: [amplitud, cteTiempo]</param>
        /// <returns>Una lista de PointPairList con las curvas generadas</returns>
        public List<PointPairList> generarPuntos(double[] parametros)
        {              
            //Seteo los atributos amplitud y cteTiempo
            this.amplitud = parametros[0];
            this.cteTiempo = parametros[1];

            //Creo una lista de PointPairLists
            List<PointPairList> listas = new List<PointPairList>();

            //Agrego los Titulos de las curvas
            Titulos.Add("Salida Escalon Primer Orden");
            Titulos.Add("Entrada Escalon");
            Titulos.Add("63 % de la rta final");
            Titulos.Add("Tiempo de Asentamiento");
            Titulos.Add("Tiempo de subida 10%");
            Titulos.Add("Tiempo de subida 90%");
            Titulos.Add("Tiempo de subida");
            Titulos.Add("Pendiente en el origen");


            /*Agrego curvas a la lista:
             * 0 - Salida
             * 1 - Entrada
             * 2 - 63% de la rta final  
             * 3 - Tiempo de Asentamiento
             * 4 - Tiempo de Subida 10%
             * 5 - Tiempo de subida 90%
             * 6 - Diferencia tiempo de subida
             * 7 - Pendiente en el origen
            */
            for (int i = 0; i < 8; i++)
                listas.Add(new PointPairList());


            //Agrego los puntos de la curva principal
            for (double t = 0.0; t < this.FinEjeX*10; t = t + pasoEntrePuntos)
                listas[0].Add(t, Y(this.amplitud, this.cteTiempo, t));

            //Agrego los puntos de la entrada
            listas[1].Add(0, this.amplitud);
            listas[1].Add(5*this.cteTiempo*10, this.amplitud);

            //Agrego los puntos del 63% de la respuesta final
            listas[2].Add(this.cteTiempo, 0);
            listas[2].Add(this.cteTiempo,Y(this.amplitud,this.cteTiempo,this.cteTiempo));
            listas[2].Add(0, Y(this.amplitud, this.cteTiempo, this.cteTiempo));
            
            //Agrego los puntos del Tiempo de Asentamiento
            listas[3].Add(4 * this.cteTiempo, 0);
            listas[3].Add(4 * this.cteTiempo,Y(this.amplitud,this.cteTiempo,4 * this.cteTiempo));
            listas[3].Add(0,Y(this.amplitud,this.cteTiempo,4 * this.cteTiempo));

            //Agrego los puntos del Tiempo de Subida 10%
            listas[4].Add(-this.cteTiempo * Math.Log(0.9), 0);
            listas[4].Add(-this.cteTiempo * Math.Log(0.9), Y(this.amplitud, this.cteTiempo, -this.cteTiempo * Math.Log(0.9)));
            listas[4].Add(0, Y(this.amplitud, this.cteTiempo, -this.cteTiempo * Math.Log(0.9)));

            //Agrego los puntos del Tiempo de Subida 90%
            listas[5].Add(-this.cteTiempo * Math.Log(0.1), 0);
            listas[5].Add(-this.cteTiempo * Math.Log(0.1), Y(this.amplitud, this.cteTiempo, -this.cteTiempo * Math.Log(0.1)));
            listas[5].Add(0, Y(this.amplitud, this.cteTiempo, -this.cteTiempo * Math.Log(0.1)));

            //Diferencia tiempo de subida
            listas[6].Add(-this.cteTiempo * Math.Log(0.9), 0);
            listas[6].Add(-this.cteTiempo * Math.Log(0.1), 0);

            //Agrego los puntos de recta Pendiente en el Origen
            listas[7].Add(0, 0);
            listas[7].Add(this.cteTiempo, this.amplitud);

            //Lleno la lista Medidas
            Medidas.Clear();

            Medidas.Add(null);
            Medidas.Add(null);
            Medidas.Add(2.2 * this.cteTiempo);
            Medidas.Add(4 * this.cteTiempo);
            

            return listas;

        }

        #endregion

        private double Y(double amplitud, double cteTiempo, double t)
        {
            return amplitud * (1 - Math.Exp(-t / cteTiempo));
        }
    }

}
