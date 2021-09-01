using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BartenderApplication.Models;
using BartenderApplication.Repository;


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
            return View("~/Views/Home/Customer", drinksmodel.ToList());
        }

        public IActionResult CreateTicket(TicketsModel ticketsModel)
        {
            ticketsModel.Id = Guid.NewGuid().ToString();
            _fakeRepository.Tickets.Add(ticketsModel);
            return RedirectToAction("Index");
        }

        
    }
}
