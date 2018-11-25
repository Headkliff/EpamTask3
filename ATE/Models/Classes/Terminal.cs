using System;
using ATE.Events;

namespace ATE.Models.Classes
{
    public class Terminal
    {
        public event EventHandler<CallEvent> CallEvent;
        public event EventHandler<AnswerEvent> AnswerEvent;
        public event EventHandler<EndCallEvent> EndCallEvent;

        private Guid Id { get; }
        public int TelephoneNumber { get; }
        private Port TerminalPort { get; }

        public Terminal(int number, Port port)
        {
            this.TelephoneNumber = number;
            this.TerminalPort = port;
        }
    }
}
