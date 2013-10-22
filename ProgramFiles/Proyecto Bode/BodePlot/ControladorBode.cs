using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BodePlot
{
    public class ControladorBode
    {
        #region Constantes

        /// <summary>
        /// Cantidad de puntos a calcular.
        /// </summary>
        private const double CANT_PUNTOS_A_CALCULAR_EJE_X = 50000.0;

        /// <summary>
        /// Valor que se adiciona al inicio y fin del eje Y en magnitud.
        /// </summary>
        private const double VALOR_ADICIONAL_PARA_INICIO_Y_FIN_MAGNITUD = 5.0;

        /// <summary>
        /// Valor que se adiciona al inicio y fin del eje Y en fase.
        /// </summary>
        private const double VALOR_ADICIONAL_INICIO_Y_FIN_FASE = 5.0;

        /// <summary>
        /// Valor que se adiciona al inicio y fin del eje Y en fase, en caso
        /// de tener ambos el mismo valor. 
        /// </summary>
        private const double VALOR_ADICIONAL_INICIO_Y_FIN_FASE_IGUALES = 45.0;

        #endregion

        #region Propiedades

        /// <summary>
        /// Inicio del eje X, tanto de magnitud como de fase.
        /// </summary>
        public double InicioEjeX
        {
            get
            {
                return 0.01;
            }
        }

        /// <summary>
        /// Fin del eje X, tanto de magnitud como de fase.
        /// </summary>
        public double FinEjeX
        {
            get
            {
                return 1000.0;
            }
        }

        /// <summary>
        /// Inicio del eje Y de magnitud.
        /// </summary>
        private double _InicioEjeYMagnitud;
        public double InicioEjeYMagnitud
        {
            get
            {
                return _InicioEjeYMagnitud;
            }
            set
            {
                _InicioEjeYMagnitud = value;
            }
        }

        /// <summary>
        /// Fin del eje Y de magnitud.
        /// </summary>
        private double _FinEjeYMagnitud;
        public double FinEjeYMagnitud
        {
            get
            {
                return _FinEjeYMagnitud;
            }
            set
            {
                _FinEjeYMagnitud = value;
            }
        }

        /// <summary>
        /// Inicio del eje Y de fase.
        /// </summary>
        private double _InicioEjeYFase;
        public double InicioEjeYFase
        {
            get
            {
                return _InicioEjeYFase;
            }
            set
            {
                _InicioEjeYFase = value;
            }
        }

        /// <summary>
        /// Fin del eje Y de fase.
        /// </summary>
        private double _FinEjeYFase;
        public double FinEjeYFase
        {
            get
            {
                return _FinEjeYFase;
            }
            set
            {
                _FinEjeYFase = value;
            }
        }

        /// <summary>
        /// Lista de curvas individuales.
        /// </summary>
        private List<Curva> _CurvasIndividuales;
        public List<Curva> CurvasIndividuales
        {
            get
            {
                return _CurvasIndividuales;
            }
            set
            {
                _CurvasIndividuales = value;
            }
        }

        /// <summary>
        /// Lista de curvas parciales, cada una compuesta por la suma
        /// algebraica de todas las curvas individuales anteriores.
        /// </summary>
        private List<Curva> _CurvasParciales;
        public List<Curva> CurvasParciales
        {
            get
            {
                return _CurvasParciales;
            }
            set
            {
                _CurvasParciales = value;
            }
        }

        /// <summary>
        /// Cruce de ganancia.
        /// </summary>
        private Nullable<double>[,] _CruceGanancia;
        public Nullable<double>[,] CruceGanancia
        {
            get
            {
                return _CruceGanancia;
            }
            set
            {
                _CruceGanancia = value;
            }
        }

        /// <summary>
        /// Cruce de fase.
        /// </summary>
        private Nullable<double>[,] _CruceFase;
        public Nullable<double>[,] CruceFase
        {
            get
            {
                return _CruceFase;
            }
            set
            {
                _CruceFase = value;
            }
        }

        /// <summary>
        /// Margen de fase.
        /// </summary>
        private Nullable<double> _MargenFase;
        public  Nullable<double> MargenFase
        {
            get
            {
                return _MargenFase;
            }
            set
            {
                _MargenFase = value;
            }
        }

        /// <summary>
        /// Margen de ganancia.
        /// </summary>
        private Nullable<double> _MargenGanancia;
        public Nullable<double> MargenGanancia
        {
            get
            {
                return _MargenGanancia;
            }
            set
            {
                _MargenGanancia = value;
            }
        }

        /// <summary>
        /// Coordenadas del ancho de banda.
        /// </summary>
        private double[] _anchoBanda;
        public double[] AnchoBanda
        {
            get
            {
                return _anchoBanda;
            }
            set
            {
                _anchoBanda = value;
            }
        }



        #endregion

        /// <summary>
        /// Calcula los valores de inicio y fin de los ejes, los márgenes, cruces, y genera las
        /// curvas individuales y parciales. Luego de la llamada a esta función, se podrá obtener mediante
        /// las propiedades de esta clase, todos los valores recién descritos.
        /// </summary>
        /// <param name="k">Constante real.</param>
        /// <param name="n1">Orden del Cero en el Origen.</param>
        /// <param name="T1">Constante de tiempo del primer Cero Simple.</param>
        /// <param name="T2">Constante de tiempo del segundo Cero Simple.</param>
        /// <param name="Td">Retardo de tiempo.</param>
        /// <param name="n2">Orden del Polo en el Origen.</param>
        /// <param name="T3">Constante de tiempo del primer Polo Simple.</param>
        /// <param name="T4">Constante de tiempo del segundo Polo Simple.</param>
        /// <param name="Wn">Frecuencia natural amortiguada.</param>
        /// <param name="psi">Coeficiente de amortiguamiento.</param>
        public ControladorBode(Nullable<double> k, Nullable<double> n1, Nullable<double> T1, Nullable<double> T2,
             Nullable<double> Td, Nullable<double> n2, Nullable<double> T3, Nullable<double> T4, Nullable<double> Wn, Nullable<double> psi)
        {
            this.CurvasIndividuales = new List<Curva>();
            this.CurvasParciales = new List<Curva>();
            CruceGanancia = new Nullable<double>[2,2];
            CruceFase = new Nullable<double>[2,2];
            
            #region Generación de curvas individuales y puntos de corte

		    //En cada curva generamos los puntos de magnitud y fase, y el punto de corte.

            //Primero generamos la Constante Real.
            if (k != null)
            {
                Curva curva = new Curva();

                ConstanteReal funcion = new ConstanteReal();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)k) });
                    puntosFase.Add(new double[] { w, funcion.fase() });
                }

                curva.Nombre = "Constante real";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = null;

                this.CurvasIndividuales.Add(curva);
            }

            //Luego generamos todas las curvas que tienen punto de corte.
            if (n1 != null)
            {
                Curva curva = new Curva();

                CeroOrigen funcion = new CeroOrigen();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)n1, (double)w) });
                    puntosFase.Add(new double[] { w, funcion.fase((double)n1) });
                }

                curva.Nombre = "Cero en el origen";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = funcion.puntoCorte();

                this.CurvasIndividuales.Add(curva);
            }

            if(T1 != null)
            {
                Curva curva = new Curva();

                CeroSimple funcion  = new CeroSimple();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)T1, (double)w) });
                    puntosFase.Add(new double[] { w, funcion.fase((double)T1, (double)w) });
                }

                curva.Nombre = "Cero simple";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = funcion.puntoCorte((double)T1);

                this.CurvasIndividuales.Add(curva);
            }

            if(T2 != null)
            {
                Curva curva = new Curva();

                CeroSimple funcion  = new CeroSimple();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)T2, (double)w) });
                    puntosFase.Add(new double[] { w, funcion.fase((double)T2, (double)w) });
                }

                curva.Nombre = "Cero simple";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = funcion.puntoCorte((double)T2);

                this.CurvasIndividuales.Add(curva);
            }

            if(n2 != null)
            {
                Curva curva = new Curva();

                PoloOrigen funcion  = new PoloOrigen();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)n2, (double)w) });
                    puntosFase.Add(new double[] { w, funcion.fase((double)n2) });
                }

                curva.Nombre = "Polo en el origen";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = funcion.puntoCorte();

                this.CurvasIndividuales.Add(curva);
            }

            if(T3 != null)
            {
                Curva curva = new Curva();

                PoloSimple funcion  = new PoloSimple();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)T3, (double)w) });
                    puntosFase.Add(new double[] { w, funcion.fase((double)T3, (double)w) });
                }

                curva.Nombre = "Polo simple";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = funcion.puntoCorte((double)T3);

                this.CurvasIndividuales.Add(curva);
            }

            if(T4 != null)
            {
                Curva curva = new Curva();

                PoloSimple funcion  = new PoloSimple();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)T4, (double)w) });
                    puntosFase.Add(new double[] { w, funcion.fase((double)T4, (double)w) });
                }

                curva.Nombre = "Polo simple";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = funcion.puntoCorte((double)T4);

                this.CurvasIndividuales.Add(curva);
            }

            if(Wn != null && psi != null)
            {
                Curva curva = new Curva();

                PoloCuadratico funcion  = new PoloCuadratico();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud((double)Wn, (double)psi, (double)w) });
                    puntosFase.Add(new double[] { w, funcion.fase((double)Wn, (double)psi, (double)w) });
                }

                curva.Nombre = "Polo cuadrático";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = funcion.puntoCorte((double)Wn, (double)psi);

                this.CurvasIndividuales.Add(curva);
            }

            //Por último generamos el Retardo Puro.
            if(Td != null)
            {
                Curva curva = new Curva();

                RetardoPuro funcion  = new RetardoPuro();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (double w = this.InicioEjeX; w <= this.FinEjeX; w += (this.FinEjeX - this.FinEjeYMagnitud) / CANT_PUNTOS_A_CALCULAR_EJE_X)
                {
                    puntosMagnitud.Add(new double[] { w, funcion.magnitud() });
                    puntosFase.Add(new double[] { w, funcion.fase((double)Td, (double)w) });
                }

                curva.Nombre = "Retardo puro";
                curva.PuntosMagnitud = puntosMagnitud;
                curva.PuntosFase = puntosFase;
                curva.PuntoCorte = null;

                this.CurvasIndividuales.Add(curva);
            } 

	        #endregion

            #region Ordenamiento de curvas

		    //Reordenamos las curvas individuales según la abscisa de su punto de corte,
            //dejando fijas, si existen, la Constante Real (primer curva) en el primer lugar, y el 
            //Retardo Puro (última curva) en el último lugar.
            if (this.CurvasIndividuales.Count > 0)
	        {
                //Utilizamos las curvas que tienen punto de corte.
		        List<Curva> curvasConPuntoCorte = new List<Curva>();
                for(int indiceCurva = 0; indiceCurva < this.CurvasIndividuales.Count; indiceCurva++)
                {
                    if(this.CurvasIndividuales[indiceCurva].PuntoCorte != null)
                        curvasConPuntoCorte.Add(this.CurvasIndividuales[indiceCurva]);
                } 

                //Ordenamos las curvas de la colección temporal.
                Curva curvaAuxiliar = new Curva();
                for (int i = 1; i < curvasConPuntoCorte.Count; i++)
                {
                    for (int j = 0; j < curvasConPuntoCorte.Count - i; j++)
                    {
                        if (curvasConPuntoCorte[j].PuntoCorte[0] > curvasConPuntoCorte[j + 1].PuntoCorte[0])
                        {
                            curvaAuxiliar = curvasConPuntoCorte[j];
                            curvasConPuntoCorte[j] = curvasConPuntoCorte[j + 1];
                            curvasConPuntoCorte[j + 1] = curvaAuxiliar;
                        }
                    }
                }

                //Reemplazamos las curvas índividuales con las curvas ordenadas.
                int indiceCurvaConPuntoCorte = 0;
                for(int indiceCurva = 0; indiceCurva < this.CurvasIndividuales.Count; indiceCurva++)
                {
                    if(this.CurvasIndividuales[indiceCurva].PuntoCorte != null)
                    {
                        this.CurvasIndividuales[indiceCurva] = curvasConPuntoCorte[indiceCurvaConPuntoCorte];
                        indiceCurvaConPuntoCorte++;
                    }
                }
	        } 

	        #endregion

            #region Generación de curvas parciales

		    //Sumamos todos los puntos Y de las curvas de manera progresiva, hasta llegar
            // a la última curva. En ese momento, la última curva parcial conforma la curva final.
            for (int indiceCurvaSuperior = 0; indiceCurvaSuperior < this.CurvasIndividuales.Count; indiceCurvaSuperior++)
            {
                Curva curvaParcial = new Curva();
                List<double[]> puntosMagnitud = new List<double[]>();
                List<double[]> puntosFase = new List<double[]>();

                for (int indicePunto = 0; indicePunto < this.CurvasIndividuales[indiceCurvaSuperior].PuntosMagnitud.Count; indicePunto++)
                {
                    double ySumado = 0;

                    for (int indiceCurvaInferior = 0; indiceCurvaInferior <= indiceCurvaSuperior; indiceCurvaInferior++)
                        ySumado += this.CurvasIndividuales[indiceCurvaInferior].PuntosMagnitud[indicePunto][1];

                    puntosMagnitud.Add(new double[] { this.CurvasIndividuales[indiceCurvaSuperior].PuntosMagnitud[indicePunto][0], ySumado });
                }

                for (int indicePunto = 0; indicePunto < this.CurvasIndividuales[indiceCurvaSuperior].PuntosFase.Count; indicePunto++)
                {
                    double ySumado = 0;

                    for (int indiceCurvaInferior = 0; indiceCurvaInferior <= indiceCurvaSuperior; indiceCurvaInferior++)
                        ySumado += this.CurvasIndividuales[indiceCurvaInferior].PuntosFase[indicePunto][1];

                    puntosFase.Add(new double[] { this.CurvasIndividuales[indiceCurvaSuperior].PuntosFase[indicePunto][0], ySumado });
                }

                curvaParcial.Nombre = "Curva parcial";
                curvaParcial.PuntosMagnitud = puntosMagnitud;
                curvaParcial.PuntosFase = puntosFase;

                this.CurvasParciales.Add(curvaParcial);
            } 

	        #endregion

            #region Cálculo de inicios y fin de los eje Y

            if (this.CurvasIndividuales.Count > 0 && this.CurvasParciales.Count > 0)
            {
                double yMinMagnitud = this.CurvasIndividuales[0].PuntosMagnitud[0][1];
                double yMaxMagnitud = this.CurvasIndividuales[0].PuntosMagnitud[0][1];
                //double yMinFase = this.CurvasIndividuales[0].PuntosFase[0][1];
                double yMinFase = -360;
                double yMaxFase = this.CurvasIndividuales[0].PuntosFase[0][1];

                //Recorremos todos los puntos de fase y magnitud de las curvas individuales y parciales,
                //buscando los valores máximo y mínimo. Usamos el mismo índice de curva para todas las curvas
                //ya que sabemos que todas ellas tienen el mismo tamaño.
                //Tener en cuenta que los valores mínimo y máximo deben ser separados, dos para magnitud y
                //dos para fase.
                for (int indiceCurva = 0; indiceCurva < this.CurvasIndividuales.Count; indiceCurva++)
                {
                    for (int indicePunto = 0; indicePunto < this.CurvasIndividuales[indiceCurva].PuntosMagnitud.Count; indicePunto++)
                    {
                        //Verificamos las curvas individuales.
                        if (this.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][1] < yMinMagnitud)
                            yMinMagnitud = this.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][1];

                        if (this.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][1] > yMaxMagnitud)
                            yMaxMagnitud = this.CurvasIndividuales[indiceCurva].PuntosMagnitud[indicePunto][1];

                        //if (this.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][1] < yMinFase)
                        //    yMinFase = this.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][1];

                        if (this.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][1] > yMaxFase)
                            yMaxFase = this.CurvasIndividuales[indiceCurva].PuntosFase[indicePunto][1];

                        //Verificamos las curvas parciales.
                        if (this.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][1] < yMinMagnitud)
                            yMinMagnitud = this.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][1];

                        if (this.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][1] > yMaxMagnitud)
                            yMaxMagnitud = this.CurvasParciales[indiceCurva].PuntosMagnitud[indicePunto][1];

                        //if (this.CurvasParciales[indiceCurva].PuntosFase[indicePunto][1] < yMinFase)
                        //    yMinFase = this.CurvasParciales[indiceCurva].PuntosFase[indicePunto][1];

                        if (this.CurvasParciales[indiceCurva].PuntosFase[indicePunto][1] > yMaxFase)
                            yMaxFase = this.CurvasParciales[indiceCurva].PuntosFase[indicePunto][1];
                    }
                }

                this.InicioEjeYMagnitud = yMinMagnitud - VALOR_ADICIONAL_PARA_INICIO_Y_FIN_MAGNITUD;
                this.FinEjeYMagnitud = yMaxMagnitud + VALOR_ADICIONAL_PARA_INICIO_Y_FIN_MAGNITUD;

                //this.InicioEjeYFase = yMinFase - VALOR_ADICIONAL_INICIO_Y_FIN_FASE_IGUALES;
                this.InicioEjeYFase = yMinFase;
                this.FinEjeYFase = yMaxFase + VALOR_ADICIONAL_INICIO_Y_FIN_FASE_IGUALES;

            }

            #endregion

            # region Calculo Cruce de Ganancia y Fase

            double margen = 0.01;
            
            //Se Obtiene el punto donde la Ganacia cruza el 0
            for (int indicePunto = 0; (indicePunto + 1) < CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud.Count; indicePunto++)
            {
                if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][1] > 0) && (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][1] < 0 ))
                {
                    this.CruceGanancia[0,0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][0]) / 2;
                    this.CruceGanancia[0,1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][1]) / 2;
                    break;
                }

                if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][1] < 0) && (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][1] > 0))
                {
                    this.CruceGanancia[0,0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][0]) /2 ;
                    this.CruceGanancia[0,1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][1]) /2 ;
                    break;
                }
            }

            //Se Calcula el Margen de Fase
            if (CruceGanancia[0,0] != null)
            {
                for (int indicePunto = 0; (indicePunto + 1) < CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase.Count; indicePunto++)
                {
                    if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][0] <= CruceGanancia[0,0] + margen) && (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][0] >= CruceGanancia[0,0] - margen))
                    {
                        this.CruceGanancia[1, 0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][0]) / 2;
                        this.CruceGanancia[1, 1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1]) / 2;
                        
                        //MargenFase =  Math.Round( ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] - 180) * Math.PI) / 180 ,4) ;
                        MargenFase = Math.Round((CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] - (-180)), 2);
                        break;
                    }                    
                }
            }

            for (int indicePunto = 0; (indicePunto + 1) < CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase.Count; indicePunto++)
            {
                if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] > -180) && (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1] < -180))
                {
                    this.CruceFase[0,0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][0]) / 2D;
                    this.CruceFase[0,1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1]) / 2D;
                    break;
                }

                if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] < -180) && (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1] > -180))
                {
                    this.CruceFase[0,0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][0]) / 2;
                    this.CruceFase[0,1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1]) / 2;
                    break;
                }

                if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] > 180) && (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1] < 180))
                {
                    this.CruceFase[0,0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][0]) / 2D;
                    this.CruceFase[0,1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1]) / 2D;
                    break;
                }

                if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] < 180) && (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1] > 180))
                {
                    this.CruceFase[0,0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][0]) / 2;
                    this.CruceFase[0,1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosFase[indicePunto + 1][1]) / 2;
                    break;
                }
            }

            //Se calcula el margen de ganancia
            if (CruceFase[0,0] != null)
            {
                for (int indicePunto = 0; (indicePunto + 1) < CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud.Count; indicePunto++)
                {
                    if ((CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][0] <= CruceFase[0,0] + margen) && (CurvasIndividuales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][0] >= CruceFase[0,0] - margen))
                    {
                        this.CruceFase[1, 0] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][0] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][0]) / 2;
                        this.CruceFase[1, 1] = (CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][1] + CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto + 1][1]) / 2;
                                                
                        MargenGanancia = Math.Round( 0 - CurvasParciales[(CurvasParciales.Count - 1)].PuntosMagnitud[indicePunto][1] ,1);
                        break;
                    }
                }
            }




            #endregion 

            # region Calculo Ancho de Banda
            List<double[]> curvaTotal = CurvasParciales[CurvasParciales.Count - 1].PuntosMagnitud;
            
            //Valor a frecuencia 0 menos 3 db.
            double caidaDbAnchoBanda = curvaTotal[0][1] - 3;
            
            foreach (double[] punto in curvaTotal)
            {
                if (punto[1] <= caidaDbAnchoBanda)
                {
                    AnchoBanda = punto;
                    break;
                }
            }

            #endregion

        }
    }
}