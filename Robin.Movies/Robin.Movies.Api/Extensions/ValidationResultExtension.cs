using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Robin.Movies.Api.Extensions
{
    /// <summary>
    /// Extension for Fluent Validators ValidationResult
    /// </summary>
    public static class ValidationResultExtension
    {
        /// <summary>
        /// Adds the model error tp the model state
        /// </summary>
        /// <param name="result">Instance of ValidationResult</param>
        /// <param name="modelState">ModelStateDictionary</param>
        /// <returns></returns>
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
