using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.DTO;
using Project.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        // Register method
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new()
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                IdentityResult result = await userManager.CreateAsync(appUser, registerDTO.Password);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Compte créé avec succès" });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Erreur", error.Description);
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        // Login method
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginDTO.username);
                if (user != null && await userManager.CheckPasswordAsync(user, loginDTO.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: configuration["JWT:Issuer"],
                        audience: configuration["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: creds
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new
                    {
                        token = tokenString,
                        expiration = token.ValidTo,
                        username = user.UserName
                    });
                }

                return Unauthorized(new { message = "Nom d'utilisateur ou mot de passe incorrect." });
            }
            return BadRequest(ModelState);
        }

        // Get current user method
        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { message = "Utilisateur non authentifié" });
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "Utilisateur non trouvé" });
            }

            var userDTO = new
            {
                user.UserName,
                user.Email,
                user.Id
            };

            return Ok(userDTO);
        }
    }
}
