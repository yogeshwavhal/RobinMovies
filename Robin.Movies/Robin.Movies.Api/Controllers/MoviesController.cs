using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robin.Movies.Api.Entities;
using Robin.Movies.Api.Models;
using Robin.Movies.Api.Services.Contracts;

namespace Robin.Movies.Api.Controllers
{
    /// <summary>
    /// Controller for movies
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/movies/")]
    public class MoviesController : ControllerBase
    {
        #region Private Fields

        private readonly ILogger<MoviesController> _logger;
        private readonly IMapper _mapper;
        private readonly IMoviesRepository _moviesRepository;

        #endregion

        #region Public Constructor
        /// <summary>
        /// Initializes the dependencies
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="moviesRepository"></param>
        public MoviesController(
            ILogger<MoviesController> logger,
            IMapper mapper,
            IMoviesRepository moviesRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _moviesRepository = moviesRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the Movie response by mapping id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Returns the requested movie</returns>
        /// <response code="200">Returns the requested movie</response>
        /// <response code="404">Requested movie is not found</response>
        /// <response code="500">Server error occurred while searching for the requested movie</response>
        [HttpGet("{movieId}", Name = "GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieResponse>> GetMovie(string movieId)
        {
            _logger.LogInformation("Finding movie in DB.");
            //Find the Movie Item in DB
            var movieEntity = await _moviesRepository.GetByIdAsync(movieId);

            //If not found
            if (movieEntity == null)
            {
                return NotFound();
            }

            //If found convert it Movie --> MovieResponse
            var movieResponse = _mapper.Map<MovieResponse>(movieEntity);
            return Ok(movieResponse);
        }

        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <returns>Returns movies collection</returns>
        /// <response code="200">Returns the requested movies collection</response>
        /// <response code="404">No movie found</response>
        /// <response code="500">Server error occurred while searching for the requested movie</response>
        [HttpGet(Name = "GetMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieResponse>> GetAllMovies()
        {
            _logger.LogInformation("Finding all movie in DB.");
            //Find the Movies in DB
            var movieCollectionEntity = await _moviesRepository.GetAllAsync();

            //If not found
            if (movieCollectionEntity == null)
            {
                return NotFound();
            }

            //If found convert it Collection of Movie --> Collection of MovieResponse
            var movieResponseCollection = _mapper.Map<IEnumerable<MovieResponse>>(movieCollectionEntity);
            return Ok(movieResponseCollection);
        }

        /// <summary>
        /// Creates the Movie
        /// </summary>
        /// <returns>Returns the created movie</returns>
        /// <response code="200">Movie has been created successfully</response>
        /// <response code="400">Could not creat a movie</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieResponse>> CreateMovie(MovieForCreationRequest movieRequest)
        {
            _logger.LogInformation("Creating a movie.");

            //Create movie entity by mapping the movie request model
            var movieEntity = _mapper.Map<Movie>(movieRequest);

            //Add the created movie instance
            await _moviesRepository.AddAsync(movieEntity);

            var movieResponseToBereturn = _mapper.Map<MovieResponse>(movieEntity);

            return CreatedAtAction("GetMovie", new { movieId = movieEntity.Id }, movieResponseToBereturn);
        }

        #endregion
    }
}
