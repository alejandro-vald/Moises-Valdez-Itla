using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace RegistroPacientes
{
    public class GestorPacientes
    {
        private readonly PacienteRepositorio _repositorio;

        public GestorPacientes(PacienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void RegistrarPaciente(Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.Nombre) || string.IsNullOrWhiteSpace(paciente.Apellido))
                throw new ArgumentException("El nombre y el apellido son obligatorios.");

            if (string.IsNullOrWhiteSpace(paciente.Cedula))
                throw new ArgumentException("La cédula es obligatoria.");

            if (paciente.Edad < 0 || paciente.Edad > 130)
                throw new ArgumentException("La edad ingresada no es válida (debe estar entre 0 y 130).");

            try
            {
                _repositorio.Insertar(paciente);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new InvalidOperationException($"Ya existe un paciente registrado con la cédula {paciente.Cedula}.");
            }
        }

        public List<Paciente> ListarPacientes()
        {
            return _repositorio.ObtenerTodos();
        }

        public Paciente? ConsultarPorCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                throw new ArgumentException("Debe ingresar una cédula para buscar.");

            return _repositorio.BuscarPorCedula(cedula);
        }

        public bool ModificarDiagnostico(int id, string diagnostico)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(diagnostico))
                throw new ArgumentException("El diagnóstico no puede quedar vacío.");

            return _repositorio.ActualizarDiagnostico(id, diagnostico);
        }

        public bool EliminarPaciente(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a cero.");

            return _repositorio.Eliminar(id);
        }
    }
}