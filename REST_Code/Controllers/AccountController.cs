using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using REST_Code.DTOs;
using REST_Code.DTOs.Models;
using REST_Code.Models;
using REST_Code.Models.IRepository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace REST_Code.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : Controller
    {
        #region Init
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IIconRepository _iconRepository;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IUserRepository userRepository, IIconRepository iconRepository, IConfiguration conf)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _iconRepository = iconRepository;
            _config = conf;
        }
        #endregion

        // POST : api/account/login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">the login details</param>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<String>> CreateToken(LoginDTO model)
        {
            // System login through Email and password
            IdentityUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token);
                }
            }
            return BadRequest();
        }

        // POST : api/account
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="model">the user details</param>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<String>> Register(RegisterDTO model)
        {
            // Basic registration of required credentials
            IdentityUser idUser = new IdentityUser { UserName = model.UserName, Email = model.Email };
            User user = new User { Email = model.Email, Username = model.UserName, Avatar =  _iconRepository.GetBy(16)};
            var result = await _userManager.CreateAsync(idUser, model.Password);

            if (result.Succeeded)
            {
                _userRepository.Add(user);
                _userRepository.SaveChanges();
                string token = GetToken(idUser);
                return Created("", token);
            }
            return BadRequest();
        }

        // GET : api/account/username
        /// <summary>
        /// Get the user with the given username
        /// </summary>
        /// <param name="username">the username of the user</param>
        /// <returns>the user</returns>
        [AllowAnonymous]
        [HttpGet("{username}")]
        public ActionResult<UserDTO> GetUser(String username)
        {
            User user = _userRepository.GetBy(username);
            if (user == null)
                return NotFound();

            UserDTO tempUser = UserDTO.FromUser(user);
            if (!(User != null && User.Identity.IsAuthenticated && User.Identity.Name.Equals(user.Username)))
            {
                if (user.EmailIsPrivate)
                    tempUser.Email = "privacy@fluxcode.be";
                // Private attributes only readable for logged in users
                tempUser.CreatedPosts = user.CreatedPosts.Select(PostDTO.FromPost); ;
            }
            return tempUser;
        }

        // GET : api/account/byEmail/email
        /// <summary>
        /// Get the user with the given email
        /// </summary>
        /// <param name="email">the email of the user</param>
        /// <returns>the user</returns>
        [AllowAnonymous]
        [HttpGet("byEmail/{email}")]
        public ActionResult<UserDTO> GetUserByEmail(String email)
        {
            User user = _userRepository.GetByEmail(email);
            if (user == null)
                return NotFound();

            UserDTO tempUser = UserDTO.FromUser(user);
            if (!(User != null && User.Identity.IsAuthenticated && User.Identity.Name.Equals(user.Username)))
            {
                if (user.EmailIsPrivate)
                    tempUser.Email = "privacy@fluxcode.be";
                // Private attributes only readable for logged in users
                tempUser.CreatedPosts = user.CreatedPosts.Select(PostDTO.FromPost); ;
            }
            return tempUser;
        }

        // GET : api/account/checkusername
        /// <summary>
        /// Get the availability of the given username
        /// </summary>
        /// <param name="username">the username</param>
        /// <returns>the availability of the username</returns>
        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>> CheckAvailableUserNameAsync(String username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user == null;
        }

        // GET : api/account/checkemail
        /// <summary>
        /// Get the availability of the given email
        /// </summary>
        /// <param name="email">the email</param>
        /// <returns>the availability of the email</returns>
        [AllowAnonymous]
        [HttpGet("checkemail")]
        public async Task<ActionResult<Boolean>> CheckAvailableEmailAsync(String email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null;
        }

        // PUT : api/account
        /// <summary>
        /// Edit the user with the given id
        /// </summary>
        /// <param name="model">the user with the changed properties</param>
        /// <returns>Status 204</returns>
        [HttpPut]
        public ActionResult<User> Edit(UserDTO model)
        {
            User user;
            if (!_userRepository.TryGetUser(model.Id, out user))
                return NotFound();

            if (!User.Identity.Name.Equals(user.Username))
                return BadRequest();

            // Username, Email, Password don't get changed
            user.DisplayName = model.DisplayName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Description = model.Description;
            user.Github = model.Github;
            user.EmailIsPrivate = model.EmailIsPrivate;

            _userRepository.SaveChanges();
            return user;
        }

        private string GetToken(IdentityUser user)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                null, null, claims,
                // 45 min token timeout
                expires: DateTime.Now.AddMinutes(45),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}