
namespace NET105.Areas.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using NET105.Areas.MockData;
    using NET105.Entities;
    using NET105.Helper;

    [Area("Manager")]
    [Route("Manager/[controller]/[action]")]
    public class DbManagerController : Controller
    {
        private readonly ShopContext context ;

        public DbManagerController(ShopContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> InsertCategory()
        {
            MockCategory category = new();
            try
            {
                await context.Categories.AddRangeAsync(category.GetCategories());
                await context.SaveChangesAsync();
                TempData["Message"] = "Thêm Data mẫu category thành công" ;
                TempData["MessageType"] = MessageHelper.success;
            }catch
            {
                TempData["Message"] = "Không thêm data được !" ;
                TempData["MessageType"] = MessageHelper.error;
            }

            return RedirectToAction(nameof(Index));

        }

         public async Task<IActionResult> InsertProduct()
        {
            MockProduct product = new();
            try
            {
                await context.Products.AddRangeAsync(product.GetProducts());
                await context.SaveChangesAsync();
                TempData["Message"] = "Thêm Data mẫu Product thành công" ;
                TempData["MessageType"] = MessageHelper.success;
            }catch
            {
                TempData["Message"] = "Không thêm data được !" ;
                TempData["MessageType"] = MessageHelper.error;
            }

            return RedirectToAction(nameof(Index));

        }
   
    }
}