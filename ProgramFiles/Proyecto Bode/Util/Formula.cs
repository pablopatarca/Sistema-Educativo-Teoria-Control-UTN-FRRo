using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Util
{
    [Serializable]
    public class Formula
    {
        /// <summary>
        /// Título de la fórmula, por ejemplo "Fórmula del ejemplo 18.5".
        /// </summary>
        private string _Titulo;
        public string Titulo
        {
            get
            {
                return _Titulo;
            }
            set
            {
                _Titulo = value;
            }
        }

        /// <summary>
        /// Descripción de la fórmula, por ejemplo "Corresponde a un sistema con margen infinito...".
        /// </summary>
        private string _Descripcion;
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }
        }

        /// <summary>
        /// Constante real.
        /// </summary>
        private Nullable<double> _K;
        public Nullable<double> K
        {
            get
            {
                return _K;
            }
            set
            {
                _K = value;
            }
        }

        /// <summary>
        /// Orden del Cero en el Origen.
        /// </summary>
        private Nullable<double> _N1;
        public Nullable<double> N1
        {
            get
            {
                return _N1;
            }
            set
            {
                _N1 = value;
            }
        }

        /// <summary>
        /// Constante de tiempo del primer Cero Simple.
        /// </summary>
        private Nullable<double> _T1;
        public Nullable<double> T1
        {
            get
            {
                return _T1;
            }
            set
            {
                _T1 = value;
            }
        }

        /// <summary>
        /// Constante de tiempo del segundo Cero Simple.
        /// </summary>
        private Nullable<double> _T2;
        public Nullable<double> T2
        {
            get
            {
                return _T2;
            }
            set
            {
                _T2 = value;
            }
        }

        /// <summary>
        /// Retardo de Tiempo.
        /// </summary>
        private Nullable<double> _Td;
        public Nullable<double> Td
        {
            get
            {
                return _Td;
            }
            set
            {
                _Td = value;
            }
        }

        /// <summary>
        /// Orden del Polo en el Origen.
        /// </summary>
        private Nullable<double> _N2;
        public Nullable<double> N2
        {
            get
            {
                return _N2;
            }
            set
            {
                _N2 = value;
            }
        }

        /// <summary>
        /// Constante de tiempo del primer Polo Simple.
        /// </summary>
        private Nullable<double> _T3;
        public Nullable<double> T3
        {
            get
            {
                return _T3;
            }
            set
            {
                _T3 = value;
            }
        }

        /// <summary>
        /// Constante de tiempo del segundo Polo Simple.
        /// </summary>
        private Nullable<double> _T4;
        public Nullable<double> T4
        {
            get
            {
                return _T4;
            }
            set
            {
                _T4 = value;
            }
        }

        /// <summary>
        /// Frecuencia natural amortiguada.
        /// </summary>
        private Nullable<double> _Wn;
        public Nullable<double> Wn
        {
            get
            {
                return _Wn;
            }
            set
            {
                _Wn = value;
            }
        }

        /// <summary>
        /// Coeficiente de amortiguamiento.
        /// </summary>
        private Nullable<double> _Psi;
        public Nullable<double> Psi
        {
            get
            {
                return _Psi;
            }
            set
            {
                _Psi = value;
            }
        }

        /// <summary>
        /// Obtiene todas las fórmulas que son persistentes.
        /// </summary>
        /// <returns>Lista de fórmulas.</returns>
        public static List<Formula> getAll()
        {
            List<Formula> formulas = new List<Formula>();

            if (File.Exists(obtenerRutaArchivo()))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream streamLectura = new FileStream(obtenerRutaArchivo(), FileMode.Open);
                formulas = (List<Formula>)formatter.Deserialize(streamLectura);
                streamLectura.Close();
            }

            return formulas;
        }

        /// <summary>
        /// Guarda una fórmula.
        /// </summary>
        /// <param name="formula">Fórmula a guardar.</param>
        public static void save(Formula formula)
        {
            //Leemos todas las fórmulas.
            List<Formula> formulas = getAll();

            //Agregamos la fórmula a la colección.
            formulas.Add(formula);

            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists(obtenerRutaArchivo()))
            {
                //Vaciamos el archivo.
                File.WriteAllText(obtenerRutaArchivo(), string.Empty);

                FileStream streamEscritura = new FileStream(obtenerRutaArchivo(), FileMode.Append);
                formatter.Serialize(streamEscritura, formulas);
                streamEscritura.Close();
            }
            else
            {
                FileStream streamEscritura = new FileStream(obtenerRutaArchivo(), FileMode.Create);
                formatter.Serialize(streamEscritura, formulas);
                streamEscritura.Close();
            }
        }

        /// <summary>
        /// Actualiza una fórmula.
        /// </summary>
        /// <param name="formula">Fórmula a actualizar.</param>
        public static void update(Formula formula)
        {
            //Leemos todas las fórmulas.
            List<Formula> formulas = getAll();

            if (formulas.Count > 0)
            {
                //Buscamos la fórmula según su título y la editamos.
                for (int indiceEjemplo = 0; indiceEjemplo < formulas.Count; indiceEjemplo++)
                {
                    if (formulas[indiceEjemplo].Titulo.Equals(formula.Titulo))
                    {
                        formulas[indiceEjemplo].Descripcion = formula.Descripcion;
                        formulas[indiceEjemplo].K = formula.K;
                        formulas[indiceEjemplo].N1 = formula.N1;
                        formulas[indiceEjemplo].T1 = formula.T1;
                        formulas[indiceEjemplo].T2 = formula.T2;
                        formulas[indiceEjemplo].Td = formula.Td;
                        formulas[indiceEjemplo].N2 = formula.N2;
                        formulas[indiceEjemplo].T3 = formula.T3;
                        formulas[indiceEjemplo].T4 = formula.T4;
                        formulas[indiceEjemplo].Wn = formula.Wn;
                        formulas[indiceEjemplo].Psi = formula.Psi;

                        break;
                    }
                }

                //Vaciamos el archivo.
                File.WriteAllText(obtenerRutaArchivo(), string.Empty);

                //Guardamos la colección con la fórmula editada.
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream streamEscritura = new FileStream(obtenerRutaArchivo(), FileMode.Append);
                formatter.Serialize(streamEscritura, formulas);
                streamEscritura.Close();
            }
        }

        /// <summary>
        /// Elimina una fórmula.
        /// </summary>
        /// <param name="formula">Fórmula a eliminar.</param>
        public static void delete(Formula formula)
        {
            //Leemos todas las fórmulas.
            List<Formula> formulas = getAll();

            if (formulas.Count > 0)
            {
                //Buscamos la fórmula según su título y lo eliminamos.
                for (int indiceEjemplo = 0; indiceEjemplo < formulas.Count; indiceEjemplo++)
                {
                    if (formulas[indiceEjemplo].Titulo.Equals(formula.Titulo))
                    {
                        formulas.RemoveAt(indiceEjemplo);
                        break;
                    }
                }

                //Vaciamos el archivo.
                File.WriteAllText(obtenerRutaArchivo(), string.Empty);

                //Guardamos la colección con la fórmula eliminada.
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream streamEscritura = new FileStream(obtenerRutaArchivo(), FileMode.Append);
                formatter.Serialize(streamEscritura, formulas);
                streamEscritura.Close();
            }
        }

        /// <summary>
        /// Obtiene la ruta del archivo donde se almacenan las fórmulas.
        /// </summary>
        /// <returns>Ruta del archivo.</returns>
        private static string obtenerRutaArchivo()
        {
            string ruta = Path.Combine(Environment.CurrentDirectory, Recursos.nombre_carpeta_ejemplos);

            //Si la ruta no existe, creamos la carpeta necesaria para que exista.
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            return Path.Combine(Environment.CurrentDirectory,
                Recursos.nombre_carpeta_ejemplos, Recursos.nombre_archivo_ejemplos);
        }
    }
}
