using System;

namespace Application.Commands.Acoes.BuscarValor
{
    public class BuscarValorCommandResult
    {
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}