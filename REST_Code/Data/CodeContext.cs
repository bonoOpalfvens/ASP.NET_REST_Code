using Microsoft.EntityFrameworkCore;
using REST_Code.Models;
using System;

namespace REST_Code.Data
{
    public class CodeContext : DbContext
    {
        public CodeContext(DbContextOptions<CodeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Board>().HasMany(b => b.Posts).WithOne().IsRequired().HasForeignKey("BoardId");
            builder.Entity<Board>().Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Board>().Property(b => b.Icon).IsRequired().HasMaxLength(200);
            builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
