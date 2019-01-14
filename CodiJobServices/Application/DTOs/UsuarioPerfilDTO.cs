using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class UsuarioperfilDTO
    {
        public Guid UsuperId { get; set; }
        public string UsuperDesc { get; set; }
        public string UsuperGit { get; set; }
        public string UsuperBlog { get; set; }
        public string UsuperWeb { get; set; }
        public string Token { get; set; }
    }
}
