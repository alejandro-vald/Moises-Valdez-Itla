using System;

namespace RegistroPacientes
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} {Apellido} | Cédula: {Cedula} | Edad: {Edad} | Tel: {Telefono} | Diag: {Diagnostico}";
        }
    }
}