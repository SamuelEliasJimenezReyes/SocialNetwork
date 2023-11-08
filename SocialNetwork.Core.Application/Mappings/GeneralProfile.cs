using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.Core.Domain.Entites;
using SocialNetwork.Core.Application.ViewModels.Publications;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Coments;

namespace SocialNetwork.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region UserProfile
            CreateMap<AuthenticationRequest, LoginViewModel>()
                                .ForMember(x => x.HasError, opt => opt.Ignore())
                                .ForMember(x => x.Error, opt => opt.Ignore())
                                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                                .ForMember(x => x.HasError, opt => opt.Ignore())
                                .ForMember(x => x.Error, opt => opt.Ignore())
                                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                                .ForMember(x => x.HasError, opt => opt.Ignore())
                                .ForMember(x => x.Error, opt => opt.Ignore())
                                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                                .ForMember(x => x.HasError, opt => opt.Ignore())
                                .ForMember(x => x.Error, opt => opt.Ignore())
                                .ReverseMap();
            #endregion

            #region FriendProfile
            CreateMap<Friends, AddFriendViewModel>()
                        .ReverseMap()
                        .ForMember(x => x.IsDeleted, z => z.Ignore());
            CreateMap<Friends, FriendViewModel>()
                        .ReverseMap()
                        .ForMember(x => x.IsDeleted, z => z.Ignore())
                        .ForMember(x => x.ID, z => z.Ignore());

            #endregion

            #region PublicationProfile
            CreateMap<Publications, SavePublicationViewModel>()
                                    .ReverseMap()
                                    .ForMember(x => x.Coments, z => z.Ignore())
                                    .ForMember(x => x.ComentID, z => z.Ignore());
            CreateMap<Publications, PublicationsViewModel>()
                        .ReverseMap()
                        .ForMember(x => x.Coments, z => z.Ignore())
                        .ForMember(x => x.ComentID, z => z.Ignore())
                        .ForMember(x => x.ID, z => z.Ignore());


            #endregion


            #region ComentProfile
            CreateMap<Coments, ComentsViewModel>()
                .ReverseMap()
                .ForMember(x => x.IsDeleted, z => z.Ignore())
                .ForMember(x => x.ID, z => z.Ignore());

            CreateMap<Coments, SaveComentsViewModel>()
                .ReverseMap()
                .ForMember(x => x.IsDeleted, z => z.Ignore())
                .ForMember(x => x.ID, z => z.Ignore());
            #endregion
        }
    }
}
