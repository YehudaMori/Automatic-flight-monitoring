using Entities;
using Flight;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    class LegService : Hub
    {
        
        public string FinishMessage { get; set; }
        List<Leg> Legs = new List<Leg>
        {
            new Leg { Number = 1, Capacity = 0, CrossingTime = 2, Used = UsedTo.Landing },
            new Leg { Number = 2, Capacity = 0, CrossingTime = 2, Used = UsedTo.Landing },
            new Leg { Number = 3, Capacity = 0, CrossingTime = 2, Used = UsedTo.Landing },
            new Leg { Number = 4, Capacity = 0, CrossingTime = 3, Used = UsedTo.Both },
            new Leg { Number = 5, Capacity = 0, CrossingTime = 3, Used = UsedTo.Landing },
            new Leg { Number = 6, Capacity = 0, CrossingTime = 4, Used = UsedTo.Both },
            new Leg { Number = 7, Capacity = 0, CrossingTime = 4, Used = UsedTo.Both },
            new Leg { Number = 8, Capacity = 0, CrossingTime = 3, Used = UsedTo.Departure }
        };
        private static LegService init;
        public static LegService Init
        {
            get
            {
                if (init == null)
                    return init = new LegService();
                return init;
            }
        }

        LegService() { }

        public string FreeShuttleService()
        {
            if (CheckLanding())
                return "Landing";
            if(CheckDeparture())
                return "Departure";
            return "Nop";
        }


        public bool CheckLanding()
        {
            if (Legs[5].FlightNumber != 0 || Legs[6].FlightNumber != 0)
                return false;
            return true;
        }
        public bool CheckDeparture()
        {
            if (Legs[0].FlightNumber != 0)
                return false;
            return true;
        }
        public async Task StartingProcessLandingAsync(MyFlight flight){
            await AutoLandingtAsync(flight);
        }

        public async Task AutoLandingtAsync(MyFlight flight)
        {
            for (int i = 0; i < Legs.Count() - 2; i++)
            {
                if (i < 5)
                {
                    flight.CurrentLeg = Legs[i].Number;
                    Legs[i].FlightNumber = flight.Number;
                    await Task.Delay(Legs[i].CrossingTime * 1000);
                    Legs[i].FlightNumber = 0;
                }
                else
                  await FinishLandingAsync(flight);
            }
        }

        private async Task FinishLandingAsync(MyFlight flight)
        {
            int numberLeg = 5;
            if (Legs[numberLeg].FlightNumber != 0) numberLeg = 6;

            flight.CurrentLeg = 6;
            Legs[numberLeg].FlightNumber = flight.Number;
            await Task.Delay(Legs[numberLeg].CrossingTime * 1000);
            Legs[numberLeg].FlightNumber = 0;

        }


        public async Task StartingProcessDepartureAsync(MyFlight flight)
        {
            await AutoDepartureAsync(flight);
        }

        private async Task AutoDepartureAsync(MyFlight flight)
        {
            var departureLegs = Legs.Where(l => l.Used != UsedTo.Landing)
                .OrderBy(l => l.CrossingTime)
                .ToList();

            for (int i = departureLegs.Count() - 1; i >= 0 ; i--)
            {
                if (departureLegs[i].FlightNumber != 0) i--;
                flight.CurrentLeg = Legs[departureLegs[i].Number - 1].Number;
                Legs[departureLegs[i].Number - 1].FlightNumber = flight.Number;
                await Task.Delay(Legs[departureLegs[i].Number - 1].CrossingTime * 1000);
                Legs[departureLegs[i].Number - 1].FlightNumber = 0;
                if (i == 3) i--;
            }
        }

        internal async Task StartingCriticalLandinAsync(MyFlight flight)
        {
            await AutoLandingtAsync(flight);
        }

        public List<Leg> PrintLegs()
        {
            var legs = Legs.ToList();
            return legs;
        }

    }
}
