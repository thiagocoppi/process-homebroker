using Dapper;
using Domain.Ordens.Models;
using Domain.Saldos;
using Domain.Saldos.Models;
using Domain.Usuarios.Models;
using Infraestrutura.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.EntityStore
{
    public class SaldoStore : ISaldoStore
    {
        private readonly IProcessContext _context;

        public SaldoStore(IProcessContext context)
        {
            _context = context;
        }

        public async Task<Saldo> ComporSaldo(Ordem ordem)
        {
            var saldoAtual = await _context.GetConnection().ExecuteScalarAsync<decimal>(SQL_ATUALIZAR_SALDO, new
            {
                valor_composicao = ordem.ObterValorOrdem(),
                usuario_id = ordem.Usuario.Id
            });

            return new Saldo(ordem.Usuario, saldoAtual);
        }

        public async Task<Saldo> ObterSaldo(Usuario usuario)
        {
            var result = await _context.GetConnection().QueryAsync<Usuario, Saldo, Saldo>(SQL_OBTER_SALDO_ATUAL, param: new
            {
                id = usuario.Id
            }, map: (usuario, saldo) =>
            {
                return new Saldo(usuario, saldo.SaldoAtual);
            }, splitOn: "SaldoTotal");

            return result.First();
        }

        public async Task InicializarSaldo(Usuario usuario)
        {
            await _context.GetConnection().ExecuteAsync(SQL_INICIALIZAR_SALDO, new
            {
                saldo_atual = 0,
                usuario_id = usuario.Id
            });
        }

        private const string SQL_ATUALIZAR_SALDO =
            @"UPDATE SALDO SET SALDO_ATUAL = (SALDO_ATUAL + :valor_composicao) WHERE usuario_id = :usuario_id RETURNING SALDO_ATUAL";

        private const string SQL_OBTER_SALDO_ATUAL =
            @"SELECT usu.ID,
                     usu.NOME,
                     usu.SENHA,
                     usu.SENHA_TRANSACAO as SenhaTransacaoEletronica,
                     usu.EMAIL,
                     usu.CPF,
                     usu.CELULAR,
                     usu.DTNASCIMENTO as DataNascimento,
                     sal.saldo_total as SaldoTotal,
                     sal.id
            FROM saldo sal
              INNER JOIN USUARIO usu on usu.id = sal.usuario_id
              WHERE sal.ID = :id";

        private const string SQL_INICIALIZAR_SALDO =
            @"INSERT INTO SALDO (SALDO_ATUAL, USUARIO_ID) VALUES (:saldo_atual, :usuario_id)";
    }
}