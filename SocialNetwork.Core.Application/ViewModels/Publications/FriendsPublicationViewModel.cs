using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Publications
{
    public class FriendsPublicationViewModel
    {
        public string UserID { get; set; }
        public int ID { get; set; }
        public string? ImagePath { get; set; }
        public string? PublicationImagePath { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? LastName { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
