using System;
using RecycleAPI.Messaging;
using RecycleAPI.Models;

namespace RecycleAPI.Repository
{
    public interface IOrderRepository
    {
        void Add(APIKey vendorKey, Order order, OrderInsertResult result);
        Order Find(int id);
        GetOrderListResult GetAll();
        GetOrderListResult GetAll(APIKey vendorKey, int page = 0, int itemsPerPage = 300);
        GetOrderListResult GetAll(APIKey vendorKey, DateTime? fromDate, DateTime? toDate, string orderStatus, int page = 0, int itemsPerPage = 300);
        GetOrderListResult GetFromOrderNumber(APIKey vendorKey, string orderNumber);
        void UpdateOrderStatusItem(APIKey vendorKey, OrderStatusItem item);
        GetOrderListResult GetOpenOrders();
    }
}