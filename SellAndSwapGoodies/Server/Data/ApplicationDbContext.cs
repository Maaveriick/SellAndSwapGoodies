using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SellAndSwapGoodies.Server.Configurations.Entities;
using SellAndSwapGoodies.Server.Models;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Listing> Listings { get; set; } 

        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set;}
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Delivery> Deliverys { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
			builder.ApplyConfiguration(new UserSeedConfiguration());
			builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new DeliveryStatusSeedConfiguration());
            builder.ApplyConfiguration(new CategorySeedConfiguration());
		}

	}
}