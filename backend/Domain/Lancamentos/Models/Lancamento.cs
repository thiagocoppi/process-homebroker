using Domain.Base;
using Domain.Ordens.Models;
using Domain.Usuarios.Models;
using System;

namespace Domain.Lancamentos.Models
{
    public class Lancamento : BaseEntity
    {
        public Lancamento(DateTime data, decimal valor, ETipoLancamento tipoLancamento, Usuario usuario)
        {
            Data = data;
            Valor = valor;
            TipoLancamento = tipoLancamento;
            Usuario = usuario;
        }

        public Lancamento(DateTime data, decimal valor, ETipoLancamento tipoLancamento, Ordem ordem, Usuario usuario) : this(data, valor, tipoLancamento, usuario)
        {
            Ordem = ordem;
        }

        public DateTime Data { get; private set; }
        public Ordem Ordem { get; private set; }
        public ETipoLancamento TipoLancamento { get; private set; }
        public Usuario Usuario { get; private set; }
        public decimal Valor { get; private set; }
    }
}