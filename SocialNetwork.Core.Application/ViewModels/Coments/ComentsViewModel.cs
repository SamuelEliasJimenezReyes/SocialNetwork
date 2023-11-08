namespace SocialNetwork.Core.Application.ViewModels.Coments
{
    public class ComentsViewModel
    {
        public int PublicationID {  get; set; }
        public string UserID {  get; set; }
        public string? ImagePath {  get; set; }
        public string UserName {  get; set; }

        public string Content { get; set; }
    }
}
