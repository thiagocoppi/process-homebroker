using Domain.Ordens.Models;
using System.Threading.Tasks;

namespace Domain.Ordens
{
    public interface IOrdemStore
    {
        Task<Ordem> CadastrarOrdem(Ordem ordem);
    }
}