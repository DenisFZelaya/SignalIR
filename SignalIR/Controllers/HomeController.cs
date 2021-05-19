using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalIR.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalIR.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext<BeerHub> _hubContext;

        public HomeController(IHubContext<BeerHub> hubContext)
        {
            _hubContext = hubContext;
        }



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BeerForms()
        {
            return View();
        }

        public async Task<IActionResult> AddBeer(Beer beer)
        {
            await _hubContext.Clients.All.SendAsync("Receive", beer.Name, beer.Brand);
            return View("BeerForms");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
