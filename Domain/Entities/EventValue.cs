using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EventValue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Название поля")]
        public string AttrName { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Значения поля")]
        public string AttrValue { get; set; }

        [Index]
        public int? EventId { get; set; }
        public Event Event { get; set; }
    }
}
