using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Publications;
using SocialNetwork.Core.Domain.Entites;

namespace SocialNetwork.Core.Application.Services
{
    public class PublicationService : GenericService<SavePublicationViewModel,PublicationsViewModel,Publications>, IPublicationService
    {
        private readonly IPublicationRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IFriendService _friendService;

        public PublicationService(IPublicationRepository repository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IAccountService accountService, IFriendService friendService) : base(repository, mapper)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
            _accountService = accountService;
            _friendService = friendService;
        }

        public override async Task<SavePublicationViewModel> Add(SavePublicationViewModel vm)
        {
            //userViewModel.Id = vm.UserID;
            ////vm.UserID = userViewModel.Id;
            return await base.Add(vm);
        }

        public override async Task Update(SavePublicationViewModel vm, int id)
        {
            //userViewModel.Id=vm.UserID;
            await base.Update(vm, id);
        }


        public async Task<List<FriendsPublicationViewModel>> GetAllByFriend(string UserName)
        {
            
            List<FriendsPublicationViewModel> publicationsList = new List<FriendsPublicationViewModel>();
            var existingUser = await _accountService.GetByUserName(UserName);

            var friends = await _friendService.GetAllFriends();

            foreach (var friend in friends)
            {
                var publicationsFriends = await _repository.GetAllAsync();
                foreach (var publications in publicationsFriends)
                {
                    var userExisted = userViewModel;    
                    var friendPost = new FriendsPublicationViewModel()
                    {
                       PublicationImagePath= publications.ImagePath,
                        Content = publications.Content,
                        PublishDate = publications.PublishDate,
                        Name = existingUser.FirstName,
                        LastName = existingUser.LastName,
                        ImagePath = existingUser.ImagePath,
                        UserName = userExisted.UserName,
                    };
                    publicationsList.Add(friendPost);
                }
            }
            return publicationsList.OrderByDescending(x => x.PublishDate).ToList();
        }

        public async Task<List<PublicationsViewModel>> GetUserPublications()
        {
            var list = await _repository.GetAllAsync();

            return list
                .Where(x=>x.UserID==userViewModel.Id)
                .Select(x=> new PublicationsViewModel
                {

                    UserID = x.UserID,
                    PublishDate=x.PublishDate,
                    Content=x.Content,

                }).OrderByDescending(x=>x.PublishDate)
                .ToList();

        }

    }
}
