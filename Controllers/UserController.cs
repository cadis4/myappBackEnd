using BusinessLogic.DTOS;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccesLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Null user, Please provide a valid user !");
            }

            if (string.Equals(user.Username, "string"))
            {
                return BadRequest("Invalid user name. Please provide a valid user name !");
            }

            if (await UserService.IsUsernameTaken(user.Username))
            {
                return Conflict("Username is already taken. Please choose a different username!");
            }

            try
            {
                await UserService.AddUser(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Null station type. Please provide a valid station type !");
            }

            try
            {
                await UserService.UpdateUser(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }



        [HttpPut]
        [Route("updateUserGrades")]
        public async Task<IActionResult> UpdateUserGradesAsync([FromBody] UserDtoGrades user)
        {
            if (user == null)
            {
                return BadRequest("Null user. Please provide a valid user !");
            }

            try
            {
                await UserService.UpdateUserGrades(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserByIdAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid station type id !");
            }

            try
            {
                await UserService.DeleteUserById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var users = await UserService.GetAllUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await UserService.GetUserById(id);

                if (user == null)
                {
                    return BadRequest("Not Found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getUserByName/{username}")]
        public async Task<IActionResult> GetUserByUsernameAsync(string username)
        {
            try
            {
                var user = await UserService.GetUserByUsername(username);

                if (user == null)
                {
                    return BadRequest("Not Found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] User user)
        {
            // Authenticate the user using the credentials
            var finduser = await UserService.Authenticate(user.Username, user.Password);

            if (finduser == null)
            {
                return Unauthorized("Invalid username or password");
                
            }

            // Generate a token for the authenticated user
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your_secret_key_here");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }

    }
}