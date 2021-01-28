using Application.Commands.Tokens.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Process_Homebroker.Middleware;
using System.Net;
using System.Threading.Tasks;

namespace Process_Homebroker.Controllers
{
    [Route("process-homebroker/api/v{version:apiVersion}/[controller]")]
    public class SegurancaController : ApiController
    {
        /// <summary>
        /// Realiza o login na aplicação
        /// </summary>
        /// <param name="command">Comando para realizar o login</param>
        /// <returns>Token para acesso à aplicação</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(CreateLoginCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CreateLoginCommandResult>> Authenticate([FromBody] CreateLoginCommand command)
        {
            var value = await Mediator.Send(command);
            return Ok(value);
        }
    }
}