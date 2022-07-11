using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Models
{
    public class Employee
    {
        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Categoria")]
        public EmployeeCategory Category { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
