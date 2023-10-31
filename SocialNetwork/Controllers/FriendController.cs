using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Friend;

namespace WebApp.SocialNetwork.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private IFriendService _service;
        private IAccountService _accountService;

        public FriendController(IFriendService service, IAccountService accountService)
        {
            _service = service;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index() => View(await _service.GetAllViewModel());


        [HttpPost]
        public async Task<IActionResult> Find()
        {
            
            return View();
        }
        public async Task<IActionResult> Add(string UserName)
        {
            var obj = await _accountService.GetByUserName(UserName);

            AddFriendViewModel vm = new()
            {
                Name=obj.FirstName,
                LastName= obj.LastName,
                UserName= obj.UserName,
            };
            ViewBag.Friends = await _service.Add(vm);

            return View("Index");
        }


    }
}
