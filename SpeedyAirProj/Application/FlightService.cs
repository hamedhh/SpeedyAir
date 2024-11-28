using SpeedyAirProj.Core;
using SpeedyAirProj.Core.Entities;
using SpeedyAirProj.Core.Interfaces;
using SpeedyAirProj.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpeedyAirProj.Application
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repository;
        private readonly string _path;
        private int _orderId;
        public FlightService(IFlightRepository repository)
        {
            _repository = repository;
            var dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            var jsonFilePath = Path.Combine(dataFolder, "orders.json");
            _path = jsonFilePath;
            _orderId = 1;
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return  _repository.GetFlights();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            if (!File.Exists(_path))
                throw new FileNotFoundException($"The file '{_path}' was not found.");
            var json = await File.ReadAllTextAsync(_path);

            return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)?.Select(x => new Order
            {
                Id = _orderId++,
                Name = x.Key,
                Destination = x.Value["destination"].ToCityCode(),
            }).ToList() ?? new List<Order>();

        }

        public async Task AssignOrdersToFlightsAsync(IEnumerable<Order> orders, IEnumerable<Flight> flights)
        {
            foreach (var order in orders)
            {
                var flight = flights.FirstOrDefault(f => f.Arrival == order.Destination && f.BoxesLoaded < f.Capacity);
                if (flight != null && flight.BoxesLoaded<=20)
                {
                    order.FlightNumber = flight.FlightNumber;
                    flight.BoxesLoaded++;
                }
            }
        }

        public async Task DisplayFlightScheduleAsync(IEnumerable<Flight> flights)
        {
            foreach (var flight in flights)
            {
              await Task.Delay(500);
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }

        public async Task DisplayOrderItinerariesAsync(IEnumerable<Order> orders, IEnumerable<Flight> flights)
        {
            foreach (var order in orders)
            {
                if (order.FlightNumber.HasValue)
                {
                    await Task.Delay(100);
                    var flight = flights.First(f => f.FlightNumber == order.FlightNumber);
                    Console.WriteLine($"order: {order.Id}, flightNumber: {order.FlightNumber}, departure: {flight.Departure}, " +
                        $"arrival: {flight.Arrival}, day: {flight.Day}, capacity:{flight.Capacity}, boxesLoaded:{flight.BoxesLoaded}");
                }
                else
                {
                    Console.WriteLine($"order: {order.Id}, flightNumber: not scheduled");
                }
            }
        }


    }
}
