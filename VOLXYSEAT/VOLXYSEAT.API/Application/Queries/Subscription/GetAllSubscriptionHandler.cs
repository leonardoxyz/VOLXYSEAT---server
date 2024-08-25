using MediatR;
using Microsoft.EntityFrameworkCore;
using Volxyseat.API.Application.Queries.Subscription;
using VOLXYSEAT.API.Application.Models.Dtos.Subscription;
using VOLXYSEAT.DOMAIN.Repositories;

namespace VOLXYSEAT.API.Application.Queries.Subscription
{
    public class GetAllSubscriptionHandler: IRequestHandler<GetAllSubscriptionQuery, IEnumerable<SubscriptionDto>>
    {
        private readonly ISubscriptionRepository _repository;

        public GetAllSubscriptionHandler(ISubscriptionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<IEnumerable<SubscriptionDto>> Handle(GetAllSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = _repository.GetAll();

            var query = subscriptions.AsQueryable();
            
            var data = query.AsNoTracking().Select(item => new SubscriptionDto
            {
                Id = item.Id,
                Type = item.TypeId,
                Status = item.StatusId,
                Description = item.Description,
                Price = item.Price,
                CreatedOn = item.CreatedOn,
                UpdatedOn = item.UpdatedOn
            }).AsEnumerable();



            return Task.FromResult(data);
        }
    }
}
