using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAirProj.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public CityCode Destination { get; set; }
        public int? FlightNumber { get; set; } = null;
        public Flight? Flight { get; set; }     
    }
}
