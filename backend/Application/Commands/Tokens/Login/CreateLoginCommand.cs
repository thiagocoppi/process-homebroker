using MediatR;

namespace Application.Commands.Tokens.Login
{
    /// <summary>
    /// Comando para realizar o login na aplicação
    /// </summary>
    public sealed class CreateLoginCommand : IRequest<CreateLoginCommandResult>
    {
        /// <summary>
        /// Email que foi utilizado no momento da criação da conta
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha que foi enviada juntamente ao e-mail
        /// </summary>
        public string Senha { get; set; }
    }
}