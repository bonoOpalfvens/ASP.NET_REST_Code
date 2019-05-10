using System;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using REST_Code.Models;

namespace REST_Code.Data
{
    public class CodeDataInitializer
    {
        private readonly CodeContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public CodeDataInitializer(CodeContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async System.Threading.Tasks.Task InitializeDataAsync()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                ArrayList _boards = new ArrayList();
                _boards.Add(new Board { Name = "C#", Icon = "https://is5-ssl.mzstatic.com/image/thumb/Purple124/v4/56/48/66/564866c6-ed2c-ac95-9664-c1364037605c/AppIcon-0-1x_U007emarketing-0-0-GLES2_U002c0-512MB-sRGB-0-0-0-85-220-0-0-0-7.png/246x0w.jpg" });
                _boards.Add(new Board { Name = "Java", Icon = "https://sdtimes.com/wp-content/uploads/2018/03/jW4dnFtA_400x400.jpg" });
                _boards.Add(new Board { Name = "JavaScript", Icon = "https://cdn.auth0.com/blog/jsleaks/logo.png" });
                _boards.Add(new Board { Name = "Python", Icon = "http://www.iconarchive.com/download/i73027/cornmanthe3rd/plex/Other-python.ico" });
                _boards.Add(new Board { Name = "Ruby", Icon = "https://cdn-images-1.medium.com/max/1200/1*9hd_8qR0CMZ8L0pVbFLjDw.png" });
                _boards.Add(new Board { Name = "PHP", Icon = "http://www.iconarchive.com/download/i105644/papirus-team/papirus-apps/github-bartzaalberg-php-tester.ico" });
                _boards.Add(new Board { Name = "C++", Icon = "https://domainciq.com//sites/default/files/gbb-uploads/CC-vw4rsc.png" });
                _boards.Add(new Board { Name = "SQL", Icon = "https://27jts3o00yy49vo2y30wem91-wpengine.netdna-ssl.com/wp-content/uploads/2018/05/ASSET-SOFTWARE-SQL-DATABASE-300x300.png" });
                _boards.Add(new Board { Name = "Bash", Icon = "https://d2eip9sf3oo6c2.cloudfront.net/tags/images/000/001/218/full/bash_shell.png" });
                _boards.Add(new Board { Name = "Kotlin", Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Kotlin-logo.svg/220px-Kotlin-logo.svg.png" });

                ArrayList _posts = new ArrayList();
                foreach (Board board in _boards)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        board.Posts.Add(new Post { Title = board.Name + i.ToString(), Board = board, User = "Bono", DateAdded = DateTime.Today });
                    }
                    _dbContext.Boards.Add(board);
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
