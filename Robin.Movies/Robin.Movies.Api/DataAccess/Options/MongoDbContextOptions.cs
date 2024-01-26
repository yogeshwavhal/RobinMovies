namespace Robin.Movies.Api.DataAccess.Options
{
    /// <summary>
    /// Holds the MongoDb connection options
    /// </summary>
    public class MongoDbContextOptions 
    {
        /// <summary>
        /// MongoDb connection url
        /// </summary>
        public required string ConnectionUrl {  get; set; }

        /// <summary>
        /// Name of the database 
        /// </summary>
        public required string DatabaseName { get; set; }

        /// <summary>
        /// Name of the collection
        /// </summary>
        public required string CollectionName {  get; set; }

    }
}
