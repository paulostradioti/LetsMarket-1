using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Models
{
    [Serializable]
    public class Product // : Entity
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é obrigatório")]
        public string Code { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Description { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Price { get; set; }

        [Display(Name = "Id")]
        //[Required(ErrorMessage = "O id é obrigatório")]
        public long Id { get; set; } = 0;

        public override string ToString()
        {
            return Description;
        }
    }
}
