using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using SellAndSwapGoodies.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Listing : BaseDomainModel
	{
		[Required]
		public string? Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be a valid numeric value with up to 2 decimal places")]
        public double? Price { get; set; }
		[Required]
		public string? Description { get; set; }
		[Required]
		public string? Location { get; set; }
		public string? ItmPic { get; set; }
		[Required]
		public int? CategoryID { get; set; }

		public virtual Category? Category { get; set; }
		[Required]
		public int? UserID { get; set; }

		public virtual User? User { get; set; }
		[Required]
		public int? ConditionID { get; set; }

		public virtual Condition? Condition { get; set;}

	}
}