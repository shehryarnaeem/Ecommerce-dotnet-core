using System;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Ecommerce.services.interfaces;
using BC = BCrypt.Net.BCrypt;
using System.Text;

namespace Ecommerce.controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpPost("")]
        [Route("signup")]
        public ActionResult<User> signUp(User user)
        {
            user.Password = BC.HashPassword(user.Password);
            this._userService.Create(user);
            return Ok();
        }


        [HttpPost("")]
        [Route("login")]
        public ActionResult<User> authenticate(User loginDto)
        {
            if (loginDto.Email != null && loginDto.Password != null)
            {
                User user = this._userService.GetUserByEmail(loginDto.Email);
                if (user != null && BC.Verify(loginDto.Password, user.Password
                ))
                {
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, "EcommerceAccessToken"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfsdfsjdbf78sdyfssdfsdfbuidfs98gdfsdbf"));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken("BikeStoreAuthenticationServer", "BikeStoreServicePostmanClient", claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}