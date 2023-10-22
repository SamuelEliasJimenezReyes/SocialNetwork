using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Infraestructure.Identity.Entites
{
    public class AplicationUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
