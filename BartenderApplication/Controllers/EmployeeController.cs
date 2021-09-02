using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BartenderApplication.Models;
using BartenderApplication.Repository;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using BartenderApplication.Models.ViewModels;
using BartenderApplication.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BartenderApplication.Controllers
{
    [Authorize("Employee")]
    public class EmployeeController : Controller
    {
        private FakeRepository _fakeRepository;

        public EmployeeController(FakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<TicketsModel> tickets = _fakeRepository.Tickets;
            return View("~/Views/Home/Employee.cshtml", tickets.ToList());
        }

        [HttpPost]
        public IActionResult Complete(string id)
        {
            TicketsModel ticketsModel = _fakeRepository.Tickets.Where(x => x.Id == id).FirstOrDefault();

            if (ticketsModel is null) { return NotFound($"Ticket with ID: {id} not found."); }

            _fakeRepository.Tickets.Remove(ticketsModel);

            return RedirectToAction("Index");

        }
    }
}
