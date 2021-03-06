﻿using Domain.Segurancas.Models;
using Domain.Usuarios;
using Domain.Usuarios.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Segurancas
{
    public sealed class SegurancaService : ISegurancaService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioStore _usuarioStore;

        public SegurancaService(IConfiguration configuration, IUsuarioStore usuarioStore)
        {
            _configuration = configuration;
            _usuarioStore = usuarioStore;
        }

        public Task<Usuario> AbrirToken(Token token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenRead = handler.ReadToken(token.Info) as JwtSecurityToken;

            if (tokenRead is null)
            {                
                throw new Exception("Token inválido!");
            }

            var nome = tokenRead.Claims.First(r => r.Type == "Nome");
            var cpf = tokenRead.Claims.First(r => r.Type == "Cpf");
            var id = tokenRead.Claims.First(r => r.Type == "Id");

            return Task.FromResult(new Usuario(nome.Value, cpf.Value, id.Value));
        }

        public async Task<Token> GerarToken(Usuario usuario)
        {
            var usuarioEncontrado = await _usuarioStore.ObterUsuarioPeloEmail(usuario.Email);

            if (usuarioEncontrado is null)
            {
                throw new Exception("Não foi encontrado o usuário para este e-mail");
            }

            if (!usuario.SenhaEstaCorreta(usuarioEncontrado.Senha))
            {
                throw new Exception("Senha informada está errada!");
            }

            var applicationSecret = _configuration.GetValue<string>("ApplicationSecret");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(applicationSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Nome", usuarioEncontrado.Nome),
                    new Claim("Cpf", usuarioEncontrado.Cpf),
                    new Claim("Id", usuarioEncontrado.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token(tokenHandler.WriteToken(token));
        }
    }
}