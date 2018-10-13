using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

//Модель для регистрации
namespace Unity_State.Models
{
    public class ClientModel
    {
        public enum Gender
        {
            Male, Famale
        }
        [Required(ErrorMessage = "Не указано имя")]
        public string login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression(@"[A-Za-z0-9._%+-]",ErrorMessage ="Некорректный пароль")]
        public string password { get; set; }
        public Gender gender;
        [Required(ErrorMessage = "Номер не указан")]
        [Phone(ErrorMessage ="Некорректный номер")]
        public string number;
        [Required(ErrorMessage = "Не указан e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckEmail", controller: "Home", HttpMethod = "POST", ErrorMessage = "Email уже используется")]
         public string email { get; set; }

    }
}
