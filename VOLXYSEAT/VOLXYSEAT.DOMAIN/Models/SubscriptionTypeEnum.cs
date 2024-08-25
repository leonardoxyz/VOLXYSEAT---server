using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOLXYSEAT.DOMAIN.Models
{
    public class SubscriptionTypeEnum
    {
        public SubscriptionEnum Id { get; set; }
        public string Name { get; set; }
    }

    public enum SubscriptionEnum : int
    {
        Basic = 0,
        Medium = 1,
        Advanced = 2,
        Personalized = 3
    }
}
