using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class BankController : Controller
    {
        private List<dynamic> _bankAccounts = new List<dynamic>() 
        { new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 } };

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank", "text/plain");
        }

        [HttpGet]
        [Route("account-details")]
        public IActionResult AccountDetails()
        {
            return Json(_bankAccounts.First());
        }

        [HttpGet]
        [Route("account-statement")]
        public IActionResult AccountStatement()
        {
            return File("dummy.pdf", "application/pdf");
        }

        [HttpGet]
        [Route("get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {
            if (!Request.RouteValues.TryGetValue("accountNumber", out var accountNumber)) return NotFound("Account Number should be supplied");
            if (Convert.ToInt32(accountNumber) != 1001) return BadRequest("Account Number should be 1001");
            return Content(_bankAccounts.First().currentBalance.ToString(), "text/plain");
        }
    }
}
