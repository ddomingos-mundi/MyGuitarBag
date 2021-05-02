using MyGuitarBag.Api.ValueObjects;
using System;
using System.Collections.Generic;

namespace MyGuitarBag.Api.Entities
{
    public class Guitar
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public IEnumerable<Pickup> Pickups { get; set; }
        public string Color { get; set; }
        public int StringQuantity { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> PhotoLinks { get; set; }
    }
}
