using Domain.Ordens.Models;
using Domain.Segurancas;
using Domain.Usuarios;
using System;
using System.Threading.Tasks;

namespace Domain.Ordens
{
    public sealed class OrdemService : IOrdemService
    {
        private readonly IOrdemStore _ordemStore;        
        private readonly IUsuarioStore _usuarioStore;

        public OrdemService(IOrdemStore ordemStore, IUsuarioStore usuarioStore)
        {
            _ordemStore = ordemStore;
            _usuarioStore = usuarioStore;
        }

        public async Task<Ordem> CadastrarOrdem(Ordem ordem)
        {
            var usuarioRegistrado = await _usuarioStore.ObterUsuarioPeloId(ordem.Usuario.Id);
            var senhaCorreta = usuarioRegistrado.EhMesmoHash(ordem.AssinaturaEletronica, usuarioRegistrado.SenhaTransacaoEletronica);

            if (!senhaCorreta)
            {
                throw new Exception("Assinatura eletrônica está errada, tenta novamente!");
            }

            return await _ordemStore.CadastrarOrdem(ordem);
        }
    }
}