using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Windows.Forms;
using System.Drawing;

namespace TeoriaDeControl
{
    public class EntradaSenoidalOrden1 : IPropiedadesGrafica
    {
        #region Mis Atributos
        private double amplitud;
        private double cteTiempo;
        private double frecuencia;
        private double valorBase;
        private double pasoEntrePuntos = 0.01;
        private double tMaxSalida = 0;
        private double tMaxEntrada = 0;
        private double maximoValorEntrada;
        private double minimoValorEntrada;
        private double maximoValorSalida;
        private double minimoValorSalida;
        private double tiempoSolapamiento = 0;
        private List<string> _Titulos = new List<string>();
        private List<Nullable<double>> _Medidas = new List<Nullable<double>>();
        private List<double> _FrecGrad = new List<double>();
        private Image _formula = TeoriaDeControl.Properties.Resources.FormulaSenoidal1Orden;
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
                return "y(t)";
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
                //return new string[] { "Amplitud", "Cte. Tiempo", "Frecuencia Angular", "Valor Base" };
                return new string[] { "Valor Base", "Amplitud", "Frecuencia", "Cte. Tiempo" };
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
                return this.valorBase - this.amplitud * 1.1;
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
                return 4 * (2 * Math.PI / this.frecuencia);
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
                return this.valorBase + this.amplitud * 1.1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public String[] Botones
        {
            set
            {
                throw new NotImplementedException();
            }

            get
            {
                return new string[] { "Sda. Total", "Referencias" };
            }
        }

        public List<double?> Medidas
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

        public List<double> FrecGrados
        {
            get
            {
                return _FrecGrad;
            }
            set
            {
                _FrecGrad = value;
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
        /// Determina el paso entre puntos dependiente de la frecuencia
        /// </summary>
        /// <returns>Devuelve el paso entre puntos</returns>
        private double getPasoEntrePuntos()
        {
            //parámetros para establecer el pasoentrepuntos dependiente de la frecuencia
            double expPaso = 0, basePaso = 10, valorIni=15, valorLimInf =0, valorLimSup=0;
            double paso = 0.01;

            //calculamos el límite superior
            valorLimSup=valorIni * Math.Pow(basePaso,expPaso);
            while (!((frecuencia >= valorLimInf) && (frecuencia < valorLimSup)))
            {
                //si no está en el rango indicado, disminuimos el paso entre puntos en décuplo
                expPaso++;
                valorLimInf = valorLimSup;
                valorLimSup = valorIni * Math.Pow(basePaso, expPaso);
                paso /= 10;
            }
            return paso;
        }

        public List<ZedGraph.PointPairList> generarPuntos(double[] parametros)
        {
            Titulos.Clear();

            //Seteo los atributos valorBase, amplitud, frecuecnia,cteTiempo.
            this.valorBase = parametros[0];
            this.amplitud = parametros[1];
            this.frecuencia = parametros[2];
            this.cteTiempo = parametros[3];
            
            double y = Math.Round(this.amplitud / (Math.Sqrt(((this.cteTiempo * this.cteTiempo) * (this.frecuencia * this.frecuencia)) + 1)), 4);
            double theta = Math.Round((Math.Atan(-this.frecuencia * this.cteTiempo) * 180) / Math.PI, 2);

            //Creo una lista de PointPairLists
            List<PointPairList> listas = new List<PointPairList>();

            //Agrego los Titulos de las curvas
            Titulos.Add("Salida senoidal estacionaria " + y + "sen(" + this.frecuencia + "t " + theta + "º)");
            Titulos.Add("Entrada Senoidal " + this.amplitud + "sen" + this.frecuencia + "t");
            Titulos.Add("Salida senoidal total");
            Titulos.Add("3 Cte. Tiempo");
            Titulos.Add("Tiempo de solapamiento");
            Titulos.Add("Valor Base");
            Titulos.Add("Pico entrada");
            Titulos.Add("Pico salida");
            Titulos.Add("Período");
            Titulos.Add("Retardo de Fase");

            /*Agrego curvas a la lista:
             * 0 - Salida senoidal estacionario
             * 1 - Entrada Senoidal
             * 2 - Salida senoidal total
             * 3 - 3 T
             * 4 - Tiempo de solapamiento
             * 5 - Valor Base
             * 6 - Pico entrada
             * 7 - Pico salida
             * 8 - Período
             * 9 - Retardo de Fase
            */
            for (int i = 0; i < 10; i++)
                listas.Add(new PointPairList());

            //Variables para comparacion del solapado
            double ySalidaCompleta;
            double ySalidaSimplificada;
            bool encontroTiempoSolapamiento = false;


            // Agrego los puntos a la curva de 3t
            listas[3].Add(3 * this.cteTiempo, 0);
            listas[3].Add(3 * this.cteTiempo, SalidaSimplificada(this.amplitud, this.frecuencia, this.cteTiempo, 3 * this.cteTiempo));

            //Agrego los puntos a la curva de Valor Base
            listas[5].Add(0, this.valorBase);
            listas[5].Add(this.FinEjeX * 5, this.valorBase);

            //establezco el paso entre puntos dependiendo de la frecuencia
            pasoEntrePuntos= getPasoEntrePuntos();

            //Agrego los puntos a las 3 curvas principales
            for (double t = 0.0; t < this.FinEjeX * 5; t = t + pasoEntrePuntos)
            {
                ySalidaCompleta = SalidaCompleta(this.amplitud, this.frecuencia, this.cteTiempo, t);
                ySalidaSimplificada = SalidaSimplificada(this.amplitud, this.frecuencia, this.cteTiempo, t);

                listas[0].Add(t, ySalidaSimplificada);

                listas[1].Add(t, Seno(this.valorBase, this.amplitud, this.frecuencia, t));

                listas[2].Add(t, ySalidaCompleta);


                if ((Math.Abs(ySalidaCompleta - ySalidaSimplificada) < (0.01 * this.amplitud)) && (encontroTiempoSolapamiento == false))
                {
                    listas[4].Add(t, 0);
                    listas[4].Add(t, ySalidaSimplificada);
                    tiempoSolapamiento = t;
                    encontroTiempoSolapamiento = true;

                }
            }

            //Calculo la cantidad de picos de la entrada
            double altura =0;
            int cantCumbres = 0;
            for (int i = 1; i < listas[1].Count - 1; i++)
            {
                if (listas[1][i].Y > listas[1][i - 1].Y && listas[1][i].Y > listas[1][i + 1].Y)
                {
                    cantCumbres++;
                }

                if (cantCumbres == 3)
                {
                    listas[6].Add(listas[1][i].X, valorBase);
                    listas[6].Add(listas[1][i].X, listas[1][i].Y);
                    //Calculo Período
                    double periodo = Math.Round(2 * Math.PI / this.frecuencia, 2);
                    listas[8].Add(listas[1][i].X - periodo, listas[1][i].Y);
                    listas[8].Add(listas[1][i].X, listas[1][i].Y);
                    //retardo de fase (gráficamente una cota)
                    altura = (valorBase+amplitud);
                    listas[9].Add(listas[1][i].X, altura * 1.001);
                    listas[9].Add(listas[1][i].X, altura * 0.999);
                    listas[9].Add(listas[1][i].X, altura);
                    break;
                }
            }

            //Calculo la cantidad de picos de la salida
            // Usando la salida simplificada.
            int cantCumbresSalida = 0;
            for (int i = 1; i < listas[0].Count - 1; i++)
            {
                if (listas[0][i].Y > listas[0][i - 1].Y && listas[0][i].Y > listas[0][i + 1].Y)
                {
                    cantCumbresSalida++;
                }

                if (cantCumbresSalida == 3)
                {
                    listas[7].Add(listas[0][i].X, valorBase);
                    listas[7].Add(listas[0][i].X, listas[0][i].Y);
                    //retardo de fase (gráficamente una cota)
                    listas[9].Add(listas[0][i].X, altura);
                    listas[9].Add(listas[0][i].X, altura*1.001);
                    listas[9].Add(listas[0][i].X, altura*0.999);
                    break;
                }
            }

            //Agrego la amplitud de la salida y la amplitud de la entrada
            double ampSalida = listas[7][1].Y;
            double ampEntrada = this.valorBase + this.amplitud;

            //Calculo el maximo y minimo valor de la entrada
            maximoValorEntrada = this.valorBase + this.amplitud;
            minimoValorEntrada = this.valorBase - this.amplitud;
            double tMaxEntrada = Math.PI / (2 * this.frecuencia); //contiene el valor de t correspondiente al pico max de la entrada (en realidad es el primer pico)



            // Estamos usando listas[0] asi que es la salida senoidal simplificada. Verificar si es correcto.
            //Maximo valor de la salida
            double tMaxSalida = 0;
            for (int i = 1; i < listas[0].Count - 1; i++)
            {
                if (listas[0][i].Y > listas[0][i - 1].Y && listas[0][i].Y > listas[0][i + 1].Y)
                {
                    //Maximo valor
                    maximoValorSalida = listas[0][i].Y;
                    tMaxSalida = listas[0][i].X;
                    break;
                }
            }
            //Minimo valor de la salida
            for (int i = 1; i < listas[0].Count - 1; i++)
            {
                if (listas[0][i].Y < listas[0][i - 1].Y && listas[0][i].Y < listas[0][i + 1].Y)
                {
                    //Minimo valor
                    minimoValorSalida = listas[0][i].Y;
                    break;
                }
            }

            frecuenciaGrados();

            //Lleno la lista Medidas
            Medidas.Clear();
            //"Overshoot"
            Medidas.Add(null);
            //"Overshoot (%)"
            Medidas.Add(null);
            //"Tiempo de Subida"
            Medidas.Add(null);
            //"Tiempo de asentamiento"
            Medidas.Add(null);
            //"Razon de caida"
            Medidas.Add(null);
            //"Periodo de Oscilacion"
            Medidas.Add(Math.Round(2 * Math.PI / this.frecuencia, 2));
            //"Retardo de fase (tiempo)"
            Medidas.Add(tMaxSalida - tMaxEntrada);
            //"Retardo de fase (radianes)"
            Medidas.Add(Math.Round(Math.Atan(-this.frecuencia * this.cteTiempo), 2));
            //"Retardo de fase (grados)"
            Medidas.Add((Math.Atan(-this.frecuencia * this.cteTiempo) * 180) / Math.PI);
            //"Relación de Amplitud (AR)"
            //Medidas.Add(ampSalida / ampEntrada);
            Medidas.Add(1 / (Math.Sqrt(Math.Pow(this.cteTiempo, 2) * Math.Pow(this.frecuencia, 2) + 1)));
            //"Tiempo 1º Pico"
            Medidas.Add(null);
            //"Max. valor de salida"
            Medidas.Add(maximoValorSalida);
            //"Max. valor de entrada"
            Medidas.Add(maximoValorEntrada);
            //"Min. valor de salida"
            Medidas.Add(minimoValorSalida);
            //"Min. valor de entrada"
            Medidas.Add(minimoValorEntrada);
            //"Separacion Entrada Salida"
            Medidas.Add(null);
            //"Tiempo solapamiento"
            Medidas.Add(tiempoSolapamiento);
            //constante de tiempo
            for (int i = 0; i < 6; i++)
            {
                Medidas.Add(null);
            }
            //"3 tau"
            Medidas.Add(3 * cteTiempo);


            return listas;

        }
        #endregion

        //Función senoidal de entrada
        private double Seno(double valorBase, double amplitud, double frecuencia, double t)
        {
            return valorBase + amplitud * Math.Sin(frecuencia * t);
        }

        //Salida completa
        private double SalidaCompleta(double amplitud, double frecuencia, double cteTiempo, double t)
        {
            //Variables al cuadrado.
            double cteTiempo2 = cteTiempo * cteTiempo,
                   frecuencia2 = frecuencia * frecuencia;

            return this.valorBase + ((amplitud * frecuencia * cteTiempo) / (cteTiempo2 * frecuencia2 + 1)) * Math.Pow(Math.E, (-t / cteTiempo))
                + (amplitud / (Math.Sqrt(frecuencia2 * cteTiempo2 + 1))) * Math.Sin(frecuencia * t + phi(frecuencia, cteTiempo));
        }

        //Salida simplificada
        private double SalidaSimplificada(double amplitud, double frecuencia, double cteTiempo, double tiempo)
        {
            //Variables al cuadrado.
            double cteTiempo2 = cteTiempo * cteTiempo,
                   frecuencia2 = frecuencia * frecuencia;

            return this.valorBase + (amplitud / (Math.Sqrt(frecuencia2 * cteTiempo2 + 1)))
                * Math.Sin(frecuencia * tiempo + phi(frecuencia, cteTiempo));
        }

        //Phi: desplazamiento de la curva
        private double phi(double frecuencia, double cteTiempo)
        {
            return Math.Atan(-frecuencia * cteTiempo);
        }

        public void frecuenciaGrados()
        {
            
            double grado = 360 / (2 * Math.PI);
            FrecGrados.Clear();
            FrecGrados.Add(grado * (-Math.Atan((cteTiempo * 0))));
            FrecGrados.Add(grado * (-Math.Atan((cteTiempo * 1))));
            FrecGrados.Add(grado * (-Math.Atan((cteTiempo * 2))));
            FrecGrados.Add(grado * (-Math.Atan((cteTiempo * 10))));
            FrecGrados.Add(grado * (-Math.Atan((cteTiempo * 100))));
            FrecGrados.Add(grado * (-Math.Atan((cteTiempo * 1000))));

            
        }

    }
}
