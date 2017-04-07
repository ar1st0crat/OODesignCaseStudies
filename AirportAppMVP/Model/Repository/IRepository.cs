using System.Collections.Generic;

namespace AirportAppMVP.Model.Repository
{
    public interface IRepository<T>
    {
        List<T> Load();
        void Save();
    }
}
