﻿
namespace Robin.Movies.Api.Models
{
    /// <summary>
    /// Movie Response 
    /// </summary>
    public class MovieResponse
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
        public required CastResponse Cast { get; set; }
    }
}
