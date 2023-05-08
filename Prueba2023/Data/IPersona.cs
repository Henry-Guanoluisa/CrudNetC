using Prueba2023.Models;
using System.Collections.Generic;

namespace Prueba2023.Data
{
    public interface IPersona
    {
        IEnumerable<Persona> ObtenerPersonas();
        Persona ObtenerPersonaPorId(int id);
        void InsertarPersona(Persona persona);
        void ActualizarPersona(Persona persona);
        void EliminarPersona(int id);
    }
}