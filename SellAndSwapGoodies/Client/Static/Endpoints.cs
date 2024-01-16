using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SellAndSwapGoodies.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string CategoriesEndpoint = $"{Prefix}/categories";
        public static readonly string ChatsEndpoint = $"{Prefix}/chats";
        public static readonly string DeliveryStatusesEndpoint = $"{Prefix}/deliverystatuses";
        public static readonly string ListingsEndpoint = $"{Prefix}/listings";
        public static readonly string OffersEndpoint = $"{Prefix}/offers";
        public static readonly string ProfilesEndpoint = $"{Prefix}/profiles";
        public static readonly string ReviewsEndpoint = $"{Prefix}/reviews";
        public static readonly string TransactionsEndpoint = $"{Prefix}/transactions";
        public static readonly string UsersEndpoint = $"{Prefix}/users";
        public static readonly string ConditionsEndpoint = $"{Prefix}/conditions";
		public static readonly string DeliverysEndpoint = $"{Prefix}/deliverys";
	}
}
