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
                    Name = "Mav",
                    Age = 20,
                    Gender = "Male",
                    EmailAddress = "yeemaverick68@gmail.com",
                    Password = "1234",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new User
                {
                    Id = 2,
                    Name = "Atu",
                    Age = 19,
                    Gender = "Male",
                    EmailAddress = "AtuTu@gmail.com",
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
