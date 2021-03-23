

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Dtos.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Controllers
{
    
    public class AccountController : AbstractAPIController
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signManager;
        private readonly IUserRepo _userRepo;
        private readonly ApplicationSettings _appSettings;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager,
            IUserRepo userRepo, IOptions<ApplicationSettings> appSettings, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _userRepo = userRepo;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<userManagerResponse>> Login(LoginDto LoginModel)
        {
            var user = await _userManager.FindByEmailAsync(LoginModel.email);
            if (user == null)
                return NotFound();
            var pass = await _userManager.CheckPasswordAsync(user, LoginModel.password);
            if (!pass)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                }),
                Expires = System.DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);
            return new userManagerResponse
            {
                jwtToken = encryptedToken
            };
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto RegisterModel)
        {
           var UserNameExist=await FindUserByName(RegisterModel.username);
           var UserEmailExist = await FindUserByEmail(RegisterModel.email);

            if(UserNameExist )
            {
                return BadRequest(new { message = "this username already exist !!" });
            }

            if ( UserEmailExist)
            {
                return BadRequest(new { message = "this email already exist !!" });
            }

            var role = await _roleManager.RoleExistsAsync("User");
            if(!role)
            {
               await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            var user = new AppUser
            {
                UserName = RegisterModel.username,
                Email = RegisterModel.email,
                Address = RegisterModel.Address,
                PhoneNumber = RegisterModel.mobile
            };

            var rez = await _userManager.CreateAsync(user, RegisterModel.password);
            if (rez.Succeeded)
            {
                await _signManager.PasswordSignInAsync(user, RegisterModel.password, false, false);
                await _userManager.AddToRoleAsync(user,"User");
                return Ok();
            }

            return BadRequest(rez.Errors);
        }

        private async Task<bool> FindUserByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if(user==null)
            {
                return false ;
            }
            return true;
        }
        private async Task<bool> FindUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            return true;
        }

    }
}
