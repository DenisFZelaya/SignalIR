using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalIR
{
    public class BeerHub: Hub // Hereda del hub
    {
        //Metodo que escucha
        public async Task Send(string Name, String Brand)
        {
            await Clients.All.SendAsync("Receive", Name, Brand);
        }
    }
}
