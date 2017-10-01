using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Event // Event // Команда
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя должно быть установлено")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Дата на мероприятие не может быть пустой")]
        [Column(TypeName = "date")]
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]//Тут исправить
        public DateTime Date { get; set; }

        
        [Required(ErrorMessage = "Время на мероприятие не может быть пустой")]
        [Display(Name = "Время")]
        public TimeSpan Time { get; set; }

       
        [Required(ErrorMessage = "Количество не может быть пустым")]
        [Range(1,int.MaxValue, ErrorMessage = "Ошибка ввода количества человек")]
        [Display(Name = "Количество человек на мероприятии")]
        public int CountPeople { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ReservedPeople { get; set; }

        public ICollection<EventValue> EventsValue { get; set; }
        public Event()
        {
            EventsValue = new List<EventValue>();
        }
    }

}
