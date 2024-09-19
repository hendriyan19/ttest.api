namespace test.api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using test.api.Models;
    using test.api.ViewModel;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> RequestToken([FromBody] LoginVM loginDto)
        {
            var user = await _userRepository.GetUserByUsernameAndPassword(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new { Token = "Generated JWT Token" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
                Email = registerDto.Email
            };

            await _userRepository.AddUser(user);
            return Ok("User registered successfully");
        }
    }

}
