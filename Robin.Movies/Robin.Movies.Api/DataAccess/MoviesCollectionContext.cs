using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Robin.Movies.Api.DataAccess.Contracts;
using Robin.Movies.Api.DataAccess.Options;
using Robin.Movies.Api.Entities;

namespace Robin.Movies.Api.DataAccess
{
    /// <summary>
    /// Manages movies collection
    /// </summary>
    public class MoviesCollectionContext : ICollectionContext<Movie>
    {
        /// <summary>
        /// Obtains the connection with MongoDb
        /// </summary>
        /// <param name="mongoClient"></param>
        /// <param name="options"></param>
        public MoviesCollectionContext(
            IMongoClient mongoClient,
            IOptions<MongoDbContextOptions> options)
        {
            var db = mongoClient.GetDatabase(options.Value.DatabaseName);
            Collection = db.GetCollection<Movie>(options.Value.CollectionName);
        }

        /// <summary>
        /// Give the instance of Movies Collection
        /// </summary>
        public IMongoCollection<Movie> Collection { get; }
    }
}
