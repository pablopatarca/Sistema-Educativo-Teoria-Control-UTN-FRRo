using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class Curva
    {
        /// <summary>
        /// Nombre de la curva, por ejemplo "Cero en el origen".
        /// </summary>
        public string _Nombre;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        /// <summary>
        /// Lista de puntos que conforman la curva de magnitud.
        /// </summary>
        private List<double[]> _PuntosMagnitud;
        public List<double[]> PuntosMagnitud
        {
            get
            {
                return _PuntosMagnitud;
            }
            set
            {
                _PuntosMagnitud = value;
            }
        }

        /// <summary>
        /// Lista de puntos que conforman la curva de fase.
        /// </summary>
        private List<double[]> _PuntosFase;
        public List<double[]> PuntosFase
        {
            get
            {
                return _PuntosFase;
            }
            set
            {
                _PuntosFase = value;
            }
        }

        /// <summary>
        /// Coordenadas del punto de corte.
        /// </summary>
        private double[] _PuntoCorte;
        public double[] PuntoCorte
        {
            get
            {
                return _PuntoCorte;
            }
            set
            {
                _PuntoCorte = value;
            }
        }
    }
}
