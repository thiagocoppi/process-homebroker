using Domain.Emails;
using Domain.Emails.Models;
using Domain.Usuarios.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public sealed class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioStore _usuarioStore;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioStore usuarioStore, IEmailService emailService, IConfiguration configuration)
        {
            _usuarioStore = usuarioStore;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<Usuario> RegistrarNovoUsuario(Usuario usuario)
        {
            if (await _usuarioStore.VerificarUsuarioExiste(usuario.Cpf))
            {
                throw new Exception("Usuário já está cadastrado ao sistema!");
            }
            var senhaTransacao = usuario.AdicionarSenhaTransacaoEletronica();
            var usuarioRegistrado = await _usuarioStore.RegistrarUsuario(usuario);
            var texto = _configuration.GetValue<string>("Email:EmailEnviar").Replace("@SENHA_TRANSACIONAL@", senhaTransacao);
            var tituloEmail = _configuration.GetValue<string>("Email:TituloEmail");

            _emailService.EnviarEmail(new ProcessEmail(usuario.Email, true, texto, tituloEmail));

            return usuarioRegistrado;
        }
    }
}