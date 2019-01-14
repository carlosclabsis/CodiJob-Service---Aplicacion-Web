using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authenticacion
{
    public interface IUserService
    {
        Task<UsuarioperfilDTO> AuthenticateAsync(string username, string password);
    }
}
