using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Domain.Entites;
using SocialNetwork.Infraestructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infraestructure.Persistence.Repositories
{
    public class FriendRepository : BaseRepository<Friends>, IFriendRepository
    {
        private readonly ApplicationContext _dbContext;

        public FriendRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
