using FluentValidation;
using LibroHub.Domain.Entities;
using LibroHub.Domain.Interfaces;

namespace LibroHub.Application.LibroHub.Commands.CreateLibroHub
{
    public class CreateLibroHubCommandValidator : AbstractValidator<CreateLibroHubCommand>
    {
        public CreateLibroHubCommandValidator(ILibroHubRepository repository)
        {

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter Title")
                .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
                .MaximumLength(30).WithMessage("Name should have maxium of 30 characters")
                .Custom((value, context) =>
                {
                    var existingLibroHub = repository.GetByName(value).Result;
                    if (existingLibroHub != null)
                    {
                        context.AddFailure($"A book with title: {value} has already been added");
                    }
                });

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
                .NotEmpty().WithMessage("Please enter Rating")
                .InclusiveBetween(1, 10).WithMessage("Ratings only from 1 to 10. ");
        }
    }
}