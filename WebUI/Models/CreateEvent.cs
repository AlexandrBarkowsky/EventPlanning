using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class CreateEventViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<EventValue> EventsValue { get; set; }
    }
}