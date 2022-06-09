namespace NET105.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}