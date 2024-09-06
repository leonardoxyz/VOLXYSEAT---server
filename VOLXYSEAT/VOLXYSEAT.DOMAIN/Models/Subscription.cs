using System.ComponentModel.DataAnnotations;
using VOLXYSEAT.DOMAIN.Core;
using VOLXYSEAT.DOMAIN.Exceptions;

namespace VOLXYSEAT.DOMAIN.Models
{
    public class Subscription : Entity
    {
        private readonly List<SubscriptionHistory> _histories;
        public SubscriptionProperties SubscriptionProperties { get; set; }

        private Subscription()
        {
            _histories = new List<SubscriptionHistory>();
        }
        public Subscription(
            SubscriptionEnum typeId,
            SubscriptionStatus statusId,
            string description,
            double price,
            DateTime createdOn,
            DateTime updatedOn)
        {
            TypeId = typeId;
            StatusId = statusId;
            Description = description;
            Price = price;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }
        public SubscriptionEnum TypeId { get; private set; }
        public SubscriptionStatus StatusId { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public List<SubscriptionHistory> History => _histories;
        public void Close(string comment)
        {
            if (StatusId == SubscriptionStatus.Inactive)
                throw new VolxyseatDomainException("Subscription is already inactive.");

            var oldStatus = StatusId;
            StatusId = SubscriptionStatus.Inactive;
            UpdatedOn = DateTime.UtcNow;

            _histories.Add(new SubscriptionHistory(Id, "System", oldStatus, SubscriptionStatus.Inactive, comment));
        }

        public void Open(string comment)
        {
            if (StatusId == SubscriptionStatus.Active)
                throw new VolxyseatDomainException("Subscription is already active.");

            var oldStatus = StatusId;
            StatusId = SubscriptionStatus.Active;
            UpdatedOn = DateTime.UtcNow;

            _histories.Add(new SubscriptionHistory(Id, "System", oldStatus, SubscriptionStatus.Active, comment));
        }
    }
}
