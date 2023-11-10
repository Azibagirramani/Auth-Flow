namespace NgGold.Interface
{
    public interface IPasswordHash
    {

        string generateHash(string plainPassword);
        bool compareHash(string plainPassword, string hashedPassword);

    }
}


