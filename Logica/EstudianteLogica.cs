using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

using System.Configuration;
using intento4.Modelo;
using System.Data.SQLite;

namespace intento4.Logica
{
     
    public class EstudianteLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        //SINGLETON

        private static EstudianteLogica _instancia = null;
        public EstudianteLogica() { }

        public static EstudianteLogica Instancia
        {
            get {
                if (_instancia == null)
                {
                    _instancia = new EstudianteLogica();
                }
                return _instancia;
            }
        }


        public bool Guardar(Estudiante obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                //consulta
                string query = "insert into Estudiantes(Codigo,Nombre) values (@codigo,@nombre)";

                SQLiteCommand cmd = new SQLiteCommand(query,conexion);
                cmd.Parameters.Add(new SQLiteParameter("@codigo",obj.Codigo));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }

            }

            return respuesta;
        }

        public List<Estudiante> Listar()
        {
            List<Estudiante> oLista = new List<Estudiante>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                //consulta
                string query = "select ID_usuario,Codigo,Nombre from Estudiantes";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Estudiante()
                        {
                            ID_usuario = int.Parse (dr["ID_usuario"].ToString()),
                            Codigo = dr["Codigo"].ToString(),
                            Nombre = dr["Nombre"].ToString()

                        });
                    }
                }

            }

            return oLista;
        }

    }
}