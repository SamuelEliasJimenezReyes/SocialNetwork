using SocialNetwork.Core.Domain.Common;

namespace SocialNetwork.Core.Domain.Entites
{
    public class Publications : BaseEntity
    {
        public string Content { get; set; }
        public string? ImagePath { get; set; }
        public DateTime PublishDate { get; set; }

        //Navigation propierties 
        public string UserID { get; set; }
        public int ComentID { get; set; }
        public ICollection<Coments> Coments { get; set; }
    }
}
