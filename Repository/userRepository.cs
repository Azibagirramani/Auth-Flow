using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NgGold.Data;
using NgGold.Dto;
using NgGold.Interface;
using NgGold.Models;
using System.Text;



namespace NgGold.Repository
{


    public class UserRepository : IUser
    {
        private readonly DBContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(DBContext context, IConfiguration configuration)

        {
            _context = context;
            _configuration = configuration;
        }

        public List<Users> All()
        {
            return _context.User.ToList();
        }

        public async Task<Users?> FindById(Guid userId)
        {
            try
            {
                var user = await _context.User.FindAsync(userId);
                if (user == null)
                {
                    throw new("User not found");
                }
                return user;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        public async Task<Users?> FindOneByEmail(string email)
        {


            try
            {
                var isExist = await _context.User.SingleOrDefaultAsync(e => e.Email == email);
                return isExist;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                throw;
            }

        }

        public async Task<bool> Save(Users users)
        {
            try
            {
                await _context.AddAsync(users);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public string BearerToken(Users users)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(_configuration["JwtOptions:SigningKey"]);
                var securityKey = new SymmetricSecurityKey(bytes);
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, users.Email),
                new Claim(JwtRegisteredClaimNames.NameId, Convert.ToString(users.Id)),
                new Claim("role", Convert.ToString(2)),
                new Claim("Date", DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["JwtOptions:Issuer"],
                    audience: _configuration["JwtOptions:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtOptions:ExpirationSeconds"])),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}


