using Dapper;
using Domain.Ordens;
using Domain.Ordens.Models;
using Infraestrutura.Context;
using System;
using System.Threading.Tasks;

namespace Infraestrutura.EntityStore
{
    public class OrdemStore : IOrdemStore
    {
        private readonly IProcessContext _processContext;

        public OrdemStore(IProcessContext processContext)
        {
            _processContext = processContext;
        }

        public async Task<Ordem> CadastrarOrdem(Ordem ordem)
        {
            var IdOrdem = await _processContext.GetConnection().ExecuteScalarAsync<Guid>(SQL_CADASTRAR_NOVA_ORDEM, new
            {
                data = ordem.Data,
                preco = ordem.ValorCompra,
                quantidade = ordem.Quantidade,
                codigo = ordem.Acao.Nome,
                usuario_id = ordem.Usuario.Id,
                valor_total = ordem.ValorTotal
            });
            ordem.AlterarIdentificador(IdOrdem);
            return ordem;
        }

        /// <summary>
        /// Faz o insert e garante que haverá apenas uma ordem cadastrada para o usuário em caso de duplicidade de requests
        /// </summary>
        private const string SQL_CADASTRAR_NOVA_ORDEM =
            @"INSERT INTO ORDEM (DATA, PRECO, QUANTIDADE, CODIGO, USUARIO_ID, VALOR_TOTAL) 
                SELECT :data, :preco, :quantidade, :codigo, :usuario_id, :valor_total WHERE NOT EXISTS (SELECT ID FROM ORDEM WHERE DATA = :data AND PRECO = :preco AND USUARIO_ID = :usuario_id)
              RETURNING id";


    }
}