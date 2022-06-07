

namespace NET105.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NET105.Interface;

    [ApiController]
    [Route("Carts/[action]")]
    public class CartController : Controller
    {
        private readonly ICategory categorySvc;

        public CartController(ICategory categorySvc)
        {
            this.categorySvc = categorySvc;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categorySvc.GetCategories().ToListAsync();
            
            return Ok(categories);
        }   
    }
}