using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.Helpers;

namespace WebApp.SocialNetwork.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("User");

            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }
    }
}