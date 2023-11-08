using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Domain.Entites;
using SocialNetwork.Infraestructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Infraestructure.Persistence.Repositories
{
    public class ComentRepository : BaseRepository<Coments>, IComentRepository
    {
        private readonly ApplicationContext _dbContext;

        public ComentRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Coments> GetComments(int ID)
        {
            return _dbContext.Coments.Where(a => a.ID == ID).ToList();

        }
    }
}
