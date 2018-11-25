using System;

namespace ATE.Events
{
    public class EndCallEvent : EventArgs, ICallingEvent
    {
        public Guid Id { get; }
        public int TelephoneNumber { get; }
        public int CalledTelephoneNumber { get; }

        public EndCallEvent(Guid id, int number)
        {
            Id = id;
            TelephoneNumber = number;
        }
    }
}
