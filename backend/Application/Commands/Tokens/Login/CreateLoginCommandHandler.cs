using Domain.Segurancas;
using Domain.Usuarios.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Tokens.Login
{
    public sealed class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, CreateLoginCommandResult>
    {
        private readonly ISegurancaService _segurancaService;

        public CreateLoginCommandHandler(ISegurancaService segurancaService)
        {
            _segurancaService = segurancaService;
        }

        public async Task<CreateLoginCommandResult> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            var tokenGerado = await _segurancaService.GerarToken(new Usuario(request.Email, request.Senha));
            return new CreateLoginCommandResult()
            {
                DataExpiracao = tokenGerado.DataExpiracao,
                Token = tokenGerado.Info
            };
        }
    }
}