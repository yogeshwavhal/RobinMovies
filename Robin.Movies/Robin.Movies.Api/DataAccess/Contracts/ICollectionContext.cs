using MongoDB.Driver;

namespace Robin.Movies.Api.DataAccess.Contracts
{
    /// <summary>
    /// Manages the collection of type TModel
    /// </summary>
    /// <typeparam name="TModel">Type of collection model</typeparam>
    public interface ICollectionContext<TModel> where TModel : class
    {
        /// <summary>
        /// Provides acess to the instance of collection of type TModel
        /// </summary>
        IMongoCollection<TModel> Collection { get; }
    }
}
