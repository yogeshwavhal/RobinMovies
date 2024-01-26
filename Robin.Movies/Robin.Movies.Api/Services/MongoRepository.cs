using MongoDB.Driver;
using Robin.Movies.Api.Constants;
using Robin.Movies.Api.DataAccess.Contracts;
using Robin.Movies.Api.Entities;
using Robin.Movies.Api.Services.Contracts;

namespace Robin.Movies.Api.Services
{
    public class MongoRepository<TModel> : IRepository<TModel> where TModel : class
    {
        public MongoRepository(ICollectionContext<TModel> collectionContext)
        {
            Collection = collectionContext.Collection;
        }

        public MongoRepository(IDbContext dbContext)
        {
            Collection = dbContext.MongoDatabase.GetCollection<TModel>(ApiConstant.MongoDb.CollectionName.MovieCollection);
        }

        /// <summary>
        /// Instance of the MongoCollection
        /// </summary>
        protected IMongoCollection<TModel> Collection { get; }

        public Task<IEnumerable<TModel>> FindAllAsync(Func<TModel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> FindByIdAsync(string id)
        {
            var idFilter = Builders<TModel>.Filter.Eq("_id", id);
            var movies = await Collection.FindAsync(idFilter);
            return movies.FirstOrDefault();
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
