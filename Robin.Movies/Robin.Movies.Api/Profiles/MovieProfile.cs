using AutoMapper;
using Robin.Movies.Api.Models;

namespace Robin.Movies.Api.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Entities.Movie, MovieResponse>();
            CreateMap<Entities.Cast, CastResponse>();
        }
    }
}
