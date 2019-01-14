using Application.DTOs.CustomDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).Length(4, 10);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(4, 10);
            
        }
    }
}
