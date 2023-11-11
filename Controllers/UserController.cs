using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using NgGold.Models;
using NgGold.Dto;
using NgGold.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace NgGold.Controllers;

public class AuthCredentials
{
    public string? Access_token { get; set; }
    public Users? User { get; set; }
}
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUser _userRepository;
    private readonly IPasswordHash _passwordHash;

    public UserController(IUser userRepository, IPasswordHash passwordHash)
    {
        _userRepository = userRepository;
        _passwordHash = passwordHash;
    }
    [HttpGet("/current")]
    [Authorize(Roles = "2")]
    public IActionResult GetAllUsers()
    {


        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var user_id = identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        Console.WriteLine(_userRepository.FindById(Guid.Parse(user_id)));
        return Ok();
    }

    [HttpPost("/register")]
    public async Task<IActionResult> createUser([FromBody] UserDto users)
    {
        var exist = await _userRepository.FindOneByEmail(users.Email);
        if (exist != null)
        {
            return BadRequest("User with this email already exists.");
        }

        var passwordHash = _passwordHash.generateHash(users.Password);


        bool saved = await _userRepository.Save(new Users()
        {
            Role = users.Role,
            Email = users.Email,
            IsVerified = false,
            Password = passwordHash,
        });
        if (!saved) return BadRequest();


        return Ok();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> login([FromBody] LoginDto login)
    {

        if (!ModelState.IsValid) return BadRequest(ModelState);
        var current_user = await _userRepository.FindOneByEmail(login.Email);
        if (current_user == null) return Unauthorized();
        bool isPassword = _passwordHash.compareHash(login.Password, current_user.Password);
        if (!isPassword) return Unauthorized("Wrong password");
        string jwt = _userRepository.BearerToken(current_user);
        AuthCredentials cr = new AuthCredentials
        {
            Access_token = jwt,
            User = current_user
        };



        return Ok(cr);
    }
}