using Application.Commands.Ordens.Cadastrar;
using MediatR;

namespace Application.Queries.Saldos
{
    public class ObterSaldoContaQueryRequest : IRequest<ObterSaldoContaQueryResponse>
    {
        public UsuarioCommand Usuario { get; set; }
    }
}