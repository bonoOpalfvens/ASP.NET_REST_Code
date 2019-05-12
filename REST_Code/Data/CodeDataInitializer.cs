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
                ArrayList _icons = new ArrayList();
                _icons.Add(new Icon { Url = "https://imgur.com/omMCBMa.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/5MwLh8T.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/HUBBvDr.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/xAvIBex.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/jYEGeFZ.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/lgNXztq.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/74qa5vN.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/vDtB0fR.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/bQC0Ppy.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/8dexDFH.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/YHZF0gC.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/ctWeuno.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/jSRe2wW.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/PEdNf6X.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/Seed15K.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/Seed15K.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/luL9jdc.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/ojavEjW.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/YajwjJS.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/QRraeMn.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/4ibvTmp.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/C1OPiLw.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/0GfzcrT.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/LadrKUH.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/YBVmTx3.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/Mdhsqlo.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/68rC6Ar.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/ha09fSu.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/nPbtlbD.png" });
                _icons.Add(new Icon { Url = "https://imgur.com/bMxp0CX.png" });

                foreach(Icon icon in _icons){
                    _dbContext.Icons.Add(icon);
                }

                ArrayList _boards = new ArrayList();
                const string description = "Programming Language";
                _boards.Add(new Board { Name = "C#", Icon = (Icon)_icons[2], Description = description });
                _boards.Add(new Board { Name = "Java", Icon = (Icon)_icons[3], Description = description });
                _boards.Add(new Board { Name = "JavaScript", Icon = (Icon)_icons[4], Description = description });
                _boards.Add(new Board { Name = "Python", Icon = (Icon)_icons[7], Description = description });
                _boards.Add(new Board { Name = "Ruby", Icon = (Icon)_icons[8], Description = description });
                _boards.Add(new Board { Name = "PHP", Icon = (Icon)_icons[6], Description = description });
                _boards.Add(new Board { Name = "C++", Icon = (Icon)_icons[1], Description = description });
                _boards.Add(new Board { Name = "SQL", Icon = (Icon)_icons[9], Description = description });
                _boards.Add(new Board { Name = "Bash", Icon = (Icon)_icons[0], Description = description });
                _boards.Add(new Board { Name = "Kotlin", Icon = (Icon)_icons[5], Description = description });

                User user = new User { Username = "Bono", Email = "Bono@fluxcode.be", Avatar = (Icon)_icons[2] };
                _dbContext.AppUsers.Add(user);

                ArrayList _posts = new ArrayList();
                foreach (Board board in _boards)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        board.Posts.Add(new Post { Title = board.Name + i.ToString(), Board = board, User = user, DateAdded = DateTime.Today });
                    }
                    _dbContext.Boards.Add(board);
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
