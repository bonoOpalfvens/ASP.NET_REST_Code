using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REST_Code.Models;
using REST_Code.Models.DataBindings;
using System;

namespace REST_Code.Data
{
    public class CodeContext : IdentityDbContext
    {
        public CodeContext(DbContextOptions<CodeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Icon>().ToTable("Icons");
            builder.Entity<Icon>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<BoardLikes>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PostLikes>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PostLikes>().HasOne(p => p.Post).WithMany(b => b.Likes).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PostLikes>().HasOne(p => p.User).WithMany(b => b.LikedPosts).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CommentLikes>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CommentLikes>().HasOne(p => p.Comment).WithMany(b => b.Likes).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<CommentLikes>().HasOne(p => p.User).WithMany(b => b.LikedComments).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().HasMany(u => u.CreatedComments).WithOne(c => c.User).HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>().HasMany(u => u.CreatedPosts).WithOne(p => p.User).HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>().HasMany(u => u.LikedPosts).WithOne(b => b.User).HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<User>().HasMany(u => u.LikedComments).WithOne(b => b.User).HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Board>().ToTable("Boards");
            builder.Entity<Board>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Board>().HasMany(b => b.Posts).WithOne().HasForeignKey("BoardId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Board>().HasMany(b => b.Likes).WithOne(b => b.Board).HasForeignKey("BoardId").OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().HasOne(p => p.Board).WithMany(b => b.Posts).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>().HasOne(p => p.User).WithMany(u => u.CreatedPosts).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>().HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey("PostId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Post>().HasMany(p => p.Likes).WithOne(b => b.Post).HasForeignKey("PostId").OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>().ToTable("Comments");
            builder.Entity<Comment>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().HasOne(c => c.Post).WithMany(b => b.Comments).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comment>().HasOne(c => c.User).WithMany(u => u.CreatedComments).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comment>().HasMany(p => p.Likes).WithOne(b => b.Comment).HasForeignKey("CommentId").OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Icon> Icons { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> AppUsers { get; set; }
    }
}
