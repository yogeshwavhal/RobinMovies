using MongoDB.Driver;
using Robin.Movies.Api.Entities;
using Robin.Movies.Api.Services.Contracts;
using System.Linq.Expressions;

namespace Robin.Movies.Api.Services
{
    internal class MovieRepo : IMoviesRepository
    {
        private readonly IMongoClient _mongoClient;
        private IMongoCollection<Movie> _collection;

        public MovieRepo(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            var db = _mongoClient.GetDatabase("RobinMoviesDev");
            _collection = db.GetCollection<Movie>("Movies");
        }

        public async Task AddAsync(Movie model)
        {
            await _collection.InsertOneAsync(model);
        }

        public Task<IEnumerable<Movie>> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var movies = await _collection.FindAsync(Builders<Movie>.Filter.Empty);
            return await movies.ToListAsync();
        }

        public Task<IEnumerable<Movie>> GetAllAsync(Expression<Func<Movie, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string id, Movie model)
        {
            throw new NotImplementedException();
        }
    }
}
