using System;
using ATE.Enums;
using ATE.Events;

namespace ATE.Models.Classes
{
    public class Port
    {
        public event EventHandler<CallEvent> CallPortEvent;
        public event EventHandler<AnswerEvent> AnswerPortEvent;
        public event EventHandler<CallEvent> CallEvent;
        public event EventHandler<AnswerEvent> AnswerEvent;

        public event EventHandler<EndCallEvent> EndCallEvent;


        public PortState State;
        public bool Flag;

        public Port()
        {
            State = PortState.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == PortState.Disconnect)
            {
                State = PortState.Connect;
                terminal.CallEvent += CallingTo;
                terminal.AnswerEvent += AnswerTo;
                terminal.EndCallEvent += EndCall;
                Flag = true;
            }
            return Flag;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == PortState.Connect)
            {
                State = PortState.Disconnect;
                terminal.CallEvent += CallingTo;
                terminal.AnswerEvent += AnswerTo;
                terminal.EndCallEvent += EndCall;
                Flag = false;
            }
            return false;
        }

        protected virtual void RaiseIncomingCallEvent(int number, int calledNumber)
        {
            if (CallPortEvent != null)
            {
                CallPortEvent(this, new CallEvent(number, calledNumber));
            }
        }

        protected virtual void RaiseIncomingCallEvent(int number, int calledNumber, Guid id)
        {
            if (CallPortEvent != null)
            {
                CallPortEvent(this, new CallEvent(number, calledNumber, id));
            }
        }

        protected virtual void RaiseAnswerCallEvent(int number, int calledNumber, CallState state)
        {
            if (AnswerPortEvent != null)
            {
                AnswerPortEvent(this, new AnswerEvent(number, calledNumber, state));
            }
        }

        protected virtual void RaiseAnswerCallEvent(int number, int calledNumber, CallState state, Guid id)
        {
            if (AnswerPortEvent != null)
            {
                AnswerPortEvent(this, new AnswerEvent(id, number, calledNumber, state));
            }
        }

        protected virtual void RaiseCallingToEvent(int number, int calledNumber)
        {
            if (CallEvent != null)
            {
                CallEvent(this, new CallEvent(number, calledNumber));
            }
        }

        protected virtual void RaiseAnswerToEvent(AnswerEvent eventArgs)
        {
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new AnswerEvent(
                    eventArgs.Id,
                    eventArgs.CalledTelephoneNumber,
                    eventArgs.CalledTelephoneNumber,
                    eventArgs.StateInCall));
            }
        }

        protected virtual void RaiseEndCallEvent(Guid id, int number)
        {
            if (EndCallEvent != null)
            {
                EndCallEvent(this, new EndCallEvent(id, number));
            }
        }

        private void CallingTo(object sender, CallEvent e)
        {
            RaiseCallingToEvent(e.TelephoneNumber, e.CalledTelephoneNumber);
        }

        private void AnswerTo(object sender, AnswerEvent e)
        {
            RaiseAnswerToEvent(e);
        }

        private void EndCall(object sender, EndCallEvent e)
        {
            RaiseEndCallEvent(e.Id, e.TelephoneNumber);
        }

        public void IncomingCall(int number, int calledNumber)
        {
            RaiseIncomingCallEvent(number, calledNumber);
        }

        public void IncomingCall(int number, int calledNumber, Guid id)
        {
            RaiseIncomingCallEvent(number, calledNumber, id);
        }

        public void AnswerCall(int number, int calledNumber, CallState state)
        {
            RaiseAnswerCallEvent(number, calledNumber, state);
        }

        public void AnswerCall(int number, int calledNumber, CallState state, Guid id)
        {
            RaiseAnswerCallEvent(number, calledNumber, state, id);
        }
    }
}
