using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Profile : BaseDomainModel
	{
		public string? ProfileBio { get; set; }
		public int? ProfilePhoto { get; set; }
	}
}