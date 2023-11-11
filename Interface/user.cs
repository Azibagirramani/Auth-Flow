using NgGold.Dto;
using NgGold.Models;

namespace NgGold.Interface;


public interface IUser
{
    List<Users> All();
    Task<Users?> FindOneByEmail(string email);

    Task<bool> Save(Users users);

    Task<Users?> FindById(Guid userId);

    string BearerToken(Users users);
}