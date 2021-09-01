using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BartenderApplication.Repository;

namespace BartenderApplication.Controllers
{
    public class MenuController : Controller
    {
        //private List<DrinksModel> _opportunities = new List<DrinksModel>();
        private FakeRepository _fakeRepository;

        public MenuController(FakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }


        public IActionResult Menu()
        {
            return View();
        }
    }
}
