using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ch.cena.swiper.backend.data.Models;
using ch.cena.swiper.backend.service.Contracts.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ch.cena.swiper.backend.api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IOptions<HostConfig> _hostConfig;

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<HostConfig> hostConfig
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostConfig = hostConfig;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return GenerateJwtToken(model.Email, appUser);
            }
            
            return new UnauthorizedResult();
        }

        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return GenerateJwtToken(model.Email, user);
            }

            return new UnauthorizedResult();
        }

        [HttpPost]
        public async Task<object> RegisterIos([FromBody] RegisterGuidDto model) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = model.iCloudKitId
            };

            var result = await _userManager.CreateAsync(user, model.iCloudKitId);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return GenerateJwtToken(model.iCloudKitId, user);
            }

            return new UnauthorizedResult();
        }

        private object GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_hostConfig.Value.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_hostConfig.Value.JwtExpireDays);

            var token = new JwtSecurityToken(
                _hostConfig.Value.JwtIssuer,
                _hostConfig.Value.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    public class RegisterGuidDto {
            [RegularExpression(@"^_[0-9a-f]{32}$")]
        public string iCloudKitId { get; set; }
    }
        public class LoginDto
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

        }

        public class RegisterDto
        {
            [Required]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
            public string Password { get; set; }
        }
    }
}