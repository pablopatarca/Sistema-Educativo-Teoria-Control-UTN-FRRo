using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeoriaDeControl;
using Root_Locus;
using DiagramasBode;
using FormularioSplash;
using Controladores;
using Ejemplos;
using System.Diagnostics;
using System.IO;

namespace FormularioPrincipal
{
    public partial class FormPrincipal : Form
    {
        TeoriaDeControl.Historial h;

        public FormPrincipal()
        {
            InitializeComponent();
            h = new TeoriaDeControl.Historial();

        }

        ///<summary>
        /// Executes a process and waits for it to end. 
        ///</summary>
        ///<param name="cmd">Full Path of process to execute.</param>
        ///<param name="cmdParams">Command Line params of process</param>
        ///<param name="workingDirectory">Process' working directory</param>
        ///<param name="timeout">Time to wait for process to end</param>
        ///<param name="stdOutput">Redirected standard output of process</param>
        ///<returns>Process exit code</returns>
        private int ExecuteProcess(string cmd, string cmdParams, string workingDirectory, int timeout, string stdOutput)
        {
            using (Process process = Process.Start(new ProcessStartInfo(cmd, cmdParams)))
            {
                process.StartInfo.WorkingDirectory = workingDirectory;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                stdOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit(timeout);
                return process.ExitCode;
            }
        }

        private void respuestaTransienteIni(String respuesta) {
            //Llama al formulario de respuesta transiente indicándole qué respuesta se desea ver
            frmRespuestaTransienteMain formEntradasSalidas;

            try
            {
                this.menu.Enabled = false;
                this.acercaDeToolStripMenuItem.Enabled = false;
                this.salirToolStripMenuItem.Enabled = false;

                formEntradasSalidas = new frmRespuestaTransienteMain(respuesta,h);
                formEntradasSalidas.MdiParent = this;
                formEntradasSalidas.FormClosing += new FormClosingEventHandler(form_FormClosing);
                formEntradasSalidas.Show();
            }
            catch (Exception e) {}
        }

        private void rootLocusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.métodoRootLocusToolStripMenuItem_Click();
        }

        private void métodoRootLocusToolStripMenuItem_Click()
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            FormRootLocus formRootLocus;
            formRootLocus = new FormRootLocus();
            formRootLocus.MdiParent = this;
            formRootLocus.FormClosing += new FormClosingEventHandler(form_FormClosing);
            formRootLocus.Show();
        }
        
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSplash formSplash = new FormSplash();
            formSplash.ShowDialog();
        }

        private void diagramasDeBodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.metodoDiagramasDeBodeToolStripMenuItem_Click();
        }

        private void metodoDiagramasDeBodeToolStripMenuItem_Click()
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            FrmPrincipal formBode;
            formBode = new FrmPrincipal();
            formBode.MdiParent = this;
            formBode.FormClosing += new FormClosingEventHandler(form_FormClosing);
            formBode.Show();
        }

        /// <summary>
        /// Inicializa la nueva ventana (hija) de Controlador según el tipo de controlador pasado como parámetro
        /// </summary>
        /// <param name="cont">Tipo de controlador que se selecciona dentro del Menú Controlador</param>
        private void nuevoControlador(Controladores.IPropiedadesGrafica cont)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            frmControladores formControladores;
            formControladores = new frmControladores(cont);
            formControladores.MdiParent = this;
            formControladores.FormClosing += new FormClosingEventHandler(form_FormClosing);
            formControladores.Show();
        }

        private void controladoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menu.Enabled = true;
            this.acercaDeToolStripMenuItem.Enabled = true;
            this.salirToolStripMenuItem.Enabled = true;
        }

        private void escalónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Escalon1");
        }
        
        private void impulsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Impulso1");
        }

        private void senoidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Senoidal1");
        }

        private void rampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Rampa1");
        }

        private void escalónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Escalon2");
        }

        private void impulsoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Impulso2");
        }

        private void senoidalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Senoidal2");
        }

        private void sintonizacionDeControladores_Click(object sender, EventArgs e)
        {
        var processInfo = new ProcessStartInfo("java ", "-jar SintonizacionControladoresv1.2.jar")
        {
            CreateNoWindow = true,
            UseShellExecute = false
        };

        processInfo.WorkingDirectory = Directory.GetCurrentDirectory(); // this is where your jar file is.
        Console.WriteLine(Directory.GetCurrentDirectory());

        Process proc;

        if ((proc = Process.Start(processInfo)) == null)
        {
            throw new InvalidOperationException("??");
        }

        proc.WaitForExit();
        int exitCode = proc.ExitCode;
        proc.Close();


    }

        private void rampaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            respuestaTransienteIni("Rampa2");
        }
        
        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void proporcionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoControlador(new Proporcional());
        }

        private void proporcionalDerivativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoControlador(new ProporcionalDerivativo());
        }

        private void proporcionalIntegralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoControlador(new ProporcionalIntegral());
        }

        private void proporcionalIntegralDerivativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoControlador(new ProporcionalIntegralDerivativo());
        }

        private void respuestaAUnaEntradaImpulsoUnitarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            FrmRespuestaEntradaImpulso frmRespuestaEntradaImpulso = new FrmRespuestaEntradaImpulso();
            frmRespuestaEntradaImpulso.MdiParent = this;
            frmRespuestaEntradaImpulso.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frmRespuestaEntradaImpulso.Show();
        }
        
        private void genéricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.métodoRootLocusToolStripMenuItem_Click();
        }


        private void genéricoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.metodoDiagramasDeBodeToolStripMenuItem_Click();
        }

        private void efectoDeLaAcciónDeControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            FrmPrincipalControladores frmPrincipal = new FrmPrincipalControladores();
            frmPrincipal.MdiParent = this;
            frmPrincipal.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frmPrincipal.Show();
        }

        private void conAcciónDeControladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            Root_Locus.FormRootLocusControladores diagramaBloques = new Root_Locus.FormRootLocusControladores();
            diagramaBloques.MdiParent = this;
            diagramaBloques.FormClosing += new FormClosingEventHandler(form_FormClosing);
            diagramaBloques.Show();
        }

        private void tanqueDeAguaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            Ejemplos.FrmEscalónPrimerOrdenTanqueDeAgua escalónPrimerOrden = new Ejemplos.FrmEscalónPrimerOrdenTanqueDeAgua();
            escalónPrimerOrden.MdiParent = this;
            escalónPrimerOrden.FormClosing += new FormClosingEventHandler(form_FormClosing);
            escalónPrimerOrden.Show();
        }

        private void termómetroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            Ejemplos.FrmEscalónPrimerOrdenTermómetro escalónPrimerOrden = new Ejemplos.FrmEscalónPrimerOrdenTermómetro();
            escalónPrimerOrden.MdiParent = this;
            escalónPrimerOrden.FormClosing += new FormClosingEventHandler(form_FormClosing);
            escalónPrimerOrden.Show();
        }

        private void avionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            Ejemplos.FrmEscalónSegundoOrdenAvion escalónSegundoOrden = new Ejemplos.FrmEscalónSegundoOrdenAvion();
            escalónSegundoOrden.MdiParent = this;
            escalónSegundoOrden.FormClosing += new FormClosingEventHandler(form_FormClosing);
            escalónSegundoOrden.Show();
        }

        private void submarinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.menu.Enabled = false;
            this.acercaDeToolStripMenuItem.Enabled = false;
            this.salirToolStripMenuItem.Enabled = false;

            Ejemplos.FrmEscalónSegundoOrdenSubmarino escalónSegundoOrden = new Ejemplos.FrmEscalónSegundoOrdenSubmarino();
            escalónSegundoOrden.MdiParent = this;
            escalónSegundoOrden.FormClosing += new FormClosingEventHandler(form_FormClosing);
            escalónSegundoOrden.Show();
        }
    }
}
