<<<<<<< HEAD
﻿int[] ids = new int[100];
string[] nombres = new string[100];
double[] precios = new double[100];
int[] stocks = new int[100];
int totalRegistros = 0;

bool continuar = true;

=======
﻿using System;

bool continuar = true;

// Estructura para que el usuario elija su opcion
>>>>>>> 0f4c6703ecdc16ca353ca90f527619c2b3823d51
while (continuar)
{
    Console.Clear();
    Console.WriteLine("==========================================");
<<<<<<< HEAD
    Console.WriteLine("   ESTRUCTURA BASE - PROYECTO FINAL       ");
    Console.WriteLine("==========================================");
    Console.WriteLine("1. Agregar Producto");
    Console.WriteLine("2. Buscar Producto (Por ID o por Nombre)");
    Console.WriteLine("3. Modificar Producto");
    Console.WriteLine("4. Eliminar Producto");
    Console.WriteLine("5. Listar Productos");
    Console.WriteLine("6. Salir");
    Console.WriteLine("==========================================");
    Console.Write("Seleccione una opción (1-6): ");

    string opcion = Console.ReadLine() ?? "";

    try
    {
        switch (opcion)
        {
            case "1":
                AgregarProducto();
                break;
            case "2":
                BuscarProducto();
                break;
            case "3":
                ModificarProducto();
                break;
            case "4":
                EliminarProducto();
                break;
            case "5":
                ListarProductos();
                break;
            case "6":
                Console.Write("\n¿Está seguro que desea salir del programa? (S/N): ");
                string confirmar = (Console.ReadLine() ?? "").Trim().ToUpper();
                if (confirmar == "S")
                {
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                }
                break;
            default:
                Console.WriteLine("\n[Error]: Opción no válida. Debe elegir un número entre 1 y 6.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("\n[Error de formato]: Debe ingresar valores numéricos válidos.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n[Error inesperado]: {ex.Message}");
=======
    Console.WriteLine("            MENU PRINCIPAL          ");
    Console.WriteLine("==========================================");
    Console.WriteLine("1. Sumar");
    Console.WriteLine("2. Restar");
    Console.WriteLine("3. Multiplicar");
    Console.WriteLine("4. Dividir");
    Console.WriteLine("5. Evaluar Estudiante (¿Aprobó o Reprobó?)");
    Console.WriteLine("6. Salir");
    Console.Write("Elige una opción (1-6): ");

    string opcion = Console.ReadLine();
    
    switch (opcion)
    {
        case "1":
            RealizarOperacion("Suma");
            break;
        case "2":
            RealizarOperacion("Resta");
            break;
        case "3":
            RealizarOperacion("Multiplicacion");
            break;
        case "4":
            RealizarOperacion("Division");
            break;
        case "5":
            EvaluarEstudiante();
            break;
        case "6":
            Console.WriteLine("OK ten un buen dia ");
            continuar = false;
            break;
        default:
            Console.WriteLine(" ¡¡¡Error!!! Por favor, elige otro número.");
            break;
>>>>>>> 0f4c6703ecdc16ca353ca90f527619c2b3823d51
    }

    if (continuar)
    {
<<<<<<< HEAD
        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
=======
        Console.WriteLine("Presiona cualquier tecla para continuar...");
>>>>>>> 0f4c6703ecdc16ca353ca90f527619c2b3823d51
        Console.ReadKey();
    }
}

<<<<<<< HEAD
void AgregarProducto()
{
    Console.WriteLine("\n--- AGREGAR NUEVO REGISTRO ---");

    if (totalRegistros >= 100)
    {
        Console.WriteLine("[Error]: La memoria está llena (máximo 100 registros).");
        return;
    }

    Console.Write("Ingrese el ID (número entero): ");
    int idNuevo = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < totalRegistros; i++)
    {
        if (ids[i] == idNuevo)
        {
            Console.WriteLine("[Error]: Ya existe un registro con ese ID.");
            return;
        }
    }

    Console.Write("Ingrese el Nombre: ");
    string nombreNuevo = (Console.ReadLine() ?? "").Trim();
    if (nombreNuevo == "")
    {
        Console.WriteLine("[Error]: El nombre no puede estar vacío.");
        return;
    }

    Console.Write("Ingrese el Precio: ");
    double precioNuevo = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese el Stock: ");
    int stockNuevo = Convert.ToInt32(Console.ReadLine());

    ids[totalRegistros] = idNuevo;
    nombres[totalRegistros] = nombreNuevo;
    precios[totalRegistros] = precioNuevo;
    stocks[totalRegistros] = stockNuevo;
    totalRegistros++;

    Console.WriteLine("¡Registro agregado exitosamente!");
}

void BuscarProducto()
{
    Console.WriteLine();
    if (totalRegistros == 0)
    {
        Console.WriteLine("No hay registros en la memoria.");
        return;
    }

    Console.WriteLine("--- MÓDULO DE BÚSQUEDA ---");
    Console.WriteLine("1. Buscar por ID exacto");
    Console.WriteLine("2. Buscar por Nombre");
    Console.Write("Elija un criterio (1-2): ");
    string criterio = Console.ReadLine() ?? "";

    switch (criterio)
    {
        case "1":
            Console.Write("Ingrese el ID a buscar: ");
            int idBuscado = Convert.ToInt32(Console.ReadLine());
            bool encontrado = false;

            for (int i = 0; i < totalRegistros; i++)
            {
                if (ids[i] == idBuscado)
                {
                    Console.WriteLine($"¡Encontrado! -> ID: {ids[i]} | Nombre: {nombres[i]} | Precio: ${precios[i]} | Stock: {stocks[i]}");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se encontró ningún registro con ese ID.");
            break;

        case "2":
            Console.Write("Ingrese el nombre (o parte de él): ");
            string texto = (Console.ReadLine() ?? "").ToLower();
            int coincidencias = 0;

            for (int i = 0; i < totalRegistros; i++)
            {
                if (nombres[i].ToLower().Contains(texto))
                {
                    Console.WriteLine($"ID: {ids[i]} | Nombre: {nombres[i]} | Precio: ${precios[i]} | Stock: {stocks[i]}");
                    coincidencias++;
                }
            }

            if (coincidencias == 0)
                Console.WriteLine("No se encontraron coincidencias.");
            break;

        default:
            Console.WriteLine("[Error]: Criterio no válido.");
            break;
    }
}

void ModificarProducto()
{
    Console.WriteLine();
    if (totalRegistros == 0)
    {
        Console.WriteLine("No hay registros para modificar.");
        return;
    }

    Console.WriteLine("--- MODIFICAR REGISTRO ---");
    Console.Write("Ingrese el ID del registro a modificar: ");
    int idMod = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < totalRegistros; i++)
    {
        if (ids[i] == idMod)
        {
            Console.WriteLine($"Datos actuales -> Nombre: {nombres[i]}, Precio: ${precios[i]}, Stock: {stocks[i]}");

            Console.Write("Ingrese el nuevo nombre: ");
            nombres[i] = Console.ReadLine() ?? "";

            Console.Write("Ingrese el nuevo precio: ");
            precios[i] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el nuevo stock: ");
            stocks[i] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("¡Registro modificado correctamente!");
            return;
        }
    }

    Console.WriteLine("[Error]: No se encontró un registro con ese ID.");
}

void EliminarProducto()
{
    Console.WriteLine();
    if (totalRegistros == 0)
    {
        Console.WriteLine("No hay registros para eliminar.");
        return;
    }

    Console.WriteLine("--- ELIMINAR REGISTRO ---");
    Console.Write("Ingrese el ID del registro a eliminar: ");
    int idDel = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < totalRegistros; i++)
    {
        if (ids[i] == idDel)
        {
            Console.Write($"¿Está seguro de eliminar a '{nombres[i]}'? (S/N): ");
            string confirmar = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (confirmar == "S")
            {
                for (int j = i; j < totalRegistros - 1; j++)
                {
                    ids[j] = ids[j + 1];
                    nombres[j] = nombres[j + 1];
                    precios[j] = precios[j + 1];
                    stocks[j] = stocks[j + 1];
                }
                totalRegistros--;
                Console.WriteLine("¡Registro eliminado exitosamente!");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
            return;
        }
    }

    Console.WriteLine("[Error]: No se encontró un registro con ese ID.");
}

void ListarProductos()
{
    Console.WriteLine("\n--- LISTADO GENERAL DE REGISTROS ---");
    if (totalRegistros == 0)
    {
        Console.WriteLine("La memoria está vacía actualmente.");
        return;
    }

    Console.WriteLine("--------------------------------------------------");
    for (int i = 0; i < totalRegistros; i++)
    {
        Console.WriteLine($"ID: {ids[i]} | Nombre: {nombres[i]} | Precio: ${precios[i]} | Stock: {stocks[i]}");
        Console.WriteLine("--------------------------------------------------");
=======
static void RealizarOperacion(string tipo)
{
    Console.WriteLine($"--- Operación: {tipo} ---");
    try
    {
        Console.Write("Ingresa el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingresa el segundo número: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double resultado = 0;

        switch (tipo)
        {
            case "Suma":
                resultado = num1 + num2;
                break;
            case "Resta":
                resultado = num1 - num2;
                break;
            case "Multiplicacion":
                resultado = num1 * num2;
                break;
            case "Division":
                if (num2 == 0)
                {
                    Console.WriteLine("[Error] ¡No se puede dividir entre cero!");
                    return;
                }
                resultado = num1 / num2;
                break;
        }

        Console.WriteLine($"El resultado de la {tipo.ToLower()} es: {resultado}");
    }
    catch (FormatException)
    {
        Console.WriteLine("¡¡¡Error!!! Por favor, ingresar solo números.");
    }
}

static void EvaluarEstudiante()
{
    Console.WriteLine("--- Evaluación de Estudiante ---");
    try
    {
        Console.Write("Ingresa la calificación final (0 - 100): ");
        double calificacion = Convert.ToDouble(Console.ReadLine());

        if (calificacion < 0 || calificacion > 100)
        {
            Console.WriteLine("¡¡¡Error!!! La calificación debe estar en el rango de 0 a 100.");
            return;
        }

        if (calificacion >= 70)
        {
            Console.WriteLine($"Felicidades! Con {calificacion} puntos, el estudiante ha **APROBADO**.Suerte la proxima estudie mas que esta flojo");
        }
        else
        {
            Console.WriteLine($"Lo sentimos. Con {calificacion} puntos, el estudiante ha **REPROBADO**.Muy bien te mereces un chicle");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("¡¡¡Error!!! Por favor, ingresa un valor numérico para la calificación.");
>>>>>>> 0f4c6703ecdc16ca353ca90f527619c2b3823d51
    }
}