
namespace Robin.Movies.Api.Models
{
    public class MovieResponse
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public double ImbdRating { get; set; }

        public required CastResponse Cast { get; set; }
    }
}
