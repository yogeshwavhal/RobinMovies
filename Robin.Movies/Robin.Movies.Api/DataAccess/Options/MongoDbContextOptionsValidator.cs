
using Microsoft.Extensions.Options;

namespace Robin.Movies.Api.DataAccess.Options
{
    /// <summary>
    /// Responsible for validating the MongoDbContextOptions
    /// </summary>
    public class MongoDbContextOptionsValidator : IValidateOptions<MongoDbContextOptions>
    {
        /// <summary>
        /// Validates the MongoDbContextOptions
        /// </summary>
        /// <param name="name">Name of the property which will be validated</param>
        /// <param name="options">Instance of MongoDbContextOptions to be validated</param>
        /// <returns>Returns the ValidationResult depending on success or failure</returns>
        public ValidateOptionsResult Validate(string? name, MongoDbContextOptions options)
        {
            if (options == null)
            {
                return ValidateOptionsResult.Fail("MongoDbContextOptions can not be null.");
            }
            else if (options.ConnectionUrl == null)
            {
                return ValidateOptionsResult.Fail("Connection Url can not be null.");
            }
            else if (options.DatabaseName == null)
            {
                return ValidateOptionsResult.Fail("Database name can not be null.");
            }
            else if(options.CollectionName == null)
            {
                return ValidateOptionsResult.Fail("Collection name can not be null.");
            }
            return ValidateOptionsResult.Success;
        }
    }
}
