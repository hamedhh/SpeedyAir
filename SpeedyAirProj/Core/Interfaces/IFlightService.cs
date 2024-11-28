using SpeedyAirProj.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAirProj.Core.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();

        Task<IEnumerable<Order>> GetOrdersAsync();
        Task AssignOrdersToFlightsAsync(IEnumerable<Order> orders, IEnumerable<Flight> flights);
        Task DisplayFlightScheduleAsync(IEnumerable<Flight> flights);
        Task DisplayOrderItinerariesAsync(IEnumerable<Order> orders, IEnumerable<Flight> flights);
    }
}
