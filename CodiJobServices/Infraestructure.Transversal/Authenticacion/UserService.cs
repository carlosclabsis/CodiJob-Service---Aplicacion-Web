using Application.DTOs;
using Application.IServices;
using Microsoft.IdentityModel.Tokens;

using Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Infraestructure.Transversal.Authenticacion
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private IUsuarioperfilService ServiceUsuarioPerfil;
        private readonly AppSettings _appSettings;
        public UserService(UserManager<IdentityUser> userMgr,
                            SignInManager<IdentityUser> signInMgr,
                            IUsuarioperfilService serviceUsuarioPerfil,
                            IOptions<AppSettings> appSettings)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            ServiceUsuarioPerfil = serviceUsuarioPerfil;
            _appSettings = appSettings.Value;
        }
        public async Task<UsuarioperfilDTO> AuthenticateAsync(string username, string password)
        {
            IdentityUser Iuser = await userManager.FindByNameAsync(username);
            if (Iuser != null)
            {
                await signInManager.SignOutAsync();
                if ((await signInManager.PasswordSignInAsync(Iuser, password, false, false)).Succeeded)
                {
                    var UserDTO = ServiceUsuarioPerfil.GetUsuarioPerfil(Guid.Parse(Iuser.Id));
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] 
                        {
                            new Claim(ClaimTypes.Name, UserDTO.UsuperId.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    UserDTO.Token = tokenHandler.WriteToken(token);

                    return UserDTO;
                }
            }
            return null;
        }
    }
    public class AppSettings
    {
        public string Secret { get; set; }
    }
}
