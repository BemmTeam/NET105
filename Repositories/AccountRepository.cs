
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NET105.Entities;
using NET105.Interfaces;
using NET105.Models;
using Org.BouncyCastle.Asn1.Ocsp;

namespace NET105.Repository
{
    public class AccountRepository : Interfaces.IAccount
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly IEmailSender emailSender;

        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
        }



        public bool IsSignedIn(ClaimsPrincipal user)
        {
            return signInManager.IsSignedIn(user);
        }

        public async Task<bool> SignInAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.rememberMe, true);
            return result.Succeeded;
        }

        public async Task<bool> SignUpAsync(SignUpModel model, IUrlHelper url, HttpRequest request, string returnUrl)
        {
            User user = new User { FullName = model.FullName, UserName = model.UserName, Email = model.Email, Address = model.Address };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user); // phát sinh ra 1 mã token của user 
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code)); //encode ra url 
                var callbackUrl = url.ActionLink(
                    action: "ConfirmEmail",
                    controller: "Account",
                    values: new
                    {
                        userId = user.Id,
                        code = code,
                        returnUrl = returnUrl
                    }, protocol: request.Scheme
                );
                await emailSender.SendEmailAsync(model.Email, "Xác nhận tài khoản",
                 $"Bạn đã đăng ký tại shop Food nhấn vào link để xác nhận <a href='{callbackUrl}'>xác nhận</a>");

                return true;
            }
            else
            {
                return false;

            }
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string code)
        {

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {

                return false;
            }
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }
            return result.Succeeded;
        }


        public async Task UpdateUserAsync(string id, User user)
        {
            var findUser = await userManager.FindByIdAsync(id);
            findUser.Address = user.Address;
            findUser.FullName = user.FullName;
            findUser.UserName = user.UserName;
            findUser.Email = user.Email;
            findUser.PhoneNumber = user.PhoneNumber;
            await userManager.UpdateAsync(findUser);
        }
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }


        public async Task<User> GetUserAsync(ClaimsPrincipal user)
        {
            var userfound = await userManager.GetUserAsync(user);

            return userfound;
        }


        public async Task ChangePassword(ChangePassword model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var result = await userManager.ResetPasswordAsync(user, token, model.NewPassword);
        }

        public async Task<bool> CheckPassword(string password)
        {
            var passwordValidator = new PasswordValidator<User>();
            var result = await passwordValidator.ValidateAsync(userManager, null, password);


            return result.Succeeded;

        }
    }
}