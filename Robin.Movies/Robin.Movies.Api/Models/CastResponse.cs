namespace Robin.Movies.Api.Models
{
    public class CastResponse
    {
        public required IEnumerable<string> Actors { get; set; }

        public required IEnumerable<string> Director { get; set; }

        public required IEnumerable<string> Producers { get; set; }
    }
}
