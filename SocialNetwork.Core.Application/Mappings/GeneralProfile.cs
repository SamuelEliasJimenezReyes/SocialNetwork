﻿using SocialNetwork.Core.Application.Dtos.Account;
using SocialNetwork.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


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

        }
    }
}