using Domain.Usuarios;
using Domain.Usuarios.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Usuarios.CriarNovoUsuario
{
    public class CriarNovoUsuarioCommandHandler : IRequestHandler<CriarNovoUsuarioCommand, CriarNovoUsuarioCommandResult>
    {
        private readonly IUsuarioService _usuarioService;

        public CriarNovoUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<CriarNovoUsuarioCommandResult> Handle(CriarNovoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioRegistrado = await _usuarioService.RegistrarNovoUsuario(new Usuario(request.Nome, request.Cpf, request.Email,
                request.DataNascimento, request.Celular, request.Senha));

            return new CriarNovoUsuarioCommandResult()
            {
                Email = usuarioRegistrado.Email
            };
        }
    }
}