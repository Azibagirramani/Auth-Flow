using NgGold.Dto;
using NgGold.Models;

namespace NgGold.Interface;


public interface IUser
{
    List<Users> All();
    Task<Users?> FindOneByEmail(UserDto users);

    Task<bool> Save(Users users);
}