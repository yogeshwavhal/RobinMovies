﻿namespace Robin.Movies.Api.Models
{
    /// <summary>
    /// Movie Cast response Model
    /// </summary>
    public class CastResponse
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
