using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Drawing;
using System.Text;
using ZedGraph;

namespace Root_Locus
{
    public class RootLocus : IPropiedadesGrafica
    {
        #region Atributos

        private PointPairList polos;
        private PointPairList ceros;
        private double[][] pYcOrdenados;  //Se guardan los polos y los ceros en un vector ordenados

        PointPairList[] ramasSup;
        PointPairList[] ramasInf;
        List<PointPairList> rectasEje;

        public PointPairList liPtoRuptura;
        public PointPairList liPtoRupturaSalida;
        public double cg; //centro de gravedad
        public List<double> angAsintotas;
        public List<double> kCritico;

        //private PolyLib.Polynomial poliCeros;
        //private PolyLib.Polynomial poliPolos;

        double magnitud = 0.05;
        double precAncho = 0.001;
        int cantAncho = 360;
        int cantIntentos = 2;
        double pasoX = 0.001;
        double limX = 0.360;
        double pasoY = 0.0001;
        double limY = 0.400;

        double limBajadaY = 0.15;

        double precConAng = 0.01745;

        double precK = 0.14;
        double inicioK = 0;
        public double finK = 1700;
        public int cantPtos = 7000;
        
        public int n;  //Cantidad de Polos
        public int m;  //Cantidad de Ceros        

        public PointPairList Polos
        {
            get { return polos; }
            set
            {
                polos = value;
                n = value.Count;
            }  //Se registran la cantidad de polos
        }
        public PointPairList Ceros
        {
            get { return ceros; }
            set
            {
                ceros = value;
                m = value.Count;
            }  //Se registran la cantidad de ceros
        }

        public bool conImaginarios = false;
        #endregion
        
        #region Datos fijos

        private String _titulo;
        public String Titulo
        {
            //devuelve el titulo de la grafica
            get {return _titulo;}
            set {_titulo =value;}
        }

        private String _nombreEjeX;
        public String NombreEjeX
        {
            //devuelve el nombre a rotular en el eje X
            get {return _nombreEjeX;}
            set {_nombreEjeX =value;}
        }

        private String _nombreEjeY;
        public String NombreEjeY
        {
            //devuelve el nombre a rotular en el eje y
            get { return _nombreEjeY; }
            set {_nombreEjeY =value;}
        }

        private bool _logEjeX;
        public bool LogEjeX
        {
            //establece si la escala del eje X es logaritmica
            get { return _logEjeX; }
            set {_logEjeX =value;}
        }

        private bool _logEjeY;
        public bool LogEjeY
        {
            //establece si la escala del eje Y es logaritmica
            get { return _logEjeY; }
            set {_logEjeY =value;}
        }

        private String[] _nombreParametros;
        public String[] NombreParametros
        {
            //devuelve un arreglo con los nombres de los parametros necesarios para generar la grafica
            //los nombres de los parametros se mostraran en la tabla para ingresar los datos
            get { return _nombreParametros; }
            set { _nombreParametros = value; }
        }

        #endregion

        #region Datos calculados

        //los siguientes son datos que obtendran luego de generar la serie de puntos

        public double InicioEjeX
        {
            //determina el valor de inicio del eje X
            get;
            set;
        }

        double _inicioEjeY;
        public double InicioEjeY
        {
            //determina el valor de inicio del eje Y
            get { return _inicioEjeY;}
            set { _inicioEjeY = value ;}
        }

        public double FinEjeX
        {
            //determina el ultimo valor que mostrara el eje X
            get;
            set;
        }

        public double FinEjeY
        {
            //determina el ultimo valor que mostrara el eje Y
            get;
            set;
        }

        #endregion

        #region Constructor
        public RootLocus()
        {
            polos = new PointPairList();
            ceros = new PointPairList();
            
            //Provisorio            
            InicioEjeY = -7;
            FinEjeY = 7;

            InicioEjeX = -7;
            FinEjeX = 7;
            
        }
        #endregion
        
        #region Metodos

        public List<PointPairList> lineasAmortiguacionCte()
        {
            List<PointPairList> lineasAmortiguacionCte = new List<PointPairList>();

            //Defino el tamaño máximo de la compenente X de las líneas
            //como porcentaje de la longitud del eje X.
            double MaxComponenteX = 0.5 * this.InicioEjeX;
            //Defino el paso entre los puntos de las líneas.
            double pasoLineas = 0.01;
            
            for (int i = 0; i < 5; i++)
            {
                lineasAmortiguacionCte.Add(new PointPairList());
                lineasAmortiguacionCte[i].Add(0, 0);
                double psi = 0.2 * i + 0.1;
                
                for (double j = pasoLineas; j < 1+pasoLineas; j += pasoLineas)
                {
                    lineasAmortiguacionCte[i].Add(MaxComponenteX * j, Math.Abs(MaxComponenteX * j * Math.Tan(Math.Acos(psi)))); 
                }
            }

            return lineasAmortiguacionCte;
        }
        
        public List<PointPairList> asintotas()
        {
            List<PointPairList> asintotas = new List<PointPairList>();
            angAsintotas = new List<double>();
            
            cg = calculaCentroGravedad();
            PointPair ptoCG = new PointPair(cg,0);

            for (int k = 0; k < n - m; k++)
            {
                double ang = Math.PI * (2 * k + 1) / (n - m);
                angAsintotas.Add(ang);

                //Si el angulo esta entre 0º y 90º
                if (ang > 0 && ang < (Math.PI / 2))
                {
                    double x = cg + (FinEjeY / Math.Tan(ang));
                    double y = FinEjeY;

                    if (x > FinEjeX)
                    {
                        x = FinEjeX;
                        y = Math.Tan(ang) * (FinEjeX - cg);
                    }

                    PointPair pto = new PointPair(x, y);
                    PointPairList lista = new PointPairList();
                    lista.Add(ptoCG);
                    lista.Add(pto);
                    asintotas.Add(lista);

                    y = y * -1;
                    pto = new PointPair(x, y);
                    lista = new PointPairList();
                    lista.Add(ptoCG);
                    lista.Add(pto);
                    asintotas.Add(lista);
                }
                //Si el angulos esta entre 90º y 180º
                else if (ang > (Math.PI / 2) && ang < Math.PI)
                {
                    double nuevoAng = Math.PI - ang;

                    double x = cg - (FinEjeY / Math.Tan(nuevoAng));
                    double y = FinEjeY;

                    if (x < InicioEjeX)
                    {
                        x = InicioEjeX;
                        y = Math.Tan(nuevoAng) * (cg - InicioEjeX);
                    }

                    PointPair pto = new PointPair(x, y);
                    PointPairList lista = new PointPairList();
                    lista.Add(ptoCG);
                    lista.Add(pto);
                    asintotas.Add(lista);

                    y = y * -1;
                    pto = new PointPair(x, y);
                    lista = new PointPairList();
                    lista.Add(ptoCG);
                    lista.Add(pto);
                    asintotas.Add(lista);
                }
                //Si el angulo es 90º la asintota es vertical
                else if (ang == (Math.PI / 2))
                {
                    PointPairList lista = new PointPairList();

                    PointPair pto = new PointPair(cg, FinEjeY);
                    lista.Add(pto);

                    pto = new PointPair(cg, InicioEjeY);
                    lista.Add(pto);

                    asintotas.Add(lista);
                }
                //Si el angulo es 0º o 180º no hay asintotas visibles (estan sobre el eje X)
                else if (ang == 0 || ang == Math.PI)
                {
                }
            }

            return asintotas;       
        }

        public List<PointPairList> rectasEjeReal()
        {
            rectasEje = new List<PointPairList>();
            PointPairList semiRecta = new PointPairList();

            if ((n + m) % 2 != 0)                   //Si el numero de ceros y polos es Impar la ultima raiz va hacia el infinito
            {
                for (int i = 0; i < pYcOrdenados[0].Length-1; i += 2)      //Se los agrupa en pares y se crean rectas 
                {
                    semiRecta.Clear();
                    for (double d = pYcOrdenados[0][i]; d >= pYcOrdenados[0][i + 1]; d -= pasoX)
                    {
                        PointPair pto = new PointPair(d, 0);
                        pto.Z = calculaK(pto);
                        semiRecta.Add(pto);
                    }
                    rectasEje.Add(semiRecta.Clone());
                }
                //Esta raiz queda sola y va hacia el infinito
                semiRecta.Clear();
                for (double d = pYcOrdenados[0][pYcOrdenados[0].Length-1]; d >= this.InicioEjeX; d-= pasoX)
                {
                    PointPair pto = new PointPair(d, 0);
                    pto.Z = calculaK(pto);
                    semiRecta.Add(pto);
                }
                rectasEje.Add(semiRecta.Clone());
            }
            else
            {
                for (int i = 0; i < pYcOrdenados[0].Length; i += 2)      //Se los agrupa en pares y se crean rectas        
                {
                    semiRecta.Clear();
                    for (double d = pYcOrdenados[0][i]; d >= pYcOrdenados[0][i + 1]; d -= pasoX)
                    {
                        PointPair pto = new PointPair(d, 0);
                        pto.Z = calculaK(pto);
                        semiRecta.Add(pto);
                    }
                    rectasEje.Add(semiRecta.Clone());
                }
                    
            }

            return rectasEje;
        }

        public List<PointPairList> rectasLocus()
        {
            List<PointPairList> curvas = new List<PointPairList>();
            iniciarRamas();

            if (n == 2 && m == 0) //Controlador Proporcional
            {
                PointPair p = new PointPair(cg, 0.1);
                p.Z = calculaK(p);
                ramasSup[0].Add(p);
                ramasInf[0].Add(p.X, -p.Y, p.Z);
                p = new PointPair(cg, FinEjeY);
                p.Z = calculaK(p);
                ramasSup[0].Add(p);
                ramasInf[0].Add(p.X, -p.Y, p.Z);

                curvas.Add(ramasSup[0]);
                curvas.Add(ramasInf[0]);
            }
            else
            for (int i = 0; i < liPtoRupturaSalida.Count; i++)
            {
                cambiarDireccion(liPtoRupturaSalida[i], 1, i);
                //busqueda(liPtoRuptura[i], i);

                curvas.Add(ramasSup[i]);
                curvas.Add(ramasInf[i]);
            }

            return curvas;
        }
     
        private void cambiarDireccion(PointPair ultPunto, int dir, int nroRama)
        {
            switch (dir)
            {
                case 1: arrDer(ultPunto, nroRama); break;
                case 2: arrIzq(ultPunto, nroRama); break;
                case 3: abaIzq(ultPunto, nroRama); break;
                case 4: abaDer(ultPunto, nroRama); break;
                default: break;
            }
        }

        private void arrDer(PointPair ultPunto, int nroRama)
        {
            bool limite = false;
            bool encontro = false;

            double re = ultPunto.X;            
            while ((re<FinEjeX) && (re>InicioEjeX) && (ultPunto.Y < FinEjeY)) 
            {
                for (double im = (ultPunto.Y + pasoY); im < (ultPunto.Y + limY) && im > 0; im += pasoY)
                {
                    im = Math.Round(im, 5);
                    if (verificaCondAng(new PointPair(re, im)))
                    {                        
                        PointPair nuevo = new PointPair(re, im);
                        nuevo.Z = calculaK(nuevo);
                        ramasSup[nroRama].Add(nuevo);
                        ramasInf[nroRama].Add(new PointPair(re, (-1 * im), nuevo.Z));
                        ultPunto = nuevo;
                        if(!encontro) encontro = true;
                        break;
                    }
                }
                re += pasoX;
                if(re >= ultPunto.X + limX)
                {
                    limite = true;
                    break;
                }
                if (conImaginarios)
                    if (Math.Abs(ultPunto.Y - ceros[0].Y) < limBajadaY && Math.Abs(ultPunto.X - ceros[0].X) < limX)
                    {
                        ramasSup[nroRama].Add(ceros[0]);
                        ramasInf[nroRama].Add(ceros[1]);
                        if (!encontro) encontro = true;
                        break;
                    }
            }

            int totPuntos = (ramasSup[nroRama].Count-1);
            PointPair ptoBase = ramasSup[nroRama][totPuntos];
            if (!encontro)
            {
                if (totPuntos == 0)
                    cambiarDireccion(ptoBase, 3, nroRama);
                else
                    cambiarDireccion(ptoBase, 2, nroRama);
            }
            else
            {
                if (limite)
                    cambiarDireccion(ptoBase, 2, nroRama);
            }
        }

        private void arrIzq(PointPair ultPunto,int nroRama)
        {
            bool limite = false;
            bool encontro = false;

            double re = ultPunto.X;
            while ((re < FinEjeX) && (re > InicioEjeX) && (ultPunto.Y < FinEjeY))
            {
                for (double im = (ultPunto.Y + pasoY); im < (ultPunto.Y + limY) && im > 0; im += pasoY)
                {
                    im = Math.Round(im, 5);
                    if (verificaCondAng(new PointPair(re, im)))
                    {
                        PointPair nuevo = new PointPair(re, im);
                        nuevo.Z = calculaK(nuevo);
                        ramasSup[nroRama].Add(nuevo);
                        ramasInf[nroRama].Add(new PointPair(re, (-1 * im), nuevo.Z));
                        ultPunto = nuevo;
                        if (!encontro) encontro = true;
                        break;
                    }
                }
                re -= pasoX;
                if (re <= ultPunto.X - limX)
                {
                    limite = true;
                    break;
                }

                if (conImaginarios)
                    if (Math.Abs(ultPunto.Y - ceros[0].Y) < limBajadaY && Math.Abs(ultPunto.X - ceros[0].X) < limX)
                    {
                        ramasSup[nroRama].Add(ceros[0]);
                        ramasInf[nroRama].Add(ceros[1]);
                        if (!encontro) encontro = true;
                        break;
                    }
            }

            
            int totPuntos = (ramasSup[nroRama].Count - 1);
            PointPair ptoBase = ramasSup[nroRama][totPuntos];
            if (!encontro)
            {
                if (totPuntos > 0)
                    cambiarDireccion(ptoBase, 4, nroRama);
                else
                    cambiarDireccion(ptoBase, 3, nroRama);
            }
            else
            {
                if (limite)
                    cambiarDireccion(ptoBase, 3, nroRama);
            }
        }

        private void abaIzq(PointPair ultPunto, int nroRama)
        {
            bool limite = false;
            bool encontro = false;

            double re = ultPunto.X;
            while ((re < FinEjeX) && (re > InicioEjeX) && (ultPunto.Y < FinEjeY))
            {
                for (double im = (ultPunto.Y - pasoY); im > (ultPunto.Y - limY) && im > 0; im -= pasoY)
                {
                    im = Math.Round(im, 5);
                    if (verificaCondAng(new PointPair(re, im)))
                    {
                        PointPair nuevo = new PointPair(re, im);
                        nuevo.Z = calculaK(nuevo);
                        ramasSup[nroRama].Add(nuevo);
                        ramasInf[nroRama].Add(new PointPair(re, (-1 * im), nuevo.Z));
                        ultPunto = nuevo;
                        if (!encontro) encontro = true;
                        break;
                    }
                }

                if (ultPunto.Y < limBajadaY)
                {
                    PointPair nuevo = new PointPair(re, 0);
                    nuevo.Z = calculaK(nuevo);
                    ramasSup[nroRama].Add(nuevo);
                    ramasInf[nroRama].Add(nuevo);
                    ultPunto = nuevo;
                    encontro = true;
                    break;
                }

                re -= pasoX;
                if (re <= ultPunto.X - limX)
                {
                    limite = true;
                    break;
                }

                if (conImaginarios)
                    if (Math.Abs(ultPunto.Y - ceros[0].Y) < limBajadaY && Math.Abs(ultPunto.X - ceros[0].X) < limX)
                    {
                        ramasSup[nroRama].Add(ceros[0]);
                        ramasInf[nroRama].Add(ceros[1]);
                        if (!encontro) encontro = true;
                        break;
                    }
            }

            int totPuntos = (ramasSup[nroRama].Count - 1);
            PointPair ptoBase = ramasSup[nroRama][totPuntos];
            if (!encontro)
            {
                if (totPuntos > 0)
                    cambiarDireccion(ptoBase, 1, nroRama);
                else
                    cambiarDireccion(ptoBase, 4, nroRama);
            }
            else
            {
                if (limite)
                    cambiarDireccion(ptoBase, 4, nroRama);
            }
        }

        private void abaDer(PointPair ultPunto, int nroRama)
        {
            bool encontro = false;

            double re = ultPunto.X;
            while ((re < FinEjeX) && (re > InicioEjeX) && (ultPunto.Y < FinEjeY))
            {
                for (double im = (ultPunto.Y - pasoY); im > (ultPunto.Y - limY) && im > 0; im -= pasoY)
                {
                    im = Math.Round(im, 5);
                    if (verificaCondAng(new PointPair(re, im)))
                    {
                        PointPair nuevo = new PointPair(re, im);
                        nuevo.Z = calculaK(nuevo);
                        ramasSup[nroRama].Add(nuevo);
                        ramasInf[nroRama].Add(new PointPair(re, (-1 * im), nuevo.Z));
                        ultPunto = nuevo;
                        if (!encontro) encontro = true;
                        break;
                    }
                }

                if (ultPunto.Y < limBajadaY)
                {
                    PointPair nuevo = new PointPair(re, 0);
                    nuevo.Z = calculaK(nuevo);
                    ramasSup[nroRama].Add(nuevo);
                    ramasInf[nroRama].Add(nuevo);
                    ultPunto = nuevo;
                    encontro = true;
                    break;
                }

                re += pasoX;

                if (conImaginarios)
                    if (Math.Abs(ultPunto.Y - ceros[0].Y) < limBajadaY && Math.Abs(ultPunto.X - ceros[0].X) < limX)
                    {
                        ramasSup[nroRama].Add(ceros[0]);
                        ramasInf[nroRama].Add(ceros[1]);
                        if (!encontro) encontro = true;
                        break;
                    }
            }
        }

        public double calculaK(PointPair ptoLG)
        {
            double valorPolos = 1;
            double valorCeros = 1;

            foreach (PointPair p in polos)
            {
                Vector vec = new Vector(Math.Round(ptoLG.X - p.X, 5), Math.Round(ptoLG.Y - p.Y, 5));
                valorPolos = valorPolos * vec.Length;
            }
            if (!(ceros.Count == 0)) // condicion para verificar que haya ceros, sino hay el valor por defecto de valorceros es 1 y no altera la division 
            {
                foreach (PointPair z in ceros)
                {
                    Vector vec = new Vector(Math.Round(ptoLG.X - z.X, 5), Math.Round(ptoLG.Y - z.Y, 5));
                    valorCeros = valorCeros * vec.Length;
                }
            }

            return Math.Round(valorPolos / valorCeros, 2);
        }

        public PointPair calculaPtoRuptura(double limInf, double limSup)
        {
            double sumaPolos = 0;
            double sumaCeros = 0;
            double ptoRuptura = limInf;

            for (double s = limInf; s <= limSup; s += 0.00001)
            {
                //s = Math.Round(s, 5);
                
                sumaPolos = 0;
                sumaCeros = 0;

                foreach (PointPair p in polos)
                    sumaPolos += (1 / (s - p.X));

                foreach (PointPair z in ceros)
                    sumaCeros += (1 / (s - z.X));

                //sumaCeros = Math.Round(sumaCeros, 2);
                //sumaPolos = Math.Round(sumaPolos, 2);

                //sumaCeros = truncarTresDec(sumaCeros);
                //sumaPolos = truncarTresDec(sumaPolos);

                if (Math.Abs(sumaCeros - sumaPolos) < 0.001)
                {
                    ptoRuptura = s;
                    break;
                }
            }
            return new PointPair(ptoRuptura,0);
        }

        private double truncarTresDec(double nro)
        {
            return ((double)((int)(nro * 1000))) / 1000;
        }

        private double calculaCentroGravedad()
        {
            double sumaPolos = 0;
            double sumaCeros = 0;

            foreach (PointPair p in polos)
                sumaPolos += p.X;

            foreach (PointPair z in ceros)
                sumaCeros += z.X;

            return ((sumaPolos - sumaCeros) / (n - m));   //Formula del Centro de Gravedad          
        }

        private double calculaAng(PointPair p, PointPair Sc)
        {
            Vector vecX = new Vector(1, 0);
            Vector vec = new Vector(Math.Round(Sc.X - p.X, 5), Math.Round(Sc.Y - p.Y, 5));
            //Retorna el angulo entre el vector Sc-p y el eje X
            return Vector.AngleBetween(vec, vecX);
        }

        public bool calculaKCritico()
        {
            kCritico = new List<double>();

            foreach (PointPairList r in ramasSup)
            {
                double ptoRuptura = r[0].X;
                bool ladoNegativo = (ptoRuptura < 0) ? (true) : (false);

                foreach (PointPair pto in r)
                {
                    bool esInestable = (pto.X < 0) ? (true) : (false);
                    if (esInestable != ladoNegativo)
                    {
                        kCritico.Add(pto.Z);
                        ladoNegativo = esInestable;
                    }
                }
            }
            foreach (PointPairList r in rectasEje)
            {
                double ptoRuptura = r[0].X;
                bool ladoNegativo = (ptoRuptura <= 0) ? (true) : (false);

                foreach (PointPair pto in r)
                {
                    bool esInestable = (pto.X <= 0) ? (true) : (false);
                    if (esInestable != ladoNegativo)
                    {
                        kCritico.Add(pto.Z);
                        ladoNegativo = esInestable;
                    }
                }
            }
            bool encontrado = (kCritico.Count == 0)?(false):(true);
            return encontrado;
        }

        public void ordenarPolosYCeros()
        {
            //Provisorio - Esto podria estar en otro lugar mejor
            if (m > 0)
                if (ceros[0].Y > 0)
                    conImaginarios = true;

            pYcOrdenados = new double[2][];

            if (conImaginarios)
            {
                pYcOrdenados[0] = new double[n];
                pYcOrdenados[1] = new double[n];
            }
            else
            {
                pYcOrdenados[0] = new double[n + m];
                pYcOrdenados[1] = new double[n + m];
            }



            for (int i = 0; i < n; i++)
            {
                pYcOrdenados[0][i] = polos[i].X;
                pYcOrdenados[1][i] = 1;                       //A los polos se coloca un uno
            }
            if (!conImaginarios)
            {
                for (int i = n; i < n + m; i++)
                {
                    pYcOrdenados[0][i] = ceros[i - n].X;
                    pYcOrdenados[1][i] = 0;                      //A los ceros se coloca un cero                 
                }
            }

            Array.Sort(pYcOrdenados[0], pYcOrdenados[1]);          //Se lo ordena en forma descendente
            Array.Reverse(pYcOrdenados[0]);
            Array.Reverse(pYcOrdenados[1]);        
        }

        public void resize()
        {
            double primerRaiz = pYcOrdenados[0][0];
            double ultimaRaiz = pYcOrdenados[0][pYcOrdenados[0].Length-1];

            if (ultimaRaiz < 0)
                InicioEjeX = ultimaRaiz - (Math.Abs(0 - ultimaRaiz));
            else
                InicioEjeX = -1D;
            FinEjeX = primerRaiz + 1.5;        
        }
        
        private void iniciarRamas()
        {
            ramasSup = new PointPairList[liPtoRupturaSalida.Count];
            ramasInf = new PointPairList[liPtoRupturaSalida.Count];

            for (int i = 0; i < liPtoRupturaSalida.Count; i++)
            {
                ramasSup[i] = new PointPairList();
                ramasInf[i] = new PointPairList();
                ramasSup[i].Add(liPtoRupturaSalida[i]);
                ramasInf[i].Add(liPtoRupturaSalida[i]);
            }
        }

        public bool PuntoRuptura()
        {
            liPtoRuptura = new PointPairList();
            liPtoRupturaSalida = new PointPairList();
            bool encontrado = false;
            int cant = pYcOrdenados[0].Length;

            for (int i = 0; i < cant - 1; i += 2)      //Se los agrupa en pares y se verifica de que tipo son    
            {
                if (pYcOrdenados[1][i] == pYcOrdenados[1][i + 1] )//Si son los dos Polos o los dos Ceros hay punto de ruptura
                {
                    PointPair p = calculaPtoRuptura(pYcOrdenados[0][i + 1], pYcOrdenados[0][i]);
                    liPtoRuptura.Add(p);
                    encontrado = true;
                    if(pYcOrdenados[1][i] == 1)
                        liPtoRupturaSalida.Add(p);
                }
            }
            //Si hay una rama que va al infinito y la raiz de mas a la izquierda es un cero real --> hay punto de ruptura
            if((n-m)%2!=0 && !conImaginarios && pYcOrdenados[1][cant-1] == 0)
            {
                liPtoRuptura.Add(calculaPtoRuptura(InicioEjeX, pYcOrdenados[0][cant-1]));
                encontrado = true;
            }

            return encontrado;
        }

        public bool verificaCondAng(PointPair Sc)
        {
            double sumaAngCeros = 0;
            double sumaAngPolos = 0;

            //Dado un punto Sc se suman los angulos que forma con cada Cero y Polo
            foreach (PointPair z in ceros)
                sumaAngCeros += calculaAng(z, Sc);
            foreach (PointPair p in polos)
                sumaAngPolos += calculaAng(p, Sc);

            bool respuesta;
            //Si satisface la condicion de angulo se devuelve True, sino False
            //Precision util para flotantes con 5 decimales
            //if (Math.IEEERemainder(Math.Round((sumaAngCeros - sumaAngPolos),3), 180) == 0)
            double aux = Math.Abs(Math.IEEERemainder(Math.Round((sumaAngCeros - sumaAngPolos), 3), 180));
            if (aux < precConAng)
                respuesta = true;
            else
                respuesta = false;

            return respuesta;
        }

        private double normalizar(double a)
        { 
            bool correcto = false;
            while (!correcto)
            {
                if (a < 0)
                    a += 360;
                if (a >= 360)
                    a -= 360;

                if (a >= 0 && a <= 360)
                    correcto = true;
            }

            return a * Math.PI / 180;       
        }
        #endregion       

        #region Obsoleto
        /*  
         * 
        private void busqueda(PointPair ptoRup, int rama)
        {
            PointPair u = ptoRup.Clone();
            PointPair p = new PointPair(ptoRup.X, 0.01); //Agrego un pto arriba del pto ruptura
            double a = Math.PI / 2; //Angulo con respecto al punto anterior

            bool fin = false;
            while (!fin) //En cada iteracion se agrega un punto hasta finalizar
            {
                p.Z = calculaK(p);
                ramasSup[rama].Add(p);  //Agrego el pto encontrado
                ramasInf[rama].Add(p.X, -p.Y, p.Z);

                double aux = normalizar(calculaAng(p, u));   //Calculo el angulo con respecto al pto anterior
                if (Math.Abs(a - aux) >= Math.PI * 30 / 180)
                    a = (a + aux) / 2;
                else
                    a = aux;

                double ang = normalizar(90 - (aux / Math.PI * 180));
                u = p.Clone();          //Reemplazo el ultimo punto con el pto recien encontrado

                bool encontro = false;
                int cont = 1;
                while (!encontro && cont < cantIntentos) //En cada iteracion se intenta un nuevo punto y se lo desplaza hasta que satisfaga la cond de angulo
                {
                    p = u.Clone();
                    //Se intenta con un punto en la misma direccion que el ultimo angulo a una distancia igual a "magnitud"
                    p.X += (Math.Cos(a) * magnitud * cont);
                    p.Y += (Math.Sin(a) * magnitud * cont++);

                    double dif = condAng(p);
                    //Si se satisface la condicion de angulo se finaliza el while interno
                    if (dif < precConAng)
                    {
                        encontro = true;
                        break;
                    }

                    //for (int i = 0; i < cantAncho * cont; i++)
                    for (int i = 0; i < cantAncho; i++)
                    {
                        p.X += Math.Cos(ang) * Math.Pow(-1, i) * i * precAncho;
                        p.Y += Math.Sin(ang) * Math.Pow(-1, i) * i * precAncho;

                        dif = condAng(p);
                        if (dif < precConAng)
                        {
                            encontro = true;
                            break;
                        }
                    }
                }

                //Condiciones de fin
                if (p.X < InicioEjeX || p.X > FinEjeX || p.Y <= 0 || p.Y > FinEjeY) //Limites de grafica
                    fin = true;
                if (conImaginarios)
                    if (Math.Abs(p.Y - ceros[0].Y) < limBajadaY && Math.Abs(p.X - ceros[0].X) < limX)  //se llego a un cero imag
                    {
                        ramasSup[rama].Add(ceros[0]);
                        ramasInf[rama].Add(ceros[1]);
                        fin = true;
                    }
                if (a > Math.PI || a < 0)
                    fin = true;              
                if (ramasSup[rama].Count > 5000)
                    fin = true;
            }
        }

         * public List<PointPairList> rectasLocus2()
        {
            List<PointPairList> curvas = new List<PointPairList>();
            iniciarRamas();

            if (n == 2 && m == 0) //Controlador Proporcional
            {
                PointPair p = new PointPair(cg, 0.1);
                p.Z = calculaK(p);
                ramasSup[0].Add(p);
                ramasInf[0].Add(p.X, -p.Y, p.Z);
                p = new PointPair(cg, FinEjeY);
                p.Z = calculaK(p);
                ramasSup[0].Add(p);
                ramasInf[0].Add(p.X, -p.Y, p.Z);

                curvas.Add(ramasSup[0]);
                curvas.Add(ramasInf[0]);
            }
            else
            {
                for (int i = 0; i < liPtoRuptura.Count; i++)
                {
                    busqueda(liPtoRuptura[i], i);

                    curvas.Add(ramasSup[i]);
                    curvas.Add(ramasInf[i]);
                }
            }

            return curvas;
        }

       
        
        public List<PointPairList> rectasLocus(int metodo)
        {
            //Calcula la precision
            precK = (finK - inicioK) / cantPtos;

            List<PointPairList> curvas = new List<PointPairList>();
            iniciarRamas();

            double k = Math.Round(inicioK, 3);
            while (k < finK)
            {
                //Saca las raices del polinomio dado un valor K
                PolyLib.Polynomial p = poliPolos + (k * poliCeros);
                PolyLib.Complex[] raices = PolyLib.Polynomial.Roots(p);

                foreach (PolyLib.Complex raiz in raices)
                {
                    if (!raiz.IsReal())
                    {
                        if (raiz.Im > 0)
                        {
                            foreach (PointPairList c in ramasSup)
                            {
                                //Saca la distancia del ultimo pto de la rama con la nueva raiz
                                double absX = Math.Abs(c[c.Count - 1].X - raiz.Re);
                                double absY = Math.Abs(c[c.Count - 1].Y - raiz.Im);
                                //Si esta cerca la raiz se agrega a la rama, sino pertenecera a otra rama quizas
                                if (absX < 0.1 && absY < 0.6)
                                    c.Add(new PointPair(raiz.Re, raiz.Im, k));
                            }
                        }
                        else //Si la raiz es imaginaria negativa
                        {
                            foreach (PointPairList c in ramasInf)
                            {
                                double absX = Math.Abs(c[c.Count - 1].X - raiz.Re);
                                double absY = Math.Abs(c[c.Count - 1].Y - raiz.Im);
                                if (absX < 0.1 && absY < 0.6)
                                    c.Add(new PointPair(raiz.Re, raiz.Im, k));
                            }
                        }
                    }
                }

                k += precK;
                k = Math.Round(k, 3);
            }

            foreach (PointPairList r in ramasSup)
                if (r[r.Count - 1].Y < 0.25)
                    r.Add(new PointPair(r[r.Count - 1].X, 0));

            foreach (PointPairList r in ramasInf)
                if (r[r.Count - 1].Y > -0.25)
                    r.Add(new PointPair(r[r.Count - 1].X, 0));


            foreach (PointPairList r in ramasSup)
                curvas.Add(r);
            foreach (PointPairList r in ramasInf)
                curvas.Add(r);

            return curvas;
        }        
         * public double calculaAngPartida()
        {
            //Provisorio
            return 0;
        }

        public void generarPolinomio()
        {
            PolyLib.Polynomial.FactorizedPolynomial fpPolos = new PolyLib.Polynomial.FactorizedPolynomial();
            fpPolos.Factor = new PolyLib.Polynomial[polos.Count];
            fpPolos.Power = new int[polos.Count];

            for (int i = 0; i < polos.Count; i++)
			{	
	            //Se crea el polinomio (s-pi)
                double[] coefs = new double[2];
                coefs[0] = (-1*polos[i].X);
                coefs[1] = 1;
                PolyLib.Polynomial f = new PolyLib.Polynomial(coefs);
                //Se agrega este polinomio a la lista de factores del polinomio factorizado fpPolos
                fpPolos.Factor[i] = f;
                fpPolos.Power[i] = 1;
            }
            poliPolos = new PolyLib.Polynomial();
            poliPolos = PolyLib.Polynomial.Expand(fpPolos);
            

            if (ceros.Count != 0)
            {
                PolyLib.Polynomial.FactorizedPolynomial fpCeros = new PolyLib.Polynomial.FactorizedPolynomial();
                fpCeros.Factor = new PolyLib.Polynomial[ceros.Count];
                fpCeros.Power = new int[ceros.Count];
                
                for (int i = 0; i < ceros.Count; i++)
                {
                    //Se crea el polinomio (s-zi)
                    double[] coefs = new double[2];
                    coefs[0] = (-1 * ceros[i].X);
                    coefs[1] = 1;
                    PolyLib.Polynomial f = new PolyLib.Polynomial(coefs);
                    //Se agrega este polinomio a la lista de factores del polinomio factorizado fpCeros
                    fpCeros.Factor[i] = f;
                    fpCeros.Power[i] = 1;
                }

                poliCeros = new PolyLib.Polynomial();
                poliCeros = PolyLib.Polynomial.Expand(fpCeros);
            }
            else
            {
               poliCeros = new PolyLib.Polynomial(1d);                
            }
        }
         * 
         * public List<PointPairList> asintotas()
        {
            List<PointPairList> asintotas = new List<PointPairList>();

            cg = calculaCentroGravedad();

            PointPair ptoCG = new PointPair(cg, 0);

            double ang = Math.PI / (n - m); //Calcula el angulo de la 1º asintota

            //Si el angulo esta entre 0º y 90º
            if (ang > 0 && ang < (Math.PI / 2))
            {
                double x = cg + (FinEjeY / Math.Tan(ang));
                double y = FinEjeY;

                if (x > FinEjeX)
                {
                    x = FinEjeX;
                    y = Math.Tan(ang) * (FinEjeX - cg);
                }

                PointPair pto = new PointPair(x, y);
                PointPairList lista = new PointPairList();
                lista.Add(ptoCG);
                lista.Add(pto);
                asintotas.Add(lista);

                y = y * -1;
                pto = new PointPair(x, y);
                lista = new PointPairList();
                lista.Add(ptoCG);
                lista.Add(pto);
                asintotas.Add(lista);
            }
            //Si el angulos esta entre 90º y 180º
            else if (ang > (Math.PI / 2) && ang < Math.PI)
            {
                double nuevoAng = Math.PI - ang;

                double x = cg - (FinEjeY / Math.Tan(nuevoAng));
                double y = FinEjeY;

                if (x < InicioEjeX)
                {
                    x = InicioEjeX;
                    y = Math.Tan(nuevoAng) * (cg - InicioEjeX);
                }

                PointPair pto = new PointPair(x, y);
                PointPairList lista = new PointPairList();
                lista.Add(ptoCG);
                lista.Add(pto);
                asintotas.Add(lista);

                y = y * -1;
                pto = new PointPair(x, y);
                lista = new PointPairList();
                lista.Add(ptoCG);
                lista.Add(pto);
                asintotas.Add(lista);
            }
            //Si el angulo es 90º la asintota es vertical
            else if (ang == (Math.PI / 2))
            {
                PointPairList lista = new PointPairList();

                PointPair pto = new PointPair(cg, FinEjeY);
                lista.Add(pto);

                pto = new PointPair(cg, InicioEjeY);
                lista.Add(pto);

                asintotas.Add(lista);
            }
            //Si el angulo es 0º o 180º no hay asintotas visibles (estan sobre el eje X)
            else if (ang == 0 || ang == Math.PI)
            {
            }

            return asintotas;
        }
        
        */
        #endregion

    }
}
