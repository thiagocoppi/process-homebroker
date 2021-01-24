using Domain.Lancamentos.Models;
using System.Threading.Tasks;

namespace Domain.Lancamentos
{
    public interface ILancamentoService
    {
        Task<Lancamento> RegistrarLancamento(Lancamento lancamento);
    }
}