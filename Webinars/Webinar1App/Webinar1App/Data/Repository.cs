using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Webinar1App.Entities;

namespace Webinar1App.Data
{
    /// <summary>
    /// Это production-репозиторий, работающий с реальным источником данных - 
    /// в нашем случае с json-файлом data.json
    /// </summary>
    class Repository : IRepository
    {
        private readonly List<Driver> _drivers = new List<Driver>();

        public IEnumerable<Driver> GetDrivers()
        {
            // logic of deserialization

            if (!File.Exists("data.json"))
            {
                return null;
            }

            using (var f = File.OpenText("data.json"))
            {
                var json = f.ReadToEnd();

                return JsonConvert.DeserializeObject<Driver[]>(json,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
        }

        public void AddDriver(Driver driver)
        {
            _drivers.Add(driver);
        }

        public void RemoveDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);

            if (driver != null)
            {
                _drivers.Remove(driver);
            }
        }
    }
}
