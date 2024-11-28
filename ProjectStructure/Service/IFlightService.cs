using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Service
{
    public interface IFlightService
    {
        string GetFlightSchedules();
        string GetFlightScheduleById(int flightNumber);



    }
}
