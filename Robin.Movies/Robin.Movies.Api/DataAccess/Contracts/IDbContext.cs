using MongoDB.Driver;

namespace Robin.Movies.Api.DataAccess.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Provides MongoDatabase instance
        /// </summary>
        IMongoDatabase MongoDatabase { get; }
    }
}
