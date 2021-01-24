using Application.Commands.Acoes.BuscarValor;
using Application.Commands.Ordens.Cadastrar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Process_Homebroker.Middleware;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Process_Homebroker.Controllers
{
    [Route("process-homebroker/api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class AcaoController : ApiController
    {
        [HttpPost("buscar-acao")]
        [ProducesResponseType(typeof(BuscarValorCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<BuscarValorCommandResult>> BuscarAcaoFinanceira([FromBody] BuscarValorCommand command)
        {
            var value = await Mediator.Send(command);
            return Ok(value);
        }

        [HttpPost("comprar-acao")]
        [ProducesResponseType(typeof(CadastrarOrdemCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CadastrarOrdemCommandResult>> ComprarAcaoFinanceira([FromBody] CadastrarOrdemCommand command)
        {
            var nome = User.Claims.First(r => r.Type == "Nome");
            var cpf = User.Claims.First(r => r.Type == "Cpf");
            var id = User.Claims.First(r => r.Type == "Id");
            command.Usuario = new UsuarioCommand()
            {
                Cpf = cpf.Value,
                Id = id.Value.ToString(),
                Nome = nome.Value
            };
            var value = await Mediator.Send(command);
            return Ok(value);
        }
    }
}