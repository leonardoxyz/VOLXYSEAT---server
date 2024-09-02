using Moq;
using VOLXYSEAT.API.Application.Commands.Subscription.Create;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.DOMAIN.Repositories;

namespace VOLXYSEAT.TESTS.Application.Commands
{
    public class SubscriptionCommandHandlerTest
    {
        private readonly CreateSubscriptionCommandHandler _handler;
        private readonly Mock<ISubscriptionRepository> _mockRepository;

        public SubscriptionCommandHandlerTest()
        {
            _mockRepository = new Mock<ISubscriptionRepository>();
            _handler = new CreateSubscriptionCommandHandler(_mockRepository.Object);
        }
    }
}