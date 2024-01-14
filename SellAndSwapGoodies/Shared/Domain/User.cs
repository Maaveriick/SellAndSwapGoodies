using System.Reflection;
using System.Runtime;

namespace CarRentalManagement.Shared.Domain
{
	public class User : BaseDomainModel
	{
		public string? Name { get; set; }
		public int? Age { get; set; }
		public string? Gender { get; set; }
		public string? EmailAddress { get; set; }
		public string? Password { get; set; }
		public int? ProfileID { get; set; }
		public virtual Profile ? Profile { get; set; }
	}
}