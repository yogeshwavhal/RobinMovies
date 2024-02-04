
using Robin.Movies.Api.Entities;

namespace Robin.Movies.Api.Services.Contracts
{
    /// <summary>
    /// Manages the operation on movies
    /// </summary>
    public interface IMoviesRepository :  IRepository<Movie>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Movie>> FindByNameAsync(string name);
        
    }
}
