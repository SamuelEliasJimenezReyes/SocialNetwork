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

        public async Task<IActionResult> Index() 
        {

            ViewBag.Friends = await _service.GetAllFriends();
            return View(new AddFriendViewModel () ); 
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddFriendViewModel vm)
        {
            var obj = await _accountService.GetByUserName(vm.UserName);


            vm.Name = obj.FirstName;
            vm.LastName = obj.LastName;
            vm.UserName = obj.UserName;

            ViewBag.Friends = await _service.Add(vm);

            return View("Index",vm);
        }


    }
}
