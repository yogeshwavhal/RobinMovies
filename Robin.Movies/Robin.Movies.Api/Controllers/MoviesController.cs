using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robin.Movies.Api.Models;
using Robin.Movies.Api.Services.Contracts;

namespace Robin.Movies.Api.Controllers
{
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

        [HttpGet("{id}", Name = "GetMovieById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<MovieResponse>> GetMovie(string id)
        {
            _logger.LogInformation("Finding movie in DB.");
            //Find the Movie Item in DB
            var movieEntity = await _moviesRepository.FindByIdAsync(id);

            //If not found
            if (movieEntity == null)
            {
                return NotFound();
            }

            //If found convert it Movie --> MovieResponse
            var movieResponse = _mapper.Map<MovieResponse>(movieEntity);
            return Ok(movieResponse);
        }
        #endregion
    }
}
