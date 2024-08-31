using FcBarcelona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FcBarcelona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Inyecta IConfiguration en el constructor
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            // Verifica las credenciales
            if (user.User == "Admin2024" && user.Password == "P4sw0rd2024") // Credenciales válidas
            {
                // Generación del token
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken( // Configuración del token
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions); // Genera el token

                // Devuelve un mensaje de éxito junto con el token
                return Ok(new
                {
                    Message = "Inicio de sesión exitoso.",
                    Token = tokenString
                });
            }

            // Si las credenciales son incorrectas
            return Unauthorized("Credenciales incorrectas.");
        }
    }
}

