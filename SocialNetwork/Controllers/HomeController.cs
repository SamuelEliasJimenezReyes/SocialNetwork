using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;

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

        public IActionResult Index()
        {
            return View();
        }

    }
}