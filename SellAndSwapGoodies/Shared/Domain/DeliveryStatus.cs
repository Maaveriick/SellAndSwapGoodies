using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellAndSwapGoodies.Shared.Domain;
using System.ComponentModel.DataAnnotations;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class DeliveryStatus:BaseDomainModel
	{
		public string? Status { get; set; }
	}
}
