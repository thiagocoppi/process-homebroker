using System;

namespace Application.Commands.Tokens.Login
{
    public class CreateLoginCommandResult
    {
        public string Token { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}