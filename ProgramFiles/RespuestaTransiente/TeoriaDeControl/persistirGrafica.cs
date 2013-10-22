using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace TeoriaDeControl
{
    class persistirGrafica
    {
       protected DataTable datosGrafica;
       protected String tipo;
       protected int ultimoIdRespTransiente;

       public persistirGrafica()
       {
       }

        public persistirGrafica(String tipo)
        {
            this.tipo = tipo;
            this.datosGrafica = this.getDatosGrafica();
        }

        public virtual DataTable getDatosGrafica()
        {
            return new DataTable();
        }

        public virtual DataTable getDatosGrafica(String titulo)
        {
            return new DataTable();
        }

        public virtual bool aplicarCambios(String titulo) { return false; }

        /// <summary>
        /// Inserta una nueva grafica en la tabla actual para luego guardarla
        /// </summary>
        /// <param name="g">la clase grafica que está siendo utilizada actualmente</param>
        public void nuevaGrafica(Grafica g)
        {
            bool noDatos = false;
            int cont = 0, tipoInt=-1;
            for (int i=0; i < this.datosGrafica.Rows.Count; i++)
                this.datosGrafica.Rows[i].Delete();
            this.datosGrafica.AcceptChanges();
            foreach (DataGridViewRow dgvr in g.dataGrid.Rows)
            {
                cont = 1;
                noDatos = false;
                do
                {
                    //revisar si hay alguna celda vacía  || (dgvr.Cells[cont].Value == null)
                    if (dgvr.Cells[cont].Value == null)
                    {
                        noDatos = true;
                    }
                    cont++;
                } while (cont < dgvr.Cells.Count);

                //si no hay celdas vacías
                if (!noDatos)
                {
                    //cambiar , por . para no tener problemas al guardar en la DB ya que sino la "," no la toma como tal
                    //y guarda el número como si no tuviese decimales
                    for (int i = 1; i < dgvr.Cells.Count;i++ )
                    {
                        try
                        {
                            dgvr.Cells[i].Value = Double.Parse(dgvr.Cells[i].Value.ToString().Replace(",", "."));
                        }
                        catch (FormatException e) { }
                    }

                    DataRow fila = this.datosGrafica.NewRow();
                    //agregar los datos a la fila
                    try
                    {
                        switch (tipo)
                        {
                            case ("Escalon1"):
                                tipoInt = 1;
                                break;
                            case ("Impulso1"):
                                tipoInt = 2;
                                break;
                            case ("Senoidal1"):
                                tipoInt = 3;
                                break;
                            case ("Rampa1"):
                                tipoInt = 4;
                                break;
                            case ("Escalon2"):
                                tipoInt = 5;
                                break;
                            case ("Impulso2"):
                                tipoInt = 6;
                                break;
                            case ("Senoidal2"):
                                tipoInt = 7;
                                break;
                        }
                        fila["tipo"] = tipoInt;
                        fila["titulo"] = g.getNombre();

                        //parámetros
                        if (!((tipo == "Senoidal1") || (tipo == "Senoidal2")))
                        {
                            //Si no son senoidales
                            fila["amplitud"] = dgvr.Cells[1].Value;
                            fila["cteTiempo"] = dgvr.Cells[2].Value;
                        }
                        else
                        {
                            //si son senoidales
                            fila["valorBase"] = dgvr.Cells[1].Value;
                            fila["amplitud"] = dgvr.Cells[2].Value;
                            fila["frecuencia"] = dgvr.Cells[3].Value;
                            fila["cteTiempo"] = dgvr.Cells[4].Value;
                            if (tipo == "Senoidal2") fila["coefAmort"] = dgvr.Cells[5].Value;
                        }

                        //si son entradas escalón o impulso de 2º orden se agrega el coeficiente de Amortiguaicón y el tiempo de asentamiento
                        if ((tipo == "Escalon2") || (tipo == "Impulso2"))
                        {
                            fila["coefAmort"] = dgvr.Cells[3].Value;
                            fila["tiempoAsent"] = dgvr.Cells[4].Value;
                        }
                        fila["id_respuesta"] = ultimoIdRespTransiente;

                        this.datosGrafica.Rows.Add(fila);
                    }
                    catch (Exception e) { }
                }
                else
                {
                    //si hay celdas vacías doy por terminado el for
                    break;
                }
            }
        }

        /// <summary>
        /// Obtiene los titulos de las graficas guardadas
        /// </summary>
        /// <returns></returns>
        public List<String> getTitulos()
        {
            List<String> lstTitulos = new List<string>();
            try
            {
                if (this.datosGrafica == null) MessageBox.Show("nulo");
                DataRow[] titulos = this.datosGrafica.Select(null, null, DataViewRowState.CurrentRows);
                foreach (DataRow t in titulos)
                {
                    lstTitulos.Add((String)t["titulo"]);
                }
            }
            catch (Exception e) { MessageBox.Show("error:"+e.Data); }

            return lstTitulos;
        }

        /// <summary>
        /// Obtiene un DataGridView con los datos guardados de los parámetros de cada una de las funciones
        /// </summary>
        /// <param name="titulo">Título con que se guardó el conjunto de gráficas</param>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public DataGridView getGrafica(String titulo,DataGridView tabla)
        {
            DataTable graficas=getDatosGrafica(titulo);
            DataRow[] grafica = graficas.Select(null, null, DataViewRowState.CurrentRows);

            switch (tipo)
            {
                case ("Escalon1"):
                    for (int i = 0; i < grafica.Length; i++)
                    {
                        tabla.Rows[i].Cells["Amplitud"].Value = grafica[i]["Amplitud"];
                        tabla.Rows[i].Cells["Cte. Tiempo"].Value = grafica[i]["cteTiempo"];
                    }
                    break;
                case ("Impulso1"):
                    for (int i = 0; i < grafica.Length; i++)
                    {
                        tabla.Rows[i].Cells["Amplitud"].Value = grafica[i]["Amplitud"];
                        tabla.Rows[i].Cells["Cte. Tiempo"].Value = grafica[i]["cteTiempo"];
                    }
                    break;
                case ("Senoidal1"):
                    for (int i = 0; i < grafica.Length; i++)
                    {
                        tabla.Rows[i].Cells["Valor Base"].Value = grafica[i]["valorBase"];
                        tabla.Rows[i].Cells["Amplitud"].Value = grafica[i]["Amplitud"];
                        tabla.Rows[i].Cells["Cte. Tiempo"].Value = grafica[i]["cteTiempo"];
                        tabla.Rows[i].Cells["Frecuencia"].Value = grafica[i]["frecuencia"];
                    }
                    break;
                case ("Rampa1"):
                    for (int i = 0; i < grafica.Length; i++)
                    {
                        tabla.Rows[i].Cells["Amplitud"].Value = grafica[i]["Amplitud"];
                        tabla.Rows[i].Cells["Cte. Tiempo"].Value = grafica[i]["cteTiempo"];
                    }
                    break;
                case ("Escalon2"):
                    for (int i = 0; i < grafica.Length; i++)
                    {
                        tabla.Rows[i].Cells["Amplitud"].Value = grafica[i]["Amplitud"];
                        tabla.Rows[i].Cells["Cte. Tiempo"].Value = grafica[i]["cteTiempo"];
                        tabla.Rows[i].Cells["Coef. Amort."].Value = grafica[i]["coefAmort"];
                        tabla.Rows[i].Cells["% Tiempo Asent."].Value = grafica[i]["tiempoAsent"];
                    }
                    break;
                case ("Impulso2"):
                    for (int i = 0; i < grafica.Length; i++)
                    {
                        tabla.Rows[i].Cells["Amplitud"].Value = grafica[i]["Amplitud"];
                        tabla.Rows[i].Cells["Cte. Tiempo"].Value = grafica[i]["cteTiempo"];
                        tabla.Rows[i].Cells["Coef. Amort."].Value = grafica[i]["coefAmort"];
                        tabla.Rows[i].Cells["% Tiempo Asent."].Value = grafica[i]["tiempoAsent"];
                    }
                    break;
                case ("Senoidal2"):
                    for (int i = 0; i < grafica.Length; i++)
                    {
                        tabla.Rows[i].Cells["Valor Base"].Value = grafica[i]["valorBase"];
                        tabla.Rows[i].Cells["Amplitud"].Value = grafica[i]["Amplitud"];
                        tabla.Rows[i].Cells["Cte. Tiempo"].Value = grafica[i]["cteTiempo"];
                        tabla.Rows[i].Cells["Frecuencia"].Value = grafica[i]["frecuencia"];
                        tabla.Rows[i].Cells["Coef. Amort."].Value = grafica[i]["coefAmort"];
                    }
                    break;
            }

            if (!((tipo == "Senoidal1") || (tipo == "Senoidal2")))
            {
                for (int i = grafica.Length; i < tabla.Rows.Count; i++)
                {
                    for (int j = 1; j < tabla.Rows[i].Cells.Count; j++)
                        tabla.Rows[i].Cells[j].Value = "";
                }
            }

            return tabla;
        }
    }
}

