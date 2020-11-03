using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebConsola.Models;

namespace WebConsola.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpPost]
        //[Route("[action]")]
        //public IActionResult Login(LoginViewModel model)
        //{
        //    // Codigo para validar la contraseña


        //    // Asumimos que es valido

        //    var user = new User
        //    {
        //        Name = "Eduardo",
        //        Email = "admin@kodoti.com",
        //        UserId = Guid.NewGuid(), //"a79b2e64-a4de-4f3a-8cf6-a68ba400db24"
        //    };
        //    // Creamos los claims (pertenencias, características) del usuario
        //    var claims = new[]
        //    {
        //            new Claim(ClaimTypes.Name, user.Name),
        //            new Claim(ClaimTypes.Email, user.Email)
        //    };
        //    // leemos el secret_key desde  uestro appseting

        //    var secretKey = _configuration.GetValue<string>("SecretKey");
        //    var key = Encoding.ASCII.GetBytes(secretKey);

        //    // creamos los claims (pertenencias, caracteristicas) del usuario

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {

        //        Subject = new ClaimsIdentity(),
        //        // Nuestro token va a durar un dia
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        // Credenciales para generar el token usando nuestro secretKey
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

        //    //return tokenHandler.WriteToken(createdToken);
        //    return null;
        //}



        [HttpPost("/token")]
        public IActionResult Get(string username, string password)
        {
            if (username == password)
                return Ok(GenerateToken(username));
            else
                return Unauthorized();
        }
        private string GenerateToken(string username)
        {
            var header = new JwtHeader(
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("your-secret-key-here")
                    ),
                    SecurityAlgorithms.HmacSha256)
            );

            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.UniqueName, username),
            };
            var payload = new JwtPayload(claims);

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
