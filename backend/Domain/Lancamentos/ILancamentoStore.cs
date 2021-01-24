using Domain.Lancamentos.Models;
using System.Threading.Tasks;

namespace Domain.Lancamentos
{
    public interface ILancamentoStore
    {
        Task RegistrarLancamento(Lancamento lancamento);
    }
}