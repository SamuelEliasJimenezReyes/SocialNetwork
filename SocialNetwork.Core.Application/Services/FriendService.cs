using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Publications;
using SocialNetwork.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class FriendService : GenericService<AddFriendViewModel, FriendViewModel,Friends> , IFriendService
    {
        private readonly IFriendRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;


        public FriendService(IFriendRepository repository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IAccountService accountService) : base(repository, mapper)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
            _accountService = accountService;
        }
        public override async Task<AddFriendViewModel> Add(AddFriendViewModel vm)
        {
            userViewModel.Id = vm.UserID;
            return await base.Add(vm);
        }

        public override async Task Update(AddFriendViewModel vm, int id)
        {
            userViewModel.Id = vm.UserID;
            await base.Update(vm, id);
        }




        public async Task<List<FriendsPublicationViewModel>> GetAllFriends()
        {
            var friendlist = await _repository.GetAllAsync();
            FriendsPublicationViewModel vm = new();
            List<FriendsPublicationViewModel> friendPublicationList = new();

            var query = friendlist.Where(f => f.UserID == userViewModel.Id).ToList();

            if (query.Count > 0)
            {
                foreach (var item in query)
                {
                        
                    var user = await _accountService.GetByUserID(item.FriendID);
                    vm.UserName = userViewModel.UserName;
                    vm.Name = item.Name;
                    vm.ImagePath = user.ImagePath;
                    vm.Name = user.FirstName;
                    vm.LastName = user.LastName;
                    friendPublicationList.Add(vm);
                }
            }
            return friendPublicationList;
        }


    }

}
