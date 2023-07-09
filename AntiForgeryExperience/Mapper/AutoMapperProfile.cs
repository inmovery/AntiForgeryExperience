namespace AntiForgeryExperience.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BookDto, BookEntity>().ReverseMap();
    }
}