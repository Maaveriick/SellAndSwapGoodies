using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SellAndSwapGoodies.Shared.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Chat:BaseDomainModel
	{
		public string? MessageText { get; set; }
		public DateTime ChatTimeStamp { get; set; }
		public string? MessageUser { get; set; }

        public int? UserID { get; set; }
		public virtual User ? User { get; set; }
		public int? OfferID { get; set; }
		public virtual Offer ? Offer { get; set; }
		public int? ListingID { get; set; }
		public virtual Listing ? Listing { get; set; }

	}
}
