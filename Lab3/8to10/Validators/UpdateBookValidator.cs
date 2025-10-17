using FluentValidation;
using _8to10.Features.Books;

namespace _8to10.Validators;

public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookValidator()
    {
        // Id must be provided
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        // Title validation
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        // Author validation
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author is required.")
            .MaximumLength(100).WithMessage("Author cannot exceed 100 characters.");

        // Year validation
        RuleFor(x => x.YearPublished)
            .InclusiveBetween(1500, DateTime.UtcNow.Year)
            .WithMessage($"Year published must be between 1500 and {DateTime.UtcNow.Year}.");
    }
}