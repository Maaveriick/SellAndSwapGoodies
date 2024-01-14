using System.Drawing;
using SellAndSwapGoodies.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellAndSwapGoodies.Server.Data;

namespace SellAndSwapGoodies.Server.Configurations.Entities
{
	public class CategorySeedConfiguration : IEntityTypeConfiguration<Category>
	{
		//gg
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(
				new Category
				{
					Id = 1,
					Name = "Electrical Appliances",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"
				},
				new Category
				{
					Id = 2,
					Name = "Clothing",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"
				},
				new Category
				{
					Id = 3,
					Name = "Watches",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"
				},
				new Category
				{
					Id = 4,
					Name = "Toys",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"
				},
				new Category
				{
					Id = 5,
					Name = "Cars",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"
				},
				new Category
				{
					Id = 6,
					Name = "Home Services",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"
				},
				new Category
				{
					Id = 7,
					Name = "Electronics",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"

				},
				new Category
				{
					Id = 8,
					Name = "Furniture",
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now,
					CreatedBy = "System",
					UpdatedBy = "System"
				}
				);
		}
	}
}
