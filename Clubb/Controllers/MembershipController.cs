using Clubb.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clubb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        public MembershipController(IUnitOfWork unitOfWork)
        {
            _repo = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> getall()
        {
            var x =await _repo.membership.getall();
            return Ok(x);
        }


        [HttpGet("statistics")]
        public async Task<IActionResult> statistics()
        {
            var x = await _repo.membership.statistics();
            return Ok(x);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id)
        {
            var x =await _repo.membership.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            if (x.Type == "Gold")
            {
                x.EndDate = x.EndDate.AddYears(3);
            }
            if (x.Type== "Silver")
            {
                x.EndDate =x.EndDate.AddMonths(3);
            }
            if (x.Type == "Basic")
            {
                x.EndDate = x.EndDate.AddMonths(1);
            }
           await _repo.SaveChangeAsync();
            return Ok(x);

        }
    }
}
