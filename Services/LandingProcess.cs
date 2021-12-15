using Entities;
using Flight;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace Services
{
    public class LandingProcess
    {
        public async Task StartLandingAsync(MyFlight flight)
        {
            await LegService.Init.StartingProcessLandingAsync(flight);
        }

        internal async Task CriticalLandingAsync(MyFlight flight)
        {
            await LegService.Init.StartingCriticalLandinAsync(flight);
        }
    }
}
