using SpeedyAirProj.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAirProj.Core.Interfaces
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetFlights();
        IEnumerable<Order> GetOrders();

    }

}
