using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberSystem.DTOs.User;
using UberSystem.Repo.Interface;

namespace UberSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IunitOfWork _repo;
        private readonly IMapper _map;
        public UserController(IunitOfWork iunitOfWork, IMapper mapper)
        {
            _repo = iunitOfWork;
            _map = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var x =await _repo.user.GetAll();
            var list = _map.Map<List<UserDTO>>(x);
            return Ok(list);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string name)
        {
            var x = await _repo.user.SearchByName(name);
            if (x == null)
            {
                return BadRequest("Name Not Found");
            }
            var list = _map.Map<UserDTO>(x);
            return Ok(list);
        }



    }
}
