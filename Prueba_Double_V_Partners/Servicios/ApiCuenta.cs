using Newtonsoft.Json;
using Prueba_Double_V_Partners.Models;
using RestSharp;
using System.Text;

namespace Prueba_Double_V_Partners.Servicios
{
    public interface IApiCuenta
    {
        Task<RespuestaCuenta> CrearCuenta(Cuenta cuenta);
        Task<RespuestaCuenta> ValidarLogin(Usuarios usuario);
    }

    public class ApiCuenta : IApiCuenta
    {

        static HttpClient client = new HttpClient();

        public async Task<RespuestaCuenta> CrearCuenta(Cuenta cuenta)
        {

            var client = new RestClient("https://localhost:7196/api/v1/CrearCuenta");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(cuenta);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response =  await client.ExecuteAsync(request);

            var resjson = JsonConvert.DeserializeObject<RespuestaCuenta>(response.Content);

            return resjson;

        }

        public async Task<RespuestaCuenta> ValidarLogin(Usuarios usuario)
        {

            var client = new RestClient("https://localhost:7196/api/v1/ValidarLogin");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(usuario);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            var resjson = JsonConvert.DeserializeObject<RespuestaCuenta>(response.Content);

            return resjson;

        }

    }
}
