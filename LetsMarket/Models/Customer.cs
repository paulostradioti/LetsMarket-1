using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Models
{
    public class Customer
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "O Documento é Obrigatório")]
        [MinLength(11)]
        [MaxLength(11)]
        public string Document { get; set; }


        [Display(Name = "Categoria")]
        public CustomerCategory? Category { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Document}";
        }
    }
}
