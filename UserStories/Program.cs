using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpeedyAirProj.Application;
using SpeedyAirProj.Core.Interfaces;
using SpeedyAirProj.Infrastructure.Context;
using SpeedyAirProj.Infrastructure.Repositories;

var collection = new ServiceCollection();

collection.AddDbContext<SpeedyAirDbContext>(options =>
    options.UseSqlite("Data source=app.data"));

collection.AddScoped<IFlightService, FlightService>();
collection.AddScoped<IFlightRepository, FlightRepository>();

var provider = collection.BuildServiceProvider();

using (var scope = provider.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SpeedyAirDbContext>();
    dbContext.Database.EnsureCreated();

    var service = scope.ServiceProvider.GetService<IFlightService>();
    if (service == null)
    {
        Console.WriteLine("Failed to resolve IFlightService.");
    }
    else
    {
        // USER STORY #1:
        Console.WriteLine("USER STORY #1: getting all flights...");
        var flights = await service.GetFlightsAsync();
        var orders = await service.GetOrdersAsync();

        // Display flight schedule asynchronously
        await service.DisplayFlightScheduleAsync(flights);

        // USER STORY #2:
        Console.WriteLine("USER STORY #2: ");
        Console.WriteLine("please enter 'a' to assign order->to flights: ");

        // Wait for input and handle assignments asynchronously
        while (true)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.ToLower() == "a")
            {
                await service.AssignOrdersToFlightsAsync(orders, flights);
                await service.DisplayOrderItinerariesAsync(orders, flights);
                Console.WriteLine("finish assaignment.. ");
            }
        }
    }
}

Console.ReadLine();
