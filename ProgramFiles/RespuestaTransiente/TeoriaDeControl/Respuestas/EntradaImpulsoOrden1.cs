using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace TeoriaDeControl
{
    public class EntradaImpulsoOrden1 : IPropiedadesGrafica
    {

        #region Mis Atributos
        private double amplitud;
        private double cteTiempo;
        private double pasoEntrePuntos = 0.01;
        private List<string> _Titulos = new List<string>();
        private List<Nullable<double>> _Medidas = new List<Nullable<double>>();
        private Image _formula = TeoriaDeControl.Properties.Resources.FormulaImpulso1Orden;
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
                return 1.1*(this.amplitud / this.cteTiempo);
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
                return new string[] { "37% Rta. Final", "Tpo. Asentamiento" };
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
            Titulos.Add("Salida Impulso Primer Orden");
            Titulos.Add("Entrada Impulso");
            Titulos.Add("37 % de la rta final");
            Titulos.Add("Tiempo de Asentamiento");
            Titulos.Add("Pendiente en el origen");

            /*Agrego curvas a la lista:
             * 0 - Salida
             * 1 - Entrada
             * 2 - 37% de la rta final 
             * 3 - Tiempo de Asentamiento
             * 4 - Pendiente en el origen
            */
            for (int i = 0; i < 5; i++)
                listas.Add(new PointPairList());
            

            //Agrego los puntos de la curva principal
            for (double t = 0.0; t < this.FinEjeX*10; t = t + pasoEntrePuntos)
                listas[0].Add(t, Y(this.amplitud, this.cteTiempo, t));
            
            //Agrego los puntos de la entrada
            listas[1].Add(0, 0);
            listas[1].Add(0, this.amplitud/this.cteTiempo);

            //Agrego los puntos del 37% de la respuesta final
            listas[2].Add(this.cteTiempo, 0);
            listas[2].Add(this.cteTiempo, Y(this.amplitud, this.cteTiempo, this.cteTiempo));
            listas[2].Add(0, Y(this.amplitud, this.cteTiempo, this.cteTiempo));

            //Agrego los puntos del 2% de la respuesta final
            listas[3].Add(4 * this.cteTiempo, 0);
            listas[3].Add(4 * this.cteTiempo, Y(this.amplitud, this.cteTiempo, 4 * this.cteTiempo) / 2);
            listas[3].Add(4 * this.cteTiempo, Y(this.amplitud, this.cteTiempo, 4 * this.cteTiempo));            
            listas[3].Add(0, Y(this.amplitud, this.cteTiempo, 4 * this.cteTiempo));

            //Agrego los puntos de recta Pendiente en el Origen
            listas[4].Add(0, listas[0][0].Y);
            listas[4].Add(this.cteTiempo, 0);
            
            //Lleno la lista Medidas
            Medidas.Clear();
            Medidas.Add(null);
            Medidas.Add(null);
            Medidas.Add(null);
            Medidas.Add(4 * this.cteTiempo);
            
            
            return listas;

        }

        #endregion

        private double Y(double amplitud, double cteTiempo, double t)
        {
            return amplitud * ((1.0 / cteTiempo) * Math.Pow(Math.E, (-t / cteTiempo)));
        }
        

        
    }
}