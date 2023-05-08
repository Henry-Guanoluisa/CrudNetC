using System.Data;
using Dapper;
using Prueba2023.Data;
using Prueba2023.Models;

namespace Prueba2023.Data
{
    public class PersonaImple : IPersona
    {
        private readonly Conexion _conexion;

        public PersonaImple(Conexion conexion)
        {
            _conexion = conexion;
        }

        public void ActualizarPersona(Persona persona)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", persona.Id, DbType.Int32);
                parametros.Add("@Identificacion", persona.Identificacion, DbType.String);
                parametros.Add("@Nombres", persona.Nombres, DbType.String);
                parametros.Add("@Apellidos", persona.Apellidos, DbType.String);
                parametros.Add("@TipoIdentificacion", persona.TipoIdentificacion, DbType.String);
                parametros.Add("@Correo", persona.Correo, DbType.String);
                conexion.Execute("sp_actualizar_persona", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void EliminarPersona(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);
                conexion.Execute("sp_eliminar_persona", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertarPersona(Persona persona)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Identificacion", persona.Identificacion, DbType.String);
                parametros.Add("@Nombres", persona.Nombres, DbType.String);
                parametros.Add("@Apellidos", persona.Apellidos, DbType.String);
                parametros.Add("@TipoIdentificacion", persona.TipoIdentificacion, DbType.String);
                parametros.Add("@Correo", persona.Correo, DbType.String);
                conexion.Execute("sp_crear_persona", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public Persona ObtenerPersonaPorId(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);
                return conexion.QueryFirstOrDefault<Persona>("sp_consultar_persona", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Persona> ObtenerPersonas()
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                return conexion.Query<Persona>("sp_consultar_todo", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}