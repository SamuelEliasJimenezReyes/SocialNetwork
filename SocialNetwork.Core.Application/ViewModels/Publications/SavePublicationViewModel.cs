using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Core.Application.ViewModels.Publications
{
    public class SavePublicationViewModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        public string? ImagePath { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }

        public string Content { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;


    }
}
