using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace TeoriaDeControl
{
    public interface IPropiedadesGrafica
    {
        #region Datos fijos

        List<string> Titulos
        {
            //devuelve el titulo de la grafica
            get;
            set;
        }

        String NombreEjeX
        {
            //devuelve el nombre a rotular en el eje X
            get;
            set;
        }

        String NombreEjeY
        {
            //devuelve el nombre a rotular en el eje y
            get;
            set;
        }

        String[] NombreParametros
        {
            //devuelve un arreglo con los nombres de los parametros necesarios para generar la grafica
            //los nombres de los parametros se mostraran en la tabla para ingresar los datos
            //ORDEN DE LOS PARAMETROS
            //parametros[0] = Amplitud
            //parametros[1] = Cte. Tiempo;
            //parametros[2] = Coef. Amort;
            //parametros[3] = Frecuencia;
            //parametros[4] = Valor Base;
            //parametros[5] = valorPorcentTA;

            get;
            set;
        }

        String[] Botones
        {
            get;
            set;
        }

        #endregion

        #region Datos calculados

        //los siguientes son datos que obtendran luego de generar la serie de puntos

        double InicioEjeX
        {
            //determina el valor de inicio del eje X
            get;
            set;
        }

        double InicioEjeY
        {
            //determina el valor de inicio del eje Y
            get;
            set;
        }

        double FinEjeX
        {
            //determina el ultimo valor que mostrara el eje X
            get;
            set;
        }

        double FinEjeY
        {
            //determina el ultimo valor que mostrara el eje Y
            get;
            set;
        }

        List<Nullable<double>> Medidas
        {
            //Devuelve las medidas de desempeño
            //Medidas[0] = valor del OVERSHOOT
            //Medidas[1] = valor de la RAZON DE CAIDA
            //Medidas[2] = valor del TIEMPO DE SUBIDA
            //Medidas[3] = valor del TIEMPO DE ASENTAMIENTO
            //Medidas[4] = valor del PERIODO DE OSCILACION
            //Medidas[5] = valor del DESPLAZAMIENTO en radianes (solamente para el seno)
            //Medidas[6] = valor del PERIODO (solamente para el seno)


            get;
            set;
        }

        //indica la amortiguación de la gráfica si es que tiene
        String Amortiguacion { get;}

        //indica la formula de la entrada, la imagen que se muestra a la derecha
        Image Formula { get; }

        #endregion

        List<PointPairList> generarPuntos(double[] parametros);
    }
}