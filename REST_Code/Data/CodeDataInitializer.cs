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
            //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                ArrayList Comments = new ArrayList();
                Comments.Add("Too many snakes on this goddamn plane.");
                Comments.Add("Your mother was a hamster and your father smelt of elderberries.");
                Comments.Add("Scruffy-looking nerfherder!");
                Comments.Add("Say what, one more time.");
                Comments.Add("'What' ain't no country I've ever heard of. They speak English in 'What'?");
                Comments.Add("What?");
                Comments.Add("Nanananananananananananananananana Batman");
                Comments.Add("I say we take off and nuke the site from orbit. It's the only way to be sure.");
                Comments.Add("I have come here to chew bubblegum and kick ass... and I'm all out of bubblegum.");
                Comments.Add("I'm afraid I can't let you do that.");
                Comments.Add("Mister Stark. I don't feel so good");
                Comments.Add("With great power, comes great responsibility.");
                Comments.Add("Glory to The Old One.");
                Comments.Add("Join me, and we will rule the galaxy together!");
                Comments.Add("That's no moon :O");
                Comments.Add("Gungans no dyin' withouta fight. Wesa warriors. Wesa got a grand army. That's why you no likin' us, mesa thinks.");
                Comments.Add("The ability to speak doesn't make you intelligent.");

                ArrayList Content = new ArrayList();
                Content.Add("Along hummingbird thus deliberate misunderstood more eel goodness beneath thorough depending jeepers camel wow the regardless laggard much and sporadically immeasurably lizard told melodiously far more insolently blanched over dived trod and and raccoon well since sordidly scooped black when that one spitefully but cheered while less and so yikes somber due knelt ouch one goodness up took one the blanched and untactful more much crab deserved so toward this less gosh off bred and much soberly boa as gosh boa eccentric so before.Along hummingbird thus deliberate misunderstood more eel goodness beneath thorough depending jeepers camel wow the regardless laggard much and sporadically immeasurably lizard told melodiously far more insolently blanched over dived trod and and raccoon well since sordidly scooped black when that one spitefully but cheered while less and so yikes somber due knelt ouch one goodness up took one the blanched and untactful more much crab deserved so toward this less gosh off bred and much soberly boa as gosh boa eccentric so before.");
                Content.Add("Menacingly darn slight in ahead depending one quizzical much that knelt studiedly hamster and criminal hey surprising that however far far unicorn that in jeepers wrung demurely more alongside hello hedgehog tarantula jeepers more flailed gosh goodness much censoriously far rewound and robin far staidly that alas avaricious hello that some some and then alas permissively out otter understood this and hatchet horse fumed a a insistent frightening snickered lizard that that so hey the when disbanded a hooted vigilant the.Along hummingbird thus deliberate misunderstood more eel goodness beneath thorough depending jeepers camel wow the regardless laggard much and sporadically immeasurably lizard told melodiously far more insolently blanched over dived trod and and raccoon well since sordidly scooped black when that one spitefully but cheered while less and so yikes somber due knelt ouch one goodness up took one the blanched and untactful more much crab deserved so toward this less gosh off bred and much soberly boa as gosh boa eccentric so before.");
                Content.Add("Spoon-fed and toucan prior stupid thus much and spoiled undid much after sheep broke until more alas was far away a wore some poorly far fish jeez beat far darn far a conductively scallop persistently less polite wow mongoose giggly jeepers outgrew wherever far less peevish goodness the goodness around seagull dear seagull alongside willfully this the yikes regarding thus had about one far sniffed that excellently or until packed thus far overrode shark labrador maladroit some far great because crud alas sorely ouch between one astonishing opaquely consoled happily gamely handsome the and and overcast much.Along hummingbird thus deliberate misunderstood more eel goodness beneath thorough depending jeepers camel wow the regardless laggard much and sporadically immeasurably lizard told melodiously far more insolently blanched over dived trod and and raccoon well since sordidly scooped black when that one spitefully but cheered while less and so yikes somber due knelt ouch one goodness up took one the blanched and untactful more much crab deserved so toward this less gosh off bred and much soberly boa as gosh boa eccentric so before.");
                Content.Add("More much much far that eel preparatory hello awesome whispered ouch grunted permissive jeez oh jeez spiteful yikes outside scooped and yet depending as and unceremoniously blandly the between parrot that scorpion haltered far until hey alas jaguar well unimaginative much however lorikeet the armadillo a less intellectual much darn far one and the more before far because irritable kangaroo and amid hey contemplated this suddenly some oh far a unheedfully notwithstanding agonizingly less put needless endlessly notoriously jeez otter and dear more jeepers goat amid.Along hummingbird thus deliberate misunderstood more eel goodness beneath thorough depending jeepers camel wow the regardless laggard much and sporadically immeasurably lizard told melodiously far more insolently blanched over dived trod and and raccoon well since sordidly scooped black when that one spitefully but cheered while less and so yikes somber due knelt ouch one goodness up took one the blanched and untactful more much crab deserved so toward this less gosh off bred and much soberly boa as gosh boa eccentric so before.");
                Content.Add("Some hence so cried until before nudged much wryly goldfinch tartly much outside above thus krill darn underwrote frowned jeepers jeez well punitively less wasp amenable hung roadrunner hugged but owl far bowed complacent less on before roadrunner conditional wherever one hello hedgehog boyishly sadistically partook tightly occasionally far locked and delicate a subtle by and as more then hello and bound or hence goodness outside completely jeez gosh vulnerably some newt toucan less stole fabulously fled strewed after notwithstanding a delightfully tenable wow to.Along hummingbird thus deliberate misunderstood more eel goodness beneath thorough depending jeepers camel wow the regardless laggard much and sporadically immeasurably lizard told melodiously far more insolently blanched over dived trod and and raccoon well since sordidly scooped black when that one spitefully but cheered while less and so yikes somber due knelt ouch one goodness up took one the blanched and untactful more much crab deserved so toward this less gosh off bred and much soberly boa as gosh boa eccentric so before.");
                Content.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eget odio at turpis ornare posuere. Fusce convallis convallis volutpat. Praesent dignissim tincidunt augue. Vestibulum sed porttitor mi. Fusce suscipit nisi vel mi condimentum, in dictum justo rutrum. Maecenas sit amet lacus diam. Cras sit amet ligula a risus accumsan accumsan quis vel elit. Morbi eget sollicitudin lorem. Suspendisse molestie bibendum arcu, eu hendrerit ex venenatis non. Mauris euismod, risus eu semper vulputate, quam metus tincidunt sem, a hendrerit risus dui a elit. Integer sagittis ut mi in tempus. In non malesuada neque. Nam nec lectus in purus egestas luctus at a erat. Cras molestie ut nisl id blandit. Ut eu sollicitudin nisi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec eget magna a eros blandit elementum euismod quis lectus. Suspendisse ac est quis lorem iaculis dapibus. Integer porttitor dictum velit sit amet euismod. Mauris molestie tempor varius. Interdum et malesuada fames ac ante ipsum primis in faucibus. In hac habitasse platea dictumst. Nullam faucibus tempus nulla vitae efficitur. Morbi non ligula eu nisl sodales pulvinar et at sem. Duis maximus nisi at nunc elementum condimentum. Pellentesque nulla risus, sodales sit amet lacinia eu, congue eu est. Aliquam sodales cursus iaculis. Aliquam sit amet urna a turpis lacinia varius non vitae risus. Nulla vel est mattis, convallis tellus vestibulum, dictum dui. Phasellus nec nulla euismod, posuere felis nec, tincidunt augue. Aenean leo sem, venenatis eu sem id, mattis vestibulum sem. Nam bibendum massa augue, volutpat hendrerit dolor laoreet sed. Nulla ac nunc congue, convallis dui eget, condimentum enim. Morbi tincidunt pellentesque tortor, non malesuada tortor egestas at. Sed egestas enim justo, non congue est tincidunt quis. Phasellus sed porttitor nunc, id feugiat nibh. Nullam tempor facilisis libero, vitae lobortis metus consectetur vulputate. Vivamus ultricies leo mi, in pellentesque metus venenatis sit amet. Vestibulum eu lobortis dolor. Fusce vulputate ornare nisi, in aliquet odio ornare eget. Duis vitae viverra mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam erat volutpat. Phasellus feugiat purus a purus venenatis cursus. Vestibulum quis ligula finibus, placerat augue quis, vehicula eros. Nulla commodo lorem in porttitor pulvinar. Vivamus et pharetra eros, non hendrerit ex. In pulvinar accumsan ligula, id tristique lacus porta ac. Donec semper mi at consequat venenatis. Ut cursus nunc et condimentum imperdiet. Pellentesque tincidunt fermentum dui vitae malesuada. Suspendisse blandit ipsum ut sollicitudin commodo. Vivamus fermentum, lacus tempor posuere dictum, risus mauris faucibus sapien, at pharetra ex nisi a tellus. Vivamus nulla diam, facilisis in egestas eu, facilisis at nibh. Aenean porttitor dictum neque sit amet finibus. Vestibulum id neque a arcu tincidunt porta. Aliquam imperdiet eros enim, vel viverra justo porttitor a. ");

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

                ArrayList Users = new ArrayList();
                User user = new User { Username = "TheLegend27", Email = "legend27@fluxcode.be", Avatar = (Icon)_icons[22] };
                IdentityUser idUser = new IdentityUser { UserName = user.Username, Email = user.Email };
                User user2 = new User { Username = "Noobmaster", Email = "noobmaster@fluxcode.be", Avatar = (Icon)_icons[21] };
                IdentityUser idUser2 = new IdentityUser { UserName = user2.Username, Email = user2.Email };
                User user3 = new User { Username = "Arthemis", Email = "arthemis@fluxcode.be", Avatar = (Icon)_icons[24] };
                IdentityUser idUser3 = new IdentityUser { UserName = user3.Username, Email = user3.Email };
                User user4 = new User { Username = "Acerak", Email = "acerak@fluxcode.be", Avatar = (Icon)_icons[25] };
                IdentityUser idUser4 = new IdentityUser { UserName = user4.Username, Email = user4.Email };
                User user5 = new User { Username = "LeechQueen", Email = "kevincoolxd@gmail.com", Avatar = (Icon)_icons[26] };
                IdentityUser idUser5 = new IdentityUser { UserName = user5.Username, Email = user5.Email };
                User user6 = new User { Username = "StanLee", Email = "StanLee@fluxcode.be", Avatar = (Icon)_icons[27] };
                IdentityUser idUser6 = new IdentityUser { UserName = user6.Username, Email = user6.Email };
                await _userManager.CreateAsync(idUser, "P@ssword1111");
                await _userManager.CreateAsync(idUser2, "P@ssword1111");
                await _userManager.CreateAsync(idUser3, "P@ssword1111");
                await _userManager.CreateAsync(idUser4, "P@ssword1111");
                await _userManager.CreateAsync(idUser5, "P@ssword1111");
                await _userManager.CreateAsync(idUser6, "P@ssword1111");
                Users.Add(user);
                Users.Add(user2);
                Users.Add(user3);
                Users.Add(user4);
                Users.Add(user5);
                Users.Add(user6);
                _dbContext.AppUsers.AddRange(user, user2, user3, user4, user5, user6);

                ArrayList _posts = new ArrayList();
                Random rand = new Random();
                foreach (Board board in _boards)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        ICollection<Comment> tempComments = new List<Comment>();
                        int rando = rand.Next(5);
                        for(int x = 0; x < rando; x++)
                        {
                            tempComments.Add(new Comment { User = (User)Users[rand.Next(Users.Count-1)], DateAdded = DateTime.Today.AddDays(-rando), Content = (string)Comments[rand.Next(Comments.Count-1)] });
                        }
                        board.Posts.Add(new Post { Title = board.Name + i.ToString(), Board = board, User = user, DateAdded = DateTime.Today.AddDays(-20 - i), Content = (string)Content[rand.Next(Content.Count - 1)], Comments = tempComments, Likes = (rand.Next(2) == 1) ? new List<PostLikes> { new PostLikes { User = (User)Users[rand.Next(Users.Count - 1)], DateLiked = DateTime.Today.AddDays(-20 - rand.Next(30)) } } : null });
                    }
                    _dbContext.Boards.Add(board);
                }
                _dbContext.SaveChanges();
            }
        }
    }
}
