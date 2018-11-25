using System;

namespace ATE.Events
{
    public interface ICallingEvent
    {
        Guid Id { get; }
        int TelephoneNumber { get; }
        int CalledTelephoneNumber { get; }

    }
}
