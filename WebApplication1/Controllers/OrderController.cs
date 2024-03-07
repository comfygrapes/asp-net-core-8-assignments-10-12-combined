using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [Route("Order")]
        public IActionResult Order([Bind(nameof(order.OrderDate), nameof(order.InvoicePrice), nameof(order.Products))]Order order)
        {
            var rand = new Random();

            if (ModelState.IsValid)
            {
                order.OrderNo = rand.Next(99999);

                return Json(order.OrderNo);
            }
            var errorsList = new List<string>();
            foreach (var value in ModelState.Values) 
            {
                foreach(var error in value.Errors) 
                {
                    errorsList.Add(error.ErrorMessage);
                }
            }
            var errors = string.Join("\n", errorsList);
            return BadRequest(errors);
        }
    }
}
