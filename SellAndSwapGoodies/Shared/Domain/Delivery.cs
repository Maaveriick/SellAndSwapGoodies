using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellAndSwapGoodies.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace SellAndSwapGoodies.Shared.Domain
{
    public class Delivery : BaseDomainModel
    {
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        public int? DeliveryStatusID { get; set; }
        public virtual DeliveryStatus? DeliveryStatus { get; set; }

        public int? UserID { get; set; }
        public virtual User? User { get; set; }

        public int? ListingID { get; set; }
        public virtual Listing? Listing { get; set; }


    }
}

