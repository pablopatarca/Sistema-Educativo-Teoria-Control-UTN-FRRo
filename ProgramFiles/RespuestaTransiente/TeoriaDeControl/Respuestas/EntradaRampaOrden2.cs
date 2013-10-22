using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace TeoriaDeControl
{
    public class EntradaRampaOrden2 : IPropiedadesGrafica
    {

        #region Mis Atributos
        private double pendiente;
        private double cteTiempo;
        private double coefAmort;
        private double pasoEntrePuntos = 0.01;
        private double precisionError = 0.03;
        private double delta, difEntSal1, difEntSal2, difEntSal3, difEntSal4, difEntSal5;
        private double _FinEjeX;
        private List<string> _Titulos = new List<string>();
        private List<Nullable<double>> _Medidas = new List<Nullable<double>>();
        private Image _formula;
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
                return new string[] { "Pendiente", "Cte. Tiempo", "Coef. Amort." };
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
                return _FinEjeX;
            }
            set
            {
                _FinEjeX = value;
            }
        }

        public double FinEjeY
        {
            get
            {
                return 1.1 * this.pendiente * (this.FinEjeX - this.cteTiempo);
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
                if (coefAmort < 1)
                    return "SUA";
                else if (coefAmort == 1)
                    return "CRA";
                else
                    return "SOA";
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
        /// Calcula los puntos de las curvas para una funcion Rampa de segundo orden.
        /// </summary>
        /// <param name="parametros">parámetros de la función Rampa de segundo orden: [pendiente, cteTiempo, coefAmort]</param>
        /// <returns>Una lista de PointPairList con las curvas generadas</returns>
        public List<PointPairList> generarPuntos(double[] parametros)
        {
            //Seteo los atributos pendiente, cteTiempo y coefAmort
            this.pendiente = parametros[0];
            this.cteTiempo = parametros[1];
            this.coefAmort = parametros[2];

            //Creo una lista de PointPairLists
            List<PointPairList> listas = new List<PointPairList>();

            //Agrego los Titulos de las curvas
            Titulos.Add("Salida Rampa Segundo Orden");
            Titulos.Add("Entrada Rampa");
            Titulos.Add("1 Cte. Tiempo");
            Titulos.Add("Recta a 1 Cte. Tiempo");
            Titulos.Add("Recta a 4 Cte. Tiempo");


            /*Agrego curvas a la lista:
             * 0 - Salida
             * 1 - Entrada
             * 2 - 1 Cte. Tiempo
             * 3 - Recta a 1 Cte. Tiempo
             * 4 - Recta a 4 Cte. Tiempo             
            */
            for (int i = 0; i < 5; i++)
                listas.Add(new PointPairList());

            #region Caso 1, coefAmort < 1

            if (this.coefAmort < 1)
            {
                //seteamos la formula
                _formula = TeoriaDeControl.Properties.Resources.FormulaRampa2Orden1;

                //Calculo a cuantos tau (constantes de tiempo) se estabiliza el error.            
                int nroCteTiempoI = 1;
                int nroCteTiempoJ = 2;
                double errorCteTiempoI = Math.Abs(entrada(this.pendiente, nroCteTiempoI * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoI * this.cteTiempo));
                double errorCteTiempoJ = Math.Abs(entrada(this.pendiente, nroCteTiempoJ * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoJ * this.cteTiempo));

                while (Math.Abs(errorCteTiempoJ - errorCteTiempoI) > precisionError)
                {
                    nroCteTiempoI++;
                    nroCteTiempoJ++;
                    errorCteTiempoI = Math.Abs(entrada(this.pendiente, nroCteTiempoI * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoI * this.cteTiempo));
                    errorCteTiempoJ = Math.Abs(entrada(this.pendiente, nroCteTiempoJ * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoJ * this.cteTiempo));
                }

                //Calculo cada cuantos tau (constantes de tiempo) tomo el error dividiendo el rango en la cantidad de errores a mostrar.
                this.delta = (double)nroCteTiempoJ / 5;
                //if (this.delta > 1)
                //{
                //    this.delta = Math.Truncate(this.delta);
                //}

                //Calculo los errores.
                this.difEntSal1 = entrada(this.pendiente, this.delta * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.delta * this.cteTiempo);
                this.difEntSal2 = entrada(this.pendiente, 2 * this.delta * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 2 * this.delta * this.cteTiempo);
                this.difEntSal3 = entrada(this.pendiente, 3 * this.delta * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 3 * this.delta * this.cteTiempo);
                this.difEntSal4 = entrada(this.pendiente, 4 * this.delta * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 4 * this.delta * this.cteTiempo);
                this.difEntSal5 = entrada(this.pendiente, 5 * this.delta * this.cteTiempo) - YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 5 * this.delta * this.cteTiempo);
                
                //Establezco hasta donde graficar.
                FinEjeX = nroCteTiempoJ * this.cteTiempo;

                
                //Agrego los puntos de la curva principal
                // Multiplico el finEjeX por 5 por el problema del zoom
                for (double t = 0.0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
                {
                    listas[0].Add(t, YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, t));
                }

                //Agrego los puntos de la entrada
                // Multiplico el finEjeX por 5 por el problema del zoom
                for (double t = 0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
                {
                    listas[1].Add(t, entrada(this.pendiente, t));
                }

                //Agrego los puntos de la curva de 1 cteTiempo
                listas[2].Add(this.cteTiempo, 0);
                listas[2].Add(this.cteTiempo, YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.cteTiempo));
                listas[2].Add(0, YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.cteTiempo));

                //Agrego los puntos de la recta a 1 cteTiempo
                listas[3].Add(this.cteTiempo, YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.cteTiempo));
                listas[3].Add(this.cteTiempo, entrada(this.pendiente, this.cteTiempo));


                //Agrego los puntos de la recta a 4 cteTiempo
                listas[4].Add(4 * this.cteTiempo, YCoefAmortMenorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 4 * this.cteTiempo));
                listas[4].Add(4 * this.cteTiempo, entrada(this.pendiente, 4 * this.cteTiempo));
            }

            #endregion

            #region Caso 2, coefAmort = 1

            if (this.coefAmort == 1)
            {
                //seteamos la formula
                _formula = TeoriaDeControl.Properties.Resources.FormulaRampa2Orden2;

                //Calculo a cuantos tau (constantes de tiempo) se estabiliza el error.            
                int nroCteTiempoI = 1;
                int nroCteTiempoJ = 2;
                double errorCteTiempoI = Math.Abs(entrada(this.pendiente, nroCteTiempoI * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, nroCteTiempoI * this.cteTiempo));
                double errorCteTiempoJ = Math.Abs(entrada(this.pendiente, nroCteTiempoJ * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, nroCteTiempoJ * this.cteTiempo));

                while (errorCteTiempoJ - errorCteTiempoI > precisionError)
                {
                    nroCteTiempoI++;
                    nroCteTiempoJ++;
                    errorCteTiempoI = Math.Abs(entrada(this.pendiente, nroCteTiempoI * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, nroCteTiempoI * this.cteTiempo));
                    errorCteTiempoJ = Math.Abs(entrada(this.pendiente, nroCteTiempoJ * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, nroCteTiempoJ * this.cteTiempo));
                }

                //Calculo cada cuantos tau (constantes de tiempo) tomo el error dividiendo el rango en la cantidad de errores a mostrar.
                this.delta = (double)nroCteTiempoJ / 5;
                //if (this.delta > 1)
                //{
                //    this.delta = Math.Truncate(this.delta);
                //}

                //Calculo los errores.
                this.difEntSal1 = entrada(this.pendiente, this.delta * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, this.delta * this.cteTiempo);
                this.difEntSal2 = entrada(this.pendiente, 2 * this.delta * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, 2 * this.delta * this.cteTiempo);
                this.difEntSal3 = entrada(this.pendiente, 3 * this.delta * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, 3 * this.delta * this.cteTiempo);
                this.difEntSal4 = entrada(this.pendiente, 4 * this.delta * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, 4 * this.delta * this.cteTiempo);
                this.difEntSal5 = entrada(this.pendiente, 5 * this.delta * this.cteTiempo) - YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, 5 * this.delta * this.cteTiempo);

                //Establezco hasta donde graficar.
                FinEjeX = nroCteTiempoJ * this.cteTiempo;
                
                
                //Agrego los puntos de la curva principal
                // Multiplico el finEjeX por 5 por el problema del zoom
                for (double t = 0.0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
                {
                    listas[0].Add(t, YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, t));
                }

                //Agrego los puntos de la entrada
                // Multiplico el finEjeX por 5 por el problema del zoom
                for (double t = 0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
                {
                    listas[1].Add(t, entrada(this.pendiente, t));
                }

                //Agrego los puntos de la curva de 1 cteTiempo
                listas[2].Add(this.cteTiempo, 0);
                listas[2].Add(this.cteTiempo, YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, this.cteTiempo));
                listas[2].Add(0, YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, this.cteTiempo));

                //Agrego los puntos de la recta a 1 cteTiempo
                listas[3].Add(this.cteTiempo, YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, this.cteTiempo));
                listas[3].Add(this.cteTiempo, entrada(this.pendiente, this.cteTiempo));


                //Agrego los puntos de la recta a 4 cteTiempo
                listas[4].Add(4 * this.cteTiempo, YCoefAmortIgualAUno(this.pendiente, this.cteTiempo, 4 * this.cteTiempo));
                listas[4].Add(4 * this.cteTiempo, entrada(this.pendiente, 4 * this.cteTiempo));
            }

            #endregion

            #region Caso 3, coefAmort > 1

            if (this.coefAmort > 1)
            {
                //seteamos la formula
                _formula = TeoriaDeControl.Properties.Resources.FormulaRampa2Orden3;

                //Calculo a cuantos tau (constantes de tiempo) se estabiliza el error.            
                int nroCteTiempoI = 1;
                int nroCteTiempoJ = 2;
                double errorCteTiempoI = Math.Abs(entrada(this.pendiente, nroCteTiempoI * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoI * this.cteTiempo));
                double errorCteTiempoJ = Math.Abs(entrada(this.pendiente, nroCteTiempoJ * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoJ * this.cteTiempo));

                while (errorCteTiempoJ - errorCteTiempoI > precisionError)
                {
                    nroCteTiempoI++;
                    nroCteTiempoJ++;
                    errorCteTiempoI = Math.Abs(entrada(this.pendiente, nroCteTiempoI * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoI * this.cteTiempo));
                    errorCteTiempoJ = Math.Abs(entrada(this.pendiente, nroCteTiempoJ * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, nroCteTiempoJ * this.cteTiempo));
                }

                //Calculo cada cuantos tau (constantes de tiempo) tomo el error dividiendo el rango en la cantidad de errores a mostrar.
                this.delta = (double)nroCteTiempoJ / 5;
                //if (this.delta > 1)
                //{
                //    this.delta = Math.Truncate(this.delta);
                //}

                //Calculo los errores.
                this.difEntSal1 = entrada(this.pendiente, this.delta * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.delta * this.cteTiempo);
                this.difEntSal2 = entrada(this.pendiente, 2 * this.delta * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 2 * this.delta * this.cteTiempo);
                this.difEntSal3 = entrada(this.pendiente, 3 * this.delta * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 3 * this.delta * this.cteTiempo);
                this.difEntSal4 = entrada(this.pendiente, 4 * this.delta * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 4 * this.delta * this.cteTiempo);
                this.difEntSal5 = entrada(this.pendiente, 5 * this.delta * this.cteTiempo) - YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 5 * this.delta * this.cteTiempo);

                //Establezco hasta donde graficar.
                FinEjeX = nroCteTiempoJ * this.cteTiempo;

                
                //Agrego los puntos de la curva principal
                // Multiplico el finEjeX por 5 por el problema del zoom
                for (double t = 0.0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
                {
                    listas[0].Add(t, YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, t));
                }

                //Agrego los puntos de la entrada
                // Multiplico el finEjeX por 5 por el problema del zoom
                for (double t = 0; t < 5 * this.FinEjeX; t = t + pasoEntrePuntos)
                {
                    listas[1].Add(t, entrada(this.pendiente, t));
                }

                //Agrego los puntos de la curva de 1 cteTiempo
                listas[2].Add(this.cteTiempo, 0);
                listas[2].Add(this.cteTiempo, YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.cteTiempo));
                listas[2].Add(0, YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.cteTiempo));

                //Agrego los puntos de la recta a 1 cteTiempo
                listas[3].Add(this.cteTiempo, YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, this.cteTiempo));
                listas[3].Add(this.cteTiempo, entrada(this.pendiente, this.cteTiempo));


                //Agrego los puntos de la recta a 4 cteTiempo
                listas[4].Add(4 * this.cteTiempo, YCoefAmortMayorAUno(this.pendiente, this.cteTiempo, this.coefAmort, 4 * this.cteTiempo));
                listas[4].Add(4 * this.cteTiempo, entrada(this.pendiente, 4 * this.cteTiempo));
            }

            #endregion
            
            //Lleno la lista Medidas
            Medidas.Clear();
            for (int i = 0; i < 26; i++)
                Medidas.Add(null);
            //Delta
            Medidas.Add(this.delta);
            
            //Separación entrada salida
            Medidas.Add(difEntSal1);
            Medidas.Add(difEntSal2);
            Medidas.Add(difEntSal3);
            Medidas.Add(difEntSal4);
            Medidas.Add(difEntSal5);

            return listas;

        }

        #endregion

        //Función rampa, donde coefAmort < 1
        private double YCoefAmortMenorAUno(double pendiente, double cteTiempo, double coefAmort, double tiempo)
        {
            return (cteTiempo / Math.Sqrt(1 - coefAmort * coefAmort) * Math.Pow(Math.E, -coefAmort * tiempo / cteTiempo) *
                   Math.Sin(Math.Sqrt(1 - coefAmort * coefAmort) * tiempo / cteTiempo + Math.Atan(2 * coefAmort * Math.Sqrt(1 - coefAmort * coefAmort) / (2 * coefAmort * coefAmort - 1))) +
                   tiempo - 2 * coefAmort * cteTiempo) * pendiente;
        }

        //Función rampa, donde coefAmort = 1
        private double YCoefAmortIgualAUno(double pendiente, double cteTiempo, double tiempo)
        {
            return ((tiempo + 2 * cteTiempo) * Math.Pow(Math.E, -tiempo / cteTiempo) + tiempo - 2 * cteTiempo) * pendiente;
        }

        //Función rampa, donde coefAmort > 1
        private double YCoefAmortMayorAUno(double pendiente, double cteTiempo, double coefAmort, double tiempo)
        {
            double tau1 = cteTiempo / (coefAmort - Math.Sqrt(coefAmort * coefAmort - 1));
            double tau2 = cteTiempo / (coefAmort + Math.Sqrt(coefAmort * coefAmort - 1));
            return (tau1 * tau1 / (tau1 - tau2) * Math.Pow(Math.E, -tiempo / tau1) +
                   tau2 * tau2 / (tau2 - tau1) * Math.Pow(Math.E, -tiempo / tau2) +
                   tiempo - (tau1 + tau2)) * pendiente;
        }

        private double entrada(double pendiente, double tiempo)
        {
            return pendiente * tiempo;
        }
    }
}
