using AutoMapper;
using LibroHub.Application.ApplicationUser;
using LibroHub.Domain.Interfaces;
using MediatR;

namespace LibroHub.Application.LibroHub.Commands.CreateLibroHub
{
    public class CreateLibroHubCommandHandler : IRequestHandler<CreateLibroHubCommand>
    {
        private readonly ILibroHubRepository _libroHubRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateLibroHubCommandHandler(ILibroHubRepository libroHubRepository, IMapper mapper, IUserContext userContext)
        {
            _libroHubRepository = libroHubRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateLibroHubCommand request, CancellationToken cancellationToken)
        {
            var libroHub = _mapper.Map<Domain.Entities.LibroHub>(request);
            libroHub.EncodeName();
            //dodać id usera
            libroHub.CreatedById = _userContext.GetCurrentUser().Id;

            await _libroHubRepository.Create(libroHub);

            return Unit.Value;
        }
    }
}
