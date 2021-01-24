using Domain.Acoes.Models;
using Domain.Base;
using Domain.Lancamentos.Models;
using Domain.Usuarios.Models;
using System;

namespace Domain.Ordens.Models
{
    public class Ordem : BaseEntity
    {
        public Ordem(Acao acao, decimal valorCompra, int quantidade, DateTime data)
        {
            Acao = acao;
            ValorCompra = valorCompra;
            Quantidade = quantidade;            
            Data = data;
        }

        public Ordem(Guid id, Acao acao, decimal valorCompra, int quantidade, DateTime data) : this(acao, valorCompra, quantidade, data)
        {
            Id = id;
        }

        public Ordem(Acao acao, DateTime data, int quantidade, decimal valor, Usuario usuario, string assinatura, ETipoLancamento tipoOrdem)
        {
            Acao = acao;
            Data = data;
            Quantidade = quantidade;
            Usuario = usuario;
            ValorCompra = valor;
            AssinaturaEletronica = assinatura;
            TipoOrdem = tipoOrdem;
        }

        public Acao Acao { get; private set; }
        public DateTime Data { get; private set; }
        public int Quantidade { get; private set; }
        public Usuario Usuario { get; private set; }
        public decimal ValorCompra { get; private set; }
        public decimal ValorTotal => ValorCompra * Quantidade;
        public string AssinaturaEletronica { get; private set; }
        public ETipoLancamento TipoOrdem { get; private set; }

        public void AdicionarUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }

        public decimal ObterValorOrdem()
        {
            if (TipoOrdem == ETipoLancamento.C)
            {
                return ValorTotal * -1;
            }

            return ValorTotal;
        }

        public bool OrdemInvalida()
        {
            return Id == Guid.Empty;
        }
    }
}