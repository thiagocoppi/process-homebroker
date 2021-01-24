using Domain.Base;
using System;

namespace Domain.Acoes.Models
{
    public class Acao
    {
        public string Nome { get; private set; }
        public DateTime Data { get; private set; }
        public decimal ValorMercado { get; private set; }

        protected Acao()
        {
        }

        public Acao(string nome, DateTime data)
        {
            Nome = nome;
            Data = data;
        }

        public Acao(string nome, DateTime data, decimal valorMercado) : this(nome, data)
        {
            ValorMercado = valorMercado;
        }

        public void AlterarNomeAcao(string nome)
        {
            Nome = nome;
        }

        public void AlterarValorMercado (decimal valor)
        {
            ValorMercado = valor;
        }
    }
}