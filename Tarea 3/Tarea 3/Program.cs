Console.WriteLine("Hello, World!");
using System;

Console.WriteLine("Mi Agenda Perrón");
Console.WriteLine("Bienvenido a tu lista de contactos\n");

Agenda miAgenda = new Agenda();
bool running = true;

while (running)
{
    Console.Write("1. Agregar Contacto      ");
    Console.Write("2. Ver Contactos     ");
    Console.Write("3. Buscar Contactos      ");
    Console.Write("4. Modificar Contacto        ");
    Console.Write("5. Eliminar Contacto     ");
    Console.WriteLine("6. Salir");
    Console.Write("Elige una opción: ");

    try
    {
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                miAgenda.AgregarContacto();
                break;
            case 2:
                miAgenda.VerContactos();
                break;
            case 3:
                miAgenda.BuscarContacto();
                break;
            case 4:
                miAgenda.ModificarContacto();
                break;
            case 5:
                miAgenda.EliminarContacto();
                break;
            case 6:
                running = false;
                Console.WriteLine("Saliendo de la agenda...");
                break;
            default:
                Console.WriteLine("Opción no válida\n");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Por favor, ingrese un número válido.\n");
    }
}