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

namespace Controles
{
    public partial class TxtBase : TextBox
    {
        private string _ExpresionRegular;
        public string ExpresionRegular
        {
            get
            {
                return _ExpresionRegular;
            }
            set
            {
                _ExpresionRegular = value;
            }
        }

        public bool Valido
        {
            get
            {
                return Regex.IsMatch(Text, ExpresionRegular);
            }
        }

        public TxtBase()
        {
            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (Valido)
                BackColor = Color.White;
            else
                BackColor = Color.Pink;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            //Sólo permitimos valores numéricos, el retroceso y el caracter separador.
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                if (e.KeyChar.ToString() != Regex.Escape(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator) &&
                    e.KeyChar != (char) Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
