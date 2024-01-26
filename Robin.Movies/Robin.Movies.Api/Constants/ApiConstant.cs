namespace Robin.Movies.Api.Constants
{
    /// <summary>
    /// Holds all the api constants
    /// </summary>
    public static class ApiConstant
    {
        /// <summary>
        /// Holds all the MongoDb related constants
        /// </summary>
        public static class MongoDb
        {
            /// <summary>
            /// Holds all the collection names used in this api
            /// </summary>
            public static class CollectionName
            {
                /// <summary>
                /// Hold Movie Collection Name
                /// </summary>
                public const string MovieCollection = "Movie";
            }
        }

        /// <summary>
        /// Holds all the config related constants
        /// </summary>
        public static class Config
        {
            /// <summary>
            /// Holds all the config section 
            /// </summary>
            public static class Section
            {
                /// <summary>
                /// Hold the section name of MongoDbContextOptions
                /// </summary>
                public const string MongoDbContextOptions = "MongoDbContextOptions";
            }
        }
    }
}
