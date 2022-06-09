using API_DB_Double_V_Partners.Models;
using API_DB_Double_V_Partners.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_DB_Double_V_Partners.Controllers.V1
{
    [ApiController]
    [Route("api/v1")]
    public class CuentaController : ControllerBase
    {
        private readonly IRepositorioPruebas repositorioPruebas;

        public CuentaController(IRepositorioPruebas repositorioPruebas)
        {
            this.repositorioPruebas = repositorioPruebas;
        }

        [HttpPost]
        [Route("CrearCuenta")]
        public async  Task<ActionResult<RespuestaCuenta>> GuardarInfo(Cuenta cuenta)
        {
            RespuestaCuenta cuentaRespuesta = new RespuestaCuenta();

            try
            {
                var existe = await repositorioPruebas.ExisteUsuario(cuenta.Usuario.Usuario);

                if (existe)
                {
                    cuentaRespuesta.exito = false;
                    cuentaRespuesta.Mensaje = $"El Usuario { cuenta.Usuario.Usuario } ya existe";

                    return BadRequest(cuentaRespuesta);
                }

                await repositorioPruebas.Crear(cuenta);

                cuentaRespuesta.exito = true;
                cuentaRespuesta.Mensaje = "Cuenta Creada Exitosamente";

                return Ok(cuentaRespuesta);

            }
            catch (Exception)
            {
                cuentaRespuesta.exito = false;
                cuentaRespuesta.Mensaje = "Hubo un problema al crear la cuenta, por favor comunicarse con soporte";

                return StatusCode(500, cuentaRespuesta);
            }
            

        }

        [HttpGet]
        [Route("ConsultarPersonas")]
        public async Task<ActionResult<List<RespuestaPersona>>> ConsultarPersonas()
        {
            return await repositorioPruebas.ConsultarPersonas();
        }

        [HttpPost]
        [Route("ValidarLogin")]
        public async Task<ActionResult<RespuestaCuenta>> UsuarioLogin(Usuarios usuarios)
        {
            RespuestaCuenta cuentaRespuesta = new RespuestaCuenta();
            var login = await repositorioPruebas.ValidarLoginUsuario(usuarios);

            if (login)
            {
                cuentaRespuesta.exito = true;
                cuentaRespuesta.Mensaje = "Logeado Correctamente";
                return Ok(cuentaRespuesta);
            }
            else
            {
                cuentaRespuesta.exito = false;
                cuentaRespuesta.Mensaje = "Usuario y/o contraseña son incorrectos";
                return BadRequest(cuentaRespuesta);
            }
        }

    }
}
