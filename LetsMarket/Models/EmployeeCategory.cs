using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public enum EmployeeCategory
    {
        [Display(Name = "Caixa")]
        Cashier,

        [Display(Name = "Gerente")]
        Manager,

        [Display(Name = "Assistente")]
        Assistant,
    }
}
