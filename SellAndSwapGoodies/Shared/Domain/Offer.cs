using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SellAndSwapGoodies.Shared.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellAndSwapGoodies.Shared.Domain
{
	public class Offer:BaseDomainModel
	{
        [ForeignKey("Sender")]
        public int? SenderId { get; set; }

        [ForeignKey("Receiver")]
        public int? ReceiverId { get; set; }

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
    }
}
