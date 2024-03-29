using FluentValidation;
using Robin.Movies.Api.Models;

namespace Robin.Movies.Api.Validators
{
    /// <summary>
    /// Validator for movie response models
    /// </summary>
    public class MovieValidator : AbstractValidator<MovieForCreationRequest>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public MovieValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage($"Title can not be empty.");
            RuleFor(x => x.Cast).NotNull().WithMessage("Cast can not be null");
        }
    }
}
