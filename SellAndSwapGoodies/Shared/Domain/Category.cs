using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Category : BaseDomainModel
	{
		public string? Name { get; set; }
	}
}
