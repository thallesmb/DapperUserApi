using DapperUserApi.DTO;
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO)
        {
            var user = await _userInterface.CreateUser(createUserDTO);

            if (user.Status == false)
                return BadRequest(user);

            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            var user = await _userInterface.RemoveUser(userId);

            if (user.Status == false)
                return BadRequest(user);

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> AlterUser(AlterUserDTO alterUserDTO)
        {
            var user = await _userInterface.AlterUser(alterUserDTO);

            if (user.Status == false)
                return BadRequest(user);

            return Ok(user);
        }
    }
}