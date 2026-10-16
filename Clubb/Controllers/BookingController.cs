using Clubb.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Clubb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _repo = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> getall()
        {
            var x = await _repo.membership.Getall();
            var list = x.Select(a => new
            {
                Id=a.Id,
                facilityName=a.Facility.Name,
                Status=a.Status,
                GroupSize=a.GroupSize,
                EndTime=a.EndTime,
                StartTime=a.StartTime,
                BookingDate=a.BookingDate,
                MemberName=a.Member.FullName,
              

            });
            return Ok(list);
        }
    }
}
