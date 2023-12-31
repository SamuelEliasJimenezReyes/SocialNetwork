﻿using SocialNetwork.Core.Application.Dtos.Email;
using SocialNetwork.Core.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IEmailServices
    {
        public MailSettings MailSettings { get; }
        Task SendAsync(EmailRequest request);
    }
}
