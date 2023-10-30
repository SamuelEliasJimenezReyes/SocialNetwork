using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Friend;

namespace WebApp.SocialNetwork.Controllers
{
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
        public async Task<IActionResult> Find(RegisterRequest value)
        {
            var obj = await _accountService.GetByUserName(value);

            AddFriendViewModel vm = new()
            {
                Name=value.FirstName,
                LastName= value.LastName,
                UserName= value.UserName,
            };

            await _service.Add(vm);
            return View();
        }


    }
}
