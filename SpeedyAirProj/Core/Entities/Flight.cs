using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAirProj.Core.Entities
{
    public class Flight
    {
        [Key]
        public int FlightNumber { get; set; }
        public CityCode Departure { get; set; }
        public CityCode Arrival { get; set; }
        public int Day { get; set; }
        public int Capacity { get; set; } = 20;
        public int BoxesLoaded { get; set; } = 0;
        public IEnumerable<Order>? Orders { get; set; }
    }


}
