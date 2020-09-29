using System;
using OpenEventSourcing.Events;

namespace SIO.Testing.Stubs
{
    public class TestEvent : Event
    {
        public TestEvent(Guid aggregateId, int version) : base(aggregateId, version)
        {
        }
    }
}
