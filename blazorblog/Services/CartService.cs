public class CartService
{
    // Internal list to hold cart items
    private List<CartItem> cart = new List<CartItem>();

    // Retrieve all cart items
    public List<CartItem> GetCartItems()
    {
        return cart;
    }

    // Add item to the cart (or update the quantity if it already exists)
    public void AddToCart(Product product, int quantity)
    {
        var existingItem = cart.FirstOrDefault(ci => ci.Product.Name == product.Name);

        if (existingItem != null)
        {
            // If item already exists, update its quantity
            existingItem.Quantity += quantity;
        }
        else
        {
            // Add new item to the cart
            cart.Add(new CartItem { Product = product, Quantity = quantity });
        }
    }

    // Remove an item from the cart
    public void RemoveFromCart(CartItem item)
    {
        cart.Remove(item);
    }

    // Update the quantity of a specific cart item
    public void UpdateQuantity(CartItem item, int newQuantity)
    {
        var existingItem = cart.FirstOrDefault(ci => ci.Product.Name == item.Product.Name);
        if (existingItem != null && newQuantity > 0)
        {
            existingItem.Quantity = newQuantity;
        }
    }

    // Clear all items from the cart
    public void ClearCart()
    {
        cart.Clear();
    }

    // Calculate total cost of the cart items (excluding shipping or taxes)
    public decimal GetCartTotal()
    {
        return cart.Sum(item => item.Product.Price * item.Quantity);
    }
}

// CartItem class to hold product and quantity
public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

// Product class (you can extend it with more fields as necessary)
// Product.cs
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
}
