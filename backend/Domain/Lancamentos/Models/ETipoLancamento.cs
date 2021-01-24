using System.ComponentModel.DataAnnotations;

namespace Domain.Lancamentos.Models
{
    public enum ETipoLancamento
    {
        [Display(Description = "Lancamento de compra")]
        C = 0,
        [Display(Description = "Lancamento de venda")]
        V = 1,
        [Display(Description = "Lancamento de retirada")]
        R = 2,
        [Display(Description = "Lancamento de depósito")]
        D = 3
    }
}
