using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.Dtos.Account;
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


        public FriendService(IFriendRepository repository, IHttpContextAccessor httpContextAccessor, AuthenticationResponse userViewModel, IMapper mapper, IAccountService accountService) : base(repository, mapper)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            this.userViewModel = userViewModel;
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




        public async Task<List<FriendViewModel>> GetAllFriends()
        {
            var friendlist = await _repository.GetAllAsync();
            FriendViewModel friend = new();
            List<FriendViewModel> list = new();

            friendlist = friendlist.Where(f => f.UserName == userViewModel.UserName).ToList();

            if (friendlist.Count > 0)
            {
                foreach (var f in friendlist)
                {
                    friend.UserName = userViewModel.UserName;
                    friend.Name = f.Name;
                    var user = await _accountService.GetByUserName(friend.UserName);
                    friend.ImagePath = user.ImagePath;
                    friend.Name = user.FirstName;
                    friend.LastName = user.LastName;
                    list.Add(friend);
                }
            }
            return list;
        }

    }
}
