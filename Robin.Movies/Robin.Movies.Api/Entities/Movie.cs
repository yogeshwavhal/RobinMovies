using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Robin.Movies.Api.Entities
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        [BsonElement("Title")]
        public required string Title { get; set; }

        [BsonElement("Description")]
        public required string Description { get; set; }

        [BsonElement("ImbdRating")]
        public double ImbdRating {  get; set; } 

        public required Cast Cast { get; set; }
    }
}
