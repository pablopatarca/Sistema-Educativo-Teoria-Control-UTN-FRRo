using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class PoloSimple
    {
        /// <summary>
        /// Calcula la magnitud de una función de tipo Polo Simple.
        /// </summary>
        /// <param name="T">Constante de tiempo del Polo Simple.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Magnitud del Polo Simple, en db.</returns>
        public double magnitud(double T, double w)
        {
            return -20 * Math.Log10(Math.Sqrt(1 + w * w * T * T));
        }

        /// <summary>
        /// Calcula la fase de una función de tipo Polo Simple.
        /// </summary>
        /// <param name="T">Constante de tiempo del Polo Simple.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Fase del Polo Simple, en grados.</returns>
        public double fase(double T, double w)
        {
            return -Math.Atan(w * T) * (180 / Math.PI);
        }

        /// <summary>
        /// Calcula el punto de corte de una función de tipo Polo Simple.
        /// </summary>
        /// <param name="T">Constante de tiempo del Polo Simple.</param>
        /// <returns>Punto de corte del Polo Simple.</returns>
        public double[] puntoCorte(double T)
        {
            return new double[] { 1 / T, 0 };
        }
    }
}
