using Microsoft.EntityFrameworkCore;
using NgGold.Data;
using NgGold.Dto;
using NgGold.Interface;
using NgGold.Models;

namespace NgGold.Repository
{
    public class UserRepository : IUser
    {
        private readonly DBContext _context;
        public UserRepository(DBContext context)

        {
            _context = context;
        }

        public List<Users> All()
        {
            return _context.User.ToList();
        }

        public async Task<Users?> FindOneByEmail(UserDto user)
        {
            var isExist = await _context.User.SingleOrDefaultAsync(e => e.Email == user.Email);
            return isExist;
        }

        public async Task<bool> Save(Users users)
        {
            try
            {
                await _context.AddAsync(users);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}


