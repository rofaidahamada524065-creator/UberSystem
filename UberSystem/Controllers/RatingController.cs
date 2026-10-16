using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberSystem.DTOs.payments;
using UberSystem.DTOs.Rating;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IunitOfWork _repo;
        private readonly IMapper _map;
        public RatingController(IunitOfWork iunitOfWork, IMapper mapper)
        {
            _repo = iunitOfWork;
            _map = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateRating dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var x = _map.Map<Rating>(dto);
            await _repo.rating.CreateAsync(x);
            await _repo.SavechangeAsync();
            return Ok();

        }

        [HttpGet("TopDrivers")]
        public async Task<IActionResult> TopDrivers()
        {
            var x = await _repo.rating.TopDrivers();
            var list = x.Select(a=>new
            {
                a.ride.Driver.DriverId,
                a.Score,
                a.Comment,
            });
            return Ok(list);
        }
    }
}
