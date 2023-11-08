using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Coments;
using SocialNetwork.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class ComentService:GenericService<SaveComentsViewModel,ComentsViewModel,Coments> , IComentsService
    {
        private readonly IComentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;
        private readonly AuthenticationResponse _response;
        private readonly IAccountService _accountServices;

        public ComentService(IComentRepository repository, IMapper mapper, IHttpContextAccessor http, IAccountService accountServices) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _http = http;
            _accountServices = accountServices;
            _response = _http.HttpContext.Session.Get<AuthenticationResponse>("user");
        }





        public async Task<List<ComentsViewModel>> GetAllComments(int ID)
        {

            var list = _repository.GetComments(ID);


            List<ComentsViewModel> comments = new ();


            foreach (var item in list)
            {
                var user = await _accountServices.GetByUserID(_response.Id);
                ComentsViewModel vm = new ();

                vm.Content = item.Content;
                vm.PublicationID = item.PublicationID;
                vm.UserID = item.UserID;
                vm.ImagePath = user.ImagePath;
                vm.UserName = user.UserName;

                comments.Add(vm);
            }

            return comments;


        }

        }
    }
