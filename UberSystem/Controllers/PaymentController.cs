using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberSystem.DTOs.payments;
using UberSystem.DTOs.Ride;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IunitOfWork _repo;
        private readonly IMapper _map;
        public PaymentController(IunitOfWork iunitOfWork, IMapper mapper)
        {
            _repo = iunitOfWork;
            _map = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(createupdateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Enter Data");
            }
            var x = _map.Map<Payment>(dto);
            await _repo.payment.CreateAsync(x);
            await _repo.SavechangeAsync();
            return Ok();

        }

        [HttpGet("statistics")]
        public async Task<IActionResult > statistics()
        {
            var x =await _repo.payment.Payment();
            return Ok(x);
        }

    }
}
