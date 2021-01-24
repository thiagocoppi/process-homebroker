using MediatR;
using System;

namespace Application.Commands.Usuarios.CriarNovoUsuario
{
    public sealed class CriarNovoUsuarioCommand : IRequest<CriarNovoUsuarioCommandResult>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
    }
}