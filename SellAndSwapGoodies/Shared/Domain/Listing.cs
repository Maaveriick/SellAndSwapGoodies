using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using SellAndSwapGoodies.Shared.Domain;

namespace CarRentalManagement.Shared.Domain
{
	public class Listing : BaseDomainModel
	{
		public string? Name { get; set; }
		public double? Price { get; set; }
		public string? Condition { get; set; }
		public string? Description { get; set; }
		public string? Location { get; set; }
		public int? ItmPic { get; set; }
		public int? CategoryID { get; set; }
		public virtual Category ? Category { get; set; }
		public int? UserID { get; set; }
		public virtual User ? User { get; set; }

	}
}