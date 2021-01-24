using Application.Commands.Tokens.Login;
using Application.Commands.Usuarios.CriarNovoUsuario;
using Microsoft.AspNetCore.Mvc;
using Process_Homebroker.Middleware;
using System.Net;
using System.Threading.Tasks;

namespace Process_Homebroker.Controllers
{
    [Route("process-express/api/v{version:apiVersion}/[controller]")]
    public class SegurancaController : ApiController
    {
        /// <summary>
        /// Realiza o login na aplicação ProcessExpress com as informações para processar o arquivo OFX
        /// </summary>
        /// <param name="command">Comando para realizar o login</param>
        /// <returns>Token para acesso à aplicação</returns>

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(CreateLoginCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CreateLoginCommandResult>> Authenticate([FromBody] CreateLoginCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}