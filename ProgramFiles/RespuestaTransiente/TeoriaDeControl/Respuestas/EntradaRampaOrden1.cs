using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace TeoriaDeControl
{
    public class EntradaRampaOrden1 : IPropiedadesGrafica
    {

        #region Mis Atributos
        private double pendiente;
        private double cteTiempo;
        private double pasoEntrePuntos = 0.01;
        private double difEntSal1Thau, difEntSal2Thau, difEntSal3Thau, difEntSal4Thau, difEntSal5Thau;
        private List<string> _Titulos = new List<string>();
        private List<Nullable<double>> _Medidas = new List<Nullable<double>>();
        private Image _formula = TeoriaDeControl.Properties.Resources.FormulaRampa1Orden;
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
                return new string[] { "Pendiente", "Cte. Tiempo" };
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
                return 1.1*this.pendiente*(this.FinEjeX-this.cteTiempo);
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
                return new string[] { "1 Cte. Tiempo", "Separacion E / S" };
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
        /// Calcula los puntos de las curvas para una funcion Rampa de primer orden.
        /// </summary>
        /// <param name="parametros">parámetros de la función Rampa de primer orden: [pendiente, cteTiempo]</param>
        /// <returns>Una lista de PointPairList con las curvas generadas</returns>
        public List<PointPairList> generarPuntos(double[] parametros)
        {
            //Seteo mis propiedades Pendiente y Thau
            this.pendiente = parametros[0];
            this.cteTiempo = parametros[1];

            //Creo una lista de PointPairLists
            List<PointPairList> listas = new List<PointPairList>();

            //Agrego los Titulos de las curvas
            Titulos.Add("Salida Rampa Primer Orden");
            Titulos.Add("Entrada Rampa");
            Titulos.Add("1 Cte. Tiempo");
            Titulos.Add("Recta a 1 Cte. Tiempo");
            Titulos.Add("Recta a 4 Cte. Tiempo");


            //Agrego una curva a la lista para la curva principal y una segunda para la entrada
            for (int i = 0; i < 5; i++)
                listas.Add(new PointPairList());

            //Agrego los puntos de la curva principal
            // Multiplico el finEjeX por 5 por el problema del zoom
            for (double t = 0.0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
            {
                listas[0].Add(t, Y(this.pendiente, this.cteTiempo, t));
            }

            //Agrego los puntos de la entrada
            // Multiplico el finEjeX por 5 por el problema del zoom
            for (double t = 0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
            {
                listas[1].Add(t,entrada(this.pendiente,t));
            }

            //Agrego los puntos de la curva de 1 cteTiempo
            listas[2].Add(this.cteTiempo,0);
            listas[2].Add(this.cteTiempo,Y(this.pendiente,this.cteTiempo,this.cteTiempo));
            listas[2].Add(0, Y(this.pendiente, this.cteTiempo, this.cteTiempo));

            //Agrego los puntos de la recta a 1 cteTiempo
            listas[3].Add(this.cteTiempo,Y(this.pendiente,this.cteTiempo,this.cteTiempo));
            listas[3].Add(this.cteTiempo, entrada(this.pendiente, this.cteTiempo));

            
            //Agrego los puntos de la recta a 4 cteTiempo
            listas[4].Add(4 * this.cteTiempo, Y(this.pendiente, this.cteTiempo, 4 * this.cteTiempo));
            listas[4].Add(4 * this.cteTiempo, entrada(this.pendiente, 4 * this.cteTiempo));

            //Calculos de las diferencias entre la entrada y la salida a 1,2,3,4 y 5 Thau
            this.difEntSal1Thau = ((entrada(this.pendiente, 1 * this.cteTiempo)) - (Y(this.pendiente, this.cteTiempo, 1 * this.cteTiempo)));
            this.difEntSal2Thau = ((entrada(this.pendiente, 2 * this.cteTiempo)) - (Y(this.pendiente, this.cteTiempo, 2 * this.cteTiempo)));
            this.difEntSal3Thau = ((entrada(this.pendiente, 3 * this.cteTiempo)) - (Y(this.pendiente, this.cteTiempo, 3 * this.cteTiempo)));
            this.difEntSal4Thau = ((entrada(this.pendiente, 4 * this.cteTiempo)) - (Y(this.pendiente, this.cteTiempo, 4 * this.cteTiempo)));
            this.difEntSal5Thau = ((entrada(this.pendiente, 5 * this.cteTiempo)) - (Y(this.pendiente, this.cteTiempo, 5 * this.cteTiempo)));
            


            //Lleno la lista Medidas
            Medidas.Clear();
            for(int i = 0; i < 15;i++)
                Medidas.Add(null);
            //Separacion Entrada Salida
            Medidas.Add(999999999);
            //Tiempo de Solapamiento
            Medidas.Add(null);
            Medidas.Add(difEntSal1Thau);
            Medidas.Add(difEntSal2Thau);
            Medidas.Add(difEntSal3Thau);
            Medidas.Add(difEntSal4Thau);
            Medidas.Add(difEntSal5Thau);

            return listas;

        }

        #endregion

        private double Y(double pendiente, double cteTiempo, double t)
        {
            return pendiente * (t - cteTiempo * (1 - Math.Pow(Math.E, (-t / cteTiempo))));
        }

        private double entrada(double pendiente, double t)
        {
            return pendiente * t;
        }

                

    }

}