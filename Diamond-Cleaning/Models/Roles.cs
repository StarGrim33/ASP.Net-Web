using System.ComponentModel.DataAnnotations;

namespace Diamond_Cleaning.Models
{
    public class Roles
    {
        public Roles() { }

        public Roles(string name) 
        { 
            Name = name;
        }

        [Required(ErrorMessage="Не указано имя роли")]
        [StringLength(50, MinimumLength=1, ErrorMessage= "Имя роли должно содержать от 1 до 50 символов")]
        public string Name { get; set; }

    }
}
