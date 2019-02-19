using System.Collections.Generic;

namespace Infra
{
    public interface IDataRepository
    {
        IEnumerable<string> GetRawData();

        void SaveReport(IEnumerable<string> report);
    }
}