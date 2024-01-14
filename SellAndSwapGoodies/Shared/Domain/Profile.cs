﻿using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CarRentalManagement.Shared.Domain
{
	public class Profile : BaseDomainModel
	{
		public string? ProfileBio { get; set; }
		public int? ProfilePhoto { get; set; }
	}
}