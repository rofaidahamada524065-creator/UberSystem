using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberSystem.DTOs.Ride;
using UberSystem.DTOs.User;
using UberSystem.DTOs.vehicles;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IunitOfWork _repo;
        private readonly IMapper _map;
        public RideController(IunitOfWork iunitOfWork, IMapper mapper)
        {
            _repo = iunitOfWork;
            _map = mapper;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string Pickup)
        {
            var x = await _repo.ride.SearchPickup(Pickup);
            if (x == null)
            {
                return BadRequest("Pickup Not Found");
            }
            var list = _map.Map<RideDTO>(x);
            return Ok(list);
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter(string? Statuse, int? MinFare, int? MaxFare, string? SortBy)
        {
            var x = await _repo.ride.Fillter(Statuse, MinFare, MaxFare, SortBy);
            var list = _map.Map<List<RideDTO>>(x);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpadateRide dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var x = _map.Map<Ride>(dto);
            await _repo.ride.CreateAsync(x);
            await _repo.SavechangeAsync();
            return Ok();

        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> Search(int  psagNum,int pagesize)
        {
            var x = await _repo.ride.Pagination(psagNum, pagesize);
            if (pagesize <= 0 || pagesize <= 0)
            {
                return BadRequest("pagesize and Pagenumber Must be Greater than Zeroo");
            }
           
            var list = _map.Map<List<RideDTO>>(x);
            return Ok(list);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _repo.ride.GetByid(id);
            if (x == null)
            {
                return NotFound();
            }

            _repo.ride.Delete(id);
            await _repo.SavechangeAsync();
            return Ok();
        }

        [HttpGet("{id}")]
      
        public async Task<IActionResult> GetByID(int id)
        {
            var x = await _repo.ride.GetByid(id);
            if (x == null)
            {
                return NotFound();
            }

            var list = _map.Map<RideDTO>(x);
            return Ok(list);
            
           
        }

        [HttpPatch("{id}/Accept")]
        public async Task <IActionResult> Accept(int id)
        {
            var x = await _repo.ride.GetByid(id);
            if (x == null)
            {
                return NotFound();
            }
            x.status = "Accept";
            await _repo.SavechangeAsync();
            return Ok(x.status);
        }

       [HttpPatch("{id}/Completed")]
        public async Task<IActionResult> Completed(int id)
        {
            var x = await _repo.ride.GetByid(id);
            if (x == null)
            {
                return NotFound();
            }
            x.status = "Completed";
            await _repo.SavechangeAsync();
            return Ok(x.status);
        }

        [HttpGet("Repore")]
        public async Task<IActionResult> Report()
        {
            var x =await _repo.ride.Report();
            return Ok(x);
            
        }
    }
}
