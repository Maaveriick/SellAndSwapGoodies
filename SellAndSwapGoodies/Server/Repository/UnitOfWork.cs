using SellAndSwapGoodies.Server.Data;
using SellAndSwapGoodies.Server.IRepository;
using SellAndSwapGoodies.Server.Models;
using SellAndSwapGoodies.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Drawing;

namespace SellAndSwapGoodies.Server.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private IGenericRepository<Category> _categories;
		private IGenericRepository<Chat> _chats;
		private IGenericRepository<DeliveryStatus> _deliverystatuses;
		private IGenericRepository<Listing> _listings;
		private IGenericRepository<Offer> _offers;
		private IGenericRepository<Profile> _profiles;
		private IGenericRepository<Review> _reviews;
		private IGenericRepository<Transaction> _transactions;
		private IGenericRepository<User> _users;

		private UserManager<ApplicationUser> _userManager;

		public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IGenericRepository<Category> Categories
			=> _categories ??= new GenericRepository<Category>(_context);
		public IGenericRepository<Chat> Chats
			=> _chats ??= new GenericRepository<Chat>(_context);
		public IGenericRepository<DeliveryStatus> DeliveryStatuses
			=> _deliverystatuses ??= new GenericRepository<DeliveryStatus>(_context);
		public IGenericRepository<Listing> Listings
			=> _listings ??= new GenericRepository<Listing>(_context);
		public IGenericRepository<Offer> Offers
			=> _offers ??= new GenericRepository<Offer>(_context);
		public IGenericRepository<Profile> Profiles
			=> _profiles ??= new GenericRepository<Profile>(_context);
		public IGenericRepository<Review> Reviews
			=> _reviews ??= new GenericRepository<Review>(_context);
		public IGenericRepository<Transaction> Transactions
			=> _transactions ??= new GenericRepository<Transaction>(_context);
		public IGenericRepository<User> Users
			=> _users ??= new GenericRepository<User>(_context);

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task Save(HttpContext httpContext)
		{
			//To be implemented
			string user = "System";

			var entries = _context.ChangeTracker.Entries()
				.Where(q => q.State == EntityState.Modified ||
					q.State == EntityState.Added);

			foreach (var entry in entries)
			{
				((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
				((BaseDomainModel)entry.Entity).UpdatedBy = user;
				if (entry.State == EntityState.Added)
				{
					((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
					((BaseDomainModel)entry.Entity).CreatedBy = user;
				}
			}

			await _context.SaveChangesAsync();
		}
	}
}
