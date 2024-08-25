using MediatR;
using VOLXYSEAT.DOMAIN.Models;

namespace VOLXYSEAT.API.Application.Commands.Subscription
{
    public record class CreateSubscriptionCommand(
        SubscriptionEnum TypeId,
        SubscriptionStatus StatusId,
        string Description,
        double Price,
        DateTime CreatedOn,
        DateTime UpdatedOn) : IRequest<bool>
    {

    }
}
