using Flight;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FlightControlTower.FlightService
{
    public sealed class MessageServices : BackgroundService
    {
        private readonly IHubContext<MessageHub> context;
        private List<MyFlight> myFlights = new List<MyFlight>();
        public static MainProcess Process = new MainProcess();

        public MessageServices(IHubContext<MessageHub> context)
        {
            this.context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                MyFlight Flight = await ReceivingAFlightAsync();
                myFlights.Add(Flight);
                await Task.Delay(5000);
 
                await context.Clients.All.SendAsync("onMessageReceived", Flight, stoppingToken);
                
            }
        }

        private static async Task<MyFlight> ReceivingAFlightAsync()
        {
            WebClient client = new WebClient();
            string url = $"http://localhost:27071/api/Simulator";
            var json = client.DownloadString(url);
            MyFlight Flight = JsonConvert.DeserializeObject<MyFlight>(json);

            Process.StartProcess(Flight);
            return Flight;
        }
    }
}
