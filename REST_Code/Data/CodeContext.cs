using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REST_Code.Models;
using System;

namespace REST_Code.Data
{
    public class CodeContext : IdentityDbContext
    {
        public CodeContext(DbContextOptions<CodeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Board>().ToTable("Boards");
            builder.Entity<Board>().HasKey(b => b.Id);
            builder.Entity<Board>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Board>().Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Board>().Property(b => b.Icon).IsRequired().HasMaxLength(200);
            builder.Entity<Board>().HasMany(b => b.Posts).WithOne().HasForeignKey("BoardId").OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Post>().Property(p => p.DateAdded).IsRequired();
            builder.Entity<Post>().HasOne(p => p.Board).WithMany(b => b.Posts);

            builder.Entity<User>().Property(u => u.Username).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> AppUsers { get; set; }
    }
}
