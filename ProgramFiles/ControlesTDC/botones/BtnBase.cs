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
    public partial class BtnBase : Button
    {
        private string _TextoToolTip;
        public string TextoToolTip
        {
            get
            {
                return _TextoToolTip;
            }
            set
            {
                _TextoToolTip = value;
            }
        }

        public override string Text
        {
            get
            {
                return "";
            }
        }

        public BtnBase()
        {
            InitializeComponent();

            Width = 43;
            Height = 43;
        }

        protected void establecerToolTip(string texto)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutomaticDelay = 50;
            toolTip.AutoPopDelay = 50000;
            toolTip.InitialDelay = 50;
            toolTip.ReshowDelay = 10;
            toolTip.SetToolTip(this, texto);
        }
    }
}
