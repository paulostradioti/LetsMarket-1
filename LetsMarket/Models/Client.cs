using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Models
{
    public class Client
    {
        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "O Documento é Obrigatório")]
        [MinLength(11)]
        [MaxLength(11)]
        public string Documento { get; set; }


        [Display(Name = "Categoria")]
        public ClientCategory? Category { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Documento}";
        }
    }
}
