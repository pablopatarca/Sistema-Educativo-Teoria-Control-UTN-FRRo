using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Controles.textboxes
{
    public partial class TxtDoubleValorAbsoluto : TxtBase
    {
        public TxtDoubleValorAbsoluto(): base()
        {
            ExpresionRegular = "^(0|[1-9][0-9]*)("
                             + Regex.Escape(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator)
                             + "[0-9]*[1-9])?$";
        }
    }
}
