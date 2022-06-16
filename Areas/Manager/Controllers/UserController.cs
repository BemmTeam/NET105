using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105;
using NET105.Entities;
using NET105.Helper;
using NET105.Interfaces;
using NET105.Models;
using Z.PagedList;

namespace NET105.Areas.Controllers
{
    [Area("Manager")]
    [Route("Manager/[controller]/[action]/{id?}")]
    [Authorize(Roles = RoleName.Admin)]


    public class UserController : Controller
    {
        private readonly IUser repository;

        private readonly IAccount accountSvc;

        public UserController(IUser repository, IAccount accountSvc)
        {
            this.repository = repository;
            this.accountSvc = accountSvc;
   
        }

        //  private readonly UserManager<User> userManager;

        [TempData]
        public string Message { get; set; }

        [TempData]
        public string MessageType { get; set; }

     

        // GET: User
        public async Task<IActionResult> Index(int? page, string searchString)
        {
            page ??= 1;

            IQueryable<User> users = repository.GetUsers();

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(user => user.FullName.ToLower().Contains(searchString.ToLower()));

                ViewBag.searchString = searchString;
            }
            return View(await users.ToPagedListAsync((int)page, 5));
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var user = await repository.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName, Password, RoleType , Address,City,District,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] User user)
        {
            if (ModelState.IsValid)
            {
                if (await repository.CreateAsync(user))
                {
                    Message = "Thêm người dùng thành công !";
                    MessageType = MessageHelper.success;

                    return RedirectToAction(nameof(Index));

                }
            }

            ViewData["Message"] = "Thêm người dùng không thành công !";
            ViewData["MessageType"] = MessageHelper.error;
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var user = await repository.FindUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,Address,City,District,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await accountSvc.UpdateUserAsync(id, user);

                    Message = "Cập nhật người dùng thành công !";
                MessageType = MessageHelper.success;

                return RedirectToAction(nameof(Index));
            }

            ViewData["Message"] = "Cập nhật người dùng thất bại";
            ViewData["MessageType"] = MessageHelper.error;
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (!User.IsInRole(RoleName.Admin))
            {
                Message = "Không đủ quyền xóa user này";
                MessageType = MessageHelper.success;
                return RedirectToAction("Index");
            }
            var user = await repository.GetUserAsync(id);

            return View(user);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (await repository.DeleteAsync(id))
            {
                Message = "Xóa người dùng thành công";
                MessageType = MessageHelper.success;
                return RedirectToAction("Index");

            }
            else
            {
                ViewData["Message"] = "Xóa người dùng thất bại";
                ViewData["MessageType"] = MessageHelper.error;
                return View();
            }

        }



    }
}
