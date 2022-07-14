using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Models
{
    [Serializable]
    public class Employee : Entity
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

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
            return Name;
        }

        internal bool ValidatePassword(string password)
        {
            return true;
        }
    }
}
