﻿namespace DCXAirTest.Domain.Entity.General
{
    public class Journey
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public List<Flight> Flights { get; set; }
    }
}