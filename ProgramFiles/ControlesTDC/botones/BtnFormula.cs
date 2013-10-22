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
    public partial class BtnFormula : BtnBase
    {
        public BtnFormula(): base()
        {
            Image = Recursos.formula;
            establecerToolTip("Valores");
        }
    }
}
