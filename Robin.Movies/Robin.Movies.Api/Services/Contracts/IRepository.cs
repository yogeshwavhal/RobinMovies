using System.Linq.Expressions;

namespace Robin.Movies.Api.Services.Contracts
{
    /// <summary>
    /// Repository which manages the movies
    /// </summary>
    /// <typeparam name="TModel">Movie Model</typeparam>
    public interface IRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Adds the TModel 
        /// </summary>
        /// <param name="model">Model to be added</param>
        /// <returns></returns>
        Task AddAsync(TModel model);

        /// <summary>
        /// Get all the available movies
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetAllAsync();

        /// <summary>
        /// Get the movie by matching Id
        /// </summary>
        /// <param name="id">Id of the requested movie</param>
        /// <returns></returns>
        Task<TModel> GetByIdAsync(string id);

        /// <summary>
        /// Gets all the movies which mateches 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// Updates the model
        /// </summary>
        /// <param name="id">id of the model to be updated</param>
        /// <param name="model">model with which we need to update the existing model</param>
        /// <returns>Retuns true if updation was successful false otherwise</returns>
        Task<bool> UpdateAsync(string id, TModel model);

        /// <summary>
        /// It removes the model
        /// </summary>
        /// <param name="id">Id of the model to be removed</param>
        /// <returns>Returns true if the model was deleted successfully false otherwise</returns>
        Task<bool> RemoveAsync(string id);
    }
}
