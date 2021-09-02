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
    [Authorize("Customer")]
    public class CustomerController : Controller
    {
        private FakeRepository _fakeRepository;

        public CustomerController(FakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<DrinksModel> drinksmodel = _fakeRepository.Drinks;
            return View("~/Views/Home/Customer.cshtml", drinksmodel.ToList());
        }

        public IActionResult CreateTicket(TicketsModel ticketsModel)
        {
            ticketsModel.Id = Guid.NewGuid().ToString();
            _fakeRepository.Tickets.Add(ticketsModel);
            return RedirectToAction("Index");
        }

        
    }
}
