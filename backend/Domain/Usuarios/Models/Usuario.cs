using Domain.Base;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Usuarios.Models
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string cpf, string email, DateTime dataNascimento, string celular, string senha)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataNascimento = dataNascimento;
            Celular = celular;
            Senha = GerarMD5(senha);            
        }

        public Usuario(string nome, string cpf, string email, DateTime dataNascimento, string celular, string senha, Guid id)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataNascimento = dataNascimento;
            Celular = celular;
            Senha = senha;
        }

        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public Usuario(string nome, string cpf, string id)
        {
            Nome = nome;
            Cpf = cpf;
            Id = Guid.Parse(id);
        }

        protected Usuario()
        {

        }

        public string Celular { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string SenhaTransacaoEletronica { get; private set; }

        public string AdicionarSenhaTransacaoEletronica()
        {
            var senha = GerarSenhaTransacaoEletronica();
            SenhaTransacaoEletronica = GerarMD5(senha);

            return senha;
        }

        private string GerarSenhaTransacaoEletronica()
        {
            var textoAssinatura = Nome.ToUpper().Substring(0, 3);
            var random = new Random();
            var numeroGerado = random.Next(1000, 9999);
            return string.Concat(textoAssinatura, numeroGerado.ToString());
        }

        /// <summary>
        /// Verifica se as senhas são iguais
        /// </summary>
        /// <param name="hashArmazenado">Hash armazenado anteriormente</param>
        /// <returns>TRUE se forem o mesmo</returns>
        public bool SenhaEstaCorreta(string hashArmazenado)
        {
            return EhMesmoHash(Senha, hashArmazenado);
        }

        public bool EhMesmoHash(string senha, string hash)
        {
            var hashNovo = GerarMD5(senha);

            return hashNovo == hash;
        }

        private string GerarMD5(string senha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}