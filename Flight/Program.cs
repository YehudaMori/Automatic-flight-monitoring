using System;
using System.Threading;

namespace Flight
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFlight flight = new MyFlight();

            while (true)
            {
                var f = flight.Start();

                Console.WriteLine($"number: {f.Number}");
                Console.WriteLine($"passengerCount: {f.PassengersCount}");
                Console.WriteLine($"Critical: {f.IsCritical}");
                Console.WriteLine($"Brand: {f.Brand}");
                Console.WriteLine($"Current Leg: {f.CurrentLeg}");
                Console.WriteLine($"LandingOrDeparture: {f.LandingOrDeparture}");
                Console.WriteLine("=============================== \n \n");

                Thread.Sleep(3000);
            }
        }
    }
}
