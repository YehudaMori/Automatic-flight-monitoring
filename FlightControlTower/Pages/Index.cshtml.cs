using Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace FlightControlTower.Pages
{
    public class IndexModel : PageModel 
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHubContext<FlightHub> context;
        public MainProcess mainProcess = new MainProcess();
        Timer Timer = new Timer(300);
        [BindProperty]
        public List<Leg> Legs { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHubContext<FlightHub> context)
        {
            Timer.Elapsed += TimerElapsed;
            Timer.Start();
            _logger = logger;
            this.context = context;
            Legs = new List<Leg>();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnGet();
        }

        public void OnGet()
        {
           context.Clients.All.SendAsync("onFlightReceived", mainProcess.Printer());
           Legs =  mainProcess.Printer();
        }
        
    }
}
