using Domain.Ordens.Models;
using Domain.Saldos.Models;
using Domain.Usuarios.Models;
using System.Threading.Tasks;

namespace Domain.Saldos
{
    public interface ISaldoStore
    {
        Task<Saldo> ComporSaldo(Ordem ordem);

        Task<Saldo> ObterSaldo(Usuario usuario);

        Task InicializarSaldo(Usuario usuario);
    }
}