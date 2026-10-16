using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UberSystem.DTOs.User;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly  IunitOfWork _repo;
       private readonly  IConfiguration _con;
        public AuthController(IunitOfWork iunitOfWork,IConfiguration configuration)
        {
            _repo = iunitOfWork;
            _con = configuration;
        }

        [HttpPost("rigestration")]
        public async Task<IActionResult> Register(RegusterDTO dto)
        {
            var x =await _repo.user.GetEmail(dto.Email);
            if (x !=null)
            {
                return BadRequest("This Email Alredy Exist");
            }
            if (dto.Role != "Driver" && dto.Role == "Rider")
            {
                return BadRequest("Role Mast Be Driver Or Rider");
            }

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                phone = dto.phone,
                Role = dto.Role,
                FullName = dto.FullName
            };

            await _repo.user.CreateAsync(user);
            await _repo.SavechangeAsync();
            return Ok();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var x = await _repo.user.GetEmail(dto.Email);
            if (x.Email!=dto.Email||x.Password!=dto.Password)
            {
                return BadRequest("Incvalid Email Or Password");
            }

            var token = GenarateToken(x);
            return Ok(new { token });

        }

       

        private string GenarateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_con["jwt:key"]));
            var crad = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claim = new List<Claim>
            {
            new Claim (ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.Email,user.Email)

            };

            var token = new JwtSecurityToken
                (
                issuer: _con["jwt:issuer"],
                audience: _con["jwt:audience"],
                signingCredentials: crad,
                claims: claim,
                expires: DateTime.Now.AddHours(1)


                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
