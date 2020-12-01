using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FabLabSandboxAPI.Authorization.AuthenticationDB;
using FabLabSandboxAPI.Authorization.AuthServises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FabLabSandboxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public SuperAdminController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "User already exist"
                });
            }

            IdentityUser user = new IdentityUser();
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
            }
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "User creation faild"
                });
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
            if (await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
            {
                await userManager.AddToRolesAsync(user, new[] {UserRoles.SuperAdmin });
            }

            return Ok(new Response
            {
                Status = "Success",
                Message = "User created successfully"
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userrole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userrole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }

            return Unauthorized();
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<IdentityUser>> GetAllUsers()
        {
            var tada = userManager.Users.ToList();
          //  var ShowUsers = _context.Users.ToList();
          return tada; //ShowUsers;
        }

        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPut("{email}")]
        public async Task<IActionResult> UserToAdmin( string email)
        {
            var User = await userManager.FindByNameAsync(email);
            //var User = _context..FirstOrDefault(p => p.Email == email);

            if (User != null)
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRolesAsync(User, new[] {UserRoles.Admin});
                }

                return Ok(new Response
                {
                    Status = "Success",
                    Message = "User role changed successfully"
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Status = "Error",
                Message = "User role not changed"
            });

        }
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var User = await userManager.FindByEmailAsync(email);
            if (User != null)
            {
                await userManager.DeleteAsync(User);
                return Ok(new Response
                {
                    Status = "Success",
                    Message = "User  removed successfully"
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Status = "Error",
                Message = "User not removed"
            });
        }
    }
}