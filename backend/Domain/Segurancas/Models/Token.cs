using System;

namespace Domain.Segurancas.Models
{
    public sealed class Token
    {
        public string Info { get; private set; }
        public DateTime DataExpiracao => DateTime.Now.AddHours(2);

        public Token(string info)
        {
            if (string.IsNullOrEmpty(info))
            {
                //throw new BusinessException(Messages.TokenInvalidoParaCriacao);
            }

            Info = info;
        }
    }
}