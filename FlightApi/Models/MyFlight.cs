using System;

namespace Flight
{
    class MyFlight
    {
        public int Number { get; set; }
        public int PassengersCount { get; set; }
        public bool IsCritical { get; set; }
        public string Brand { get; set; }
        public int CurrentLeg { get; set; } 
        public string LandingOrDeparture { get; set; }

        Random rnd = new Random();

        public MyFlight Start()
        {
            var f = new MyFlight();

            f.Number = rnd.Next(99, 1000);
            f.PassengersCount = rnd.Next(8, 501);
            f.Brand = Enum.GetName(typeof(Compenis), rnd.Next(1, 10));
            f.CurrentLeg = 0;
            f.LandingOrDeparture = "Landing";

            return f;
        }

        public enum Compenis
        {
            QatarAirways,
            SingaporeAirlines,
            NipponAirways,
            Emirates,
            JapanAirlines,
            CathayPacificAirways,
            EVAAir,
            QantasAirways,
            HainanAirlines,
            AirFrance,
        };
    }
}
