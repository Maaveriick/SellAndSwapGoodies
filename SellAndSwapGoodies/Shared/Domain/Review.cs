using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Review:BaseDomainModel
	{
		[Required]
		public string? ReviewText { get; set; }
        public DateTime ReviewTime { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be a number between 1 and 5")]
        public double Rating { get; set; }
        public double? AverageRating { get; set; }
        public int? UserID { get; set; }
		public virtual User ? User { get; set; }

	}
}
