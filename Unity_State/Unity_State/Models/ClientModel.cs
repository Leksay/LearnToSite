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
        public int Id { get; set; }

        public enum Gender
        {
            Male, Famale
        }
        [Required(ErrorMessage = "Не указано имя")]
        public string login { get; set; }
       
        //[RegularExpression(@"[A-Za-z0-9._%+-]",ErrorMessage ="Некорректный пароль")]
        [Required(ErrorMessage ="Введите пароль")]
       
        public string password { get; set; }
        public Gender gender;
        
        [Required]
        [Phone(ErrorMessage = "Некорректный номер")]
        public string number { get; set; }

        [Required]
        [Range(1, 110, ErrorMessage = "Недопустимыйвозраст")] 
        public int age { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckEmail", controller: "Home", HttpMethod = "POST", ErrorMessage = "Email уже используется")]
         public string email { get; set; }

        public DateTime regDate;

        
    }
}
