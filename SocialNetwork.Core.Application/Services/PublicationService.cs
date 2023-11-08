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
        private readonly IComentsService _comentService;

        public PublicationService(IPublicationRepository repository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IAccountService accountService, IFriendService friendService, IComentsService comentService) : base(repository, mapper)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
            _accountService = accountService;
            _friendService = friendService;
            _comentService = comentService;
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
            
            List<FriendsPublicationViewModel> publicationList = new ();
            var currentUser = await _accountService.GetByUserName(UserName);
            FriendsPublicationViewModel publicationFriends = new();


            var friends = await _friendService.GetAllFriends();

            foreach (var item in friends)
            {
                var publicationsFriendsList = await _repository.GetAllAsync();
                foreach (var publications in publicationsFriendsList)
                {

                    var finder = await _accountService.GetByUserID(publications.UserID);


                    publicationFriends.PublicationImagePath = publications.ImagePath;
                    publicationFriends.Content = publications.Content;
                    publicationFriends.PublishDate = publications.PublishDate;
                    publicationFriends.Name = finder.FirstName;
                    publicationFriends.LastName = finder.LastName;
                    publicationFriends.ImagePath = finder.ImagePath;
                    UserName = finder.UserName;
                    
                    publicationList.Add(publicationFriends);

                }
            }
            var linq = publicationList.OrderByDescending(x => x.PublishDate).ToList();
            return linq;
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

        public async Task<List<PublicationsViewModel>> GetAllPublicationComments()
        {
            var list = await _repository.GetAllAsync();


            List<PublicationsViewModel> result = new ();


            foreach (var item in list)
            {

                PublicationsViewModel vm = new();


                    vm.ImagePath = item.ImagePath;
                vm.Content = item.Content;
                vm.PublishDate = item.PublishDate;
                vm.ID = item.ID;
                vm.UserID = item.UserID;
                vm.Coments = await _comentService.GetAllComments(item.ID);
                

                result.Add(vm);

            }

            return result;


        }


    }
}
