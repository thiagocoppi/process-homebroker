using System;

namespace Application.Commands.Ordens.Cadastrar
{
    public class CadastrarOrdemCommandResult
    {
        public DateTime DataCadastro { get; set; }
        public string Codigo { get; set; }
        public decimal Valor { get; set; }
    }
}