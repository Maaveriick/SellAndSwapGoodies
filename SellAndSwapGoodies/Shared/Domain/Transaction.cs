using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Transaction:BaseDomainModel
	{
		public string? CreditCardName { get; set; }
		public string? CreditCardExpiryName { get; set; }
		public int? CreditCardNumber { get; set; }
		public int? UserID { get; set; }
		public virtual User ? User { get; set; }
		public int? OfferID { get; set; }
		public virtual Offer ? Offer { get; set; }	
		public int? ListingID { get; set; }
		public virtual Listing? Listing { get; set;}
		public int? DeliveryStatusID { get; set; }
		public virtual DeliveryStatus ? DeliveryStatus { get; set; }

	}
}
