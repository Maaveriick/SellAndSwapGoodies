using System.Reflection;
using System.Runtime;
using System.ComponentModel.DataAnnotations;

namespace SellAndSwapGoodies.Shared.Domain
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