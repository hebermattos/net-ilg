using Domain;
using System.Collections.Generic;

namespace Infra
{
    public interface IDataRepository
    {
        List<Data> GetData();
    }
}