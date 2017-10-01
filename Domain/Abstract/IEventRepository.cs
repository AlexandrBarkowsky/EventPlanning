using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IEventRepository
    {
        IEnumerable<Event> Events { get; }
        IEnumerable<EventValue> EventsValue { get; }
        IEnumerable<RegisterOnEvent> RegisterInEvent { get; }
        Event GetAllEventValue(Event eventObj);
        bool SaveEvent(Event Event);
        bool SaveRegisterUser(RegisterOnEvent user);
        void Update(RegisterOnEvent user);
        void UpdateReservedPeople(Event Event);
    }
}
