using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using REST_Code.Models;
using REST_Code.Models.DataBindings;

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
                const string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eget odio at turpis ornare posuere. Fusce convallis convallis volutpat. Praesent dignissim tincidunt augue. Vestibulum sed porttitor mi. Fusce suscipit nisi vel mi condimentum, in dictum justo rutrum. Maecenas sit amet lacus diam. Cras sit amet ligula a risus accumsan accumsan quis vel elit. Morbi eget sollicitudin lorem. Suspendisse molestie bibendum arcu, eu hendrerit ex venenatis non. Mauris euismod, risus eu semper vulputate, quam metus tincidunt sem, a hendrerit risus dui a elit. Integer sagittis ut mi in tempus. In non malesuada neque. Nam nec lectus in purus egestas luctus at a erat. Cras molestie ut nisl id blandit. Ut eu sollicitudin nisi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec eget magna a eros blandit elementum euismod quis lectus. Suspendisse ac est quis lorem iaculis dapibus. Integer porttitor dictum velit sit amet euismod. Mauris molestie tempor varius. Interdum et malesuada fames ac ante ipsum primis in faucibus. In hac habitasse platea dictumst. Nullam faucibus tempus nulla vitae efficitur. Morbi non ligula eu nisl sodales pulvinar et at sem. Duis maximus nisi at nunc elementum condimentum. Pellentesque nulla risus, sodales sit amet lacinia eu, congue eu est. Aliquam sodales cursus iaculis. Aliquam sit amet urna a turpis lacinia varius non vitae risus. Nulla vel est mattis, convallis tellus vestibulum, dictum dui. Phasellus nec nulla euismod, posuere felis nec, tincidunt augue. Aenean leo sem, venenatis eu sem id, mattis vestibulum sem. Nam bibendum massa augue, volutpat hendrerit dolor laoreet sed. Nulla ac nunc congue, convallis dui eget, condimentum enim. Morbi tincidunt pellentesque tortor, non malesuada tortor egestas at. Sed egestas enim justo, non congue est tincidunt quis. Phasellus sed porttitor nunc, id feugiat nibh. Nullam tempor facilisis libero, vitae lobortis metus consectetur vulputate. Vivamus ultricies leo mi, in pellentesque metus venenatis sit amet. Vestibulum eu lobortis dolor. Fusce vulputate ornare nisi, in aliquet odio ornare eget. Duis vitae viverra mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam erat volutpat. Phasellus feugiat purus a purus venenatis cursus. Vestibulum quis ligula finibus, placerat augue quis, vehicula eros. Nulla commodo lorem in porttitor pulvinar. Vivamus et pharetra eros, non hendrerit ex. In pulvinar accumsan ligula, id tristique lacus porta ac. Donec semper mi at consequat venenatis. Ut cursus nunc et condimentum imperdiet. Pellentesque tincidunt fermentum dui vitae malesuada. Suspendisse blandit ipsum ut sollicitudin commodo. Vivamus fermentum, lacus tempor posuere dictum, risus mauris faucibus sapien, at pharetra ex nisi a tellus. Vivamus nulla diam, facilisis in egestas eu, facilisis at nibh. Aenean porttitor dictum neque sit amet finibus. Vestibulum id neque a arcu tincidunt porta. Aliquam imperdiet eros enim, vel viverra justo porttitor a. ";
                foreach (Board board in _boards)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        ICollection<Comment> comments = new List<Comment>();
                        Random rand = new Random();
                        int rando = rand.Next(10);
                        for (int x = 0; x < rando; x++)
                        {
                            comments.Add(new Comment { User = user, DateAdded = DateTime.Today.AddDays(-rando), Content = "Interesting post" });
                        }
                        board.Posts.Add(new Post { Title = board.Name + i.ToString(), Board = board, User = user, DateAdded = DateTime.Today.AddDays(-20 -i), Content = content, Comments = comments, Likes = (rand.Next(2) == 1)? new List<PostLikes> { new PostLikes { User = user, DateLiked = DateTime.Today.AddDays(-20 - i) } }: null });
                    }
                    _dbContext.Boards.Add(board);
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
