using FluentValidation;
using LibroHub.Domain.Interfaces;

namespace LibroHub.Application.LibroHub.Commands.CreateLibroHub
{
    public class CreateLibroHubCommandValidator : AbstractValidator<CreateLibroHubCommand>
    {
        public CreateLibroHubCommandValidator(ILibroHubRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
                .MaximumLength(20).WithMessage("Name should have maxium of 20 characters")
                .Custom((value, context) =>
                {
                    var existingLibroHub = repository.GetByName(value).Result;
                    if (existingLibroHub != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");
        }
    }
}
