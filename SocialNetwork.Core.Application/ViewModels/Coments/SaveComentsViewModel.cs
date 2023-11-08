using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Coments
{
    public class SaveComentsViewModel
    {

        public int PublicationID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must type a Content")]
        [DataType(DataType.Text)]
        public string Content { get; set; }
    }
}
