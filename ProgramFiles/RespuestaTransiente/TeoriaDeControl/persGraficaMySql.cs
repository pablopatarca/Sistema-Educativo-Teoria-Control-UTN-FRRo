using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TeoriaDeControl
{
    class persGraficaMySql : persistirGrafica
    {
        /// <summary>
        /// inicializa el tipo de entrada que se usará y los titulos que se usarán
        /// </summary>
        /// <param name="tipo"></param>
        public persGraficaMySql(String tipo)
        {
            this.tipo = tipo;
            this.datosGrafica = this.getDatosGrafica();
        }

        /// <summary>
        /// Cadena de conexión al servidor
        /// </summary>
        protected string connectionString
        {
            get
            {
                return "server=localhost;database=TCEducativo;uid=root;";
            }
        }

        /// <summary>
        /// Devuelve todos los titulos de graficas guardadas del tipo de entrada en que se encuentra el usuario actualmente
        /// </summary>
        /// <returns></returns>
        public override DataTable getDatosGrafica()
        {
            DataTable respuestas = new DataTable();
            int ult = 0;
                using (MySqlConnection Conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("getRespuestasTipo", Conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("tipo", tipo));
                        cmd.Connection.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                        {
                            respuestas.Load(reader);
                            //obtener el último id de la respuesta y setear el atributo de persistirGrafica
                            try
                            {
                                MySqlCommand cmdUltIdRT = new MySqlCommand("getUltimoIdRespuesta", Conn);
                                cmdUltIdRT.CommandType = CommandType.StoredProcedure;
                                cmdUltIdRT.Parameters.AddWithValue("@id_r", MySqlDbType.Int32);
                                cmdUltIdRT.Parameters["@id_r"].Direction = ParameterDirection.Output;
                                cmdUltIdRT.ExecuteNonQuery();
                                ult = (int)cmdUltIdRT.Parameters["@id_r"].Value;
                                ultimoIdRespTransiente = ult;
                            }
                            catch (MySql.Data.MySqlClient.MySqlException e) { ultimoIdRespTransiente = -1; }
                            catch (DataException e) { ultimoIdRespTransiente = -1; }
                            catch (Exception e) { ultimoIdRespTransiente = -1; }
                        }
                        cmd.Connection.Close();                        
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e) 
                    { 
                        //MessageBox.Show("Ha ocurrido un error con la DB: " + e.Data); 
                    }
                    catch (DataException e)
                    {
                        //MessageBox.Show("Ha ocurrido un error con los datos" + e.Data); 
                    }
                    catch (Exception e) 
                    {
                        //MessageBox.Show("Ha ocurrido un error con los datos" + e.Data); 
                    }
                    return respuestas;
                }
        }

        /// <summary>
        /// Devuelve los datos de la gráfica correspondiente al titulo elegido
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
        public override DataTable getDatosGrafica(String titulo)
        {
            using (MySqlConnection Conn = new MySqlConnection(connectionString))
            {
                //Inicializo el procedimiento almacenado
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conn;
                cmd.CommandText = "getRespuesta";
                //agrego los paráemtros
                cmd.Parameters.AddWithValue("tipo", tipo);
                cmd.Parameters.AddWithValue("titulo", titulo);
                Conn.Open();
                //establezco un DataReader para almacenar lo que devuelve el procedimiento
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable respuestas = new DataTable();
                if (reader != null)
                {
                    //cargo lo que devolvió en una tabla denominada respuestas
                    respuestas.Load(reader);
                }
                Conn.Close();
                return respuestas;
            }
        }

        /// <summary>
        /// Verifica si el título ingresado ya existe en la base de datos
        /// </summary>
        /// <param name="titulo">título ingresado</param>
        /// <returns>Retorna true en caso de que exista y false en caso contrario</returns>
        public bool existeTitulo(String titulo)
        {
            DataTable respuestas = new DataTable();
            bool existe = false;
            using (MySqlConnection Conn = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("getRespuestasTipo", Conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("tipo", tipo));
                    cmd.Connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        respuestas.Load(reader);
                    }
                    Conn.Close();

                    foreach (DataRow r in respuestas.Rows)
                    {

                        if (r["titulo"].ToString() == titulo)
                        {
                            existe = true;
                            break;
                        }
                    }

                }
                catch (MySql.Data.MySqlClient.MySqlException e) { MessageBox.Show("Ha ocurrido un error con la base de datos: " + e.Data); }
                this.datosGrafica.AcceptChanges();
            }
            return existe;
        }

        /// <summary>
        /// Aplica los cambios que se han hecho en la tabla para guardarlos en la base de datos
        /// </summary>
        /// <param name="titulo">Título que se le quiere poner para guardarlo</param>
        public override bool aplicarCambios(String titulo)
        {
            //verifico que el titulo no esté en la base de datos
            if (!existeTitulo(titulo))
            {
                using (MySqlConnection Conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        MySqlCommand cmdInsertRespuesta = new MySqlCommand("insertRespuestaGral", Conn);
                        cmdInsertRespuesta.CommandType = CommandType.StoredProcedure;
                        cmdInsertRespuesta.Parameters.Add(new MySqlParameter("tip", tipo));
                        cmdInsertRespuesta.Parameters.Add(new MySqlParameter("tit", titulo));

                        cmdInsertRespuesta.Connection.Open();
                        cmdInsertRespuesta.ExecuteNonQuery();
                        cmdInsertRespuesta.Connection.Close();
                        MySqlCommand cmdInsertarDatos;

                        DataTable filasNuevas = this.datosGrafica;

                        ++ultimoIdRespTransiente;
                        //para cada fila se agregan los datos a la base de datos
                        foreach (DataRow fila in filasNuevas.Rows)
                        {
                            //según el tipo de función de entrada se agregan los diferentes datos que la componen
                            switch (tipo)
                            {
                                case ("Escalon2"):
                                case ("Impulso2"):
                                    cmdInsertarDatos = new MySqlCommand();
                                    cmdInsertarDatos.Connection = Conn;
                                    cmdInsertarDatos.CommandText = "insertEscImp2";
                                    cmdInsertarDatos.CommandType = CommandType.StoredProcedure;

                                    cmdInsertarDatos.Parameters.AddWithValue("@amp", fila["amplitud"]);
                                    cmdInsertarDatos.Parameters["@amp"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@cteT", fila["cteTiempo"]);
                                    cmdInsertarDatos.Parameters["@cteT"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@coefAm", fila["coefAmort"]);
                                    cmdInsertarDatos.Parameters["@coefAm"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@tiempoAs", fila["tiempoAsent"]);
                                    cmdInsertarDatos.Parameters["@tiempoAs"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@id_r", ultimoIdRespTransiente);
                                    cmdInsertarDatos.Parameters["@id_r"].Direction = ParameterDirection.Input;
                                    break;
                                case ("Senoidal1"):
                                    cmdInsertarDatos = new MySqlCommand();
                                    cmdInsertarDatos.Connection = Conn;
                                    cmdInsertarDatos.CommandText = "insertSenoidal1";
                                    cmdInsertarDatos.CommandType = CommandType.StoredProcedure;

                                    cmdInsertarDatos.Parameters.AddWithValue("@valorBa", fila["valorBase"]);
                                    cmdInsertarDatos.Parameters["@valorBa"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@amp", fila["amplitud"]);
                                    cmdInsertarDatos.Parameters["@amp"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@cteT", fila["cteTiempo"]);
                                    cmdInsertarDatos.Parameters["@cteT"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@frec", fila["frecuencia"]);
                                    cmdInsertarDatos.Parameters["@frec"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@id_r", ultimoIdRespTransiente);
                                    cmdInsertarDatos.Parameters["@id_r"].Direction = ParameterDirection.Input;
                                    break;
                                case ("Senoidal2"):
                                    cmdInsertarDatos = new MySqlCommand();
                                    cmdInsertarDatos.Connection = Conn;
                                    cmdInsertarDatos.CommandText = "insertSenoidal2";
                                    cmdInsertarDatos.CommandType = CommandType.StoredProcedure;

                                    cmdInsertarDatos.Parameters.AddWithValue("@valorBa", fila["valorBase"]);
                                    cmdInsertarDatos.Parameters["@valorBa"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@amp", fila["amplitud"]);
                                    cmdInsertarDatos.Parameters["@amp"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@cteT", fila["cteTiempo"]);
                                    cmdInsertarDatos.Parameters["@cteT"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@frec", fila["frecuencia"]);
                                    cmdInsertarDatos.Parameters["@frec"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@coefAm", fila["coefAmort"]);
                                    cmdInsertarDatos.Parameters["@coefAm"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@id_r", ultimoIdRespTransiente);
                                    cmdInsertarDatos.Parameters["@id_r"].Direction = ParameterDirection.Input;
                                    break;
                                default:
                                    cmdInsertarDatos = new MySqlCommand();
                                    cmdInsertarDatos.CommandType = CommandType.StoredProcedure;
                                    cmdInsertarDatos.Connection = Conn;
                                    cmdInsertarDatos.CommandText = "insertEscImpRam1";

                                    cmdInsertarDatos.Parameters.AddWithValue("@amp", fila["amplitud"]);
                                    cmdInsertarDatos.Parameters["@amp"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@cteT", fila["cteTiempo"]);
                                    cmdInsertarDatos.Parameters["@cteT"].Direction = ParameterDirection.Input;

                                    cmdInsertarDatos.Parameters.AddWithValue("@id_r", ultimoIdRespTransiente);
                                    cmdInsertarDatos.Parameters["@id_r"].Direction = ParameterDirection.Input;
                                    break;
                            }
                            //se realiza la transacción
                            cmdInsertarDatos.Connection.Open();
                            cmdInsertarDatos.ExecuteNonQuery();
                            cmdInsertarDatos.Connection.Close();
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e) { MessageBox.Show("Ha ocurrido un error con la base de datos: " + e.Data); }
                    this.datosGrafica.AcceptChanges();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("El título de la gráfica ingresado ya existe");
                return false;
            }
        }
    }
}
