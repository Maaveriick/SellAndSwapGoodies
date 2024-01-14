using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManagement.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Review:BaseDomainModel
	{
		public string? ReviewText { get; set; }
		public DateTime DateOut { get; set; }
		public DateTime DateIn { get; set; }
		public int? Rating { get; set; }
		public int? UserID { get; set; }
		public virtual User ? User { get; set; }

	}
}
