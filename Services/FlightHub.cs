using Entities;
using Flight;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class FlightHub : Hub
    {
        public async Task SendFlightAsync(List<Leg> list)
        {
            await Clients.All.SendAsync("onFlightReceived", list);
        }
    }
}
