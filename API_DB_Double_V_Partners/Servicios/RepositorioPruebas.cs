using API_DB_Double_V_Partners.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace API_DB_Double_V_Partners.Servicios
{
    public interface IRepositorioPruebas
    {
        Task<List<RespuestaPersona>> ConsultarPersonas();
        Task Crear(Cuenta cuenta);
        Task<bool> ExisteUsuario(string usuario);
        Task<bool> ValidarLoginUsuario(Usuarios usuario);
    }

    public class RepositorioPruebas : IRepositorioPruebas
    {
        private readonly string configuration;
        private readonly IEncriptar encriptar;

        public RepositorioPruebas(IConfiguration configuration, IEncriptar encriptar)
        {
            this.configuration = configuration.GetConnectionString("defaultConnection");
            this.encriptar = encriptar;
        }

        public async Task Crear(Cuenta cuenta)
        {
            var EncripPass = encriptar.GetSHA256(cuenta.Usuario.Pass);

            cuenta.Usuario.Pass = EncripPass;

            string query1 = @"Insert Into Personas (Nombres, Apellidos, Numero_Identificacion, Email, Tipo_Identificacion)
                Values (@Nombres, @Apellidos, @Numero_Identificacion, @Email, @Tipo_Identificacion);";

            string query2 = @"Insert Into Usuario(Usuario, Pass)
                Values (@Usuario, @Pass);";
            using  var connection = new SqlConnection(configuration);
            await connection.QueryAsync(query1, cuenta.Persona);
            await connection.QueryAsync(query2, cuenta.Usuario);

        }

        public async Task<List<RespuestaPersona>> ConsultarPersonas()
        {

            string query = @"ConsultarPersonas";

            using var connection = new SqlConnection(configuration);
            var  personas = await connection.QueryAsync<RespuestaPersona>(query);

            return personas.ToList();


        }

        public async Task<bool> ExisteUsuario(string usuario)
        {
            using var connection = new SqlConnection(configuration);
            var existe = await connection.QueryFirstOrDefaultAsync<int>(
                @"Select 1
                From Usuario
                Where Usuario = @Usuario;", 
                new { usuario });

            return existe == 1;

        }

        public async Task<bool> ValidarLoginUsuario(Usuarios usuario)
        {
            using var connection = new SqlConnection(configuration);

            var EncripPass = encriptar.GetSHA256(usuario.Pass);

            usuario.Pass = EncripPass;

            var login = await connection.QueryFirstOrDefaultAsync<int>(
                @"Select 1
                From Usuario
                Where Usuario = @Usuario And Pass = @Pass;",
                new { usuario.Usuario, usuario.Pass });

            return login == 1;

        }


    }
}
