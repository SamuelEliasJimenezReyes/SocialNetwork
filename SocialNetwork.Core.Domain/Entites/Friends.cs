using SocialNetwork.Core.Domain.Common;

namespace SocialNetwork.Core.Domain.Entites
{
    public class Friends : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }


        //Navigation Propierties
        public string UserID { get; set; }
        public string FriendID { get; set; }
    }
}
