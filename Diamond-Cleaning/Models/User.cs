﻿using System.ComponentModel.DataAnnotations;

namespace Diamond_Cleaning.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string name)
        {
            Name = name;
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 25 символов")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Не указана электронная почта")]
        [EmailAddress(ErrorMessage="Нужно ввести валидный адрес электронной почты")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string RepeatPassword { get; set; }

        public string CheckBox { get; set; }

        public bool DoRememberMe => CheckBox == "on";
    }
}
