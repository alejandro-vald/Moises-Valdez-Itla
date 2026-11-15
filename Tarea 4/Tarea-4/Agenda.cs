using System;

namespace Tarea_4
{
    public class Agenda
    {
        private readonly RepositorioContacto _repositorio;

        public Agenda(RepositorioContacto repositorio)
        {
            _repositorio = repositorio;
        }

        public void RegistrarContacto(Contacto nuevo)
        {
            _repositorio.Agregar(nuevo);
            Console.WriteLine("Contacto guardado en SQL Server con éxito.");
        }

        public void MostrarContactos()
        {
            var contactos = _repositorio.ObtenerTodos();
            Console.WriteLine("\n--- Lista de Contactos en BD ---");
            foreach (var c in contactos)
            {
                Console.WriteLine($"[{c.Id}] {c.Nombre} | Tel: {c.Telefono} | Correo: {c.Correo}");
            }
        }
    }
}