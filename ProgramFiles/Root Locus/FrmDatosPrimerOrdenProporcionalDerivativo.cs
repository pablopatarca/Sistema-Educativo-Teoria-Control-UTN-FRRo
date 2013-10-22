using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Root_Locus
{
    public partial class FrmDatosPrimerOrdenProporcionalDerivativo : Form
    {
        RootLocus rl;
        PointPairList polos;
        PointPairList ceros;
        List<double> valoresPolos;
        List<double> valoresCeros;
        List<TextBoxConFormato.FormattedTextBox> textosPolos;
        List<TextBoxConFormato.FormattedTextBox> textosCeros;
        bool conImaginarios = false;
        double ceroIm = double.NaN;
        double ceroRe = double.NaN;

        //double finK;
        //int cantPtos;

        public FrmDatosPrimerOrdenProporcionalDerivativo(PointPairList polos, PointPairList ceros, RootLocus rl,string polo1,string cero1)
        {
            InitializeComponent();
            this.rl = rl;
            this.polos = polos;
            this.ceros = ceros;

            this.ftbxPol1.Enabled = false;
            this.ftbxCer1.Enabled = false;

            this.ftbxPol1.Text = polo1;
            this.ftbxCer1.Text = cero1;

            this.chkVistaPrevia.Checked = true;
        }

        private void FrmDatosPrimerOrdenProporcionalDerivativo_Load(object sender, EventArgs e)
        {
            textosPolos = new List<TextBoxConFormato.FormattedTextBox>();
            textosCeros = new List<TextBoxConFormato.FormattedTextBox>();

            textosPolos.Add(ftbxPol1);
            textosPolos.Add(ftbxPol2);
            textosPolos.Add(ftbxPol3);
            textosPolos.Add(ftbxPol4);

            textosCeros.Add(ftbxCer1);
            textosCeros.Add(ftbxCer2);
            
            //reset();
        }

        private void btnEj1_Click(object sender, EventArgs e)
        {
            reset();

            rbRe.Checked = true;
            rbIm.Enabled = false;
            rbRe.Enabled = true;

            ftbxPol1.Text = "-1";
            ftbxPol2.Text = "-2";
            ftbxPol3.Text = "-3";
            
        }

        private void btnEj4_Click(object sender, EventArgs e)
        {
            reset();

            //ftbK.Text = "120,00";
            //ftbPtos.Text = "380";
            pbFuncTranf.Image = Root_Locus.Properties.Resources.formulaFuncionTransferencia_CerImagDoble;
            ftbxCeroRe.Visible = true;
            ftbxCeroIm.Visible = true;
            conImaginarios = true;

            
            rbIm.Checked = true;
            rbIm.Enabled = true;
            rbRe.Enabled = false;

            ftbxPol1.Text = "0";
            ftbxPol2.Text = "-0,5";
            ftbxPol3.Text = "-1";
            ftbxCeroRe.Text = "-1";
            ftbxCeroIm.Text = "1";
            
            
        }

        private void btnEj2_Click(object sender, EventArgs e)
        {
            reset();

            //ftbK.Text = "20,00";
            //ftbPtos.Text = "1000";
            rbRe.Checked = true;
            rbIm.Enabled = false;
            rbRe.Enabled = true;

            ftbxPol1.Text = "0";
            ftbxPol2.Text = "-0,05";
            ftbxPol3.Text = "-0,1";
            ftbxPol4.Text = "-2";
            
            ftbxCer1.Text = "-0,5";
            ftbxCer2.Text = "-1";
        }

        private void btnEj3_Click(object sender, EventArgs e)
        {
            reset();
            
            //ftbK.Text = "5,00";
            //ftbPtos.Text = "470";
            
            rbRe.Checked = true;
            rbIm.Enabled = false;
            rbRe.Enabled = true;
            
            ftbxPol1.Text = "-1";
            ftbxPol2.Text = "-0,5";
            ftbxCer1.Text = "-2";
            
        }
    
        private void reset()
        {
            rbRe.Select();
            foreach (TextBoxConFormato.FormattedTextBox ftbP in textosPolos)
            {
                ftbP.Text = "";
                ftbP.Visible = false;
            }
            foreach (TextBoxConFormato.FormattedTextBox ftbC in textosCeros)
            {
                ftbC.Text = "";
                ftbC.Visible = false;
            }

            //Defino los textbox que necesito
            ftbxPol1.Visible = true;
            ftbxPol1.Enabled = true;
            ftbxCer1.Visible = true;
            ftbxCer1.Enabled = true;

            ftbxCeroIm.Text = "";
            ftbxCeroIm.Visible = false;
            ftbxCeroRe.Text = "";
            ftbxCeroRe.Visible = false;
            rbRe.Enabled = true;
            rbIm.Enabled = true;

            

            //ftbK.Text = "";
            //ftbPtos.Text = "";
        }
       
        private bool validoReglas()
        {
            bool valido = true;
            bool cerosDominantes = false;
            bool polosDominantes = false;
            int cantCer = valoresCeros.Count;
            int cantPol = valoresPolos.Count;

            if (conImaginarios)
            {
                cantCer = 2;
            }
            else
            {
                for (int i = 0; i < cantCer; i++)
                    for (int j = 0; j < cantCer; j++)
                        if (Math.Abs(valoresCeros[i]) > 1 && Math.Abs(valoresCeros[j]) > 5 * Math.Abs(valoresCeros[i]))
                        {
                            cerosDominantes = true; break;
                        }
            }
            
            for (int i = 0; i < cantPol; i++)
                for (int j = 0; j < cantPol; j++)
                    if (Math.Abs(valoresPolos[i]) > 1 && Math.Abs(valoresPolos[j]) > 5 * Math.Abs(valoresPolos[i]))
                    {
                        polosDominantes = true; break;
                    }
			                 
            string resp = "Han ocurrido los siguientes errores:\n";

            if (ftbxPol1.Text.Equals("0") || ftbxCer1.Text.Equals("0"))
            {
                resp += "-El valor ingresado debe ser distino de cero.\n";
                
                if (ftbxPol1.Text.Equals("0"))
                {
                    ftbxPol1.Text = "";
                }

                if (ftbxCer1.Text.Equals("0"))
                {
                    ftbxCer1.Text = "";
                }
                                
                valido = false;
            }

            if (ftbxCer1.Text.Equals("") || ftbxPol1.Text.Equals(""))
            {
                resp += "-Debe ingresar todos los campos.\n";
                valido = false;
            }

            if (cantCer > cantPol)  
            {
                resp += "-La cantidad de polos deber ser mayor o igual a la cantidad de ceros.\n";  
                valido=false;
            }
            if (cantPol < 1)          
            {    
                resp += "-Debe ingresar por lo menos 1 polo para poder continuar.\n";   
                valido = false;
            }
            if (cerosDominantes)
            {
                resp += "-Hay Ceros sucesivos demasiado alejados entre sí.\n";
                valido = false;
            }
            if (polosDominantes)
            {
                resp += "-Hay Polos sucesivos demasiado alejados entre sí.\n";
                valido = false;
            }
            if (conImaginarios && (ceroIm == 0||double.IsNaN(ceroIm)))
            {
                resp += "-La parte imaginaria no puede estar vacía o ser igual a cero.\n";
                valido = false;
            }
            if (conImaginarios && double.IsNaN(ceroRe))
            {
                resp += "-La parte real no puede estar vacía.\n";
                valido = false;
            }

            if (!valido)
                MessageBox.Show(""+resp, "Error en los datos ingresados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            return valido;
        }

        /// <summary>
        /// Inicializa los controles cuando no están en vista previa
        /// </summary>
        private void inicializarControles()
        {
            //seteamos las propiedades iniciales de cada uno de los controles
            pbLineaDivisoria.Visible = false;
            pbFuncionG.Visible = false;
            pbNumProdK.Visible = false;
            pbNumProd2.Visible = false;
            lblNumProd2.Visible = false;
            pbNumProd3.Visible = false;
            lblNumProd3.Visible = false;
            pbNumComplejo.Visible = false;
            lblNumComReal1.Visible = false;
            lblNumComReal2.Visible = false;
            lblNumComIm1.Visible = false;
            lblNumComIm2.Visible = false;
            pbDenProd1.Visible = false;
            lblDenProd1.Visible = false;
            pbDenProd2.Visible = false;
            lblDenProd2.Visible = false;
            pbDenProd3.Visible = false;
            lblDenProd3.Visible = false;
            pbDenProd4.Visible = false;
            lblDenProd4.Visible = false;
            //visibles los controles de edición
            if (rbIm.Checked)
            {
                ftbImgAux1.Visible = true;
                ftbImgAux2.Visible = true;
                ftbRAux1.Visible = true;
                ftbRAux2.Visible = true;
                pbFuncTranf.Image = Root_Locus.Properties.Resources.formulaFuncionTransferencia_CerImagDoble;
            }
            else
            {
                pbFuncTranf.Image = Root_Locus.Properties.Resources.formulaProporcionalDerivativa;
                ftbxCer1.Visible = true;
                ftbxCer2.Visible = false;
                //para controlar las habilitaciones de las cajas de texto según el estado del anterior
                if (ftbxCer1.Text == "") ftbxCer2.Enabled = false;
                else ftbxCer2.Enabled = false;
            }
            ftbxPol1.Visible = true;
            ftbxPol2.Visible = false;
            ftbxPol3.Visible = false;
            ftbxPol4.Visible = false;

            if (ftbxPol1.Text == "") ftbxPol2.Enabled = false;
            else ftbxPol2.Enabled = true;
            
            
            
            if (ftbxPol2.Text == "") ftbxPol3.Enabled = false;
            else ftbxPol3.Enabled = true;
            
            
            if (ftbxPol3.Text == "") ftbxPol4.Enabled = false;
            else ftbxPol4.Enabled = true;
            //habilitamos los controles que se dehabilitan en vista previa
            rbIm.Enabled = true;
            rbRe.Enabled = true;
            btnEj1.Enabled = true;
            btnEj2.Enabled = true;
            btnEj3.Enabled = true;
            btnEj4.Enabled = true;
            btnLimpiar.Enabled = true;
            ftbxCeroIm.Enabled = true;
            ftbxCeroRe.Enabled = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            valoresCeros = new List<double>();
            valoresPolos = new List<double>();

            /*
            //Parseo de datos.
            try { finK = Double.Parse(ftbK.Text); }
            catch { }
            try { cantPtos = Int16.Parse(ftbPtos.Text); }
            catch { }
            */            

            foreach (TextBoxConFormato.FormattedTextBox txt in textosPolos)
                try { valoresPolos.Add(double.Parse(txt.Text)); }
                catch { }

            if (conImaginarios)
            {
                try { ceroRe = double.Parse(ftbxCeroRe.Text); }
                catch { }

                try { ceroIm = double.Parse(ftbxCeroIm.Text); }
                catch { }

            }
            else
            {
                foreach (TextBoxConFormato.FormattedTextBox txt in textosCeros)
                    try { valoresCeros.Add(double.Parse(txt.Text)); }
                    catch { }
            }
            if (validoReglas())
            {
                //rl.finK = finK;
                //rl.cantPtos = cantPtos;

                if (conImaginarios)
                {
                    ceros.Add(new PointPair(ceroRe, ceroIm, double.PositiveInfinity));
                    ceros.Add(new PointPair(ceroRe, -ceroIm, double.PositiveInfinity));                    
                }
                else
                {
                    foreach (double c in valoresCeros)
                        ceros.Add(new PointPair(c, 0, double.PositiveInfinity));
                }

                foreach (double p in valoresPolos)
                    polos.Add(new PointPair(p, 0, 0));

                this.Dispose();
            }           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == rbRe)
            {
                ftbxCeroRe.Visible = false;
                ftbxCeroIm.Visible = false;
                ftbRAux1.Visible = false;
                ftbRAux2.Visible = false;
                ftbImgAux1.Visible = false;
                ftbImgAux2.Visible = false;
                lMasMenos.Visible = false;
                lJota.Visible = false;
                ftbxCer1.Visible = true;
                ftbxCer2.Visible = false;
                conImaginarios = false;
                pbFuncTranf.Image = Root_Locus.Properties.Resources.formulaProporcionalDerivativa;
            }
            else
            {
                ftbxCeroRe.Visible = true;
                ftbxCeroIm.Visible = true;
                ftbRAux1.Visible = true;
                ftbRAux2.Visible = true;
                ftbImgAux1.Visible = true;
                ftbImgAux2.Visible = true;
                lMasMenos.Visible = true;
                lJota.Visible = true;
                ftbxCer1.Visible = false;
                ftbxCer2.Visible = false;
                conImaginarios = true;
                pbFuncTranf.Image = Root_Locus.Properties.Resources.formulaProporcionalDerivativa;
            }
        }

        private void ftbxCeroRe_TextChanged(object sender, EventArgs e)
        {
            ftbRAux1.Text = ftbxCeroRe.Text;
            ftbRAux2.Text = ftbxCeroRe.Text;
        }

        private void ftbxCeroIm_TextChanged(object sender, EventArgs e)
        {
            ftbImgAux1.Text = ftbxCeroIm.Text;
            ftbImgAux2.Text = ftbxCeroIm.Text;
        }

        private void pbFuncTranf_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento entre Vista de edición y Vista previa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkVistaPrevia_CheckedChanged(object sender, EventArgs e)
        {
            //variables para controlar las posiciones
            int posCentroH = ((pbFuncTranf.Width - pbFuncionG.Width)/ 2) + (int)(pbFuncionG.Width*1.7); //establece el centro del contenedor en forma horizontal
            //anchoTotalCtrls: es la suma de los anchos de los controles que han sido "llenados"
            //anchoNumerador: es el ancho de los controles del numerador para luego poder comparar con los del denominador 
            //                y poder marcar la línea divisoria
            //posCtrl: es la posición que tomará el control luego del centrado
            int anchoTotalCtrls = Root_Locus.Properties.Resources.funcion_G.Width, anchoNumerador = 0, anchoDenominador = 0, posCtrl = 0;
            //variables para permitir o no ver la vista previa debido a la restricción de los polos
            int cantCeros=0, cantPolos=0;
            bool permitir = false;

            //cambiar entre vista previa y vista editable
            if (chkVistaPrevia.Checked) //vista previa
            {
                //hacemos un bucle en el que en la 1º iteración rellenamos los campos y averiguamos cuáles están llenos para luego
                //saber el ancho total del numerador o denominador y después en la 2º iteración poder centrarlos
                for (int i = 0; i < 2; i++)
                {
                    if (i == 1)
                    {
                        if (permitir)
                        {
                            //si está permitido mostramos la función G(s) y la posicionamos
                            pbFuncionG.Location = new Point(posCtrl, pbFuncionG.Location.Y);
                            pbFuncionG.Visible = true;
                            posCtrl += pbFuncionG.Width;
                        }
                    }
                    
                    //Numerador
                    if (permitir)
                    {
                        //si está permitido posicionamos la constante K y la hacemos visible
                        posCtrl = posCentroH - (anchoNumerador / 2);
                        pbNumProdK.Visible = true;
                        pbNumProdK.Location = new Point(posCtrl, pbNumProdK.Location.Y);
                        posCtrl += pbNumProdK.Width;
                    }
                    //verificacmos los TextBoxes que han sido llenados en la 1º iteración
                    if (rbRe.Checked) //ceros reales
                    {
                        //para cada uno de los textboxes:
                        //nos fijamos si contienen algo, si es así y estamos en la primera iteración seteamos los textos para vista
                        //previa contamos la cantidad de ceros o polos y acumulamos el ancho del PictureBox que lo contiene
                        //Si estamos en la 2º iteración, ponemos en visible los controles inherentes al control de texto, los
                        //posicionamos y seteamos la posición del próximo control
                        if (ftbxCer1.Text != "")
                        {
                            if (i == 0)
                            {
                                lblNumProd2.Text = ftbxCer1.Text;
                                anchoTotalCtrls += pbNumProd2.Width;
                                cantCeros += 1;
                            }
                            else if ((i == 1) && (permitir))
                            {
                                lblNumProd2.Visible = true;
                                lblNumProd2.Location = new Point(posCtrl + 45, lblNumProd2.Location.Y);
                                pbNumProd2.Visible = true;
                                pbNumProd2.Location = new Point(posCtrl, pbNumProd2.Location.Y);
                                posCtrl += pbNumProd2.Width;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe completar todos los campos para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkVistaPrevia.Checked = false;
                            break;
                        }

                        if (ftbxCer2.Text != "")
                        {
                            if (i == 0)
                            {
                                lblNumProd3.Text = ftbxCer2.Text;
                                anchoTotalCtrls += pbNumProd3.Width;
                                cantCeros += 1;
                            }
                            else if ((i == 1) && (permitir))
                            {
                                lblNumProd3.Visible = true;
                                lblNumProd3.Location = new Point(posCtrl + 49, lblNumProd3.Location.Y);
                                pbNumProd3.Visible = true;
                                pbNumProd3.Location = new Point(posCtrl, pbNumProd3.Location.Y);
                                posCtrl += pbNumProd3.Width;
                            }
                        }
                    }
                    else //ceros imaginarios
                    {
                        if (ftbxCeroIm.Text != "")
                        {
                            if (i == 0)
                            {
                                lblNumComReal1.Text = ftbxCeroRe.Text;
                                lblNumComReal2.Text = ftbxCeroRe.Text;
                                lblNumComIm1.Text = ftbxCeroIm.Text;
                                lblNumComIm2.Text = ftbxCeroIm.Text;
                                anchoTotalCtrls += pbNumComplejo.Width;
                            }
                            else
                            {
                                lblNumComReal1.Visible = true;
                                lblNumComReal1.Location = new Point(posCtrl + 57, lblNumComReal1.Location.Y);
                                lblNumComReal2.Visible = true;
                                lblNumComReal2.Location = new Point(posCtrl + 212, lblNumComReal2.Location.Y);
                                lblNumComIm1.Visible = true;
                                lblNumComIm1.Location = new Point(posCtrl + 109, lblNumComIm1.Location.Y);
                                lblNumComIm2.Visible = true;
                                lblNumComIm2.Location = new Point(posCtrl + 276, lblNumComIm2.Location.Y);
                                pbNumComplejo.Location = new Point(posCtrl, pbNumComplejo.Location.Y);
                                pbNumComplejo.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("La parte imaginaria debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkVistaPrevia.Checked = false;
                            break;
                        }
                    }
                    //guardamos el valor del numerador y seteamos el anchoTotal en 0 de vuelta para luego poder comenzar con el denominador
                    if (i == 0)
                    {
                        anchoNumerador = anchoTotalCtrls - pbFuncionG.Width;
                        anchoTotalCtrls = 0;
                    }
                    else
                    {
                        // si estamos en la 2º iteración, seteamos la posición del primer control del denominador
                        posCtrl = posCentroH - (anchoDenominador / 2) + 35;
                    }
                    //Denominador
                    if (ftbxPol1.Text != "")
                    {
                        if (i == 0)
                        {
                            lblDenProd1.Text = ftbxPol1.Text;
                            anchoTotalCtrls += pbDenProd1.Width;
                            cantPolos += 1;
                        }
                        else if ((i == 1) && (permitir))
                        {
                            lblDenProd1.Visible = true;
                            lblDenProd1.Location = new Point(posCtrl + 35, lblDenProd1.Location.Y);
                            pbDenProd1.Visible = true;
                            pbDenProd1.Location = new Point(posCtrl, pbDenProd1.Location.Y);                            
                            posCtrl += pbDenProd1.Width;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkVistaPrevia.Checked = false;
                        break;
                    }

                    if (ftbxPol2.Text != "")
                    {
                        if (i == 0)
                        {
                            lblDenProd2.Text = ftbxPol2.Text;
                            anchoTotalCtrls += pbDenProd2.Width;
                            cantPolos += 1;
                        }
                        else if ((i == 1) && (permitir))
                        {
                            lblDenProd2.Visible = true;
                            lblDenProd2.Location = new Point(posCtrl + 45, lblDenProd2.Location.Y);
                            pbDenProd2.Visible = true;
                            pbDenProd2.Location = new Point(posCtrl, pbDenProd2.Location.Y);
                            posCtrl += pbDenProd2.Width;
                        }
                    }

                    if (ftbxPol3.Text != "")
                    {
                        if (i == 0)
                        {
                            lblDenProd3.Text = ftbxPol3.Text;
                            anchoTotalCtrls += pbDenProd3.Width;
                            cantPolos += 1;
                        }
                        else if ((i == 1) && (permitir))
                        {
                            lblDenProd3.Visible = true;
                            lblDenProd3.Location = new Point(posCtrl + 51, lblDenProd3.Location.Y);
                            pbDenProd3.Visible = true;
                            pbDenProd3.Location = new Point(posCtrl, pbDenProd3.Location.Y);
                            posCtrl += pbDenProd3.Width;
                        }
                    }

                    if (ftbxPol4.Text != "")
                    {
                        if (i == 0)
                        {
                            lblDenProd4.Text = ftbxPol4.Text;
                            anchoTotalCtrls += pbDenProd4.Width;
                            cantPolos += 1;
                        }
                        else if ((i == 1) && (permitir))
                        {
                            lblDenProd4.Visible = true;
                            lblDenProd4.Location = new Point(posCtrl + 52, lblDenProd4.Location.Y);
                            pbDenProd4.Visible = true;
                            pbDenProd4.Location = new Point(posCtrl, pbDenProd4.Location.Y);
                        }
                    }
                    //guardamos la posición del denominador y la ponemos como defecto en el anchoTotal
                    anchoDenominador = anchoTotalCtrls + pbFuncionG.Width;
                    anchoTotalCtrls = anchoDenominador;

                    if (i == 0)
                    {
                        //Controlamos la cantidad de ceros y polos y seteamos las posiciones visibilidades y bloqueos necesarios
                        if ((cantPolos >= cantCeros) && (cantPolos > 0))
                        {
                            permitir = true;
                            //agregamos el ancho de la constante K
                            anchoNumerador += pbNumProdK.Width;
                            //hacemos visible y seteamos las propiedades de la línea divisoria teniendo en cuenta
                            //si el numerador es más grande que el denominador
                            pbLineaDivisoria.Visible = true;
                            if (anchoNumerador > (anchoDenominador-pbFuncionG.Width))
                                anchoTotalCtrls = anchoNumerador+100;
                            pbLineaDivisoria.Width = anchoTotalCtrls-pbFuncionG.Width;
                            posCtrl = posCentroH - ((anchoTotalCtrls - pbFuncionG.Width + 20) / 2) + 13;
                            pbLineaDivisoria.Location = new Point(posCtrl, pbLineaDivisoria.Location.Y);
                            //ponemos por defecto la posición del control del numerador
                            posCtrl = posCentroH - (anchoNumerador / 2);

                            //ocultamos todo y bloquemaos todo lo que haga falta
                            pbFuncTranf.Image = Root_Locus.Properties.Resources.formulaFuncionTransferencia_vacio;
                            ftbImgAux1.Visible = false;
                            ftbImgAux2.Visible = false;
                            ftbRAux1.Visible = false;
                            ftbRAux2.Visible = false;
                            ftbxCer1.Visible = false;
                            ftbxCer2.Visible = false;
                            ftbxPol1.Visible = false;
                            ftbxPol2.Visible = false;
                            ftbxPol3.Visible = false;
                            ftbxPol4.Visible = false;
                            ftbxCeroIm.Enabled = false;
                            ftbxCeroRe.Enabled = false;
                            btnLimpiar.Enabled = false;
                            rbIm.Enabled = false;
                            rbRe.Enabled = false;
                            btnEj1.Enabled = false;
                            btnEj2.Enabled = false;
                            btnEj3.Enabled = false;
                            btnEj4.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("La cantidad de polos debe ser mayor o igual a la cantidad de ceros y debe haber al menos 1 polo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkVistaPrevia.Checked = false;
                            break;
                        }
                    }
                    else
                    {
                        //Si el denominador es más ancho que el numerador reposicionar la función G
                        if ((pbFuncionG.Location.X + pbFuncionG.Width) >= pbLineaDivisoria.Location.X)
                        {
                            posCtrl = pbLineaDivisoria.Location.X - pbFuncionG.Width -5 ;
                            pbFuncionG.Location = new Point(posCtrl, pbFuncionG.Location.Y);
                        }
                        //si se va muy a la derecha la linea divisoria traerla más a la izquierda
                        if ((pbFuncTranf.Location.X + pbFuncTranf.Width) < (pbLineaDivisoria.Location.X + pbLineaDivisoria.Width))
                        {
                            pbLineaDivisoria.Location = new Point(pbLineaDivisoria.Location.X - 5, pbLineaDivisoria.Location.Y);
                        }
                    }
                }
            }
            else //vista editable
            {
                inicializarControles();
            }
        }

        //Todos los eventos siguientes es para habilitar o no los textboxes según se haya escrito o no en el anterior
        private void ftbxCer1_Text_Changed(object sender, EventArgs e)
        {
            //if (ftbxCer1.Text != "")
            //    ftbxCer2.Enabled = true;
            //else
            //{
            //    ftbxCer2.Text = "";
            //    ftbxCer2.Enabled = false;
            //}
        }

        private void ftbxPol1_Text_Changed(object sender, EventArgs e)
        {
            //if (ftbxPol1.Text != "")
            //    ftbxPol2.Enabled = true;
            //else
            //{
            //    ftbxPol2.Text = "";
            //    ftbxPol2.Enabled = false;
            //}
        }

        private void ftbxPol2_Text_Changed(object sender, EventArgs e)
        {
            //if (ftbxPol2.Text != "")
            //    ftbxPol3.Enabled = true;
            //else
            //{
            //    ftbxPol3.Text = "";
            //    ftbxPol3.Enabled = false;
            //}
        }

        private void ftbxPol3_Text_Changed(object sender, EventArgs e)
        {
            //if (ftbxPol3.Text != "")
            //    ftbxPol4.Enabled = true;
            //else
            //{
            //    ftbxPol4.Text = "";
            //    ftbxPol4.Enabled = false;
            //}
        }

    }
}
