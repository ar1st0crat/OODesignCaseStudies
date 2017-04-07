using System.Collections.Generic;

namespace AirportAppMVC.Model.Repository
{
    public interface IRepository<T>
    {
        List<T> Load();
        void Save();
    }
}