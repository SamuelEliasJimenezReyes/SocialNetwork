using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.Helpers;


namespace WebApp.SocialNetwork.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private IFriendService _service;
        private IPublicationService _publicationService;
        private IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;
        public FriendController(IFriendService service, IAccountService accountService, IHttpContextAccessor httpContextAccessor, IPublicationService publicationService)
        {
            _service = service;
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _publicationService = publicationService;
        }

        public async Task<IActionResult> Index() 
        {

            ViewBag.Friends = await _publicationService.GetAllByFriend(userViewModel.UserName);
            return View(new AddFriendViewModel ()); 
        }

        
        [HttpPost]
        public async Task<IActionResult> Add(AddFriendViewModel vm)
        {
            var obj = await _accountService.GetByUserName(vm.UserName);


            vm.Name = obj.FirstName;
            vm.LastName = obj.LastName;
            vm.UserName = obj.UserName;
            vm.UserID =userViewModel.Id ;
            vm.FriendID = obj.ID;

            await _service.Add(vm);

            return View("Index",vm);
        }


    }
}
