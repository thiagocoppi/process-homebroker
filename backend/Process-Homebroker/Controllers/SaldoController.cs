using Application.Queries.Saldos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Process_Homebroker.Middleware;
using System.Net;
using System.Threading.Tasks;

namespace Process_Homebroker.Controllers
{
    [Route("process-homebroker/api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class SaldoController : ApiController
    {
        /// <summary>
        /// Realiza a busca do saldo atual da conta do correntista
        /// </summary>
        /// <returns>Saldo do correntista</returns>
        [HttpGet]
        [Route("buscar-saldo-conta")]
        [ProducesResponseType(typeof(ObterSaldoContaQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ObterSaldoContaQueryResponse>> ComprarAcaoFinanceira()
        {
            var command = new ObterSaldoContaQueryRequest()
            {
                Usuario = ObterUsuarioAutenticacao()
            };

            var value = await Mediator.Send(command);
            return Ok(value);
        }
    }
}