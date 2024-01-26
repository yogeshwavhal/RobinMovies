namespace Robin.Movies.Api.Entities
{
    public class Cast
    {
        public required IEnumerable<string> Actors {  get; set; }

        public required IEnumerable<string> Director {  get; set; }

        public required IEnumerable<string> Producers { get; set; }
 
    }
}