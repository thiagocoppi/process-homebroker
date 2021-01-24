using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlphaVantage.Models
{
    public class ListaAcoesModel
    {
        public ListaAcoesModel()
        {
            ListaAcoes = new List<AcaoModelResult>();
        }

        [JsonProperty("bestMatches")]
        public List<AcaoModelResult> ListaAcoes { get; set; }
    }

    public class AcaoModelResult
    {
        [JsonProperty("1. symbol")]
        public string Codigo { get; set; }

        [JsonProperty("2. name")]
        public string NomeEmpresa { get; set; }
    }
}