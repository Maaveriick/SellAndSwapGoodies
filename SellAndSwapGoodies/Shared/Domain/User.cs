using System.Reflection;
using System.Runtime;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class User : BaseDomainModel
	{
        public User()
        {
            this.SenderOffer = new HashSet<Offer>();
            this.ReceiverOffer = new HashSet<Offer>();
        }
        public string? Name { get; set; }
        public int? Age { get; set; }
		public string? Gender { get; set; }
		public string? EmailAddress { get; set; }
		public string? Password { get; set; }
		public int? ProfileID { get; set; }
		public virtual Profile ? Profile { get; set; }

		public virtual List<Offer> Offers { get; set; }

		[InverseProperty("Sender")]
		public virtual ICollection<Offer> SenderOffer { get; set; }
		[InverseProperty("Receiver")]
		public virtual ICollection<Offer> ReceiverOffer { get; set; }
	}
}