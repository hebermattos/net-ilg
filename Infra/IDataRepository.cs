using System.Collections.Generic;

namespace Infra
{
    public interface IDataRepository
    {
        IEnumerable<string> GetData();

        void SaveReport(IEnumerable<string> report);
    }
}