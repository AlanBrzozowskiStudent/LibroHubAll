using LibroHub.Application.ApplicationUser;
using LibroHub.Domain.Interfaces;
using MediatR;

namespace LibroHub.Application.LibroHub.Commands.EditLibroHub
{
    internal class EditLibroHubCommandHandler : IRequestHandler<EditLibroHubCommand>
    {
        private readonly ILibroHubRepository _repository;
        private readonly IUserContext _userContext;
        public EditLibroHubCommandHandler(ILibroHubRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditLibroHubCommand request, CancellationToken cancellationToken)
        {
            var libroHub = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser(); //pobranie
            var isEditable = user != null && libroHub.CreatedById == user.Id;

            if (!isEditable)
            {
                //nie pozwalaj na edycje
                return Unit.Value;
            }

            libroHub.Description = request.Description;
            libroHub.About = request.About;

            libroHub.BookDetails.BookCategory = request.BookCategory;
            libroHub.BookDetails.Author = request.Author;
            libroHub.BookDetails.PageNumber = request.PageNumber;
            libroHub.BookDetails.Rating = request.Rating;

            await _repository.Commit();

            return Unit.Value;
        }

    }
}
