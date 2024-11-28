using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Service
{
    internal class FlightService : IFlightService
    {
        private readonly IFlightService _flightService;
        public FlightService()
        {
                
        }
        public string GetFlightSchedules()
        {
            throw new NotImplementedException();
        }

        public string GetFlightScheduleById(int flightNumber)
        {
            throw new NotImplementedException();
        }
    }
}
