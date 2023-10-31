using SocialNetwork.Core.Application.ViewModels.Publications;
using SocialNetwork.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IPublicationService : IBaseService<SavePublicationViewModel,PublicationsViewModel,Publications> 
    {
       Task<List<FriendsPublicationViewModel>> GetAllByFriend(string UserName);
        Task<List<PublicationsViewModel>> GetUserPublications();
    }
}
