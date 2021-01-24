using Domain.Ordens.Models;
using Domain.Saldos.Models;
using Domain.Usuarios.Models;
using System.Threading.Tasks;

namespace Domain.Saldos
{
    public interface ISaldoService
    {
        Task<Saldo> ComporSaldo(Ordem ordem);
    }
}