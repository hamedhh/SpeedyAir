using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Model
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public CityCode Departure { get; set; }
        public CityCode Arrival { get; set; }
        public string Day { get; set; }
    }

    public enum CityCode 
    {
        YUL=1,
        YYZ=2,
        YYC=3,
        YVR=4,

    }
}
