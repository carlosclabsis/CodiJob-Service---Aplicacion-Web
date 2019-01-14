using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class UsuarioperfilDTOValidator : AbstractValidator<UsuarioperfilDTO>
    {
        public UsuarioperfilDTOValidator()
        {
            RuleFor(x => x.UsuperBlog).NotEmpty();
            RuleFor(x => x.UsuperBlog).Length(10, 200);
            RuleFor(x => x.UsuperDesc).NotEmpty();
            RuleFor(x => x.UsuperDesc).Length(10,200);
            RuleFor(x => x.UsuperGit).NotEmpty();
            RuleFor(x => x.UsuperGit).Length(10, 200);
            RuleFor(x => x.UsuperWeb).NotEmpty();
            RuleFor(x => x.UsuperWeb).Length(10, 200);
        }
    }
}
