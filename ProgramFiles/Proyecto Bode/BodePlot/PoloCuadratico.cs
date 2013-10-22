using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class PoloCuadratico
    {
        /// <summary>
        /// Calcula la magnitud de una función de tipo Polo Cuadrático.
        /// </summary>
        /// <param name="Wn">Frecuencia natural amortiguada.</param>
        /// <param name="psi">Coeficiente de amortiguamiento.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Magnitud del Polo Cuadrático, en db.</returns>
        public double magnitud(double Wn, double psi, double w)
        {
            return 20 * Math.Log10((Wn * Wn) / Math.Sqrt(Math.Pow(Wn * Wn - w * w, 2) + Math.Pow(2 * psi * Wn * w, 2)));
        }

        /// <summary>
        /// Calcula la fase de una función de tipo Polo Cuadrático.
        /// </summary>
        /// <param name="Wn">Frecuencia natural amortiguada.</param>
        /// <param name="psi">Coeficiente de amortiguamiento.</param>
        /// <param name="w">Frecuencia.</param>
        /// <returns>Fase del Polo Cuadrático, en grados.</returns>
        public double fase(double Wn, double psi, double w)
        {
            double fase = (180.0 * (-Math.Atan((2.0 * psi * (w / Wn)) / (1.0 - Math.Pow(w / Wn, 2))))) / Math.PI;

            if (fase < 0)
                return fase;
            else
                return fase - 180;
        }

        /// <summary>
        /// Calcula el punto de corte de una función de tipo Polo Cuadrático.
        /// </summary>
        /// <param name="Wn">Frecuencia natural amortiguada.</param>
        /// <param name="psi">Coeficiente de amortiguamiento.</param>
        /// <returns>Punto de corte del Polo Cuadrático.</returns>
        public double[] puntoCorte(double Wn, double psi)
        {
            double[] puntoCorte = new double[2];

            double abscisaPuntoCorte = Math.Sqrt(1.0 / Wn);
            puntoCorte[0] = abscisaPuntoCorte;

            double ordenadaPuntoCorte = magnitud(Wn, psi, abscisaPuntoCorte);
            puntoCorte[1] = ordenadaPuntoCorte;

            return puntoCorte;
        }
    }
}
