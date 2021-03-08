using Newtonsoft.Json;
using System.IO;

namespace Webinar1App.Data
{
    class UnitOfWork : IUnitOfWork
    {
        public IRepository Repository { get; } = new MockRepository();

        public void SaveChanges()
        {
            var drivers = Repository.GetDrivers();

            var json = JsonConvert.SerializeObject(drivers, Formatting.Indented,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            using (var f = File.CreateText("data.json"))
            {
                f.Write(json);
            }
        }
    }
}
