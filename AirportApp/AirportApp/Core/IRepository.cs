using System.Collections.Generic;

namespace AirportApp.Core
{
    public interface IRepository<T>
    {
        List<T> Load();
        List<T> LoadByDepartureCity(string city);
        void Save();
    }
}

// Пример generic-класса.
// Похоже на шаблоны в С++, но реализовано совсем иначе 
// (в .NET это не просто "большой макрос", но это отдельный тип)
//
//public class MyList<T> where T : Company      // можно вводить ограничения на тип T
//{
//    public void Add(T elem)
//    {
//        elem.Name = "vasya"; 
//    }
//}