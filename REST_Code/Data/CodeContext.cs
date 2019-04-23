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

            // Seed db
            builder.Entity<Board>().HasData(
                new Board { Id = 1, Name = "JavaScript", Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/1200px-Unofficial_JavaScript_logo_2.svg.png" },
                new Board { Id = 2, Name = "C#", Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/C_Sharp_wordmark.svg/225px-C_Sharp_wordmark.svg.png" },
                new Board { Id = 3, Name = "HTML/CSS", Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/HTML5_logo_and_wordmark.svg/180px-HTML5_logo_and_wordmark.svg.png" },
                new Board { Id = 4, Name = "Python", Icon = "https://pbs.twimg.com/profile_images/439154912719413248/pUBY5pVj_400x400.png" },
                new Board { Id = 5, Name = "Java", Icon = "https://sdtimes.com/wp-content/uploads/2019/03/jW4dnFtA_400x400.jpg" },
                new Board { Id = 6, Name = "PHP", Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/PHP-logo.svg/150px-PHP-logo.svg.png" },
                new Board { Id = 7, Name = "C++", Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/ISO_C%2B%2B_Logo.svg/210px-ISO_C%2B%2B_Logo.svg.png" },
                new Board { Id = 8, Name = ".NET", Icon = "https://upload.wikimedia.org/wikipedia/commons/0/0e/Microsoft_.NET_logo.png" },
                new Board { Id = 8, Name = "AngularJS", Icon = "https://d2eip9sf3oo6c2.cloudfront.net/tags/images/000/000/300/thumb/angular2.png" }

            );
            builder.Entity<Post>().HasData(
                new { Id = 1, Title = "Basic Webapplication", User = "Bono", DateAdded = new DateTime(2019, 04, 10, 12, 15, 10), BoardId = 1 },
                new { Id = 2, Title = "Native Windows Application", User = "SomeOtherUser", DateAdded = new DateTime(2018, 03, 4, 10, 55, 10), BoardId = 2 },
                new { Id = 3, Title = "API", User = "JustAnotherUser", DateAdded = new DateTime(2019, 7, 3, 18, 23, 10), BoardId = 8 }
            );
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
