﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManagement.Shared.Domain;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class DeliveryStatus:BaseDomainModel
	{
		public string? Status { get; set; }
	}
}
