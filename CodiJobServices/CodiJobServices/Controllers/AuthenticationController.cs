using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.CustomDTO;
using Infraestructure.Transversal.Authenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodiJobServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : Controller
    {
        IUserService UserService;
        public AuthenticationController(IUserService userService)
        {
            this.UserService = userService;
        }
        [HttpPost("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody]LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var user = await UserService.AuthenticateAsync(login.UserName, login.Password);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                return Ok(user);
            }
            else
            {
                return BadRequest(new { message = "Model(LoginDTO) is not Valid" });
            }
        }
    }
}