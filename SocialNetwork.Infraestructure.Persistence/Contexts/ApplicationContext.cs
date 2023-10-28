using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infraestructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Publications> Publications { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table
            modelBuilder.Entity<Friends>().ToTable("Friends");
            modelBuilder.Entity<Publications>().ToTable("Publications");
            #endregion

            #region Keys

            #region Primary Keys
            modelBuilder.Entity<Friends>().HasKey(x=>x.ID);
            modelBuilder.Entity<Publications>().HasKey(x=>x.ID);
            #endregion

            #region Relations

            #endregion

            #endregion

            #region Querys
            modelBuilder.Entity<Friends>().HasQueryFilter(x=>!x.IsDeleted);
            modelBuilder.Entity<Publications>().HasQueryFilter(x=>!x.IsDeleted);
            #endregion 
        }

    }
}
