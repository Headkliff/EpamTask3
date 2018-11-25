using System;
using ATE.Enums;

namespace ATE.Events
{
    public class AnswerEvent : EventArgs, ICallingEvent
    {
        public Guid Id { get; }
        public int TelephoneNumber { get; }
        public int CalledTelephoneNumber { get; }
        public CallState StateInCall { get; }

        public AnswerEvent(int number, int target, CallState state)
        {
            TelephoneNumber = number;
            CalledTelephoneNumber = target;
            StateInCall = state;
        }

        public AnswerEvent(Guid id, int number, int target, CallState state)
        {
            Id = id;
            TelephoneNumber = number;
            CalledTelephoneNumber = target;
            StateInCall = state;
        }
    }
}
