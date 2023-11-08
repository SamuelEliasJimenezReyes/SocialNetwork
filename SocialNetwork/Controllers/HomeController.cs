using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.ViewModels.Publications;
using SocialNetwork.Core.Application.Dtos.Account;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPublicationService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;

        public HomeController(IPublicationService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            this.userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllPublicationComments();

            ViewBag.Publications = list.Where(x=>x.UserID==userViewModel.Id);
            
            return View();
        }



    }
}