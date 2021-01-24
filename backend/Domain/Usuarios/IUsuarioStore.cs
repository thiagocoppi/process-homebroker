using Domain.Usuarios.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public interface IUsuarioStore
    {
        Task<Usuario> RegistrarUsuario(Usuario usuario);
        Task<bool> VerificarUsuarioExiste(string cpf, string email);
        Task<Usuario> ObterUsuarioPeloEmail(string email);
        Task<Usuario> ObterUsuarioPeloId(Guid id);
    }
}