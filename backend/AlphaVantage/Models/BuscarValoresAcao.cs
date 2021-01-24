using Newtonsoft.Json;

namespace AlphaVantage.Models
{
    public class BuscarValoresAcao
    {
        [JsonProperty("Time Series (Daily)")]
        public ListaCotacoes Cotacoes { get; set; }
    }

    public class ListaCotacoes
    {
        public ItemAcao Valor { get; set; }
    }

    public class ItemAcao
    {
        [JsonProperty("5. adjusted close")]
        public decimal ValorMedio { get; set; }
    }
}