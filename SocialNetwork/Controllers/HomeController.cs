using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Publications;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPublicationService _service;

        public HomeController(IPublicationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Publications = await _service.GetAllViewModel();
            return View();
        }



    }
}