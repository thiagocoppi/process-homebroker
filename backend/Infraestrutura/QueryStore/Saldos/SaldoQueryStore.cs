using Dapper;
using Infraestrutura.Context;
using System;
using System.Threading.Tasks;

namespace Infraestrutura.QueryStore.Saldos
{
    public class SaldoQueryStore : ISaldoQueryStore
    {
        private readonly IProcessContext _context;

        public SaldoQueryStore(IProcessContext context)
        {
            _context = context;
        }

        public async Task<decimal> BuscarSaldo(Guid usuarioId)
        {
            return await _context.GetConnection().QueryFirstOrDefaultAsync<decimal>(SQL_BUSCAR_SALDO_CORRENTISTA, new
            {
                id = usuarioId
            });
        }

        private const string SQL_BUSCAR_SALDO_CORRENTISTA =
            @"SELECT SALDO_ATUAL FROM SALDO WHERE USUARIO_ID = :id";
    }
}