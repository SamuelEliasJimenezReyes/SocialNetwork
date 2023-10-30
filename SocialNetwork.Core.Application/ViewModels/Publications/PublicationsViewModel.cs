using SocialNetwork.Core.Application.ViewModels.Coments;

namespace SocialNetwork.Core.Application.ViewModels.Publications
{
    public class PublicationsViewModel
    {
        public string UserID { get; set; }
        public int ID { get; set; }
        public string? ImagePath { get; set; }
        public string Content{ get; set; }
        public DateTime PublishDate{ get; set; }
        public List<ComentsViewModel> Coments{ get; set; }
    }
}
