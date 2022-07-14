using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Models
{
    [Serializable]
    public class Employee : Entity
    {
        private string v1;
        private string v2;
        private string v3;
        private EmployeeCategory manager;

        public Employee()
        {
        }

        public Employee(string v1, string v2, string v3, EmployeeCategory manager)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.manager = manager;
        }

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
