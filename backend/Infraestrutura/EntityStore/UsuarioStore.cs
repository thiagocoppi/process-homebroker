using Dapper;
using Domain.Usuarios;
using Domain.Usuarios.Models;
using Infraestrutura.Context;
using System;
using System.Threading.Tasks;

namespace Infraestrutura.EntityStore
{
    public sealed class UsuarioStore : IUsuarioStore
    {
        private readonly IProcessContext _context;

        public UsuarioStore(IProcessContext context)
        {
            _context = context;
        }

        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            var idGerado = await _context.GetConnection().ExecuteScalarAsync<Guid>(SQL_INSERIR_NOVO_USUARIO, new
            {
                nome = usuario.Nome,
                email = usuario.Email,
                cpf = usuario.Cpf,
                celular = usuario.Celular,
                dtnascimento = usuario.DataNascimento,
                senha = usuario.Senha,
                senha_transacao = usuario.SenhaTransacaoEletronica
            });
            usuario.AlterarIdentificador(idGerado);
            return usuario;
        }

        public async Task<bool> VerificarUsuarioExiste(string cpf)
        {
            return await _context.GetConnection().QueryFirstOrDefaultAsync<bool>(SQL_VERIFICAR_USUARIO_EXISTE_PELO_CPF_CNPJ, new
            {
                cpf
            });
        }

        public async Task<Usuario> ObterUsuarioPeloEmail(string email)
        {
            return await _context.GetConnection().QueryFirstOrDefaultAsync<Usuario>(SQL_OBTER_USUARIO_PELO_EMAIL, new
            {
                email
            });
        }

        private const string SQL_INSERIR_NOVO_USUARIO =
            @"INSERT INTO USUARIO (NOME, EMAIL, CPF, CELULAR, DTNASCIMENTO, SENHA, SENHA_TRANSACAO) VALUES (:nome, :email, :cpf, :celular, :dtnascimento, :senha, :SENHA_TRANSACAO) RETURNING ID";

        private const string SQL_VERIFICAR_USUARIO_EXISTE_PELO_CPF_CNPJ =
            @"SELECT 1 FROM USUARIO WHERE CPF = :cpf";

        private const string SQL_OBTER_USUARIO_PELO_EMAIL =
            @"SELECT ID, 
                     NOME, 
                     SENHA, 
                     SENHA_TRANSACAO as SenhaTransacaoEletronica, 
                     EMAIL, 
                     CPF, 
                     CELULAR, 
                     DTNASCIMENTO as DataNascimento
            FROM USUARIO 
              WHERE EMAIL = :email";
    }
}