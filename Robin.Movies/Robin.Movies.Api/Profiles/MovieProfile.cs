using AutoMapper;
using Robin.Movies.Api.Models;

namespace Robin.Movies.Api.Profiles
{
    /// <summary>
    /// Movie profile which hold the mapping configuration of entity and request/response models
    /// </summary>
    public class MovieProfile : Profile
    {
        /// <summary>
        /// Creating mapping configuration
        /// </summary>
        public MovieProfile()
        {
            CreateMap<Entities.Movie, MovieResponse>();
            CreateMap<Entities.Cast, CastResponse>();
            CreateMap<MovieForCreationRequest, Entities.Movie>();
            CreateMap<CastForCreationRequest, Entities.Cast>();
            CreateMap<MovieForUpdationRequest, Entities.Movie>();
            CreateMap<CastForCreationRequest, Entities.Cast>();
        }
    }
}
