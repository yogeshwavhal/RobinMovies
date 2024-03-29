namespace Robin.Movies.Api.Entities
{
    /// <summary>
    /// Movies Cast
    /// </summary>
    public class Cast
    {
        /// <summary>
        /// Names of the movie actors
        /// </summary>
        public required IEnumerable<string> Actors {  get; set; }

        /// <summary>
        /// Name of the movie director
        /// </summary>
        public required IEnumerable<string> Director {  get; set; }

        /// <summary>
        /// Names of the movie producers
        /// </summary>
        public required IEnumerable<string> Producers { get; set; }
 
    }
}