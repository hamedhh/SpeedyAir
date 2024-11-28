using SpeedyAirProj.Core.Interfaces;
using SpeedyAirProj.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedyAirProj.Infrastructure.Context;

namespace SpeedyAirProj.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly SpeedyAirDbContext _context;
        public FlightRepository(SpeedyAirDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _context.Flights.ToList();

        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
