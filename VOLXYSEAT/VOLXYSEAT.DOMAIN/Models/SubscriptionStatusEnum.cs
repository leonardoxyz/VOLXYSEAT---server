using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOLXYSEAT.DOMAIN.Models
{
    public class SubscriptionStatusEnum
    {
        public SubscriptionStatus Id { get; set; }
        public string Name { get; set; }
    }

    public enum SubscriptionStatus : int
    {
        Active = 1,
        Inactive = 2,
    }
}
