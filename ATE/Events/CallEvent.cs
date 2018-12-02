using System;

namespace ATE.Events
{
    public class CallEvent : EventArgs, ICallingEvent
    {
        public Guid Id { get; }
        public int TelephoneNumber { get; }
        public int CalledTelephoneNumber { get; }

        public CallEvent(int number, int target)
        {
            this.TelephoneNumber = number;
            this.CalledTelephoneNumber = target;
        }

        public CallEvent(int number, int target, Guid id)
        {
            this.TelephoneNumber = number;
            this.CalledTelephoneNumber = target;
            this.Id = id;
        }
    }
}
