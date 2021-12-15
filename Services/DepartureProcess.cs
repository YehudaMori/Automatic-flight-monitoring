using Flight;
using System;
using System.Threading.Tasks;

namespace Services
{
    internal class DepartureProcess
    {
        internal async Task StartDepartureAsync(MyFlight flight)
        {
           await LegService.Init.StartingProcessDepartureAsync(flight);
        }
    }
}
