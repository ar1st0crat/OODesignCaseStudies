using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webinar1App.Services;

namespace Webinar2App.AspNetMvc.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService = new DriverService();

        // GET: DriverController
        public ActionResult Index()
        {
            return View(_driverService.GetDrivers());
        }

        // GET: DriverController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DriverController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DriverController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
