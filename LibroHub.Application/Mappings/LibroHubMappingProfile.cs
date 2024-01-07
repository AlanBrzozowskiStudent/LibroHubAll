using AutoMapper;
using LibroHub.Application.ApplicationUser;
using LibroHub.Application.LibroHub;
using LibroHub.Application.LibroHub.Commands.EditLibroHub;
using LibroHub.Domain.Entities;

namespace LibroHub.Application.Mappings
{
    public class LibroHubMappingProfile : Profile
    {
        //zasady mapowania między 2 typami
        public LibroHubMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<LibroHubDto, Domain.Entities.LibroHub>()
                .ForMember(e => e.BookDetails, opt => opt.MapFrom(src => new LibroHubDetails()
                {
                    BookCategory = src.BookCategory,
                    Author = src.Author,
                    PageNumber = src.PageNumber,
                    Rating = src.Rating,
                }));

            //z encji baz danych do encji dto
            CreateMap<Domain.Entities.LibroHub, LibroHubDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.BookCategory, opt => opt.MapFrom(src => src.BookDetails.BookCategory))
                .ForMember(dto => dto.Author, opt => opt.MapFrom(src => src.BookDetails.Author))
                .ForMember(dto => dto.PageNumber, opt => opt.MapFrom(src => src.BookDetails.PageNumber))
                .ForMember(dto => dto.Rating, opt => opt.MapFrom(src => src.BookDetails.Rating));

            CreateMap<LibroHubDto, EditLibroHubCommand>(); //wszsytkie się pokrywają nie trzeba dodawać
        }

    }
}
