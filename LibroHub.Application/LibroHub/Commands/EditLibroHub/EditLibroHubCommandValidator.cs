using FluentValidation;
using LibroHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroHub.Application.LibroHub.Commands.EditLibroHub
{
    public class EditLibroHubCommandValidator : AbstractValidator<EditLibroHubCommand>
    {
        public EditLibroHubCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");
        }
    }
}
