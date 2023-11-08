using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.ViewModels.Coments;
using SocialNetwork.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IComentsService : IBaseService<SaveComentsViewModel,ComentsViewModel,Coments>
    {
        Task<List<ComentsViewModel>> GetAllComments(int ID);
    }
}
