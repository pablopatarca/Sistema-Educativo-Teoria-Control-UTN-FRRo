using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FormularioSplash;
using System.Threading;
using System.Globalization;

namespace FormularioPrincipal
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}
