using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace RegistroPacientes
{
    public class PacienteRepositorio
    {
        private readonly string _conexionString;

        public PacienteRepositorio(string conexionString)
        {
            _conexionString = conexionString;
        }

        public void Insertar(Paciente paciente)
        {
            string query = @"INSERT INTO Pacientes (Nombre, Apellido, Cedula, Edad, Telefono, Diagnostico) 
                             VALUES (@Nombre, @Apellido, @Cedula, @Edad, @Telefono, @Diagnostico)";

            using (SqlConnection conn = new SqlConnection(_conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@Cedula", paciente.Cedula);
                    cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                    cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@Diagnostico", string.IsNullOrWhiteSpace(paciente.Diagnostico) ? DBNull.Value : paciente.Diagnostico);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Paciente> ObtenerTodos()
        {
            List<Paciente> lista = new List<Paciente>();
            string query = "SELECT Id, Nombre, Apellido, Cedula, Edad, Telefono, Diagnostico, FechaRegistro FROM Pacientes";

            using (SqlConnection conn = new SqlConnection(_conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearPaciente(reader));
                        }
                    }
                }
            }
            return lista;
        }

        public Paciente? BuscarPorCedula(string cedula)
        {
            string query = "SELECT Id, Nombre, Apellido, Cedula, Edad, Telefono, Diagnostico, FechaRegistro FROM Pacientes WHERE Cedula = @Cedula";

            using (SqlConnection conn = new SqlConnection(_conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearPaciente(reader);
                        }
                    }
                }
            }
            return null;
        }

        public bool ActualizarDiagnostico(int id, string nuevoDiagnostico)
        {
            string query = "UPDATE Pacientes SET Diagnostico = @Diagnostico WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(_conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Diagnostico", nuevoDiagnostico);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool Eliminar(int id)
        {
            string query = "DELETE FROM Pacientes WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(_conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        private Paciente MapearPaciente(SqlDataReader reader)
        {
            return new Paciente
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                Cedula = reader.GetString(3),
                Edad = reader.GetInt32(4),
                Telefono = reader.GetString(5),
                Diagnostico = reader.IsDBNull(6) ? "Sin diagnóstico" : reader.GetString(6),
                FechaRegistro = reader.GetDateTime(7)
            };
        }
    }
}