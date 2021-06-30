using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Webinar3App.AspNetMvc.Application.Commands;
using Webinar3App.AspNetMvc.Application.Queries;
using Webinar3App.AspNetMvc.Models;

namespace Webinar3App.AspNetMvc.Controllers
{
    public class DriversController : Controller
    {
        private readonly IMediator _mediator;           // a.k.a. ICommandBus

        public DriversController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: DriversController
        public async Task<ActionResult<GetDriversQuery.Result>> Index()
        {
            var query = new GetDriversQuery.Query();

            var result = await _mediator.Send(query);

            return View(result);
        }

        // GET: DriversController/Generate
        public async Task<ActionResult<GetDriversQuery.Result>> Generate(IFormCollection collection)
        {
            var command = new GenerateDriverCommand.Command();

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        // GET: DriversController/Delete/5
        public async Task<ActionResult<RemoveDriverCommand.Result>> Delete(int id)
        {
            var command = new RemoveDriverCommand.Command()
            {
                Id = id
            };

            var result = await _mediator.Send(command);

            if (result.Error != null)
            {
                return View("Error", new ErrorViewModel() { RequestId = result.Error });
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: DriversController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddDriverCommand.Command command)
        {
            try
            {
                await _mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message });
            }
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
