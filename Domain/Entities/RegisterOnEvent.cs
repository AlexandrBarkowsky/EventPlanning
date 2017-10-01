using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class RegisterOnEvent
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Email")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Не верный mail, пример admin@mail.ru")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Token { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool EmailConfirmed { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
