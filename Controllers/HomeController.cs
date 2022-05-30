using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NET105.Entities;
using NET105.Interface;
using NET105.Models;

namespace NET105.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProduct productScv ;

        private readonly ICategory categoryScv ;

        public HomeController(ILogger<HomeController> logger, IProduct productScv, ICategory categoryScv)
        {
            _logger = logger;
            this.productScv = productScv;
            this.categoryScv = categoryScv;
        }

        public IActionResult Index()
        {

            var categories = categoryScv.GetCategories();
            var listCategories = categories.Include(m => m.Products).AsEnumerable();
            ViewData["listCategories"] = listCategories;
            IDictionary<string , IEnumerable<Product>> productCtgs = new Dictionary<string , IEnumerable<Product>>();

            ViewData["ProductPrice"] = productScv.GetProductsAsync().OrderByDescending(x => x.Price).Take(9);
            foreach(var item in listCategories)
            {
                productCtgs.Add(item.Name , item.Products);
            }

            


            return View(productCtgs);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
