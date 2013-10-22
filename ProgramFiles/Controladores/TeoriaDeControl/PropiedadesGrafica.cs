using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeoriaDeControl
{
    interface PropiedadesGrafica
    {

        //DATOS FIJOS

        public String titulo;
        public String Titulo
        {
            //devuelve el titulo de la grafica

        }

        public String nombreEjeX;
        public String NombreEjeX
        {
            //devuelve el nombre a rotular en el eje X

        }

        public String nombreEjeY;
        public String NombreEjeY
        {
            //devuelve el nombre a rotular en el eje y
        }

        public bool logEjeX;
        public bool LogEjeX
        {
            //establece si la escala del eje X es logaritmica
        }

        public bool logEjeX;
        public bool LogEjeX
        {
            //establece si la escala del eje Y es logaritmica
        }

        public String[] nombreParametros;
        public String[] NombreParametros
        {
            //devuelve un arreglo con los nombres de los parametros necesarios para generar la grafica
            //los nombres de los parametros se mostraran en la tabla para ingresar los datos
        }




        //DATOS CALCULADOS
        //los siguientes son datos que obtendran luego de generar la serie de puntos

        public double inicioEjeX;
        public double InicioEjeX
        {
            //determina el valor de inicio del eje X

        }

        public double inicioEjeY;
        public double InicioEjeY
        {
            //determina el valor de inicio del eje Y

        }

        public double finEjeX;
        public double FinEjeX
        {
            //determina el ultimo valor que mostrara el eje X

        }

        public double finEjeY;
        public double FinEjeY
        {
            //determina el ultimo valor que mostrara el eje Y

        }

        
    }
}
