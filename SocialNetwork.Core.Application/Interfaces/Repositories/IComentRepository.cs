using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Core.Application.Interfaces.Repositories
{
    public interface IComentRepository :IGenericRepository<Coments>
    {
         List<Coments> GetComments(int ID);
        
    }
}
