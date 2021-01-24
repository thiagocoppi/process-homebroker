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
        /// <summary>
        /// Realiza a busca de uma ação
        /// </summary>
        /// <param name="command">Comando para buscar a ação</param>        
        [HttpPost("buscar-acao")]
        [ProducesResponseType(typeof(BuscarValorCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<BuscarValorCommandResult>> BuscarAcaoFinanceira([FromBody] BuscarValorCommand command)
        {
            var value = await Mediator.Send(command);
            return Ok(value);
        }

        /// <summary>
        /// Realiza a compra de uma ação e desconta do saldo atual
        /// </summary>
        /// <param name="command">Comando para compra da ação</param>        
        [HttpPost("comprar-acao")]
        [ProducesResponseType(typeof(CadastrarOrdemCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<CadastrarOrdemCommandResult>> ComprarAcaoFinanceira([FromBody] CadastrarOrdemCommand command)
        {
            command.Usuario = ObterUsuarioAutenticacao();
            var value = await Mediator.Send(command);
            return Ok(value);
        }
    }
}