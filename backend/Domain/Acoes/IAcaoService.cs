using Domain.Acoes.Models;
using System.Threading.Tasks;

namespace Domain.Acoes
{
    public interface IAcaoService
    {
        Task<Acao> BuscarValorMercado(Acao acao);
        Task<Acao> BuscarNomeAcao(Acao acao);
    }
}