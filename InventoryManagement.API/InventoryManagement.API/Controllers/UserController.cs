using InventoryManagement.API.DataAccess;
using InventoryManagement.API.Helper;
using InventoryManagement.API.Models;
using InventoryManagement.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly InventoryDBContext context;
        private readonly IConfiguration configuration;

        public UserController(InventoryDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if(context.Users.Any(x=>x.Email == userRegisterDto.Email))
            {
                return BadRequest("Email is already in use!");
            }
            var user = new Users
            {
                Name = userRegisterDto.Name,
                Email = userRegisterDto.Email,
                PasswordHash = PasswordHasher.HashPassword(userRegisterDto.Password),
                CompanyId = userRegisterDto.CompanyId
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Ok(new { Message = "User Registerd Successfully" });
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var user = context.Users.FirstOrDefault(x=>x.Email == userLoginDto.Email);

            if (user == null || user.PasswordHash!=PasswordHasher.HashPassword(userLoginDto.Password)) 
            {
                return Unauthorized("Invalid Email or Password.");
            }

            var jwtHelper = new JwtHelper(configuration);
            var token = jwtHelper.GenerateToken(user.Id.ToString(), user.Email, user.Role);

            return Ok(new 
            { 
                Token = token,
                Message = "Login Successful."
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if(user==null)
            {
                return NotFound();
            }

            var response = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };

            return Ok(response);
        }
    }
}
