using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOLXYSEAT.DOMAIN.Core;

namespace VOLXYSEAT.DOMAIN.Models;
public class Transaction : Entity
{
    public Guid SubscriptionId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime IssueDte { get; set; }
}
