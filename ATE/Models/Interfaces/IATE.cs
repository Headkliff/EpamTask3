using ATE.Events;
using ATE.Models.Classes;

namespace ATE.Models.Interfaces
{
    public interface IATE : IInfo<CallInfo>
    {
        Terminal GetNewTerminal(IContract contract);
        IContract RegisterContract(Subscriber subscriber);
        void CallingTo(object sender, ICallingEvent e);
    }
}
