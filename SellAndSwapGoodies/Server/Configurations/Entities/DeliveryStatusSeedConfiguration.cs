using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellAndSwapGoodies.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace SellAndSwapGoodies.Server.Configurations.Entities
{
    public class DeliveryStatusSeedConfiguration : IEntityTypeConfiguration<DeliveryStatus>
    {
        public void Configure(EntityTypeBuilder<DeliveryStatus> builder)
        {
            builder.HasData(
new DeliveryStatus
{
    Id = 1,
    Status = "Shipped",
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    CreatedBy = "System",
    UpdatedBy = "System"
},
new DeliveryStatus
{
    Id = 2,
    Status = "Delivered",
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    CreatedBy = "System",
    UpdatedBy = "System"
},
new DeliveryStatus
{
    Id = 3,
    Status = "Canceled",
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    CreatedBy = "System",
    UpdatedBy = "System"
},
new DeliveryStatus
{
    Id = 4,
    Status = "Pending",
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    CreatedBy = "System",
    UpdatedBy = "System"
}
);
        }
    }
}
