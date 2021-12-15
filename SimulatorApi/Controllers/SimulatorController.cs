using Flight;
using Microsoft.AspNetCore.Mvc;


namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        [HttpGet]
        public JsonResult Index()
        {
            var flight = new MyFlight();

            return new JsonResult(flight.Start());
        }

       
    }
}
