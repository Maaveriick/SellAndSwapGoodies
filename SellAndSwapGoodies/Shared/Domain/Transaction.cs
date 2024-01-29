using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Transaction:BaseDomainModel
	{
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string? CreditCardName { get; set; }
		[Required]
		public string? CreditCardExpiryName { get; set; }
        [Required(ErrorMessage = "Credit card number is required")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Credit card number must be a 16-digit numeric value")]
        public long? CreditCardNumber { get; set; }
        [Required(ErrorMessage = "CVV is required")]
        [Range(100, 999, ErrorMessage = "CVV must be a 3-digit number")]
        public int? CVV { get; set; }
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
