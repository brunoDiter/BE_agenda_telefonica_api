using BE_AGENDA_API.Data.Repository;
using BE_AGENDA_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_AGENDA_API.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthenticationController(UserRepository userRepository ,IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<string> Auth(AuthenticationRequestBody authenticationRequestBody)
        {
            /* Verificamos credenciales */
            var user = _userRepository.Validate(authenticationRequestBody.UserName,
                authenticationRequestBody.Password);

            if (user is null)
            {
                return Forbid(); /* si nos devuelve nulo significa que el usuario no existe
                                  * o la pass está mal */
            }

            /* Generamos un token segun los Claims */
            var claims = new List<Claim>
            {
                new Claim("id",user.Id.ToString()),
                new Claim("username",user.UserName),
                new Claim("fullname",$"{user.Name}{user.LastName}"),
                new Claim("role",user.rol.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt_Audience"],
                claims : claims,
                expires : DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken
                (tokenDescriptor);

            return Ok(new
            {
                AccesToken = jwt
            });
        }
    }
}
