using AutoMapper;
using LibroHub.Application.ApplicationUser;
using LibroHub.Domain.Interfaces;
using MediatR;

namespace LibroHub.Application.LibroHub.Quires.GetAllLibroHubQuery
{
    //pobranie wszystkich elementów z baz danych
    internal class GetAllLibroHubsQueryHandler : IRequestHandler<GetAllLibroHubsQuery, IEnumerable<LibroHubDto>>
    {
        private readonly ILibroHubRepository _libroHubRepository;
        private readonly IMapper _mapper;

        public GetAllLibroHubsQueryHandler(ILibroHubRepository libroHubRepository, IMapper mapper, IUserContext userContext)
        {
            _libroHubRepository = libroHubRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LibroHubDto>> Handle(GetAllLibroHubsQuery request, CancellationToken cancellationToken)
        {

            var libroHub = await _libroHubRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<LibroHubDto>>(libroHub);

            return dtos;
        }
    }
}
