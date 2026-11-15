using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace RegistroPacientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conexionString = "Server=(local);Database=Clinica;Trusted_Connection=True;TrustServerCertificate=True;";

            PacienteRepositorio repositorio = new PacienteRepositorio(conexionString);
            GestorPacientes gestor = new GestorPacientes(repositorio);

            bool ejecutando = true;

            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("     SISTEMA DE REGISTRO DE PACIENTES     ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Registrar nuevo paciente");
                Console.WriteLine("2. Listar todos los pacientes");
                Console.WriteLine("3. Buscar paciente por cédula");
                Console.WriteLine("4. Actualizar diagnóstico");
                Console.WriteLine("5. Eliminar registro de paciente");
                Console.WriteLine("6. Salir");
                Console.WriteLine("==========================================");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            RegistrarUI(gestor);
                            break;
                        case "2":
                            ListarUI(gestor);
                            break;
                        case "3":
                            BuscarUI(gestor);
                            break;
                        case "4":
                            ActualizarUI(gestor);
                            break;
                        case "5":
                            EliminarUI(gestor);
                            break;
                        case "6":
                            ejecutando = false;
                            Console.WriteLine("\nCerrando el sistema...");
                            break;
                        default:
                            Console.WriteLine("\n[!] Opción no válida. Intente nuevamente.");
                            break;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"\n[ERROR DE BASE DE DATOS]: No se pudo completar la operación. Detalle: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\n[VALIDACIÓN]: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"\n[AVISO]: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERROR INESPERADO]: {ex.Message}");
                }

                if (ejecutando)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void RegistrarUI(GestorPacientes gestor)
        {
            Console.WriteLine("\n--- REGISTRAR NUEVO PACIENTE ---");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine() ?? "";

            Console.Write("Cédula: ");
            string cedula = Console.ReadLine() ?? "";

            int edad = LeerEntero("Edad: ");

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine() ?? "";

            Console.Write("Diagnóstico inicial (opcional): ");
            string diagnostico = Console.ReadLine() ?? "";

            Paciente nuevo = new Paciente
            {
                Nombre = nombre.Trim(),
                Apellido = apellido.Trim(),
                Cedula = cedula.Trim(),
                Edad = edad,
                Telefono = telefono.Trim(),
                Diagnostico = diagnostico.Trim()
            };

            gestor.RegistrarPaciente(nuevo);
            Console.WriteLine("\n[OK] Paciente registrado exitosamente en la base de datos.");
        }

        static void ListarUI(GestorPacientes gestor)
        {
            Console.WriteLine("\n--- LISTA DE PACIENTES REGISTRADOS ---");
            List<Paciente> pacientes = gestor.ListarPacientes();

            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados actualmente.");
                return;
            }

            foreach (Paciente p in pacientes)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine($"\nTotal de registros: {pacientes.Count}");
        }

        static void BuscarUI(GestorPacientes gestor)
        {
            Console.WriteLine("\n--- BUSCAR PACIENTE POR CÉDULA ---");
            Console.Write("Ingrese la cédula: ");
            string cedula = Console.ReadLine() ?? "";

            Paciente? encontrado = gestor.ConsultarPorCedula(cedula.Trim());

            if (encontrado != null)
            {
                Console.WriteLine("\nPaciente encontrado:");
                Console.WriteLine(encontrado.ToString());
                Console.WriteLine($"Fecha de ingreso: {encontrado.FechaRegistro:dd/MM/yyyy HH:mm}");
            }
            else
            {
                Console.WriteLine("\nNo se encontró ningún paciente con esa cédula.");
            }
        }

        static void ActualizarUI(GestorPacientes gestor)
        {
            Console.WriteLine("\n--- ACTUALIZAR DIAGNÓSTICO ---");
            int id = LeerEntero("Ingrese el ID del paciente: ");

            Console.Write("Nuevo diagnóstico: ");
            string diagnostico = Console.ReadLine() ?? "";

            bool actualizado = gestor.ModificarDiagnostico(id, diagnostico.Trim());

            if (actualizado)
                Console.WriteLine("\n[OK] Diagnóstico actualizado correctamente.");
            else
                Console.WriteLine("\n[!] No existe un paciente con el ID indicado.");
        }

        static void EliminarUI(GestorPacientes gestor)
        {
            Console.WriteLine("\n--- ELIMINAR PACIENTE ---");
            int id = LeerEntero("Ingrese el ID del paciente a eliminar: ");

            Console.Write("¿Está seguro de eliminar este registro? (S/N): ");
            string confirmacion = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (confirmacion == "S")
            {
                bool eliminado = gestor.EliminarPaciente(id);
                if (eliminado)
                    Console.WriteLine("\n[OK] Registro eliminado de la base de datos.");
                else
                    Console.WriteLine("\n[!] No se encontró ningún paciente con ese ID.");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
        }

        static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }
                Console.WriteLine("[!] Entrada inválida. Por favor ingrese un número entero.");
            }
        }
    }
}