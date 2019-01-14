using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class GrupoDTOValidator : AbstractValidator<GrupoDTO>
    {
        public GrupoDTOValidator()
        {
            RuleFor(x => x.GrupoNom).NotEmpty();
            RuleFor(x => x.GrupoNom).Length(10, 200);
            RuleFor(x => x.GrupoProm).NotEmpty();
            RuleFor(x => x.GrupoProm).Length(10, 100);
            RuleFor(x => x.GrupoFoto).NotEmpty();
        }
    }
}
