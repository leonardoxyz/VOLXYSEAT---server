using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOLXYSEAT.DOMAIN.Models
{
    public record class SubscriptionHistory
    {
        private SubscriptionHistory() { }

        public SubscriptionHistory(Guid id, string updatedBy, string comment)
        {
            this.Id = id;
            this.UpdatedOn = DateTime.UtcNow;
            this.UpdatedBy = updatedBy;
            this.Comment = comment;
        }

        public Guid Id { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public string UpdatedBy { get; private set; }
        public string Comment { get; private set; }
    }
}
