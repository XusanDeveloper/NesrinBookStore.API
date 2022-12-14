using AutoMapper;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;

namespace NesrinBookStore.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Books, BookViewModel>().ReverseMap();

            //var attachments = Mapper.Map<IEnumerable<Books>, List<BookViewModel>>(someList);
        }
    }
}
