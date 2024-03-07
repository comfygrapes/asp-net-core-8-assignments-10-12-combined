using Microsoft.AspNetCore.Mvc;
using WebApplication1.ModelBinders;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookId?}/{author?}")]
        public IActionResult Index(Book book)
        {
            return Content(book.ToString());
        }
    }
}
