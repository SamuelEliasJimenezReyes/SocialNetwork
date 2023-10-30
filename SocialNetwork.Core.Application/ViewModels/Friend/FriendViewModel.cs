using SocialNetwork.Core.Application.ViewModels.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Friend
{
    public class FriendViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }

        public List<PublicationsViewModel> Publications { get; set; }

    }
}
