using System;
using System.Collections.Generic;

namespace MyGuitarBag.Models
{
    public class GuitarModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public IEnumerable<PickupModel> Pickups { get; set; }
        public string Color { get; set; }
        public int StringQuantity { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> PhotoLinks { get; set; }
    }
}
