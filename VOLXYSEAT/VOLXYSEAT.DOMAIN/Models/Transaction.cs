using VOLXYSEAT.DOMAIN.Core;

namespace VOLXYSEAT.DOMAIN.Models;
public class Transaction : Entity
{
    public Transaction(Guid subscriptionId, Guid clientId, DateTime createdOn)
    {
        SubscriptionId = subscriptionId;
        ClientId = clientId;
        CreatedOn = createdOn;
    }

    public Transaction()
    {
        
    }
    public Guid SubscriptionId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime CreatedOn { get; private set; }
}
