using DapperUserApi.Models;
using DapperUserApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userInterface.GetUserList();

            if(users.Status == false)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userInterface.GetUserById(userId);

            if (user.Status == false)
                return NotFound();

            return Ok(user);
        }
    }
}