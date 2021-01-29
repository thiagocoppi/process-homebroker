using Domain.Base;
using Domain.Emails;
using Domain.Emails.Models;
using Domain.Exceptions;
using Domain.Saldos;
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
        private readonly ISaldoStore _saldoStore;

        public UsuarioService(IUsuarioStore usuarioStore, IEmailService emailService, 
            IConfiguration configuration, ISaldoStore saldoStore)
        {
            _usuarioStore = usuarioStore;
            _emailService = emailService;
            _configuration = configuration;
            _saldoStore = saldoStore;
        }

        public async Task<Usuario> RegistrarNovoUsuario(Usuario usuario)
        {
            throw new BusinessException("Usuário já está cadastrado ao sistema!");
            if (await _usuarioStore.VerificarUsuarioExiste(usuario.Cpf, usuario.Email))
            {
                throw new BusinessException("Usuário já está cadastrado ao sistema!");
            }
            var senhaTransacao = usuario.AdicionarSenhaTransacaoEletronica();
            var usuarioRegistrado = await _usuarioStore.RegistrarUsuario(usuario);
            var texto = _configuration.GetValue<string>("Email:EmailEnviar").Replace("@SENHA_TRANSACIONAL@", senhaTransacao);
            var tituloEmail = _configuration.GetValue<string>("Email:TituloEmail");

            _emailService.EnviarEmail(new ProcessEmail(usuario.Email, true, texto, tituloEmail));
            await _saldoStore.InicializarSaldo(usuarioRegistrado);

            return usuarioRegistrado;
        }
    }
}