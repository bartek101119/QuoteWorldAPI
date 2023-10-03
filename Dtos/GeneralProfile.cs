using AutoMapper;
using QuoteWorldAPI.Entities;

namespace QuoteWorldAPI.Dtos
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Quote, QuoteDto>()
                .ReverseMap();

            CreateMap<Comment, CommentDto>()
                .ReverseMap();

            CreateMap<Rating, RatingDto>()
                .ReverseMap();
        }
    }
}
