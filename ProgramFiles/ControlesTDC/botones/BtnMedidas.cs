using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles.botones
{
    public partial class BtnMedidas : BtnBase
    {
        public BtnMedidas(): base()
        {
            Image = Recursos.medidas;
            establecerToolTip("Medidas...");
        }
    }
}
