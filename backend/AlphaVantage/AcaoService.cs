using AlphaVantage.Models;
using Domain.Acoes;
using Domain.Acoes.Models;
using Domain.HttpServices;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaVantage
{
    public class AcaoService : IAcaoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        private const string PROPERTY_VALOR_ACAO = "5. adjusted close";

        public AcaoService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpService httpService)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpService = httpService;
        }

        /// <summary>
        /// Devido ao Alpha Vantage ser necessário adicionar alguns nomes após o nome da ação foi necessário implementar essa busca para ter o nome correto dentro da API deles
        /// </summary>
        /// <param name="acao">Acao a ser buscada</param>
        /// <returns>Ação com o código correto</returns>
        public async Task<Acao> BuscarNomeAcao(Acao acao)
        {
            var acaoEndpoint = _configuration.GetValue<string>("AlphaVantage:BuscarAcaoEndpoint");
            var urlFormatada = string.Format(acaoEndpoint, acao.Nome);

            var result = await _httpService.GetResultAsync<ListaAcoesModel>(_httpClientFactory.CreateClient(nameof(AcaoService)),
                urlFormatada);

            if (result is null || !result.ListaAcoes.Any())
            {                
                throw new Exception("Não foi encontrado nenhuma ação com o código informado!");
            }

            var primeiro = result.ListaAcoes.First();

            acao.AlterarNomeAcao(primeiro.Codigo);
            return acao;
        }

        /// <summary>
        /// Realiza a busca do valor da ação
        /// </summary>
        /// <param name="acao"></param>
        /// <returns></returns>
        public async Task<Acao> BuscarValorMercado(Acao acao)
        {
            acao = await BuscarNomeAcao(acao);
            var apiKeyAlpha = _configuration.GetValue<string>("AlphaVantage:Key");
            var endpointValor = _configuration.GetValue<string>("AlphaVantage:BuscarValorAcaoEndpoint");
            var urlFormatada = string.Format(endpointValor, acao.Nome, apiKeyAlpha);

            var result = await _httpService.GetResultAsync<JObject>(_httpClientFactory.CreateClient(nameof(AcaoService)),
                urlFormatada);

            if (result is null)
            {
                throw new Exception("Não foi encontrado o valor da ação informada!");
            }

            var valor = result.Last.First.First.First.Value<decimal>(PROPERTY_VALOR_ACAO);
            acao.AlterarValorMercado(valor);
            return acao;
        }
    }
}