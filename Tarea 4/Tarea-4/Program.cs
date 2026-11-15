using System;
using Tarea_4;

string conexionString = "Server=(local);Database=Agenda;Trusted_Connection=True;TrustServerCertificate=True;";

RepositorioContacto repo = new RepositorioContacto(conexionString);
Agenda miAgenda = new Agenda(repo);

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\n=== AGENDA CONECTADA A SQL SERVER ===");
    Console.WriteLine("1. Agregar contacto");
    Console.WriteLine("2. Ver contactos");
    Console.WriteLine("3. Salir");
    Console.Write("Elige una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine() ?? "";
            Console.Write("Correo: ");
            string correo = Console.ReadLine() ?? "";

            Contacto nuevo = new Contacto
            {
                Nombre = nombre,
                Telefono = telefono,
                Correo = correo
            };

            miAgenda.RegistrarContacto(nuevo);
            break;

        case "2":
            miAgenda.MostrarContactos();
            break;

        case "3":
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}