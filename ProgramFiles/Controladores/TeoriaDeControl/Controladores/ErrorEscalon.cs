using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Controladores
{
    class ErrorEscalon : IPropiedadesGrafica
    {

        double l_fin_eje_y;

        #region Datos Fijos

        public string Titulo
        {
            get
            {
                return "Error Escalón";
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
                return "e(t)";
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
                string[] parametros = new string[1];
                parametros[0] = "Amplitud";

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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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


        public List<ZedGraph.PointPairList> generarPuntos(double[] parametros)
        {

            double amplitud, x, y;

            List<PointPairList> curvas = new List<PointPairList> ();
            PointPairList datos = new PointPairList();
            PointPairList eje_y = new PointPairList();

            amplitud = parametros[1];
            y = amplitud;


            //agrego los puntos en t<0
            datos.Add(-40, 0);
            datos.Add(0, 0);
            datos.Add(0, amplitud);

            //calculo los puntos de la grafica
            for (double i = 0; i <= 40; i++)
            {
                x = i;
                datos.Add(x, y);
            }

            //creo el eje Y y defino el limite
            l_fin_eje_y = y + 4;
            eje_y.Add(0, 0);
            eje_y.Add(0, l_fin_eje_y + 100);

            curvas.Add(datos);
            curvas.Add(eje_y);


            return curvas;

        }



        public List<string> Titulos
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

        public string[] Botones
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

        List<double?> IPropiedadesGrafica.Medidas
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
    }
}

    