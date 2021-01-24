using Domain.Segurancas.Models;
using Domain.Usuarios.Models;
using System.Threading.Tasks;

namespace Domain.Segurancas
{
    public interface ISegurancaService
    {
        Task<Token> GerarToken(Usuario usuario);
        Task<Usuario> AbrirToken(Token token);
    }
}