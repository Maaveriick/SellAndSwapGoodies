using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Server.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		Task Save(HttpContext httpContext);
		IGenericRepository<Category> Categories { get; }
		IGenericRepository<Chat> Chats { get; }
		IGenericRepository<DeliveryStatus> DeliveryStatuses { get; }
		IGenericRepository<Listing> Listings { get; }
		IGenericRepository<Offer> Offers { get; }
		IGenericRepository<Review> Reviews { get; }
		IGenericRepository<Transaction> Transactions { get; }
		IGenericRepository<User> Users { get; }
		IGenericRepository<Condition> Conditions { get; }
		IGenericRepository<Delivery> Deliverys { get; }

	}
}