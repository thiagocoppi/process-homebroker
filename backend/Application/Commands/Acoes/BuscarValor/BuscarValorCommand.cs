using MediatR;
using System;

namespace Application.Commands.Acoes.BuscarValor
{
    public class BuscarValorCommand : IRequest<BuscarValorCommandResult>
    {        
        public string Codigo { get; set; }
    }
}