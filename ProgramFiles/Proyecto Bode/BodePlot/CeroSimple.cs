using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class CeroSimple
    {
        /// <summary>
        /// Calcula la magnitud de una función de tipo Cero Simple.
        /// </summary>
        /// <param name="T">Constante de tiempo del Cero Simple.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Magnitud del Cero Simple, en db.</returns>
        public double magnitud(double T, double w)
        {
            return 20 * Math.Log10(Math.Sqrt(1 + w * w * T * T));
        }

        /// <summary>
        /// Calcula la fase de una función de tipo Cero Simple.
        /// </summary>
        /// <param name="T">Constante de tiempo del Cero Simple.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Fase del Cero Simple, en grados.</returns>
        public double fase(double T, double w)
        {
            return Math.Atan(w * T) * (180 / Math.PI);
        }

        /// <summary>
        /// Calcula el punto de corte de una función de tipo Cero en el Origen.
        /// </summary>
        /// <param name="T">Constante de tiempo del Cero Simple.</param>
        /// <returns>Punto de corte del Cero Simple.</returns>
        public double[] puntoCorte(double T)
        {
            return new double[] { 1 / T, 0 };
        }
    }
}
