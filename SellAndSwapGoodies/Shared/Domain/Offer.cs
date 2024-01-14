using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManagement.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Offer:BaseDomainModel
	{
		public bool? OfferStatus {  get; set; }
		public int? UserID { get; set; }
		public virtual User ? User { get; set; }
	}
}
