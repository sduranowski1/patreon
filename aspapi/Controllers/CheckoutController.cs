using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using aspapi.Models;
namespace aspapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        private readonly IConfiguration _configuration;
        public CheckoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("create-checkout-session")]
        public IActionResult CreateCheckoutSession([FromBody] CheckoutFormModel model)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var lineItems = model.Items.Select(item => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = model.Currency ?? "usd",  // Use provided currency or default to USD
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.Name,
                        Description = item.Description,
                    },
                    UnitAmount = model.TotalPrice, // Total price in cents
                },
                Quantity = 1,  // You might want to adjust this based on your requirements
            }).ToList();
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = model.SuccessUrl,
                CancelUrl = model.CancelUrl,
            };
            var service = new SessionService();
            var session = service.Create(options);
            return Ok(new { sessionId = session.Id });
        }
        [HttpGet("success")]
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet("cancel")]
        public IActionResult Cancel()
        {
            return View();
        }
    }
}