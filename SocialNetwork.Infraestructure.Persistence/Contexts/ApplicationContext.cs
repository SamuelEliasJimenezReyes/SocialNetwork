using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Domain.Entites;

namespace SocialNetwork.Infraestructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Publications> Publications { get; set; }
        public DbSet<Coments> Coments { get; set; }
        public DbSet<FriendsComents> FriendsComents { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table
            modelBuilder.Entity<Friends>().ToTable("Friends");
            modelBuilder.Entity<Publications>().ToTable("Publications");
            modelBuilder.Entity<Coments>().ToTable("Coments");
            modelBuilder.Entity<FriendsComents>().ToTable("FriendsComents");
            #endregion

            #region Keys

            #region Primary Keys
            modelBuilder.Entity<Friends>().HasKey(x=>x.ID);
            modelBuilder.Entity<Coments>().HasKey(x => x.ID); 
            modelBuilder.Entity<Publications>().HasKey(x=>x.ID);
            modelBuilder.Entity<FriendsComents>().HasKey(x=>new {x.ComentID,x.FriendID});
            #endregion

            #region Relations

            modelBuilder.Entity<Publications>()
                    .HasMany(x=>x.Coments)
                    .WithOne(x=>x.Publication)
                    .HasForeignKey(x=>x.PublicationID);


            modelBuilder.Entity<FriendsComents>()
                        .HasOne(x => x.Coments)
                        .WithMany(x=>x.FriendComent)
                        .HasForeignKey(x=>x.ComentID)
                        .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<FriendsComents>()
                    .HasOne(x => x.Friends)
                    .WithMany(x => x.FriendComents)
                    .HasForeignKey(x => x.FriendID);
                        
            #endregion

            #endregion

            #region Querys
            modelBuilder.Entity<Friends>().HasQueryFilter(x=>!x.IsDeleted);
            modelBuilder.Entity<Publications>().HasQueryFilter(x=>!x.IsDeleted);
            modelBuilder.Entity<Coments>().HasQueryFilter(x=>!x.IsDeleted);
            #endregion 
        }

    }
}
