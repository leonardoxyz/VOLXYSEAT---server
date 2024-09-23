using VOLXYSEAT.DOMAIN.Core;

namespace VOLXYSEAT.DOMAIN.Models;
public class Transaction : Entity
{
    public Transaction(Guid subscriptionId, Guid clientId)
    {
        SubscriptionId = subscriptionId;
        ClientId = clientId;
        IssueDate = DateTime.UtcNow;

    }

    public Transaction()
    {
        
    }
    public Guid SubscriptionId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime IssueDate { get; set; }
}
