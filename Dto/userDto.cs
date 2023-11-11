using System.ComponentModel.DataAnnotations;

namespace NgGold.Dto;


public class UserDto
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public int Role { get; set; }
}


public class LoginDto
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}