using System.Collections.Generic;

namespace Infra
{
    public interface IDataRepository
    {
        IEnumerable<string> GetData();
    }
}