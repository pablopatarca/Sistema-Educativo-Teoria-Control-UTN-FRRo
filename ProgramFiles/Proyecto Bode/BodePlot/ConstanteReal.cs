using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class ConstanteReal
    {
        /// <summary>
        /// Calcula la magnitud de una función de tipo Constante Real.
        /// </summary>
        /// <param name="k">Constante real.</param>
        /// <returns>Magnitud de la Constante Real, en db.</returns>
        public double magnitud(double k)
        {
            return 20.0 * Math.Log10(k);
        }

        /// <summary>
        /// Calcula la fase de una función de tipo Constante Real.
        /// </summary>
        /// <returns>Fase de la Constante Real, en grados.</returns>
        public double fase()
        {
            return 0.0;
        }
    }
}
