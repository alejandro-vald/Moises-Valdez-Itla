using System;
using System.Collections.Generic;
using System.Linq;

public class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();
    private int ultimoId = 0;

    public void AgregarContacto()
    {
        Console.WriteLine("\nVamos a agregar ese contacto que te trae loco.");
        ultimoId++;

        Console.Write("Digite el Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Digite el Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Digite el Email: ");
        string email = Console.ReadLine();

        Console.Write("Digite la dirección: ");
        string direccion = Console.ReadLine();

        contactos.Add(new Contacto(ultimoId, nombre, telefono, email, direccion));
        Console.WriteLine("¡Contacto agregado exitosamente!\n");
    }

    public void VerContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("\nNo hay contactos registrados todavía.\n");
            return;
        }

        Console.WriteLine("\nId    Nombre          Telefono        Email               Dirección");
        Console.WriteLine("_________________________________________________________________________");
        foreach (var c in contactos)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
    }

    public void BuscarContacto()
    {
        VerContactos();
        if (contactos.Count == 0) return;

        Console.Write("Digite un Id de Contacto Para Mostrar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var c = contactos.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                Console.WriteLine($"\nEl nombre es: {c.Nombre}");
                Console.WriteLine($"El Teléfono es: {c.Telefono}");
                Console.WriteLine($"El Email es: {c.Email}");
                Console.WriteLine($"La dirección es: {c.Direccion}\n");
            }
            else
            {
                Console.WriteLine("No se encontró ningún contacto con ese ID.\n");
            }
        }
    }

    public void ModificarContacto()
    {
        VerContactos();
        if (contactos.Count == 0) return;

        Console.Write("Digite un Id de Contacto Para Editar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var c = contactos.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                Console.Write($"El nombre es: {c.Nombre}, Digite el Nuevo Nombre: ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre)) c.Nombre = nombre;

                Console.Write($"El Teléfono es: {c.Telefono}, Digite el Nuevo Teléfono: ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefono)) c.Telefono = telefono;

                Console.Write($"El Email es: {c.Email}, Digite el Nuevo Email: ");
                string email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email)) c.Email = email;

                Console.Write($"La dirección es: {c.Direccion}, Digite la nueva dirección: ");
                string address = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(address)) c.Direccion = address;

                Console.WriteLine("¡Contacto modificado exitosamente!\n");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.\n");
            }
        }
    }

    public void EliminarContacto()
    {
        VerContactos();
        if (contactos.Count == 0) return;

        Console.Write("Digite un Id de Contacto Para Eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var c = contactos.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                Console.WriteLine($"Seguro que desea eliminar a {c.Nombre}? 1. Si, 2. No");
                if (int.TryParse(Console.ReadLine(), out int opcion) && opcion == 1)
                {
                    contactos.Remove(c);
                    Console.WriteLine("¡Contacto eliminado correctamente!\n");
                }
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.\n");
            }
        }
    }
}