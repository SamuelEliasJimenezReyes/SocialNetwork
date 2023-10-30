namespace SocialNetwork.Core.Domain.Entites
{
    public class FriendsComents 
    {
        public int ComentID { get; set; }
        public Coments Coments { get; set; }

        public int FriendID { get; set; }
        public Friends Friends { get; set; }
    }
}
