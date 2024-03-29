using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Robin.Movies.Api.Entities
{
    /// <summary>
    /// Movie Entity Model
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Movie Id which will be used to uniquely identify the movie
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        /// <summary>
        /// Title of the movie
        /// </summary>
        [BsonElement("title")]
        public required string Title { get; set; }

        /// <summary>
        /// Movie description
        /// </summary>
        [BsonElement("description")]
        public required string Description { get; set; }

        /// <summary>
        /// Imdb rating of the movie
        /// </summary>
        [BsonElement("imbdRating")]
        public double ImbdRating {  get; set; } 

        /// <summary>
        /// Cast of the movie
        /// </summary>
        public required Cast Cast { get; set; }
    }
}
