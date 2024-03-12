using MYCMS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MYCMS.Web.Data
{
    public class CMSDbContext : IdentityDbContext<User>
    {
        public CMSDbContext(DbContextOptions<CMSDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<User>()
                   .HasQueryFilter(x => !x.IsDelete);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAttachment> PostAttachments { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<ContentChangeLog> ContentChangeLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

    }
}
