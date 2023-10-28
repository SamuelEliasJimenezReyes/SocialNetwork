using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Publications;
using SocialNetwork.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class PublicationService : GenericService<SavePublicationViewModel,PublicationsViewModel,Publications>, IPublicationService
    {
        private readonly IPublicationRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;

        public PublicationService(IPublicationRepository repository, IHttpContextAccessor httpContextAccessor, AuthenticationResponse userViewModel, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            this.userViewModel = userViewModel;
            _mapper = mapper;
        }

        public override async Task<SavePublicationViewModel> Add(SavePublicationViewModel vm)
        {
            vm.UserID = userViewModel.Id;
            return await base.Add(vm);
        }

        public override async Task Update(SavePublicationViewModel vm, int id)
        {
            vm.UserID = userViewModel.Id;
            await base.Update(vm, id);
        }

        public async Task<List<PublicationsViewModel>> GetWithComents()
        {
            List<PublicationsViewModel> a = new();
            return a;
        }

    }
}
