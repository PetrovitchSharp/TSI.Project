using System;
using System.ComponentModel.DataAnnotations;

namespace TSI.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Введите ФИО")]
        [RegularExpression("[a-zA-Zа-яА-Я]",ErrorMessage = "ФИО может содержать следующие символы: латиница и кириллица")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [MaxLength(31, ErrorMessage = "Адрес почты не может быть длиннее 31 символа")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [MaxLength(20, ErrorMessage = "Пароль не может быть длиннее 20 символов")]
        [MinLength(6, ErrorMessage = "Пароль не может быть короче 6 символов")]
        [RegularExpression("[a-zA-Z\\d_]{6,20}", ErrorMessage = "Пароль должен содержать от 6 до 20 символов: латиница, цифры и подчёркивания")]
        public string Password { get; set; }
    }

}
