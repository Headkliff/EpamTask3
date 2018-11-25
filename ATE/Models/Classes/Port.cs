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

        protected virtual void RaiseIncomingCallEvent(int number, int targetNumber)
        {
            if (CallPortEvent != null)
            {
                CallPortEvent(this, new CallEvent(number, targetNumber));
            }
        }

        protected virtual void RaiseIncomingCallEvent(int number, int targetNumber, Guid id)
        {
            if (CallPortEvent != null)
            {
                CallPortEvent(this, new CallEvent(number, targetNumber, id));
            }
        }

        protected virtual void RaiseAnswerCallEvent(int number, int targetNumber, CallState state)
        {
            if (AnswerPortEvent != null)
            {
                AnswerPortEvent(this, new AnswerEvent(number, targetNumber, state));
            }
        }

        protected virtual void RaiseAnswerCallEvent(int number, int targetNumber, CallState state, Guid id)
        {
            if (AnswerPortEvent != null)
            {
                AnswerPortEvent(this, new AnswerEvent(id, number, targetNumber, state));
            }
        }

        protected virtual void RaiseCallingToEvent(int number, int targetNumber)
        {
            if (CallEvent != null)
            {
                CallEvent(this, new CallEvent(number, targetNumber));
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

        public void IncomingCall(int number, int targetNumber)
        {
            RaiseIncomingCallEvent(number, targetNumber);
        }

        public void IncomingCall(int number, int targetNumber, Guid id)
        {
            RaiseIncomingCallEvent(number, targetNumber, id);
        }

        public void AnswerCall(int number, int targetNumber, CallState state)
        {
            RaiseAnswerCallEvent(number, targetNumber, state);
        }

        public void AnswerCall(int number, int targetNumber, CallState state, Guid id)
        {
            RaiseAnswerCallEvent(number, targetNumber, state, id);
        }
    }
}
