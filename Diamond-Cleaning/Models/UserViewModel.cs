using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Diamond_Cleaning.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(string name, string password, string firstName, string lastName, string phone)
        {
            Guid = Guid.NewGuid();
            Role = new Roles("User");
            Name = name;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public Guid Guid { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 25 символов")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string RepeatPassword { get; set; }

        public string CheckBox { get; set; }

        public bool DoRememberMe => CheckBox == "on";

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public Roles Role { get; set; }
    }
}
