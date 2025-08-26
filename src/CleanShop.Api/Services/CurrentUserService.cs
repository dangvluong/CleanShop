using CleanShop.Application.Interfaces.Services;
using CleanShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace CleanShop.Api.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        : ICurrentUserService
    {
        public string? UserId
        {
            get
            {
                return httpContextAccessor.HttpContext?.User != null ? userManager.GetUserId(httpContextAccessor.HttpContext?.User) : null;
            }
        }

        public bool IsAuthenticated => httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}