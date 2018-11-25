using System.Collections.Generic;

namespace ATE.Models.Interfaces
{
    public interface IInfo<T>
    {
        IList<T> GetInfoList();
    }
}
