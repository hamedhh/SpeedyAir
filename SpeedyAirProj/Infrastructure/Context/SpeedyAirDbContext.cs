using Microsoft.EntityFrameworkCore;
using SpeedyAirProj.Core;
using SpeedyAirProj.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAirProj.Infrastructure.Context
{
    public class SpeedyAirDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Order> Orders { get; set; }
        public SpeedyAirDbContext(DbContextOptions<SpeedyAirDbContext> options)
         : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=app.data");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for the Flight table
            modelBuilder.Entity<Flight>().HasData(
                new Flight { FlightNumber = 1, Departure = CityCode.YUL, Arrival = CityCode.YYZ, Day = 1,Capacity=20,BoxesLoaded=0},
                new Flight { FlightNumber = 2, Departure = CityCode.YUL, Arrival = CityCode.YYC, Day = 1,Capacity=20,BoxesLoaded=0},
                new Flight { FlightNumber = 3, Departure = CityCode.YUL, Arrival = CityCode.YVR, Day = 1,Capacity=20,BoxesLoaded=0},
                new Flight { FlightNumber = 4, Departure = CityCode.YUL, Arrival = CityCode.YYZ, Day = 2,Capacity=20,BoxesLoaded=0},
                new Flight { FlightNumber = 5, Departure = CityCode.YUL, Arrival = CityCode.YYC, Day = 2,Capacity=20,BoxesLoaded=0},
                new Flight { FlightNumber = 6, Departure = CityCode.YUL, Arrival = CityCode.YVR, Day = 2, Capacity = 20, BoxesLoaded = 0 }
            );

          //  base.OnModelCreating(modelBuilder);
        }

    }
}
