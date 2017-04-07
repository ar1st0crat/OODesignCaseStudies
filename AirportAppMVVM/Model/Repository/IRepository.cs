using System.Collections.Generic;

namespace AirportAppMVVM.Model.Repository
{
    public interface IRepository<T>
    {
        List<T> Load();
        void Save();
    }
}
