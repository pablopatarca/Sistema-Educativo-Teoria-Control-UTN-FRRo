﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class BtnLimpiar : BtnBase
    {
        public BtnLimpiar(): base()
        {
            Image = Recursos.limpiar;
            establecerToolTip("Limpiar");
        }
    }
}
