using Microsoft.EntityFrameworkCore;
using RecycleAPI.Messaging;
using RecycleAPI.Models;
using RecycleAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecycleAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly APIContext _context;

        public OrderRepository(APIContext context)
        {
            _context = context;
        }

        public void Add(APIKey key, Order order, OrderInsertResult result)
        {
            if (order.Vendor == null)
            {
                order.Vendor = key.Vendor;
            }

            // Check for duplicates if override not allowed
            if (key.Vendor.AllowDuplicateOrderNumbers == false)
            {
                var existing =
                    _context.Orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber && o.Vendor == key.Vendor);
                if (existing != null)
                {
                    result.Success = false;
                    result.Message =
                        $"Duplication Error: Order number {order.OrderNumber} already exists in the system";
                    return;
                }
            }


            // Adding trhe crud and logging information to the record
            order.CreatedDate = DateTime.Now;
            order.ModifiedDate = DateTime.Now;
            var vendorName = order.Vendor.VendorName;
            order.CreatedBy = vendorName;
            order.ModifiedBy = vendorName;

            _context.Orders.Add(order);
            _context.SaveChanges();

            result.Success = true;
            result.ItemId = order.ItemId;

        }


        public Order Find(int id)
        {
            return _context.Orders.FirstOrDefault(v => v.OrderId == id);
        }

        public GetOrderListResult GetAll()
        {
            var result = _context.Orders.Include(o => o.Vendor).ToList();
            var orderResult = PackageResults(0, 300, result);
            return orderResult;
        }

        public GetOrderListResult GetAll(APIKey key, int page = 0, int itemsPerPage = 300)
        {
            if (key == null)
            {
                return null;
            }

            var count = _context.Orders
                .Count(o => o.Vendor == key.Vendor);

            var result = _context.Orders
                .Where(o => o.Vendor == key.Vendor)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            var orderResult = PackageResults(page, count, result);
            return orderResult;
        }

        public GetOrderListResult GetAll(
            APIKey key, DateTime? fromDate, DateTime? toDate, string orderStatus, int page = 0, int itemsPerPage = 300)
        {
            if (key == null)
            {
                return null;
            }

            IQueryable<Order> query = null;

            if (string.IsNullOrEmpty(orderStatus))
            {
                if (!fromDate.HasValue && !toDate.HasValue)
                {
                    query = _context.Orders
                        .Where(o => o.Vendor == key.Vendor)
                        .OrderBy(o => o.OrderId);
                }

                else if (toDate.HasValue && toDate.Value > fromDate)
                {
                    query = _context.Orders.Where(o =>
                        o.Vendor == key.Vendor && (o.OrderDate >= fromDate && o.OrderDate <= toDate));
                }
                else
                {
                    query = _context.Orders.Where(o => o.Vendor == key.Vendor && o.OrderDate >= fromDate);
                }
            }
            else
            {
                if (!fromDate.HasValue && !toDate.HasValue)
                {
                    query = _context.Orders
                        .Where(o => o.Vendor == key.Vendor && o.OrderStatus == orderStatus)
                        .OrderBy(o => o.OrderId);
                }

                else if (toDate.HasValue && toDate.Value > fromDate)
                {
                    query = _context.Orders.Where(o =>
                        o.Vendor == key.Vendor && (o.OrderDate >= fromDate && o.OrderDate <= toDate) && o.OrderStatus == orderStatus);
                }
                else
                {
                    query = _context.Orders.Where(o => o.Vendor == key.Vendor && o.OrderDate >= fromDate && o.OrderStatus == orderStatus);
                }
            }

            var count = query.Count();
            var result = query
                 .OrderBy(o => o.OrderId)
                 .Skip(page * itemsPerPage)
                 .Take(itemsPerPage)
                 .ToList();
            var orderResult = PackageResults(page, count, result);
            orderResult.ItemsPerPage = itemsPerPage;
            return orderResult;
        }

        private static GetOrderListResult PackageResults(int page, int count, List<Order> result)
        {
            var orderResult = new GetOrderListResult() { TotalItems = count, Page = page };
            foreach (var order in result)
            {
                var simpleOrder = new SimpleOrder();
                Mapper.Map(order, simpleOrder);
                orderResult.Items.Add(simpleOrder);
            }

            return orderResult;
        }

        public GetOrderListResult GetFromOrderNumber(APIKey key, string orderNumber)
        {
            if (key == null)
            {
                return null;
            }

            var result = _context.Orders.Where(o => o.Vendor == key.Vendor && o.OrderNumber == orderNumber).ToList();
            var orderResult = PackageResults(0, result.Count, result);
            return orderResult;
        }

        /// <summary>
        /// Handles the updating of the 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public void UpdateOrderStatusItem(APIKey key, OrderStatusItem item)
        {
            if (key == null)
            {
                return;
            }

            var existing = _context.Orders.FirstOrDefault(i => i.ItemId == item.ItemId);
            if (existing == null)
            {
                return;
            }

            existing.OrderStatus = item.OrderStatus;
            existing.OrderTrackingNumber = item.OrderTransactionNumber;
            existing.ReciptTrackingNumber = item.ReturnTransactionNumber;
            existing.OrderStatusDate = DateTime.Now;

            // Adding the crud information to the record
            existing.ModifiedBy = key.Vendor.VendorName;
            existing.ModifiedDate = DateTime.Now;

            _context.SaveChanges();
        }

        /// <summary>
        /// Admin based to allow for processing top 200 orders 
        /// </summary>
        /// <returns></returns>
        public GetOrderListResult GetOpenOrders()
        {

            var result = _context.Orders
                .Include(o => o.Vendor)
                .OrderBy(o => o.CreatedDate)
                .Where(o => o.OrderStatus == OrderStatusValues.Pending)
                .Take(200)
                .ToList();

            var orderResult = PackageResults(0, 200, result);
            return orderResult;

        }

        public GetOrderListResult GetFromItemId(APIKey key, string itemId)
        {
            if (key == null)
            {
                return null;
            }

            var result = _context.Orders.Where(o => o.Vendor == key.Vendor && o.ItemId == itemId).ToList();
            var orderResult = PackageResults(0, result.Count, result);
            return orderResult;
        }
    }
}
