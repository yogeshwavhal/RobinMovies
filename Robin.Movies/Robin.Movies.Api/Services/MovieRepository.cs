using MongoDB.Driver;
using Robin.Movies.Api.DataAccess.Contracts;
using Robin.Movies.Api.Entities;
using Robin.Movies.Api.Services.Contracts;

namespace Robin.Movies.Api.Services
{
    internal class MovieRepository : MongoRepository<Movie>, IMoviesRepository
    {
        /// <summary>
        /// Movies Repository which manages the operation on movies collection
        /// </summary>
        /// <param name="collectionContext"></param>
        public MovieRepository(ICollectionContext<Movie> collectionContext) : base(collectionContext)
        {

        }

        /// <summary>
        /// Gets the movie by matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns the movies collection with given name</returns>
        public async Task<IEnumerable<Movie>> FindByNameAsync(string name)
        {
            var moviesByNames = await Collection
                .FindAsync(Builders<Movie>.Filter.Where(x => x.Title == name));
            return await moviesByNames.ToListAsync();
        }

    }
}
