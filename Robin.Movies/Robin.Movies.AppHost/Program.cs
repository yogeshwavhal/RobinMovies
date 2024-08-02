
var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder.AddMongoDB("mongodb")
                   .WithDataVolume()
                   .WithMongoExpress()
                   .AddDatabase("RobinMoviesDev");


var apiService = builder.AddProject<Projects.Robin_Movies_Api>("robin-movies-api")
                        .WithReference(mongo);


builder.Build().Run();
