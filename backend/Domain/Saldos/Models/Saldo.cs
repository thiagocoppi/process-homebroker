using Domain.Usuarios.Models;

namespace Domain.Saldos.Models
{
    public class Saldo
    {
        public Saldo(Usuario usuario, decimal saldoAtual)
        {
            Usuario = usuario;
            SaldoAtual = saldoAtual;
        }

        protected Saldo()
        {
        }

        public decimal SaldoAtual { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}