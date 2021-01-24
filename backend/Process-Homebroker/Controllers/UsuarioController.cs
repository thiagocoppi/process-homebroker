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
        [HttpPost("criar-novo-usuario")]
        [ProducesResponseType(typeof(CriarNovoUsuarioCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CriarNovoUsuarioCommandResult>> RealizaLancamentoFinanceiro([FromBody] CriarNovoUsuarioCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}