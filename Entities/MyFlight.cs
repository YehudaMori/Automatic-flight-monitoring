using System;

namespace Flight
{
    public class MyFlight
    {
        public int Number { get; set; }
        public int PassengersCount { get; set; }
        public bool IsCritical { get; set; }
        public string Brand { get; set; }
        public int CurrentLeg { get; set; } 
        public string LandingOrDeparture { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        static int counter = 1;
        Random rnd = new Random();

        public MyFlight Start()
        {
            var f = new MyFlight();

            f.Number = counter++;
            f.PassengersCount = rnd.Next(8, 501);
            f.Brand = Enum.GetName(typeof(Compenis), rnd.Next(1, 10));
            f.CurrentLeg = 0;
            f.LandingOrDeparture = f.Number % 2 == 0 ? "Landing" : "Departure";
            f.DateTime = DateTime.Now;
            f.IsCritical = f.Number % 12 == 0 ? true : false;
            f.Status = "waiting";
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
