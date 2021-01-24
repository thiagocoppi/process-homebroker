using Domain.Ordens.Models;
using Domain.Saldos.Models;
using Domain.Usuarios.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Saldos
{
    public class SaldoService : ISaldoService
    {
        private readonly ISaldoStore _saldoStore;

        public SaldoService(ISaldoStore saldoStore)
        {
            _saldoStore = saldoStore;
        }

        public async Task<Saldo> ComporSaldo(Ordem ordem)
        {
            return await _saldoStore.ComporSaldo(ordem);            
        }
    }
}
