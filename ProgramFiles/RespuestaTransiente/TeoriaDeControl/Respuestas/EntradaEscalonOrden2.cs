using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Collections;
using System.Drawing;

namespace TeoriaDeControl
{
    public class EntradaEscalonOrden2 : IPropiedadesGrafica
    {

        #region Mis Atributos
        private double amplitud;
        private double cteTiempo;
        private double coefAmort;
        private double pjeTiempoAsent;
        private double pasoEntrePuntos = 0.01;
        private List<string> _Titulos = new List<string>();
        private List<Nullable<double>> _Medidas = new List<Nullable<double>>();
        public string [] _Botones = {"Overshoot","Bandas"};
        private double _InicioEjeX;
        private double _InicioEjeY;
        private double _FinEjeX;
        private double _FinEjeY;
        private Image _formula;

        #endregion

        //Creo una lista de PointPairLists

        #region Implementacion de IPropiedadesGrafica
        

        public List<string> Titulos
        {
            get
            {
                return _Titulos;
            }
            set
            {
                _Titulos = value;
            }
        }

        public string NombreEjeX
        {
            get
            {
                return "Tiempo";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string NombreEjeY
        {
            get
            {
                return "Y(t)";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool LogEjeX
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool LogEjeY
        {
            get
            {
                return false;

            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string[] NombreParametros
        {
            get
            {
                return new string[] { "Amplitud", "Cte. Tiempo", "Coef. Amort.", "% Tiempo Asent." };
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double InicioEjeX
        {
            get
            {
                return _InicioEjeX;
            }
            set
            {
                value = _InicioEjeX;
            }
        }

        public double InicioEjeY
        {
            get
            {
                return _InicioEjeY;
            }
            set
            {
                value = _InicioEjeY;
            }
        }

        public double FinEjeX
        {
            get
            {
                return _FinEjeX;
            }
            set
            {
                value = _FinEjeX;
            }
        }

        public double FinEjeY
        {
            get
            {
                return _FinEjeY;
            }
            set
            {
                value = _FinEjeY;
            }
        }

        public String[] Botones
        {
            get
            {
                return _Botones;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<Nullable<double>> Medidas
        {
            get
            {
                return _Medidas;
            }
            set
            {
                _Medidas = value;
            }
        }

        public String Amortiguacion 
        { 
            get 
            {
                if (coefAmort < 1)
                    return "SUA";
                else if (coefAmort == 1)
                    return "CRA";
                else
                    return "SOA";
            } 
        }

        public Image Formula
        {
            get
            {
                return _formula;
            }
        }

        /// <summary>
        /// Calcula los puntos de las curvas para una funcion Impulso de segundo orden.
        /// </summary>
        /// <param name="parametros">parámetros de la función Impulso de segundo orden: [amplitud, cteTiempo, coefAmort, pjeAsent]</param>
        /// <returns>Una lista de PointPairList con las curvas generadas</returns>
        public List<PointPairList> generarPuntos(double[] parametros)
        {
            List<PointPairList> listas = new List<PointPairList>();

            //Seteo los atributos amplitud, cteTiempo, coefAmort y pjeAsent            
            this.amplitud = parametros[0];
            this.cteTiempo = parametros[1];
            this.coefAmort = parametros[2];
            this.pjeTiempoAsent = parametros[3];

            //Agrego los Titulos de las curvas
            Titulos.Add("Salida Escalón Segundo Orden");
            Titulos.Add("Entrada Escalón");
            Titulos.Add("Overshoot");
            Titulos.Add("Cota Superior");
            Titulos.Add("Cota Inferior");


            /*Agrego curvas a la lista:
             * 0 - Salida
             * 1 - Entrada
             * 2 - Overshoot
             * 3 - Cota Superior
             * 4 - Cota inferior             
            */
            for (int i = 0; i < 5; i++)
                listas.Add(new PointPairList());

            double cotaInferior = this.amplitud - this.amplitud * (pjeTiempoAsent / 100);
            double cotaSuperior = this.amplitud + this.amplitud * (pjeTiempoAsent / 100);
            ArrayList picosSuperiores = new ArrayList();
            double picoMaximo = -1;
            double tiempoPicoMaximo = -1;
            double razonCaida = -1;
            double periodoOscilacion = -1;
            double tiempoSubida = -1, tiempoSubida90 = -1, tiempoSubida10 = -1;
            double tiempoAsentamiento = -1;
            double tiempoAsentamientoActual = -1;
            bool seEncontroTiempoAsent = false;
            double x = 0;
            double y = 0;
            double yAnterior = 0;
            double yAnteriorAnterior = 0;
            double ov = -1;



            //Agrego el punto (0,0)
            listas[0].Add(x, y);

            //Dibujo la curva principal y calculo Tiempo de Asentamiento y Razon de caida
            #region Caso 1, coefAmort < 1

            if (this.coefAmort < 1)
            {
                //seteamos la formula
                _formula = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden1; 
                
                double xUltimoPuntoDibujado = 0;
                int indiceUltimoPuntoDibujado = 0;

                while (!seEncontroTiempoAsent)
                {

                    x = x + pasoEntrePuntos;
                    y = YCoefAmortMenorAUno(amplitud, cteTiempo, coefAmort, x);
                    listas[0].Add(x, y);
                    indiceUltimoPuntoDibujado = indiceUltimoPuntoDibujado + 1;

                    //Almacenamos el primer pico, que es el máximo
                    if (yAnterior > yAnteriorAnterior && yAnterior > y && picoMaximo == -1)
                    {
                        picoMaximo = y;
                        tiempoPicoMaximo = x;

                    }

                    //Es un punto de entrada hacia arriba si el punto actual es >= a la cota inferior y
                    //el punto anterior es menor a la cota inferior.
                    if (y >= cotaInferior && yAnterior < cotaInferior)
                        tiempoAsentamientoActual = x;

                    //Es un punto de entrada hacia abajo si el punto actual es <= a la cota superior y
                    //el punto anterior es mayor a la cota superior.
                    if (y <= cotaSuperior && yAnterior > cotaSuperior)
                        tiempoAsentamientoActual = x;

                    //En el caso de un pico SUPERIOR, se sabe que no saldrá más de la banda 
                    //en el momento en que el punto actual sea mayor al punto anterior y mayor al punto siguiente.
                    //Además, el punto actual debe estar dentro de la banda.
                    if (yAnterior > yAnteriorAnterior && yAnterior > y &&
                        yAnterior >= cotaInferior && yAnterior <= cotaSuperior)
                    {
                        seEncontroTiempoAsent = true;
                        tiempoAsentamiento = tiempoAsentamientoActual;
                        xUltimoPuntoDibujado = x;
                    }

                    //En el caso de un pico INFERIOR, se sabe que no saldrá más de la banda 
                    //en el momento en que el punto actual sea menor al punto anterior y menor al punto siguiente. 
                    //Además, el punto actual debe estar dentro de la banda.
                    if (yAnterior < yAnteriorAnterior && yAnterior < y &&
                        yAnterior >= cotaInferior && yAnterior <= cotaSuperior)
                    {
                        seEncontroTiempoAsent = true;
                        tiempoAsentamiento = tiempoAsentamientoActual;
                        xUltimoPuntoDibujado = x;
                    }


                    //Guardamos las amplitudes de todos los picos superiores
                    if (yAnterior > yAnteriorAnterior && yAnterior > y)
                        picosSuperiores.Add(y);

                    //Si encontro el primer pico y no salio de la banda superior guardamos ese punto como tiempo de asentamiento
                    if (picoMaximo != -1 && picoMaximo < cotaSuperior)
                    {
                        tiempoAsentamiento = tiempoPicoMaximo;
                        seEncontroTiempoAsent = true;
                    }

                    //Calculo del tiempo de subida
                    if (tiempoSubida == -1 && y > amplitud)
                        tiempoSubida = x;

                    //Actualizamos el punto anterior y el anterior al anterior.
                    if (!seEncontroTiempoAsent)
                    {
                        double temp = yAnterior;
                        yAnterior = y;
                        yAnteriorAnterior = temp;
                    }




                }

                //Borramos los puntos dibujados entre el Tiempo de Asentamiento y 
                //el Pico(superior o inferior) que está dentro de la banda

                while (xUltimoPuntoDibujado > tiempoAsentamiento)
                {
                    listas[0].RemoveAt(indiceUltimoPuntoDibujado);
                    indiceUltimoPuntoDibujado--;
                    xUltimoPuntoDibujado = listas[0][indiceUltimoPuntoDibujado].X;

                }

                //Overshoot
                ov = Math.Pow(Math.E, (-Math.PI * coefAmort) / (Math.Sqrt(1 - coefAmort * coefAmort)));

                //Calculo de la razon de caida
                /*if (picosSuperiores.Count >= 2)
                    razonCaida = ((double)picosSuperiores[0] - (double)picosSuperiores[1]) / (double)picosSuperiores[0];
                */

                /*
                //Calculo de la razon de caida
                if (picosSuperiores.Count >= 2)
                    razonCaida = ((double)picosSuperiores[1] / (double)picosSuperiores[0]);
                */

                //Calculo de la razon de caida
                razonCaida = ov * ov;

                //Calculo del período de oscilación
                periodoOscilacion = (2 * Math.PI * this.cteTiempo) / (Math.Sqrt(1 - this.coefAmort * this.coefAmort));
                
                


                //Lleno la lista Medidas
                Medidas.Clear();
                Medidas.Add(null);
                Medidas.Add(ov * 100);
                Medidas.Add(tiempoSubida);
                Medidas.Add(tiempoAsentamiento);
                //Razon de caida
                Medidas.Add(razonCaida);
                Medidas.Add(periodoOscilacion);
                for (int i = 0; i < 4; i++)
                    Medidas.Add(null);
                Medidas.Add(tiempoPicoMaximo);
                for (int i = 0; i < 14; i++)
                    Medidas.Add(null);
                Medidas.Add((tiempoAsentamiento / periodoOscilacion));

                //Agregamos los puntos para la linea del Overshoot
                listas[2].Add(tiempoPicoMaximo, 0);
                listas[2].Add(tiempoPicoMaximo, YCoefAmortMenorAUno(this.amplitud, this.cteTiempo, this.coefAmort, tiempoPicoMaximo));
                listas[2].Add(0, YCoefAmortMenorAUno(this.amplitud, this.cteTiempo, this.coefAmort, tiempoPicoMaximo));
            }
            
            #endregion

            #region Caso 2, coefAmort = 1

            if (this.coefAmort == 1)
            {
                //seteamos la formula
                _formula = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden2;

                while (!seEncontroTiempoAsent)
                {
                    x += pasoEntrePuntos;
                    y = YCoefAmortIgualAUno(amplitud, cteTiempo, x);

                    listas[0].Add(x, y);

                    //Una vez que entra a la banda desde abajo hacia arriba, ya no saldrá más
                    if (y > cotaInferior)
                    {
                        tiempoAsentamiento = x;
                        seEncontroTiempoAsent = true;
                    }
                    
                    //Calculo el tiempo de subida
                    if (tiempoSubida90 == -1 && y > amplitud * 0.9)
                        tiempoSubida90 = x;
                    if (tiempoSubida10 == -1 && y > amplitud * 0.1)
                        tiempoSubida10 = x;

                    //Actualizamos el punto anterior
                    yAnterior = y;
                }


                //Calculo el tiempo de subida
                tiempoSubida = tiempoSubida90 - tiempoSubida10;

                //Lleno la lista Medidas
                Medidas.Clear();
                Medidas.Add(null);
                Medidas.Add(999999999);
                Medidas.Add(tiempoSubida);
                Medidas.Add(tiempoAsentamiento);
                Medidas.Add(999999999);
                Medidas.Add(999999999);
                for (int i = 0; i < 4; i++)
                    Medidas.Add(null);
                Medidas.Add(999999999);
                for (int i = 0; i < 14; i++)
                    Medidas.Add(null);
                Medidas.Add(999999999);

                /*
                //Agregamos los puntos para la linea del Tiempo de Subida
                listas[2].Add(tiempoSubida,0);
                listas[2].Add(tiempoSubida, YCoefAmortIgualAUno(amplitud,cteTiempo,tiempoSubida));
                listas[2].Add(0,YCoefAmortIgualAUno(amplitud,cteTiempo,tiempoSubida));
                */
                
            }

            #endregion

            #region Caso 3, coefAmort > 1

            if (this.coefAmort > 1)
            {
                //seteamos la formula
                _formula = TeoriaDeControl.Properties.Resources.FormulaEscalon2Orden3;

                while (!seEncontroTiempoAsent)
                {
                    x += pasoEntrePuntos;
                    y = YCoefAmortMayorAUno(amplitud, cteTiempo, coefAmort, x);

                    listas[0].Add(x, y);

                    //Una vez que entra a la banda desde abajo hacia arriba, ya no saldrá más
                    if (y > cotaInferior)
                    {
                        tiempoAsentamiento = x;
                        seEncontroTiempoAsent = true;
                    }

                    //Calculo el tiempo de subida
                    if (tiempoSubida90 == -1 && y > amplitud * 0.9)
                        tiempoSubida90 = x;
                    if (tiempoSubida10 == -1 && y > amplitud * 0.1)
                        tiempoSubida10 = x;


                    if (listas[0].Count > 100000)
                        seEncontroTiempoAsent = true;
                        
                    
                    //Actualizamos el punto anterior
                    yAnterior = y;
                }

                //Calculo el tiempo de subida
                tiempoSubida = tiempoSubida90 - tiempoSubida10;

                //Lleno la lista Medidas
                Medidas.Clear();
                Medidas.Add(null);
                Medidas.Add(999999999);
                Medidas.Add(tiempoSubida);
                Medidas.Add(tiempoAsentamiento);
                Medidas.Add(999999999);
                Medidas.Add(999999999);
                for (int i = 0; i < 4; i++)
                    Medidas.Add(null);
                Medidas.Add(999999999);
                for (int i = 0; i < 14; i++)
                    Medidas.Add(null);
                Medidas.Add(999999999);

                /*
                //Agregamos los puntos para la linea del Tiempo de Subida
                listas[2].Add(tiempoSubida, 0);
                listas[2].Add(tiempoSubida, YCoefAmortMayorAUno(amplitud, cteTiempo, coefAmort, tiempoSubida));
                listas[2].Add(0, YCoefAmortMayorAUno(amplitud, cteTiempo, coefAmort, tiempoSubida));
                */                
            }



            #endregion

            //Le agregamos un 10% al tiempo de asentamiento para calcular el FinEjeX
            this._InicioEjeX = 0.0;
            this._FinEjeX = tiempoAsentamiento * 1.1;
            this._InicioEjeY = 0.0;
            if (coefAmort < 1)
                this._FinEjeY = picoMaximo * 1.2;
            else
                this._FinEjeY = amplitud * 1.2;



            //Continuamos dibujando las partes que faltan
            // Dibujo hasta FinEjeX * 5 por el tema del zoom

            
            #region Caso 1, coefAmort < 1

            if (coefAmort < 1)
                for (double t = tiempoAsentamiento; t <= this._FinEjeX * 5; t = t + pasoEntrePuntos)
                    listas[0].Add(t, YCoefAmortMenorAUno(amplitud, cteTiempo, coefAmort, t));

            #endregion

            #region Caso 2, coefAmort = 1

            if (coefAmort == 1)
                for (double t = tiempoAsentamiento; t <= this._FinEjeX * 5; t = t + pasoEntrePuntos)
                    listas[0].Add(t, YCoefAmortIgualAUno(amplitud, cteTiempo, t));

            #endregion

            #region Caso 3, coefAmort > 1

            if (coefAmort > 1)
                for (double t = tiempoAsentamiento; t <= this._FinEjeX * 5; t = t + pasoEntrePuntos)
                    listas[0].Add(t, YCoefAmortMayorAUno(amplitud, cteTiempo, coefAmort, t));

            #endregion

            //Agregamos los puntos para la entrada
            for (double t = 0; t <= this._FinEjeX * 5; t = t + pasoEntrePuntos)
                listas[1].Add(t, amplitud);


            //Agregamnos los puntos para las bandas
            for (double t = 0; t <= this._FinEjeX * 5; t = t + pasoEntrePuntos)
            {
                listas[3].Add(t, cotaSuperior);
                listas[4].Add(t, cotaInferior);
            }

            
            return listas;

        }

        #endregion

        //Función escalon, donde coefAmort < 1
        private double YCoefAmortMenorAUno(double amplitud, double cteTiempo, double coefAmort, double tiempo)
        {
            return (1 - (1 / Math.Sqrt(1 - (coefAmort * coefAmort))) *
                Math.Pow(Math.E, (-coefAmort * tiempo) / cteTiempo) *
                Math.Sin(Math.Sqrt(1 - coefAmort * coefAmort) * (tiempo / cteTiempo)
                    + Math.Atan(Math.Sqrt(1 - coefAmort * coefAmort) / coefAmort))) * amplitud;
        }

        //Función escalon, donde coefAmort = 1
        private double YCoefAmortIgualAUno(double amplitud, double cteTiempo, double tiempo)
        {
            return (1 - (1 + tiempo / cteTiempo) * Math.Pow(Math.E, -tiempo / cteTiempo)) * amplitud;
        }

        //Función escalon, donde coefAmort > 1
        private double YCoefAmortMayorAUno(double amplitud, double cteTiempo, double coefAmort, double tiempo)
        {
            return (1 - Math.Pow(Math.E, (-coefAmort * tiempo) / cteTiempo)
                * (Math.Cosh(Math.Sqrt(coefAmort * coefAmort - 1)
                * (tiempo / cteTiempo)) + coefAmort / (Math.Sqrt(coefAmort * coefAmort - 1))
                * Math.Sinh(Math.Sqrt(coefAmort * coefAmort - 1) * (tiempo / cteTiempo)))) * amplitud;
        }
            
    }
}


