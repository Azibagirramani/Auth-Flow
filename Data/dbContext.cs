using Microsoft.EntityFrameworkCore;
using NgGold.Models;

namespace NgGold.Data;
public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {

    }
    public DbSet<Users> User { get; set; }
    public DbSet<Business> Businesses { get; set; }


}