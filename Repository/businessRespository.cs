using Microsoft.EntityFrameworkCore;
using NgGold.Data;
using NgGold.Interface;
using NgGold.Models;

namespace NgGold.Repository
{

    public class BusinessRepository : IBusinessRepository
    {

        private DBContext _context { get; set; }

        public BusinessRepository(DBContext context)
        {

            _context = context;
        }

        public async Task<Business> Info(Guid id)
        {

            try
            {
                var _b = await _context.Businesses.SingleOrDefaultAsync(e => e.Id == id) ?? throw new("User not found");
                return _b;
            }
            catch (Exception e)
            {

                throw new(e.Message);
            }

        }
    }

}