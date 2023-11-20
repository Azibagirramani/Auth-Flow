using Microsoft.AspNetCore.Mvc;
using NgGold.Interface;


namespace NgGold.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController
    {


        private readonly IBusinessRepository _businessRepository;


        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }



        // [HttpGet(Name = "get-business-info")]
        // public async Task<IActionResult> BusinessInfo(Guid business_id)
        // {
        //     try
        //     {
        //         var b = await _businessRepository.Info(business_id);

        //         return Ok(b);
        //     }
        //     catch (Exception e)
        //     {
        //         throw;
        //     }
        // }


    }

}