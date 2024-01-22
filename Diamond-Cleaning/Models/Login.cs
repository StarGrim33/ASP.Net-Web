using System.ComponentModel.DataAnnotations;

namespace Diamond_Cleaning.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указано логин")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
