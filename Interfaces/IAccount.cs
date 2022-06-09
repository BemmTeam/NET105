namespace NET105.Interfaces
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NET105.Models;

    public  interface IAccount
    {
        bool IsSignedIn(ClaimsPrincipal user);

        Task<bool> SignInAsync(SignInModel model );

        Task<bool> SignUpAsync(SignUpModel model , IUrlHelper url , HttpRequest request , string returnUrl);

        Task<bool> ConfirmEmailAsync(string userId, string code);

        Task LogoutAsync();
    }
}