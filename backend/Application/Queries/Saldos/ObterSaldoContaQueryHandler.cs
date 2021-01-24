using Infraestrutura.QueryStore.Saldos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Saldos
{
    public class ObterSaldoContaQueryHandler : IRequestHandler<ObterSaldoContaQueryRequest, ObterSaldoContaQueryResponse>
    {
        private readonly ISaldoQueryStore _saldoQueryStore;

        public ObterSaldoContaQueryHandler(ISaldoQueryStore saldoQueryStore)
        {
            _saldoQueryStore = saldoQueryStore;
        }

        public async Task<ObterSaldoContaQueryResponse> Handle(ObterSaldoContaQueryRequest request, CancellationToken cancellationToken)
        {
            var saldoAtual = await _saldoQueryStore.BuscarSaldo(Guid.Parse(request.Usuario.Id));
            return new ObterSaldoContaQueryResponse()
            {
                Saldo = saldoAtual
            };
        }
    }
}