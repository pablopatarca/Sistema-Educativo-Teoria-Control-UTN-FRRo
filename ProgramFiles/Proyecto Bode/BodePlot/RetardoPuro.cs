using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class RetardoPuro
    {
        /// <summary>
        /// Calcula la magnitud de una función de tipo Retardo Puro.
        /// </summary>
        /// <returns>Magnitud del Retardo Puro, en db.</returns>
        public double magnitud()
        {
            return 0.0;
        }

        /// <summary>
        /// Calcula la fase de una función de tipo Retardo Puro.
        /// </summary>
        /// <param name="Td">Retardo de tiempo.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Fase del Retardo Puro, en grados.</returns>
        public double fase(double Td, double w)
        {
            return -w * Td * (180 / Math.PI);
        }
    }
}
