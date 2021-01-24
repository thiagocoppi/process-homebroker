using Domain.Lancamentos;
using Domain.Lancamentos.Models;
using Domain.Ordens.Models;
using Domain.Saldos;
using Domain.Usuarios;
using System;
using System.Threading.Tasks;

namespace Domain.Ordens
{
    public sealed class OrdemService : IOrdemService
    {
        private readonly IOrdemStore _ordemStore;
        private readonly ISaldoService _saldoService;
        private readonly ILancamentoService _lancamentoService;
        private readonly IUsuarioStore _usuarioStore;

        public OrdemService(IOrdemStore ordemStore, IUsuarioStore usuarioStore,
            ISaldoService saldoService, ILancamentoService lancamentoService)
        {
            _ordemStore = ordemStore;
            _usuarioStore = usuarioStore;
            _saldoService = saldoService;
            _lancamentoService = lancamentoService;
        }

        public async Task<Ordem> CadastrarOrdem(Ordem ordem)
        {
            var usuarioRegistrado = await _usuarioStore.ObterUsuarioPeloId(ordem.Usuario.Id);
            var senhaCorreta = usuarioRegistrado.EhMesmoHash(ordem.AssinaturaEletronica, usuarioRegistrado.SenhaTransacaoEletronica);

            if (!senhaCorreta)
            {
                throw new Exception("Assinatura eletrônica está errada, tenta novamente!");
            }

            var ordemCadastrada = await _ordemStore.CadastrarOrdem(ordem);

            if (ordemCadastrada.OrdemInvalida())
            {
                throw new Exception("Ocorreu uma tentativa de duplicação ao cadastrar a ordem!");
            }

            _ = await _saldoService.ComporSaldo(ordem);
            _ = await _lancamentoService.RegistrarLancamento(new Lancamento(ordemCadastrada.Data, ordemCadastrada.ObterValorOrdem(), ordemCadastrada.TipoOrdem, ordemCadastrada, usuarioRegistrado));

            return ordemCadastrada;
        }
    }
}