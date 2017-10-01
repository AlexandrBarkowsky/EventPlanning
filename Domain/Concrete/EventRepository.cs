using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EventRepository : IEventRepository
    {
        EventContext context = new EventContext();
        public IEnumerable<Event> Events { get { return context.Events; } }
        public IEnumerable<EventValue> EventsValue { get { return context.EventsValue; } }
        public IEnumerable<RegisterOnEvent> RegisterInEvent { get { return context.RegisterInEvent; } }

        //Загрузка связанных данных
        public Event GetAllEventValue(Event eventObj) {
            context.Entry(eventObj).Collection(c => c.EventsValue).Load();
            return eventObj;
        }
        public bool SaveEvent(Event Event) {
            if (Event.Id == 0) {
                context.Events.Add(Event);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool SaveRegisterUser(RegisterOnEvent user) {
            context.RegisterInEvent.Add(user);
            context.SaveChanges();
            return true;
        }
        public void Update(RegisterOnEvent user) {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void UpdateReservedPeople(Event Event)
        {
            context.Entry(Event).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
