using Domain.Lancamentos.Models;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Application.Commands.Ordens.Cadastrar
{
    public class CadastrarOrdemCommand : IRequest<CadastrarOrdemCommandResult>
    {
        public AcaoCommand Acao { get; set; }
        [JsonIgnore]
        public UsuarioCommand Usuario { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public string AssinaturaEletronica { get; set; }
        public DateTime Data { get; set; }
        public ETipoLancamento TipoOrdem { get; set; }
    }

    public class AcaoCommand
    {
        public string Codigo { get; set; }
        public decimal ValorMercado { get; set; }
    }

    public class UsuarioCommand
    {
        public string Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
}