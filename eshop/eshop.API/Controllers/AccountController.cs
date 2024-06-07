﻿using eshop.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user!=null)
                {
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-kritik-bir-cumledir-ona-gore"));
                    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new Claim[]
                    {
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, user.FullName),
                        new Claim(ClaimTypes.Role, user.Role),
                    };

                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer:"api.softtech",
                        audience: "client.softtech",
                        claims:claims,
                        notBefore:DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signingCredentials


                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

                }
                
            }
            return BadRequest();

        }
    }
}
