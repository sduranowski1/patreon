using System.Collections.Generic;

namespace blazorblog.Models
{
    public class CheckoutFormModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();  // List of cart items
        public long TotalPrice { get; set; }  // Total price in cents
        public string Currency { get; set; } = "usd"; // Default currency
        public string SuccessUrl { get; set; }  // Dynamic success URL
        public string CancelUrl { get; set; }   // Dynamic cancel URL
    }

    public class CartItem
    {
        public string Name { get; set; }  // Product name
        public string Description { get; set; }  // Product description
        public long Price { get; set; }  // Price in cents
    }
}
