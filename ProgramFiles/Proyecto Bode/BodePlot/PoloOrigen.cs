using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class PoloOrigen
    {
        /// <summary>
        /// Calcula la magnitud de una función de tipo Polo en el Origen.
        /// </summary>
        /// <param name="n">Orden del Polo en el Origen.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Magnitud del Polo en el Origen, en db.</returns>
        public double magnitud(double n, double w)
        {
            return -20.0 * n * Math.Log10(w);
        }

        /// <summary>
        /// Calcula la fase de una función de tipo Polo en el Origen.
        /// </summary>
        /// <param name="n">Orden del Polo en el Origen.</param>
        /// <returns>Fase del Polo en el Origen, en grados.</returns>
        public double fase(double n)
        {
            if (n == 1)
            {
                return -90;
            }
            else if (n == 2)
            {
                return -180;
            }
            else
            {
                return -270;
            }
        }

        /// <summary>
        /// Calcula el punto de corte de una función de tipo Polo en el Origen.
        /// </summary>
        /// <returns>Punto de corte del Polo en el Origen.</returns>
        public double[] puntoCorte()
        {
            return new double[] { 1.0, 0.0 };
        }
    }
}
