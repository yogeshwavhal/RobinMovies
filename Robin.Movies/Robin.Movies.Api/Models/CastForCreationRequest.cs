
namespace Robin.Movies.Api.Models
{
    /// <summary>
    /// Request model for movie cast creation
    /// </summary>
    public class CastForCreationRequest
    {
        /// <summary>
        /// Collection of movie actors
        /// </summary>
        public required IEnumerable<string> Actors { get; set; }

        /// <summary>
        /// Name of movie director
        /// </summary>
        public required IEnumerable<string> Director { get; set; }

        /// <summary>
        /// Collection of movie producers
        /// </summary>
        public required IEnumerable<string> Producers { get; set; }
    }
}
