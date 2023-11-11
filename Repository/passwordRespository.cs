using NgGold.Interface;

namespace NgGold.Repository
{


    public class PasswordHash : IPasswordHash
    {



        public bool compareHash(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }

        public string generateHash(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }
    }

}