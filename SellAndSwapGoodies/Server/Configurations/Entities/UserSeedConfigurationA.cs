using SellAndSwapGoodies.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellAndSwapGoodies.Server.Configurations.Entities
{
    public class UserSeedConfigurationA : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                 new User
                 {
                     Id = 1,
                     Name = "James",
                     Age = 18,
                     Gender = "Male",
                     EmailAddress = "James@gmail.com",
                     Password = "1234",
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 },
                 new User
                 {
                     Id = 2,
                     Name = "Taylor",
                     Age = 18,
                     Gender = "Female",
                     EmailAddress = "Taylor@gmail.com",
                     Password = "1234",
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 }
              );

        }
    }
}
