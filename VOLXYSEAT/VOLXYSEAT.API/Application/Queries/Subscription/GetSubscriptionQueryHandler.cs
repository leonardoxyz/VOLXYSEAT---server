using MediatR;
using Volxyseat.API.Application.Queries.Subscription;
using VOLXYSEAT.API.Application.Models.Dtos.Subscription;
using VOLXYSEAT.DOMAIN.Exceptions;
using VOLXYSEAT.DOMAIN.Repositories;

namespace VOLXYSEAT.API.Application.Queries.Subscription
{
    public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, SubscriptionDto>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<SubscriptionDto> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.Id);

            if (subscription == null)
            {
                throw new VolxyseatDomainException("Subscription not found.");
            }

            var subscriptionDto = new SubscriptionDto
            {
                Id = subscription.Id,
                Type = subscription.TypeId,
                Status = subscription.StatusId,
                Description = subscription.Description,
                Price = subscription.Price,
                CreatedOn = subscription.CreatedOn,
                UpdatedOn = subscription.UpdatedOn
            };

            return subscriptionDto;
        }
    }

}
