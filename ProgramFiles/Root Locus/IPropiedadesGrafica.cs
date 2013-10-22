using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Root_Locus
{
    public interface IPropiedadesGrafica
    {
        #region Datos fijos

        String Titulo
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

        bool LogEjeX
        {
            //establece si la escala del eje X es logaritmica
            get;
            set;
        }

        bool LogEjeY
        {
            //establece si la escala del eje Y es logaritmica
            get;
            set;
        }

        String[] NombreParametros
        {
            //devuelve un arreglo con los nombres de los parametros necesarios para generar la grafica
            //los nombres de los parametros se mostraran en la tabla para ingresar los datos
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

        #endregion
    }
}