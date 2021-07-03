using EventFlow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.EventSourcing.Application.Commands;
using Webinar3App.EventSourcing.Application.Interfaces;
using Webinar3App.EventSourcing.Models;

namespace Webinar3App.EventSourcing.Controllers
{
    public class DriversController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IDriverQueryService _driverQueryService;

        public DriversController(ICommandBus commandBus, IDriverQueryService driverQueryService)
        {
            _commandBus = commandBus;
            _driverQueryService = driverQueryService;
        }

        // GET: DriversController
        public async Task<ActionResult> Index(CancellationToken token)
        {
            var result = await _driverQueryService.GetActiveDrivers(token);

            return View(result);
        }

        // GET: DriversController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriversController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddDriverCommand command)
        {
            try
            {
                await _commandBus.PublishAsync(command, CancellationToken.None);

                return RedirectToAction(nameof(Index));
            }
            //catch (ValidationException ex)
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message });
            }
        }

        // GET: DriversController/Generate
        public async Task<ActionResult> Generate()
        {
            var command = new GenerateDriverCommand();

            await _commandBus.PublishAsync(command, CancellationToken.None);

            return RedirectToAction(nameof(Index));
        }

        // GET: DriversController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            await _commandBus.PublishAsync(new RemoveDriverCommand(id), CancellationToken.None);

            return RedirectToAction(nameof(Index));
        }

        // GET: DriversController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DriversController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
