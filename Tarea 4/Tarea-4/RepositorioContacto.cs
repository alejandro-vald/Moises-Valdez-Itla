using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Tarea_4
{
    public class RepositorioContacto
    {
        private readonly string _cadenaConexion;

        public RepositorioContacto(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public void Agregar(Contacto contacto)
        {
            string query = "INSERT INTO Contactos (Nombre, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)";

            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    comando.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    comando.Parameters.AddWithValue("@Correo", string.IsNullOrEmpty(contacto.Correo) ? DBNull.Value : contacto.Correo);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Contacto> ObtenerTodos()
        {
            List<Contacto> lista = new List<Contacto>();
            string query = "SELECT Id, Nombre, Telefono, Correo FROM Contactos";

            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Contacto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Telefono = reader.GetString(2),
                                Correo = reader.IsDBNull(3) ? "" : reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}