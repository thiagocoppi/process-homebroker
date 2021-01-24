using Application.Commands.Usuarios.CriarNovoUsuario;
using Microsoft.AspNetCore.Mvc;
using Process_Homebroker.Middleware;
using System.Net;
using System.Threading.Tasks;

namespace Process_Homebroker.Controllers
{
    [Route("process-homebroker/api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : ApiController
    {
        /// <summary>
        /// Realiza a criação de um novo usuário ao homebroker
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("criar-novo-usuario")]
        [ProducesResponseType(typeof(CriarNovoUsuarioCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CriarNovoUsuarioCommandResult>> RealizaLancamentoFinanceiro([FromBody] CriarNovoUsuarioCommand command)
        {
            var value = await Mediator.Send(command);
            return Ok(value);
        }
    }
}