using System;

namespace aspapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Seller { get; set; }
        public int SalesCount { get; set; }
        public string ImageUrl { get; set; }
        public List<string> ColorOptions { get; set; }
        public List<string> Capacities { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public List<string> Features { get; set; }

        // Add CreatedAt and UpdatedAt properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}