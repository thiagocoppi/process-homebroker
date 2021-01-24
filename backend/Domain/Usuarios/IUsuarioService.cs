using Domain.Usuarios.Models;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public interface IUsuarioService
    {
        Task<Usuario> RegistrarNovoUsuario(Usuario usuario);
    }
}