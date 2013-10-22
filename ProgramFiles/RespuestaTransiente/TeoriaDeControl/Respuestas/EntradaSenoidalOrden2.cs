using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using TeoriaDeControl;
using System.Windows.Forms;
using System.Drawing;

namespace TeoriaDeControl
{
    class EntradaSenoidalOrden2 : IPropiedadesGrafica
    {
        private double cteTiempo;
        private double amplitud;
        private double coefAmort;
        private double frecuencia;
        private double valorBase;
        private double omega;
        private double pasoentrepuntos=0.01;
        private double ampSalida;
        private double ampEntrada;
        private double minSalida;
        private double maxSalida;
        private double tMaxSalida = 0;
        private double _InicioEjeY, _FinEjeY;
        private List<string> _Titulos = new List<string>();
        private List<Nullable<double>> _Medidas = new List<Nullable<double>>();
        private List<double> _FrecRad = new List<double>();
        private List<double> _FrecGrad = new List<double>();
        private int id = 0;
        private Image _formula = TeoriaDeControl.Properties.Resources.FormulaSenoidal2Orden1;

        #region Implementación de IPropiedadesGrafica

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

        public string Titulo
        {
            get
            {
                return "Salida Senoidal Segundo Orden";
            }
            set
            {
                throw new NotImplementedException();
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
                //return new string[] { "Amplitud", "Cte. tiempo", "Coef. Amort", "Frecuencia", "Valor Base"};
                return new string[] { "Valor Base", "Amplitud", "Frecuencia", "Cte. Tiempo", "Coef. Amort." };
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
                return _InicioEjeY;
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
                return limiteEjeX()*4;
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
                return _FinEjeY;
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
                return new string[] { "Valor Base", "Referencias" };
            }
        }

        public String Amortiguacion
        {
            get
            {
                return "";
            }
        }

        public List<Nullable<double>> Medidas
        {

            //Devuelve las medidas de desempeño
            //Medidas[0] = valor del OVERSHOOT
            //Medidas[1] = valor de la RAZON DE CAIDA
            //Medidas[2] = valor del TIEMPO DE SUBIDA
            //Medidas[3] = valor del TIEMPO DE ASENTAMIENTO
            //Medidas[4] = valor del PERIODO DE OSCILACION

            get
            {
                return _Medidas;
            }
            set
            {
                _Medidas = value;
            }
        }

        public List<double> FrecRadianes
        {
            get
            {
                return _FrecRad;
            }
            set
            {
                _FrecRad = value;
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

        #endregion

        #region propiedades

        public EntradaSenoidalOrden2()
        {
            id = id++;
        }

        public int pId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Image Formula
        {
            get
            {
                return _formula;
            }
        }

        #endregion

        /// <summary>
        /// Determina el paso entre puntos dependiente de la frecuencia
        /// </summary>
        /// <returns>Devuelve el paso entre puntos</returns>
        private double getPasoEntrePuntos()
        {
            //parámetros para establecer el pasoentrepuntos dependiente de la frecuencia
            double expPaso = 0, basePaso = 10, valorIni = 15, valorLimInf = 0, valorLimSup = 0;
            double paso = 0.01;

            //calculamos el límite superior
            valorLimSup = valorIni * Math.Pow(basePaso, expPaso);
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

        //retorna lista de puntos para calcular la grafica
        public List<PointPairList> generarPuntos(double[] parametros)
        {
            Titulos.Clear();

            this.amplitud = parametros[1];
            this.cteTiempo = parametros[3];
            this.coefAmort = parametros[4];
            this.frecuencia = parametros[2];
            this.valorBase = parametros[0];
            this.omega = frecuencia; //* 2 * Math.PI ---> En realidad lo que se ingresa es omega

            List<PointPairList> listas = new List<PointPairList>();

            for (int x = 0; x < 10; x += 1)
            {
                listas.Add(new PointPairList());
            }
            for (int x = 3; x < 8; x++)
                listas[x] = null;

            //Se determina el paso entre puntos dependiendo de la frecuencia
            pasoentrepuntos = getPasoEntrePuntos();

            #region Caso 1, coefAmort < 1
            
            if (this.coefAmort < 1)
            {
                double y = Math.Round(this.amplitud / Math.Sqrt(Math.Pow(1 - Math.Pow(this.omega * this.cteTiempo, 2), 2) + Math.Pow(2 * this.coefAmort * this.omega * this.cteTiempo, 2)), 4);
                double theta = Math.Round((-Math.Atan2((2 * coefAmort * cteTiempo * omega), (1 - Math.Pow(cteTiempo * omega, 2)))) * 360 / (2 * Math.PI), 2);

                //Asigno los titulos
                Titulos.Add("Salida senoidal " + y.ToString() + "sen(" + this.omega.ToString() + "t " + theta.ToString() + "º)");
                Titulos.Add("Entrada Senoidal " + this.amplitud + "sen" + this.frecuencia + "t");
                Titulos.Add("Valor Base");
                for (int i = 0; i < 5; i++)
                    Titulos.Add(null);
                Titulos.Add("Período");
                Titulos.Add("Retardo de Fase");

                double parteA = Math.Pow((1 - (omega * omega * cteTiempo * cteTiempo)), 2);
                double parteB = Math.Pow(2 * coefAmort * omega * cteTiempo, 2);
                //double arctan = -1*Math.Atan(((2 * coefAmort * omega * cteTiempo)) / (1 - Math.Pow((cteTiempo * omega), 2)));
                double arctan = -Math.Atan2((2 * coefAmort * cteTiempo * omega), (1 - Math.Pow(cteTiempo * omega, 2)));
                double radicando = (Math.Pow(1 - Math.Pow(cteTiempo * omega, 2), 2) + Math.Pow(2 * coefAmort * cteTiempo * omega, 2));
                double raizInferior = Math.Sqrt(radicando);

                double seno;

                for (double t = 0; t <= limiteEjeX() * 20; t = t + pasoentrepuntos)
                {
                    seno = Math.Sin((omega * t) + arctan);

                    listas[0].Add(t, valorBase + (seno / raizInferior) * amplitud);

                    listas[1].Add(t, valorBase + (amplitud * Math.Sin(omega * t)));

                    listas[2].Add(t, valorBase);
                }
            }

            #endregion

            #region Caso 2, coefAmort = 1
            
            if (this.coefAmort == 1)
            {
                double y = Math.Round(this.amplitud / (1 + Math.Pow(this.omega * this.cteTiempo, 2)), 4);
                double theta = Math.Round(Math.Atan2(-2 * omega * cteTiempo, 1 - Math.Pow(cteTiempo * omega, 2)) * 360 / (2 * Math.PI), 2);

                //Asigno los titulos
                Titulos.Add("Salida senoidal " + y.ToString() + "sen(" + this.omega.ToString() + "t " + theta.ToString() + "º)");
                Titulos.Add("Entrada Senoidal " + this.amplitud + "sen" + this.frecuencia + "t");
                Titulos.Add("Valor Base");
                for (int i = 0; i < 5; i++)
                    Titulos.Add(null);
                Titulos.Add("Período");
                Titulos.Add("Retardo de Fase");

                double arctan = Math.Atan2(-2 * omega * cteTiempo, 1 - Math.Pow(cteTiempo * omega, 2));
                double coeficiente = this.amplitud / (1 + Math.Pow(this.omega * this.cteTiempo, 2));
                
                double seno;

                for (double t = 0; t <= limiteEjeX() * 20; t = t + pasoentrepuntos)
                {
                    seno = Math.Sin((omega * t) + arctan);

                    listas[0].Add(t, valorBase + coeficiente * seno);

                    listas[1].Add(t, valorBase + (amplitud * Math.Sin(omega * t)));

                    listas[2].Add(t, valorBase);
                }
            }

            #endregion

            #region Caso 3, coefAmort > 1
            
            if (this.coefAmort > 1)
            {
                double tau1 = cteTiempo / (this.coefAmort - Math.Sqrt(this.coefAmort * this.coefAmort - 1));
                double tau2 = cteTiempo / (this.coefAmort + Math.Sqrt(this.coefAmort * this.coefAmort - 1));
                
                double y = Math.Round(this.amplitud / (Math.Sqrt(1 + Math.Pow(omega * tau1, 2)) * Math.Sqrt(1 + Math.Pow(omega * tau2, 2))), 4);
                double theta = Math.Round((Math.Atan(-omega * tau1) + Math.Atan(-omega * tau2)) * 360 / (2 * Math.PI), 2);

                //Asigno los titulos
                Titulos.Add("Salida senoidal " + y.ToString() + "sen(" + this.omega.ToString() + "t " + theta.ToString() + "º)");
                Titulos.Add("Entrada Senoidal " + this.amplitud + "sen" + this.frecuencia + "t");
                Titulos.Add("Valor Base");
                for (int i = 0; i < 5; i++)
                    Titulos.Add(null);
                Titulos.Add("Período");
                Titulos.Add("Retardo de Fase");

                double arctan = Math.Atan(-omega * tau1) + Math.Atan(-omega * tau2);
                double coeficiente = this.amplitud / (Math.Sqrt(1 + Math.Pow(omega * tau1, 2)) * Math.Sqrt(1 + Math.Pow(omega * tau2, 2)));

                double seno;

                for (double t = 0; t <= limiteEjeX() * 20; t = t + pasoentrepuntos)
                {
                    seno = Math.Sin((omega * t) + arctan);

                    listas[0].Add(t, valorBase + coeficiente * seno);

                    listas[1].Add(t, valorBase + (amplitud * Math.Sin(omega * t)));

                    listas[2].Add(t, valorBase);
                }
            }

            #endregion

            for (int i = 1; i < listas[0].Count - 1; i++)
            {
                if (listas[0][i].Y > listas[0][i - 1].Y && listas[0][i].Y > listas[0][i + 1].Y)
                {
                    ampSalida = listas[0][i].Y;
                    break;
                }
            }

            for (int i = 1; i < listas[1].Count - 1; i++)
            {
                if (listas[1][i].Y > listas[1][i - 1].Y && listas[1][i].Y > listas[1][i + 1].Y)
                {
                    ampEntrada = listas[1][i].Y;
                    break;
                }
            }

            //Maximo y minimo valor de la salida
            
            for (int i = 1; i < listas[1].Count - 1; i++)
            {
                if (listas[0][i].Y > listas[0][i - 1].Y && listas[0][i].Y > listas[0][i + 1].Y)
                {
                    //Maximo valor
                    maxSalida = listas[0][i].Y;
                    tMaxSalida = listas[0][i].X;
                    break;
                }
            }

            for (int i = 1; i < listas[1].Count - 1; i++)
            {
                if (listas[0][i].Y < listas[0][i - 1].Y && listas[0][i].Y < listas[0][i + 1].Y)
                {
                    //Minimo valor
                    minSalida = listas[0][i].Y;
                    break;
                }
            }

            //Calculo la cantidad de picos de la entrada
            double altura = 0;
            int cantCumbres = 0;
            for (int i = 1; i < listas[1].Count - 2; i++)
            {
                if (listas[1][i].Y > listas[1][i - 1].Y && listas[1][i].Y > listas[1][i + 1].Y)
                {
                    cantCumbres++;
                }

                if (cantCumbres == 3)
                {
                    //Calculo Período
                    double periodo = Math.Round(2 * Math.PI / this.frecuencia, 2);
                    listas[8].Add((listas[1][i].X - periodo), listas[1][i].Y);
                    listas[8].Add(listas[1][i].X, listas[1][i].Y);
                    //retardo de fase (gráficamente una cota)
                    altura = (valorBase + amplitud);
                    listas[9].Add(listas[1][i].X, altura * 1.001);
                    listas[9].Add(listas[1][i].X, altura * 0.999);
                    listas[9].Add(listas[1][i].X, altura);
                    break;
                }
            }

            //Calculo la cantidad de picos de la salida
            // Usando la salida simplificada.
            int cantCumbresSalida = 0;
            for (int i = 1; i < listas[0].Count - 2; i++)
            {
                if (listas[0][i].Y > listas[0][i - 1].Y && listas[0][i].Y > listas[0][i + 1].Y)
                {
                    cantCumbresSalida++;
                }

                if (cantCumbresSalida == 3)
                {
                    //retardo de fase (gráficamente una cota)
                    listas[9].Add(listas[0][i].X, altura);
                    listas[9].Add(listas[0][i].X, altura * 1.001);
                    listas[9].Add(listas[0][i].X, altura * 0.999);
                    break;
                }
            }


            frecuenciaRadianes();
            frecuenciaGrados();
            medidasDesemp();

            //Establecemos los limites del eje Y
            if (maxSalida > (valorBase + amplitud))
                _FinEjeY = maxSalida + (maxSalida - valorBase)*0.1;
            else
                _FinEjeY = valorBase + amplitud * 1.1;

            if (minSalida < (valorBase-amplitud))
                if(minSalida >= 0)
                    _InicioEjeY = minSalida - (valorBase - minSalida)* 0.1;
                else
                    _InicioEjeY = minSalida * 1.1;
            else
                _InicioEjeY = valorBase - amplitud * 1.1;


            return listas;

        }

        public String getNombre()
        {
            return (this.GetType().Name + id);
        }

        public double limiteEjeX()
        {

            double aux = 0;

            aux = 6 * (1 / frecuencia);

            return aux;
        }

        // #region medidas de rendimiento
        // public double[] medidasRendimiento(double[] parametros)
        // {
        //     double[] medidasDeDesempe = new double[11];

        //     double valorPerOs = (2 * Math.PI) / parametros[3];
        //     medidasDeDesempe[4] = valorPerOs;

        //     double maxValorSalida = parametros[5] + (parametros[0] / ((Math.Pow(parametros[1], 2) * Math.Pow(parametros[3], 2)) + 1));
        //     medidasDeDesempe[5] = maxValorSalida;

        //en radianes
        //     double retardo = -Math.Atan2((2 * parametros[2] * parametros[1] * parametros[3]), (1 - Math.Pow(parametros[1] * parametros[3], 2)));
        //     medidasDeDesempe[6] = retardo;

        //en grados
        //     medidasDeDesempe[7] = Math.Round(retardo * 360 / (2 * Math.PI), 5);

        //     return medidasDeDesempe;
        // }

        // #endregion

        //calcula las medidas de rendimiento
         #region medidas de rendimiento
        
         public void medidasDesemp()
         {
             //List<Nullable<double>> medidasDeDesempe = new List<Nullable<double>>();

             //for (int x = 0; x <= 10; x += 1)
             //{
             //    medidasDeDesempe.Add(new double());
             //}

             Medidas.Clear();
             Medidas.Add(null);
             Medidas.Add(null);
             Medidas.Add(null);
             Medidas.Add(null);
             Medidas.Add(null);
             //Periodo de oscilacion
             Medidas.Add((2 * Math.PI) / omega);
             //retardo en tiempo
             Medidas.Add(null); //asigno null y abajo lo agrego en la posicion 6 de la lista de medidas

             #region Caso 1, coefAmort < 1
             if (this.coefAmort < 1)
             {
                 //retardo en radianes
                 Medidas.Add(-Math.Atan2((2 * coefAmort * cteTiempo * omega), (1 - Math.Pow(cteTiempo * omega, 2))));
                 //retardo en grados
                 Medidas.Add(Math.Round((-Math.Atan2((2 * coefAmort * cteTiempo * omega), (1 - Math.Pow(cteTiempo * omega, 2)))) * 360 / (2 * Math.PI), 5));
                 //AR: relacion de amplitud
                 //Medidas.Add(ampSalida / ampEntrada);
                 Medidas.Add(1 / Math.Sqrt(Math.Pow(1 - Math.Pow(this.frecuencia * this.cteTiempo, 2), 2) + Math.Pow(2 * this.coefAmort * this.frecuencia * this.cteTiempo, 2)));
             }

             #endregion

             #region Caso 2, coefAmort = 1
             if (this.coefAmort == 1)
             {
                 //retardo en radianes
                 Medidas.Add(Math.Atan2(-2 * omega * cteTiempo, 1 - Math.Pow(cteTiempo * omega, 2)));
                 //retardo en grados
                 Medidas.Add(Math.Round((Math.Atan2(-2 * omega * cteTiempo, 1 - Math.Pow(cteTiempo * omega, 2))) * 360 / (2 * Math.PI), 5));
                 //AR: relacion de amplitud
                 //Medidas.Add(ampSalida / ampEntrada);
                 Medidas.Add(1 / (1 + Math.Pow(this.omega * this.cteTiempo, 2)));
             }

             #endregion

             #region Caso 3, coefAmort > 1
             if (this.coefAmort > 1)
             {
                 double tau1 = cteTiempo / (this.coefAmort - Math.Sqrt(this.coefAmort * this.coefAmort - 1));
                 double tau2 = cteTiempo / (this.coefAmort + Math.Sqrt(this.coefAmort * this.coefAmort - 1));
                 
                 //retardo en radianes
                 Medidas.Add(Math.Atan(-omega * tau1) + Math.Atan(-omega * tau2));
                 //retardo en grados
                 Medidas.Add(Math.Round((Math.Atan(-omega * tau1) + Math.Atan(-omega * tau2)) * 360 / (2 * Math.PI), 5));
                 //AR: relacion de amplitud
                 //Medidas.Add(ampSalida / ampEntrada);
                 Medidas.Add(1 / (Math.Sqrt(1 + Math.Pow(omega * tau1, 2)) * Math.Sqrt(1 + Math.Pow(omega * tau2, 2))));
             }

             #endregion

             Medidas.Add(null);

             double maximoEntrada;
             double tMaxEntrada; //contiene el valor de t correspondiente al pico max de la entrada
             if (frecuencia == 1)
             {
                 maximoEntrada = valorBase + amplitud * Math.Sin(Math.PI / 2);
                 tMaxEntrada = Math.PI / 2;
             }
             else
             {
                 double variable = 90 / frecuencia;
                 double radianes = (frecuencia * variable * (Math.PI / 2)) / 90;
                 maximoEntrada = valorBase + amplitud * Math.Sin(radianes);
                 tMaxEntrada = radianes / frecuencia;
             }

             double minimoEntrada;
             if (frecuencia == 1)
             {
                 minimoEntrada = valorBase - amplitud * Math.Sin(Math.PI / 2);
             }
             else
             {
                 double variable = 90 / frecuencia;
                 double radianes = (frecuencia * variable * (Math.PI / 2)) / 90;
                 minimoEntrada = valorBase - amplitud * Math.Sin(radianes);
             }

             Medidas.Add(maxSalida);
             Medidas.Add(maximoEntrada);
             Medidas.Add(minSalida);
             Medidas.Add(minimoEntrada);

             Medidas[6] = tMaxSalida - tMaxEntrada;

             Medidas.Add(null); 


             
             //return medidasDeDesempe;
         }
         #endregion
         
        //devuelve los calculos de las frecuencias, en radianes y grados, variando omega
        #region frecuencia
        public void frecuenciaRadianes()
        {
            //double[] frecRad = new double[7];
            FrecRadianes.Clear();
            
            #region Caso 1, coefAmort < 1
            if (this.coefAmort < 1)
            {
                FrecRadianes.Add(-Math.Atan2((2 * coefAmort * cteTiempo * 0), (1 - Math.Pow(cteTiempo * 0, 2))));
                FrecRadianes.Add(-Math.Atan2((2 * coefAmort * cteTiempo * 1), (1 - Math.Pow(cteTiempo * 1, 2))));
                FrecRadianes.Add(-Math.Atan2((2 * coefAmort * cteTiempo * 2), (1 - Math.Pow(cteTiempo * 2, 2))));
                FrecRadianes.Add(-Math.Atan2((2 * coefAmort * cteTiempo * 10), (1 - Math.Pow(cteTiempo * 10, 2))));
                FrecRadianes.Add(-Math.Atan2((2 * coefAmort * cteTiempo * 100), (1 - Math.Pow(cteTiempo * 100, 2))));
                FrecRadianes.Add(-Math.Atan2((2 * coefAmort * cteTiempo * 1000), (1 - Math.Pow(cteTiempo * 1000, 2))));

                //return frecRad; 
            }

             #endregion

            #region Caso 2, coefAmort = 1
            if (this.coefAmort == 1)
            {
                FrecRadianes.Add(Math.Atan2(-2 * cteTiempo * 0, 1 - Math.Pow(cteTiempo * 0, 2)));
                FrecRadianes.Add(Math.Atan2(-2 * cteTiempo * 1, 1 - Math.Pow(cteTiempo * 1, 2)));
                FrecRadianes.Add(Math.Atan2(-2 * cteTiempo * 2, 1 - Math.Pow(cteTiempo * 2, 2)));
                FrecRadianes.Add(Math.Atan2(-2 * cteTiempo * 10, 1 - Math.Pow(cteTiempo * 10, 2)));
                FrecRadianes.Add(Math.Atan2(-2 * cteTiempo * 100, 1 - Math.Pow(cteTiempo * 100, 2)));
                FrecRadianes.Add(Math.Atan2(-2 * cteTiempo * 1000, 1 - Math.Pow(cteTiempo * 1000, 2)));
            }

            #endregion

            #region Caso 3, coefAmort > 1
            if (this.coefAmort > 1)
            {
                double tau1 = cteTiempo / (this.coefAmort - Math.Sqrt(this.coefAmort * this.coefAmort - 1));
                double tau2 = cteTiempo / (this.coefAmort + Math.Sqrt(this.coefAmort * this.coefAmort - 1));

                FrecRadianes.Add(Math.Atan(-0 * tau1) + Math.Atan(-0 * tau2));
                FrecRadianes.Add(Math.Atan(-1 * tau1) + Math.Atan(-1 * tau2));
                FrecRadianes.Add(Math.Atan(-2 * tau1) + Math.Atan(-2 * tau2));
                FrecRadianes.Add(Math.Atan(-10 * tau1) + Math.Atan(-10 * tau2));
                FrecRadianes.Add(Math.Atan(-100 * tau1) + Math.Atan(-100 * tau2));
                FrecRadianes.Add(Math.Atan(-1000 * tau1) + Math.Atan(-1000 * tau2));
            }

            #endregion
        }

        public void frecuenciaGrados()
        {
            //double[] frecGrad = new double[7];
            double grado = 360 / (2 * Math.PI);
            FrecGrados.Clear();
            
            #region Caso 1, coefAmort < 1
            if (this.coefAmort <1 )
            {
                FrecGrados.Add(grado * (-Math.Atan2((2 * coefAmort * cteTiempo * 0), (1 - Math.Pow(cteTiempo * 0, 2)))));
                FrecGrados.Add(grado * (-Math.Atan2((2 * coefAmort * cteTiempo * 1), (1 - Math.Pow(cteTiempo * 1, 2)))));
                FrecGrados.Add(grado * (-Math.Atan2((2 * coefAmort * cteTiempo * 2), (1 - Math.Pow(cteTiempo * 2, 2)))));
                FrecGrados.Add(grado * (-Math.Atan2((2 * coefAmort * cteTiempo * 10), (1 - Math.Pow(cteTiempo * 10, 2)))));
                FrecGrados.Add(grado * (-Math.Atan2((2 * coefAmort * cteTiempo * 100), (1 - Math.Pow(cteTiempo * 100, 2)))));
                FrecGrados.Add(grado * (-Math.Atan2((2 * coefAmort * cteTiempo * 1000), (1 - Math.Pow(cteTiempo * 1000, 2)))));

                //return frecGrad; 
            }

            #endregion

            #region Caso 2, coefAmort = 1
            if (this.coefAmort == 1)
            {
                FrecGrados.Add(grado * Math.Atan2(-2 * cteTiempo * 0, 1 - Math.Pow(cteTiempo * 0, 2)));
                FrecGrados.Add(grado * Math.Atan2(-2 * cteTiempo * 1, 1 - Math.Pow(cteTiempo * 1, 2)));
                FrecGrados.Add(grado * Math.Atan2(-2 * cteTiempo * 2, 1 - Math.Pow(cteTiempo * 2, 2)));
                FrecGrados.Add(grado * Math.Atan2(-2 * cteTiempo * 10, 1 - Math.Pow(cteTiempo * 10, 2)));
                FrecGrados.Add(grado * Math.Atan2(-2 * cteTiempo * 100, 1 - Math.Pow(cteTiempo * 100, 2)));
                FrecGrados.Add(grado * Math.Atan2(-2 * cteTiempo * 1000, 1 - Math.Pow(cteTiempo * 1000, 2)));
            }

            #endregion

            #region Caso 3, coefAmort > 1
            if (this.coefAmort > 1)
            {
                double tau1 = cteTiempo / (this.coefAmort - Math.Sqrt(this.coefAmort * this.coefAmort - 1));
                double tau2 = cteTiempo / (this.coefAmort + Math.Sqrt(this.coefAmort * this.coefAmort - 1));

                FrecGrados.Add(grado * (Math.Atan(-0 * tau1) + Math.Atan(-0 * tau2)));
                FrecGrados.Add(grado * (Math.Atan(-1 * tau1) + Math.Atan(-1 * tau2)));
                FrecGrados.Add(grado * (Math.Atan(-2 * tau1) + Math.Atan(-2 * tau2)));
                FrecGrados.Add(grado * (Math.Atan(-10 * tau1) + Math.Atan(-10 * tau2)));
                FrecGrados.Add(grado * (Math.Atan(-100 * tau1) + Math.Atan(-100 * tau2)));
                FrecGrados.Add(grado * (Math.Atan(-1000 * tau1) + Math.Atan(-1000 * tau2)));
            }

            #endregion
        }

        #endregion

        //devuelve un arreglo con los nombres de las variables necesarias para la función
        public string[] variables()
        {
            string[] aux = new string[6];

            aux[0] = "Amplitud";
            aux[1] = "Cte. Tiempo";
            aux[2] = "Coef. Amort";
            aux[3] = "Omega";
            aux[4] = "Frecuencia";
            aux[5] = "Valor Base";

            return aux;
        }
    }
}
