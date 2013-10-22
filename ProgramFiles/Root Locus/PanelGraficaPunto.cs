using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Root_Locus
{
    public class PanelGraficaPunto : Panel
    {
        private PointPair puntoPlano;

        public PointPair PuntoPlano
        {
            get
            {
                return puntoPlano;
            }
            set
            {
                puntoPlano = value;
            }
        }
    }
}
