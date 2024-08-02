using MongoDB.Driver;
using Robin.Movies.Api.Entities;
using Robin.Movies.Api.Services.Contracts;
using System.Linq.Expressions;

namespace Robin.Movies.Api.Services
{
    internal class InMemoryMovieRepository : IMoviesRepository
    {
        #region Private Fields

        private readonly HashSet<Movie> _movies;

        #endregion

        #region Public Constructor
        public InMemoryMovieRepository()
        {
            _movies = new HashSet<Movie>();
        }

        #endregion

        #region Public Methods
        public async Task AddAsync(Movie model) =>
            await Task.Run(() => _movies.Add(model));

        public async Task<IEnumerable<Movie>> FindByNameAsync(string name) =>
            await Task.Run(() => _movies.Where(x => x.Title == name));

        public async Task<IEnumerable<Movie>> GetAllAsync() =>
            await Task.Run(() => _movies);

        public Task<IEnumerable<Movie>> GetAllAsync(Expression<Func<Movie, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetByIdAsync(string id) =>
            await Task.Run(() => _movies.FirstOrDefault(x => x.Id == id));

        public async Task<bool> RemoveAsync(string id) =>
            await Task.Run(() => _movies.RemoveWhere(x => x.Id == id) > 0);

        public async Task<bool> UpdateAsync(string id, Movie model) =>
            await Task.Run(() =>
            {
                var itemToBeReplaced = _movies.FirstOrDefault(x => x.Id == id);
                if (itemToBeReplaced != null)
                {
                    _movies.Remove(itemToBeReplaced);
                    return _movies.Add(model);
                }
                return false;
            });

        #endregion
    }
}
