using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Controladores
{
    public class ProporcionalDerivativo:IPropiedadesGrafica
    {

        private double l_fin_eje_x, l_fin_eje_y;


        #region Datos Fijos

        public string Titulo
        {
            get
            {
                return "Controlador Proporcional Derivativo";
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
                return "t";
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
                return "p(t)";
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
                string[] parametros = {"Error", "Amplitud", "Ganancia", "T. Derivativo", "ps" };

                return parametros;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        #endregion


        #region Datos Calculados

        public double InicioEjeX
        {
            get
            {
                return (-0.2) * l_fin_eje_x;
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
                return -2;
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
                return l_fin_eje_x;
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
                return l_fin_eje_y;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<double> Medidas
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion


        public List<PointPairList> generarPuntos(double[] parametros)
        {

            int error;
            double kc, tau_d, ps, amplitud, x, y=0;

            error = (int)parametros[0];
            amplitud = parametros[1];
            kc = parametros[2];
            tau_d = parametros[3];
            ps = parametros[4];


            List<PointPairList> curvas = new List<PointPairList>();
            PointPairList datos = new PointPairList();
            PointPairList eje_y = new PointPairList();


            //agrego los puntos en t<0
            datos.Add(-40, ps);
            datos.Add(0, ps);


            //calculo los puntos segun el tipo de error
            switch (error)
            {
                case 1: for (double i = 0; i <= 40; i += 0.1)
                        {
                            x = i;
                            y = kc * amplitud + ps;
                            datos.Add(x, y);
                        }
                        l_fin_eje_x = 15;
                        l_fin_eje_y = y + 4;
                        break;

                case 2: for (double i = 0; i <= 40; i += 0.1)
                        {
                            x = i;
                            y = kc * amplitud * i + kc * tau_d * amplitud + ps;
                            datos.Add(x, y);
                        }
                        l_fin_eje_x = 15;
                        l_fin_eje_y = kc * tau_d * amplitud + ps + 35;
                        break;

                case 3: for (double i = 0; i <= 40; i += 0.1)
                        {
                            x = i;
                            y = kc * amplitud * Math.Pow(i, 2) + kc * tau_d * 2 * amplitud * i + ps;
                            datos.Add(x, y);
                        }
                        l_fin_eje_x = 6;
                        l_fin_eje_y = kc * tau_d * 2 * amplitud + ps + 40;
                        break;

                default: break;
            }


            //agrego los puntos para dibujar el eje y
            eje_y.Add(0, 0);
            eje_y.Add(0, y + 100);

            curvas.Add(datos);
            curvas.Add(eje_y);

            return curvas;

        }



        public List<string> Titulos
        {
            get
            {
                List<string> lista = new List<string>();
                lista.Add("");
                lista.Add("");
                return lista;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string[] Botones
        {
            get
            {
                String[] nada = { "", "" };
                return nada;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        List<double?> IPropiedadesGrafica.Medidas
        {
            get
            {
                return new List<double?>();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
