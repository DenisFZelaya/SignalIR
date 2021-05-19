using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalIR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalIR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerApiController : ControllerBase
    {
        private IHubContext<BeerHub> _hubContext;

        public BeerApiController(IHubContext<BeerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddBeer(Beer beer)
        {
            await _hubContext.Clients.All.SendAsync("Receive", beer.Name, beer.Brand);
            return Ok();
        }
    }
}
