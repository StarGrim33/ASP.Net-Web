using System.ComponentModel.DataAnnotations;

namespace Diamond_Cleaning.Models
{
    public class EditUserViewModel
    {
        [Required(ErrorMessage = "Не указано логин")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 200 символов")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Телефон пользователя должно содержать от 5 до 50 символов")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string NewPassword { get; set; }
    }
}
