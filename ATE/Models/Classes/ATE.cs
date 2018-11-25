using System;
using System.Collections.Generic;
using ATE.Events;
using ATE.Models.Interfaces;

namespace ATE.Models.Classes
{
    public class ATE : IATE
    {
        private IDictionary<int, Tuple<Port, IContract>> _usersData;
        private IList<CallInfo> _callList = new List<CallInfo>();

        public ATE()
        {
            _usersData = new Dictionary<int, Tuple<Port, IContract>>();

        }

        public Terminal GetNewTerminal(IContract contract)
        {
            var newPort = new Port();
            _usersData.Add(contract.Number, new Tuple<Port, IContract>(newPort, contract));
            var newTerminal = new Terminal(contract.Number, newPort);
            return newTerminal;
        }

        public IContract RegisterContract(Subscriber subscriber)
        {
            return null;
        }

        public void CallingTo(object sender, ICallingEvent e)
        {

        }

        public IList<CallInfo> GetInfoList()
        {
            return _callList;
        }
    }
}
