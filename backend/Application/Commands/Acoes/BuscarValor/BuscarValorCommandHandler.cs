using Domain.Acoes;
using Domain.Acoes.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Acoes.BuscarValor
{
    public class BuscarValorCommandHandler : IRequestHandler<BuscarValorCommand, BuscarValorCommandResult>
    {
        private readonly IAcaoService _acaoService;

        public BuscarValorCommandHandler(IAcaoService acaoService)
        {
            _acaoService = acaoService;
        }

        public async Task<BuscarValorCommandResult> Handle(BuscarValorCommand request, CancellationToken cancellationToken)
        {
            var retorno = await _acaoService.BuscarValorMercado(new Acao(request.Codigo, DateTime.Now));
            return new BuscarValorCommandResult()
            {
                Codigo = retorno.Nome,
                Data = retorno.Data,
                Valor = retorno.ValorMercado
            };
        }
    }
}