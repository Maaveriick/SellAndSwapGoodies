using CarRentalManagement.Server.Configurations.Entities;
using CarRentalManagement.Shared.Domain;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
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
        public DbSet<Review> Review { get; set; }
        public DbSet<Listing> Listing { get; set; } 
        public DbSet<Chat> Chat { get; set; }
        public DbSet<User> User { get; set; }  
        public DbSet<Offer> Offer { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatus { get; set;}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new CategorySeedConfiguration());
			builder.ApplyConfiguration(new RoleSeedConfiguration());
			builder.ApplyConfiguration(new UserSeedConfiguration());
			builder.ApplyConfiguration(new UserRoleSeedConfiguration());
		}

	}
}