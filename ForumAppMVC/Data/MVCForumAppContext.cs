using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCForumApp.Models;

namespace MVCForumApp.Data
{
    public class MVCForumAppContext : DbContext
    {
        public MVCForumAppContext (DbContextOptions<MVCForumAppContext> options)
            : base(options)
        {
        }

        public DbSet<MVCForumApp.Models.User> User { get; set; } = default!;
        public DbSet<MVCForumApp.Models.Topic> Topic { get; set; } = default!;
        public DbSet<MVCForumApp.Models.Post> Post { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Topic>()
                .HasOne(e => e.User)
                .WithMany(e => e.Topics)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Post>()
                .HasOne(p => p.Topic)
                .WithMany(t => t.Posts)
                .HasForeignKey(p => p.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }



    }
}
