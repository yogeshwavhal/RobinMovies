using Robin.Movies.Api.DataAccess.Contracts;
using Robin.Movies.Api.Entities;
using Robin.Movies.Api.Services.Contracts;

namespace Robin.Movies.Api.Services
{
    internal class MovieRepository : MongoRepository<Movie>, IMoviesRepository
    {
        public MovieRepository(ICollectionContext<Movie> collectionContext):base(collectionContext)
        {
            
        }

        public async Task<IEnumerable<Movie>> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

    }
}
