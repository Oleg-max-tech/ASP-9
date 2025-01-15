using AutoMapper
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieAppWithAuthors
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
