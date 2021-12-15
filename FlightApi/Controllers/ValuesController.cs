using Flight;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
      [HttpGet]
      public JsonResult Index()
      {
            var flight = new MyFlight();

            return new JsonResult(flight.Start());
      }

      private void Intresting()
      {
          
      }
    }
}
