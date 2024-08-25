using MediatR;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.DOMAIN.Repositories;

namespace VOLXYSEAT.API.Application.Commands.Subscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, bool>
    {
        private readonly ISubscriptionRepository     _repository;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

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
