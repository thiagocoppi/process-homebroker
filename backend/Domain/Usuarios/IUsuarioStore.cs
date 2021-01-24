using Domain.Usuarios.Models;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public interface IUsuarioStore
    {
        Task<Usuario> RegistrarUsuario(Usuario usuario);
        Task<bool> VerificarUsuarioExiste(string cpf);
        Task<Usuario> ObterUsuarioPeloEmail(string email);
    }
}