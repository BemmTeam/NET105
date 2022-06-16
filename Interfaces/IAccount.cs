namespace NET105.Interfaces
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NET105.Entities;
    using NET105.Models;

    public  interface IAccount
    {
        bool IsSignedIn(ClaimsPrincipal user);

        Task<bool> SignInAsync(SignInModel model );

        Task<bool> SignUpAsync(SignUpModel model , IUrlHelper url , HttpRequest request , string returnUrl);

        Task<bool> ConfirmEmailAsync(string userId, string code);

        Task LogoutAsync();

        Task<User> GetUserAsync(ClaimsPrincipal user);

        Task UpdateUserAsync(string id, User user);

        Task ChangePassword(ChangePassword model);

        Task<bool> CheckPassword(string password);



    }
}