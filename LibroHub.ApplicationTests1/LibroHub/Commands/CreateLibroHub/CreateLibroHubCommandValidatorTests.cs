using Xunit;
using FluentValidation.TestHelper;
using Moq;
using LibroHub.Domain.Interfaces;
using LibroHub.Domain.Entities;

namespace LibroHub.Application.LibroHub.Commands.CreateLibroHub.Tests
{
    public class CreateLibroHubCommandValidatorTests
    {
        private readonly CreateLibroHubCommandValidator _validator;
        private readonly Mock<ILibroHubRepository> _mockRepository;

        public CreateLibroHubCommandValidatorTests()
        {
            _mockRepository = new Mock<ILibroHubRepository>();
            _validator = new CreateLibroHubCommandValidator(_mockRepository.Object);
        }

        [Fact]
        public void ShouldHaveErrorWhenNameIsEmpty()
        {
            var model = new CreateLibroHubCommand { Name = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Name);
        }

        [Fact]
        public void ShouldHaveErrorWhenAuthorIsEmpty()
        {
            var model = new CreateLibroHubCommand { Author = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Author);
        }

        [Fact]
        public void ShouldHaveErrorWhenRatingIsZero()
        {
            var model = new CreateLibroHubCommand { Rating = 0 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Rating);
        }

        [Fact]
        public void ShouldHaveErrorWhenPageNumberIsZero()
        {
            var model = new CreateLibroHubCommand { PageNumber = 0 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.PageNumber);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenNameIsSpecified()
        {
            var model = new CreateLibroHubCommand { Name = "Test Book" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.Name);
        }

    }
}