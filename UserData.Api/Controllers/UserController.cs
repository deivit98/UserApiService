using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserData.Service.Models;
using UserData.Service.Services;

namespace UserData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers(string input)
        {
            var result = await _userService.GetUsers(input);

            return Ok(result);
        }
    }
}
