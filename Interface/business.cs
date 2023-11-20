

using NgGold.Models;

namespace NgGold.Interface
{

    public interface IBusinessRepository
    {

        Task<Business> Info(Guid user_id);

    }

}