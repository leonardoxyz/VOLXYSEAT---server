using MediatR;
using VOLXYSEAT.DOMAIN.Exceptions;
using VOLXYSEAT.DOMAIN.Repositories;

namespace VOLXYSEAT.API.Application.Commands.Subscription.Create
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, bool>
    {
        private readonly ISubscriptionRepository _repository;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository repository)
        {
            _repository = repository ?? throw new VolxyseatDomainException(nameof(repository));
        }

        public async Task<bool> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new VolxyseatDomainException(nameof(request));

            var subscription = new DOMAIN.Models.Subscription(
                request.TypeId,
                request.StatusId,
                request.Description,
                request.Price,
                request.CreatedOn,
                request.UpdatedOn
            );

            _repository.AddAsync(subscription);

            var result = await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
