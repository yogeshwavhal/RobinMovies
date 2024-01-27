
namespace Robin.Movies.Api.Models
{
    /// <summary>
    /// Request model for movie creation
    /// </summary>
    public class MovieForCreationRequest
    {
        /// <summary>
        /// Title of the movie
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Movie description
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Rating given to movie by Imbd
        /// </summary>
        public double ImbdRating { get; set; }

        /// <summary>
        /// Entire cast of the movie
        /// </summary>
        public required CastForCreationRequest Cast { get; set; }
    }
}
