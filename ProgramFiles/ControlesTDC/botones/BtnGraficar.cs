using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Controles
{
    public partial class BtnGraficar : BtnBase
    {
        public BtnGraficar(): base()
        {
            Image = Recursos.graficar;
            establecerToolTip("Graficar");
        }
    }
}
