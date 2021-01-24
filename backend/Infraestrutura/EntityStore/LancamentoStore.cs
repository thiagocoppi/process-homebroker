using Dapper;
using Domain.Lancamentos;
using Domain.Lancamentos.Models;
using Infraestrutura.Context;
using System.Threading.Tasks;

namespace Infraestrutura.EntityStore
{
    public class LancamentoStore : ILancamentoStore
    {
        private readonly IProcessContext _context;

        public LancamentoStore(IProcessContext context)
        {
            _context = context;
        }

        public async Task RegistrarLancamento(Lancamento lancamento)
        {
            await _context.GetConnection().ExecuteAsync(SQL_INSERIR_LANCAMENTO, new
            {
                usuario_id = lancamento.Ordem.Usuario.Id,
                ordem_id = lancamento.Ordem.Id,
                tipo_lancamento = lancamento.TipoLancamento.ToString(),
                data = lancamento.Data
            });
        }

        private const string SQL_INSERIR_LANCAMENTO =
            @"INSERT INTO LANCAMENTO(USUARIO_ID, ORDEM_ID, TIPO_LANCAMENTO, DATA)
                SELECT :usuario_id, :ordem_id, :tipo_lancamento, :data WHERE NOT EXISTS (SELECT ID FROM LANCAMENTO WHERE ORDEM_ID = ordem_id)";
    }
}