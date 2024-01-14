using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Chat:BaseDomainModel
	{
		public string? MessageText { get; set; }
		public int? UserID { get; set; }
		public virtual User ? User { get; set; }
		public int? OfferID { get; set; }
		public virtual Offer ? Offer { get; set; }

	}
}
