using System.Reflection;
using System.Runtime;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class User : BaseDomainModel
	{
        public User()
        {
            this.SenderOffer = new HashSet<Offer>();
            this.ReceiverOffer = new HashSet<Offer>();
        }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Password does not meet length requirements")]
        public string? Password { get; set; }
		public int? ProfileID { get; set; }
		public virtual Profile ? Profile { get; set; }
        public virtual List<Offer>? Offers { get; set; }

		[InverseProperty("Sender")]
		public virtual ICollection<Offer>? SenderOffer { get; set; }
		[InverseProperty("Receiver")]
		public virtual ICollection<Offer>? ReceiverOffer { get; set; }
	}
}