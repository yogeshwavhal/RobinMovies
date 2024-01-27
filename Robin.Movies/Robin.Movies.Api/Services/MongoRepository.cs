using MongoDB.Bson;
using MongoDB.Driver;
using Robin.Movies.Api.Constants;
using Robin.Movies.Api.DataAccess.Contracts;
using Robin.Movies.Api.Services.Contracts;
using System.Linq.Expressions;

namespace Robin.Movies.Api.Services
{
    /// <summary>
    /// Repository which manages the operation on movie collection in mongodb
    /// </summary>
    /// <typeparam name="TModel">Movie Model</typeparam>
    public class MongoRepository<TModel> : IRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Initialize the Collection
        /// </summary>
        /// <param name="collectionContext"></param>
        public MongoRepository(ICollectionContext<TModel> collectionContext)
        {
            Collection = collectionContext.Collection;
        }

        /// <summary>
        /// Initialize the collection
        /// </summary>
        /// <param name="dbContext"></param>
        public MongoRepository(IDbContext dbContext)
        {
            Collection = dbContext.MongoDatabase.GetCollection<TModel>(ApiConstant.MongoDb.CollectionName.MovieCollection);
        }

        /// <summary>
        /// Instance of the MongoCollection
        /// </summary>
        protected IMongoCollection<TModel> Collection { get; }

        /// <summary>
        /// Adds the movie to the movies collection
        /// </summary>
        /// <param name="model">Movie to be added to the collection</param>
        /// <returns></returns>
        public async Task AddAsync(TModel model)
        {
            await Collection.InsertOneAsync(model);
        }

        /// <summary>
        /// Gets all the movies which mateches 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Returns the collection of TModel which matches with the predicate </returns>
        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate)
        {
            var filterPredicate = Builders<TModel>.Filter.Where(predicate);
            var models = await Collection.FindAsync(filterPredicate);
            return await models.ToListAsync();
        }

        /// <summary>
        /// Get the movie by matching Id
        /// </summary>
        /// <param name="id">Id of the requested movie</param>
        /// <returns>Returns the Matching TModel</returns>
        public async Task<TModel> GetByIdAsync(string id)
        {
            var idFilter = Builders<TModel>.Filter.Eq("_id", new ObjectId(id));
            var movies = await Collection.FindAsync(idFilter);
            return movies.FirstOrDefault();
        }

        /// <summary>
        /// Get all the available movies
        /// </summary>
        /// <returns>Returns the Collection of TModel</returns>
        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var filter = Builders<TModel>.Filter.Empty;
            var models = await Collection.FindAsync(filter);
            return await models.ToListAsync();
        }
    }
}
