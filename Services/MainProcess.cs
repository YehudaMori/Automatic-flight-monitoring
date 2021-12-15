using Entities;
using Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Services
{
    public class MainProcess
    {
        LandingProcess Landing = new LandingProcess();
        DepartureProcess Departure = new DepartureProcess();
        List<MyFlight> FlightsLanding = new List<MyFlight>();
        List<MyFlight> FlightsDeparture = new List<MyFlight>();
        Timer Timer = new Timer(1000);
        MyFlight flight;

        public MainProcess()
        {
            Timer.Elapsed += TimerLoop;
            Timer.Start();
        }

        private void TimerLoop(object sender, ElapsedEventArgs e)
        {
            flight = NextPlane();
            
            if (flight != null)
            {
                if (flight.LandingOrDeparture == "Landing")
                {
                    Landing.StartLandingAsync(flight);
                    FlightsLanding.Remove(flight);
                }
                else
                {
                    Departure.StartDepartureAsync(flight);
                    FlightsDeparture.Remove(flight);
                }
            }

        }

        private MyFlight NextPlane()
        {
            MyFlight f = CalculateFlights(FlightsLanding, FlightsDeparture);
            return f;
        }

        private MyFlight CalculateFlights(List<MyFlight> flightsLanding, List<MyFlight> flightsDeparture)
        {
            var nextPlaneLanding = flightsLanding.FirstOrDefault(f => f.Status == "waiting");
            var nextPlaneDeparture = flightsDeparture.FirstOrDefault(f => f.Status == "waiting");
            var criti = flightsLanding.FirstOrDefault(f => f.IsCritical);
            if (criti != null) return criti;

            if (nextPlaneLanding == null && nextPlaneDeparture != null)
                return nextPlaneDeparture;
            if (nextPlaneDeparture == null && nextPlaneLanding != null)
                return nextPlaneLanding;
            
            string  s = LegService.Init.FreeShuttleService();
            
            if (s == "Landing")
                return nextPlaneLanding;
            else if (s == "Departure")
                return nextPlaneDeparture;
            return null;
        }

        public void StartProcess(MyFlight flight)
        {
            if (flight.LandingOrDeparture == "Landing")
                FlightsLanding.Add(flight);
            else
                FlightsDeparture.Add(flight);
        }

        public List<Leg> Printer()
        {
            return LegService.Init.PrintLegs();
        }
    }
}
