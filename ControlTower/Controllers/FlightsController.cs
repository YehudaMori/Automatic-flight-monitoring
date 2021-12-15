using Flight;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace ControlTower.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        List<MyFlight> myFlights = new List<MyFlight>();

        public JsonResult Index()
        {
            WebClient client = new WebClient();
            string url = $"http://localhost:27071/api/Simulator";
            var json = client.DownloadString(url);
            MyFlight Flight = JsonConvert.DeserializeObject<MyFlight>(json);
            myFlights.Add(Flight);
            Thread.Sleep(3000);
            Index();

            return new JsonResult(myFlights);
        }
    }
}
