using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberSystem.DTOs.vehicles;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vehiclesController : ControllerBase
    {
        private readonly IunitOfWork _repo;
        private readonly IMapper _map;
        public vehiclesController(IunitOfWork iunitOfWork, IMapper mapper)
        {
            _repo = iunitOfWork;
            _map = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdatevehiclesDTo dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var x = _map.Map<Vehicle>(dto);
            await _repo.vehicle.CreateAsync(x);
           await _repo.SavechangeAsync();
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateUpdatevehiclesDTo dTo,int id)
        {
            var x = await _repo.vehicle.GetByid(id);
            if (x == null)
            {
                return NotFound();
            }

            x.PlateNumber = dTo.PlateNumber;
            x.color = dTo.color;
            x.DriverId = dTo.DriverId;
            _repo.vehicle.Update(x);
            await _repo.SavechangeAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(  int id)
        {
            var x = await _repo.vehicle.GetByid(id);
            if (x == null)
            {
                return NotFound();
            }

            _repo.vehicle.Delete(id);
            await _repo.SavechangeAsync();
            return Ok();
        }

    }
}
