using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EventContext:DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventValue> EventsValue { get; set; }
        public DbSet<RegisterOnEvent> RegisterInEvent { get; set; }
    }
}
