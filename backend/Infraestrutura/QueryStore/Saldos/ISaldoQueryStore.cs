using Domain.Usuarios.Models;
using System;
using System.Threading.Tasks;

namespace Infraestrutura.QueryStore.Saldos
{
    public interface ISaldoQueryStore
    {
        Task<decimal> BuscarSaldo(Guid usuarioId);
    }
}