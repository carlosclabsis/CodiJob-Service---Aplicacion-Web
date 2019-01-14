using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class ProyectoDTOValidator : AbstractValidator<ProyectoDTO>
    {
        public ProyectoDTOValidator()
        {
            RuleFor(x => x.ProyNom).NotEmpty();
            RuleFor(x => x.ProyNom).Length(10, 200);
            RuleFor(x => x.ProyDesc).NotEmpty();
            RuleFor(x => x.ProyDesc).Length(10,100);
            RuleFor(x => x.ProyFecha).NotEmpty();
            RuleFor(x => x.ProyUrl).NotEmpty();
            RuleFor(x => x.ProyUrl).Length(10, 200);
        }
    }
}
