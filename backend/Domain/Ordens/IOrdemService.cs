using Domain.Ordens.Models;
using Domain.Segurancas.Models;
using System.Threading.Tasks;

namespace Domain.Ordens
{
    public interface IOrdemService
    {
        Task<Ordem> CadastrarOrdem(Ordem ordem);
    }
}