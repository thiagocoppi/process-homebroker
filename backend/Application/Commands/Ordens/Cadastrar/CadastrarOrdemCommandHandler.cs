using Domain.Acoes.Models;
using Domain.Lancamentos.Models;
using Domain.Ordens;
using Domain.Ordens.Models;
using Domain.Usuarios.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Ordens.Cadastrar
{
    public class CadastrarOrdemCommandHandler : IRequestHandler<CadastrarOrdemCommand, CadastrarOrdemCommandResult>
    {
        private readonly IOrdemService _ordemService;

        public CadastrarOrdemCommandHandler(IOrdemService ordemService)
        {
            _ordemService = ordemService;
        }

        public async Task<CadastrarOrdemCommandResult> Handle(CadastrarOrdemCommand request, CancellationToken cancellationToken)
        {
            var ordemCadastrada = await _ordemService.CadastrarOrdem(new Ordem(new Acao(request.Acao.Codigo, request.Data, request.Acao.ValorMercado),
                request.Data, request.Quantidade, request.Valor, new Usuario(request.Usuario.Nome, request.Usuario.Cpf, request.Usuario.Id), 
                request.AssinaturaEletronica, request.TipoOrdem));

            return new CadastrarOrdemCommandResult()
            {
                Codigo = ordemCadastrada.Acao.Nome,
                DataCadastro = ordemCadastrada.Data,
                Valor = ordemCadastrada.ValorTotal
            };
        }
    }
}