using Christ3D.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Events.Student
{
    public class StudentRemovedEvent : Event
    {
        public StudentRemovedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
