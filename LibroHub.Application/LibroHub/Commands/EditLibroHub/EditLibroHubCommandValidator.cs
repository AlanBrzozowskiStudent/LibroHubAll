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
                .MaximumLength(50).WithMessage("Description should have maxium of 50 characters");

            RuleFor(c => c.Author)
                .NotEmpty().WithMessage("Please enter Author")
                .MinimumLength(1).WithMessage("Author should have atleast 1 characters")
                .MaximumLength(30).WithMessage("Author should have maxium of 30 characters");

            RuleFor(c => c.BookCategory)
                .MaximumLength(30).WithMessage("BookCategory should have maxium of 30 characters");

            RuleFor(c => c.About)
                .MaximumLength(300).WithMessage("Opinion should have maxium of 300 characters");

            RuleFor(c => c.PageNumber)
                .InclusiveBetween(1, 10000).WithMessage("Range from 1 to 10,000");

            RuleFor(c => c.Rating)
                .InclusiveBetween(1, 10).WithMessage("Ratings only from 1 to 10. ");
        }
    }
}
