using Domain.Lancamentos.Models;
using System.Threading.Tasks;

namespace Domain.Lancamentos
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoStore _lancamentoStore;

        public LancamentoService(ILancamentoStore lancamentoStore)
        {
            _lancamentoStore = lancamentoStore;
        }

        public async Task<Lancamento> RegistrarLancamento(Lancamento lancamento)
        {
            await _lancamentoStore.RegistrarLancamento(lancamento);

            return lancamento;
        }
    }
}