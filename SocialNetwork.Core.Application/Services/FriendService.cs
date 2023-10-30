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

        public FriendService(IFriendRepository repository, IHttpContextAccessor httpContextAccessor, AuthenticationResponse userViewModel, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            this.userViewModel = userViewModel;
            _mapper = mapper;
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

    }
}
