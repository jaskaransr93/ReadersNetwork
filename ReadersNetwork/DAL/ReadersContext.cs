using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ReadersNetwork.Models;

namespace ReadersNetwork.DAL
{
    public class ReadersContext : DbContext
    {
        public ReadersContext() : base()
        {
            Database.SetInitializer<ReadersContext>(new CreateDatabaseIfNotExists<ReadersContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Followers).WithMany(x => x.Following)
                .Map(x => x.ToTable("Followers")
                    .MapLeftKey("UserId")
                    .MapRightKey("FollowerId"));

            //modelBuilder.Entity<User>()
            //    .HasMany(m => m.Followers)
            //    .WithMany(m => m.Following)
            //    .Map(x => x.MapLeftKey("UserId")
            //        .MapRightKey("FollowerId")
            //        .ToTable("UserFollowers"));

        }
    }
}