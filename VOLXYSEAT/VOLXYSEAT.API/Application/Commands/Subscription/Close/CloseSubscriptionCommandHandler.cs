using MediatR;
using VOLXYSEAT.DOMAIN.Exceptions;
using VOLXYSEAT.DOMAIN.Repositories;

namespace VOLXYSEAT.API.Application.Commands.Subscription.Close
{
    public class CloseSubscriptionCommandHandler : IRequestHandler<CloseSubscriptionCommand, bool>
    {
        private readonly ISubscriptionRepository _repository;

        public CloseSubscriptionCommandHandler(ISubscriptionRepository repository)
        {
            _repository = repository ?? throw new VolxyseatDomainException(nameof(repository));
        }

        public async Task<bool> Handle(CloseSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _repository.GetByIdAsync(request.Id);

            if (subscription == null)
                throw new VolxyseatDomainException("Subscription not found");

            subscription.Close(request.Comment);

            await _repository.UpdateAsync(subscription);
            await _repository.UnitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
