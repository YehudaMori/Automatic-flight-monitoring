using Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Leg
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public UsedTo Used { get; set; }
        public int CrossingTime { get; set; }
        public int FlightNumber { get; set; }
    }

    public enum UsedTo
    {
        Landing,
        Departure,
        Both
    };
}
