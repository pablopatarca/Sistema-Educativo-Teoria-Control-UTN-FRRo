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
    public partial class BtnRepetirUltimaFila : BtnBase
    {
        public BtnRepetirUltimaFila()
            : base()
        {
            Image = Recursos.repetir_ultima_fila;
            establecerToolTip("Repetir última fila");
        }
    }
}
