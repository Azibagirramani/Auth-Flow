using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

using NgGold.Models;
using NgGold.Data;
using NgGold.Dto;
using NgGold.Interface;
using NgGold.Repository;

namespace NgGold.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUser _userRepository;
    private readonly IPasswordHash _passwordHash;


    public UserController(DBContext context, IUser userRepository, IPasswordHash passwordHash)
    {
        _userRepository = userRepository;
        _passwordHash = passwordHash;
    }
    [Authorize]
    [HttpGet("/users")]
    public IActionResult GetAllUsers()
    {
        return Ok(_userRepository.All());
    }

    [HttpPost("/register")]
    public async Task<IActionResult> createUser([FromBody] UserDto users)
    {
        // check if user email already exist
        var exist = await _userRepository.FindOneByEmail(users);
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
    public async Task<IActionResult> login([FromBody] UserDto login)
    {

        Users exist = await _userRepository.FindOneByEmail(login);
        if (exist == null) return Unauthorized();
        bool passwordHash = _passwordHash.compareHash(login.Password, exist.Password);
        if (passwordHash) return Unauthorized("Wrong password");



        return Ok();
    }
}