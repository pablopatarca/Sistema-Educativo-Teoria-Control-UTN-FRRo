using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class BtnEjemplos : BtnBase
    {
        public BtnEjemplos(): base()
        {
            Image = Recursos.ejemplos;
            establecerToolTip("Ejemplos...");
        }
    }
}
