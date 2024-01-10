using FluentValidation.TestHelper;
using LibroHub.Application.LibroHub.Commands.EditLibroHub;
using Xunit;

public class EditLibroHubCommandValidatorTests
{
    private EditLibroHubCommandValidator validator;

    public EditLibroHubCommandValidatorTests()
    {
        validator = new EditLibroHubCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Description_Is_Too_Long()
    {
        var model = new EditLibroHubCommand { Description = new string('A', 51) };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Fact]
    public void Should_Have_Error_When_Author_Is_Empty()
    {
        var model = new EditLibroHubCommand { Author = string.Empty };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Author);
    }

    [Fact]
    public void Should_Have_Error_When_Author_Is_Too_Long()
    {
        var model = new EditLibroHubCommand { Author = new string('A', 31) };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Author);
    }

    [Fact]
    public void Should_Have_Error_When_BookCategory_Is_Too_Long()
    {
        var model = new EditLibroHubCommand { BookCategory = new string('A', 31) };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.BookCategory);
    }

    [Fact]
    public void Should_Have_Error_When_About_Is_Too_Long()
    {
        var model = new EditLibroHubCommand { About = new string('A', 301) };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.About);
    }

    [Fact]
    public void Should_Have_Error_When_PageNumber_Is_Out_Of_Range()
    {
        var model = new EditLibroHubCommand { PageNumber = 0 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.PageNumber);

        model = new EditLibroHubCommand { PageNumber = 10001 };
        result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.PageNumber);
    }

    [Fact]
    public void Should_Have_Error_When_Rating_Is_Out_Of_Range()
    {
        var model = new EditLibroHubCommand { Rating = 0 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Rating);

        model = new EditLibroHubCommand { Rating = 11 };
        result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Rating);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Command_Is_Valid()
    {
        var command = new EditLibroHubCommand
        {
            Description = new string('A', 50),
            Author = new string('A', 30),
            BookCategory = new string('A', 30),
            About = new string('A', 300),
            PageNumber = 5000,
            Rating = 5
        };

        var result = validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }
}