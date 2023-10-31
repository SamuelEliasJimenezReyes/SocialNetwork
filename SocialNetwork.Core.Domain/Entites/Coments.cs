using SocialNetwork.Core.Domain.Common;

namespace SocialNetwork.Core.Domain.Entites
{
    public class Coments : BaseEntity
    {
        public string Content { get; set; }

        //navigation propierties 
        public string UserID { get; set; }
        public int PublicationID { get; set; }
        public Publications Publication { get; set; }

    }
}
