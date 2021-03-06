namespace NET105.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using NET105.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using NET105.Models;
    using System.Threading.Tasks;
    using NET105.Helper;
    using NET105.Entities;

    [Route("[controller]/[action]")]

    public class AccountController : Controller
    {
        private readonly IAccount accountSvc;

        private readonly IUser userSvc;

        public AccountController(IAccount accountSvc, IUser userSvc)
        {
            this.accountSvc = accountSvc;
            this.userSvc = userSvc;

        }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public string MessageType { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult notifyEmail()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn(string returnUrl)
        {
            returnUrl ??= Url.Content("/");
            if (accountSvc.IsSignedIn(User))
            {
                return LocalRedirect(returnUrl);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                returnUrl ??= Url.Content("/");
                if (await accountSvc.SignInAsync(model))
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ViewData["Message"] = "Tên đăng nhập hoặc mật khẩu không đúng";
                    ViewData["MessageType"] = MessageHelper.error;
                    return View(model);
                }
            }
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp(string returnUrl)
        {
            returnUrl ??= Url.Content("/");
            if (accountSvc.IsSignedIn(User))
            {
                return LocalRedirect(returnUrl);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await accountSvc.SignUpAsync(model, Url, Request, returnUrl);
                return View("notifyEmail");
            }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("ErrorConfirmEmail");

            }
            var result = await accountSvc.ConfirmEmailAsync(userId, code);

            return View(result ? "ConfirmEmail" : "ErrorConfirmEmail");
        }

        [HttpGet]
        public IActionResult ErrorConfirmEmail()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SignOutAsync()
        {
            await accountSvc.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> InfoUser()
        {
            var user = await accountSvc.GetUserAsync(User);
            return View(user);
        }


        public async Task<IActionResult> UpdateUserAsync()
        {
            var user = await accountSvc.GetUserAsync(User);
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUser(string id, User user)
        {
            await accountSvc.UpdateUserAsync(id, user);
            ViewData["Message"] = "Cập nhật thông tin thành công";
            ViewData["MessageType"] = MessageHelper.success;
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await accountSvc.GetUserAsync(User);
            ChangePassword changePassword = new()
            {
                UserId = user.Id,
                Email = user.Email
            };
            return View(changePassword);
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            System.Console.WriteLine(model.Email);
            if (ModelState.IsValid)
            {
                if (await accountSvc.CheckPassword(model.Password))
                {
                    await accountSvc.ChangePassword(model);
                    ViewData["Message"] = "Đổi mật khẩu thành công";
                    ViewData["MessageType"] = MessageHelper.success;
                    return View(model);

                }
                ViewData["Message"] = "Mật khẩu không đúng";
                ViewData["MessageType"] = MessageHelper.error;
                return View(model);
            }
            return View(model);
        }


    }
}