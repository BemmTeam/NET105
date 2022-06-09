
namespace NET105.Areas.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NET105.Areas.MockData;
    using NET105.Entities;
    using NET105.Helper;
    using NET105.Models;
    using Microsoft.AspNetCore.Authorization;
    [Area("Manager")]
    [Route("Manager/[controller]/[action]")]
    [AllowAnonymous]
    public class DbManagerController : Controller
    {
        private readonly ShopContext context ;
        private readonly UserManager<User> userManager ;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbManagerController(ShopContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
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

        public async Task<IActionResult> InsertUser()
        {
              var rolenames = typeof(RoleName).GetFields();
            foreach(var item in rolenames) { 
                string name = item.GetRawConstantValue().ToString(); 
                var ffound = await roleManager.FindByNameAsync(name); 
                if(ffound == null ) { 
                    await roleManager.CreateAsync(new IdentityRole(name));
                }
            }
            //tạo user admin : admin - admin123 
            var useradmin = await userManager.FindByEmailAsync("admin"); 
            if(useradmin  == null) { 
                useradmin = new User () { 
                    UserName = "Admin" , 
                    FullName = "Admin",
                    Email = "Admin@gmail.com" , 
                    Address="Tphcm quan 12",
                    EmailConfirmed = true // không cần xác thực email nữa , 
                };
                await userManager.CreateAsync(useradmin,"admin123") ; 
                await userManager.AddToRoleAsync(useradmin , RoleName.Admin) ; 
            }

                TempData["Message"] = "Thêm Data mẫu User Admin thành công" ;
                TempData["MessageType"] = MessageHelper.success;

            return RedirectToAction(nameof(Index));
        }
   
    }
}