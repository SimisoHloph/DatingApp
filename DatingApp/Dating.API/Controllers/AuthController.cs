

using System.Threading.Tasks;
using Dating.API.Data;
using Dating.API.Dtos;
using Dating.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;


namespace Dating.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _repo;
         
         private readonly IConfiguration _config; 

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }

         [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if(await _repo.UserExists(userForRegisterDto.Username))
              return BadRequest("user name already Exists");

              var userToCreate = new User {
                 
                Username = userForRegisterDto.Username
              };

              var createdUser = await _repo.Register(userToCreate,userForRegisterDto.Password);

              return StatusCode(201);

        }

        [HttpPost("Login")]
         public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
           {
             
               //throw new Exception("cant get there");
             //  check if the user Exists
             var userFromRepo =  await _repo.Login(userForLoginDto.Username.ToLower(),userForLoginDto.Password);

              if(userFromRepo == null)
                     return Unauthorized();

                 var claims = new[]
                 {
                   new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                   new Claim(ClaimTypes.Name, userFromRepo.Username)
                 };

                 var key =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
                 
                 var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                 var tokenDescriptor =  new SecurityTokenDescriptor
                 {
                    Subject = new ClaimsIdentity(claims),
                    Expires  = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                 };

                 var tokenHandler = new JwtSecurityTokenHandler();  

                 var token = tokenHandler.CreateToken(tokenDescriptor);

                 return Ok(new {
                   token = tokenHandler.WriteToken(token)
                          
                 });    
                           

           }

    }
    
    
    
}