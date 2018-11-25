using ATE.Models.Classes;

namespace ATE.Models.Interfaces
{
    public interface IContract
    {
        Subscriber Subscriber { get; }
        int Number { get; }
        Tariff Tariff { get; }
    }
}
