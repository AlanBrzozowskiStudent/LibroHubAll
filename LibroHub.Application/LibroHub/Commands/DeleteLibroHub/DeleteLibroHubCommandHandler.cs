using LibroHub.Application.ApplicationUser;
using LibroHub.Application.LibroHub.Commands.CreateLibroHub;
using LibroHub.Application.LibroHub.Commands.EditLibroHub;
using LibroHub.Domain.Interfaces;
using MediatR;

namespace LibroHub.Application.LibroHub.Commands.DeleteLibroHub
{
    internal class DeleteLibroHubCommandHandler : IRequestHandler<DeleteLibroHubCommand>
    {
        private readonly ILibroHubRepository _repository;
        private readonly IUserContext _userContext;
        public DeleteLibroHubCommandHandler(ILibroHubRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(DeleteLibroHubCommand request, CancellationToken cancellationToken)
        {
            var libroHub = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser(); //pobranie
            var isEditable = user != null && libroHub.CreatedById == user.Id;

            if (!isEditable)
            {
                //nie pozwalaj na usuwanie
                return Unit.Value;
            }

            await _repository.Delete(libroHub);

            return Unit.Value;


        }
    }
}
