using Asp.Versioning;
using FluentValidation;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Prometheus;
using Robin.Movies.Api.Constants;
using Robin.Movies.Api.DataAccess;
using Robin.Movies.Api.DataAccess.Contracts;
using Robin.Movies.Api.DataAccess.Options;
using Robin.Movies.Api.Entities;
using Robin.Movies.Api.Services;
using Robin.Movies.Api.Services.Contracts;
using Robin.Movies.Api.Validators;
using Serilog;
using System.Reflection;

namespace Robin.Movies.Api.Extensions
{
    /// <summary>
    /// Extensions for Configuring services and pipelines
    /// </summary>
    public static class StartupExtension
    {
        /// <summary>
        /// It configures the pipeline
        /// </summary>
        /// <param name="builder">instance of WebApplicationBuilder </param>
        /// <returns></returns>
        public static WebApplication ConfigurePipeline(this WebApplicationBuilder builder)
        {
            //Adding serilog for logging on console as well as in file
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
                        .WriteTo.File("Logs/Robin.Movies.Api.log")
                        .CreateLogger();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setupAction =>
            {
                //setupAction.SwaggerDoc("V1", new OpenApiInfo()
                //{
                //    Title = "Movies Rest Api",
                //    Version = "v1",
                //    Contact = new OpenApiContact() { Email = "yogesh.patil@gmail.com", Name = "Yogesh Patil" },
                //    Description = "The api is about movies collection. To read see the details about the movies. ",
                //});

                var commentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentsFilePath = Path.Combine(AppContext.BaseDirectory, commentsFileName);
                setupAction.IncludeXmlComments(commentsFilePath);
            });

            var app = builder.Build();

            app.UseMetricServer();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseHttpMetrics(options => options.AddCustomLabel("host", context => context.Request.Host.Host));
            app.UseAuthorization();

            app.MapControllers();
            return app;
        }

        /// <summary>
        /// Manages the registration of services
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

            //Adding AutoMapper for current executing assembly
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.Configure<MongoDbContextOptions>(builder.Configuration.GetSection(ApiConstant.Config.Section.MongoDbContextOptions));
            builder.Services.AddSingleton<IValidateOptions<MongoDbContextOptions>, MongoDbContextOptionsValidator>();
            builder.Services.AddSingleton<IMongoClient>(x =>
            {
                var mongoDbContextOption = x.GetRequiredService<IOptions<MongoDbContextOptions>>();
                return new MongoClient(mongoDbContextOption.Value.ConnectionUrl);
            });
            builder.Services.AddScoped<IMoviesRepository, MovieRepository>();
            builder.Services.AddScoped<ICollectionContext<Movie>, MoviesCollectionContext>();
            builder.Services.AddValidatorsFromAssemblyContaining<MovieValidator>();
            return builder;
        }
    }
}
