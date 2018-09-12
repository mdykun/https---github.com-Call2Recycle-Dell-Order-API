using Microsoft.AspNetCore.Mvc;
using RecycleAPI.Models;
using RecycleAPI.Services;
using System;
using System.Collections.Generic;
using RecycleAPI.Messaging;
using RecycleAPI.Repository;

namespace RecycleAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderRepository _repository;
        private readonly IVendorService _vendorService;
        public OrdersController(
            IOrderRepository repository,
            IVendorService vendorService)
        {
            _repository = repository;
            _vendorService = vendorService;
        }


        [HttpGet(), Route("GetByItemId")]
        public GetOrderListResult GetOrderByItemId([FromHeader] string vendorKey, [FromQuery] string itemId)
        {
            var key = _vendorService.ValidateAPIKey(vendorKey);
            return _repository.GetFromItemId(key, itemId);
        }

        [HttpGet]
        public GetOrderListResult Get(
            [FromHeader] string vendorKey,
            [FromQuery] string orderNumber,
            [FromQuery] string orderStatus,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int itemsPerPage = 300,
            [FromQuery] int page = 0)
        {

            GetOrderListResult result;
            var key = _vendorService.ValidateAPIKey(vendorKey);

            //if (key == null || !key.Enabled)
            //{
            //    return new GetOrderListResult() { Success = false, Message = "API Key Not Valid" };
            //}

            if (!string.IsNullOrEmpty(orderNumber))
                result = _repository.GetFromOrderNumber(key, orderNumber);
            else
                result = _repository.GetAll(key, fromDate, toDate, orderStatus, page, itemsPerPage);

            return result;

        }

        [HttpPut]
        public InsertOrderResult Put(
            [FromHeader]string vendorKey,
            [FromBody]Order[] orders)
        {

            var key = _vendorService.ValidateAPIKey(vendorKey);
            if (key == null || !key.Enabled)
            {
                return new InsertOrderResult() { Success = false, Message = "API Key Not Valid" };
            }

            if (orders == null)
            {
                return new InsertOrderResult() { Success = false, Message = "No Orders were provided" };
            }

            var results = new List<OrderInsertResult>();
            foreach (var order in orders)
            {
                var result = new OrderInsertResult
                {
                    OrderNumber = order.OrderNumber
                };

                if (TryValidateModel(order))
                {
                    _repository.Add(key, order, result);

                    if (result.Success)
                    {
                        result.OrderStatus = order.OrderStatus;
                        result.ItemId = order.ItemId;
                    }

                }
                else
                {

                    var messages = new List<string>();
                    foreach (var item in ModelState.Keys)
                    {
                        var stateItem = ModelState[item];
                        foreach (var subItem in stateItem.Errors)
                        {
                            messages.Add(subItem.ErrorMessage);
                        }
                    }

                    result.Success = false;
                    result.Message = $"Validation Error: {string.Join("|", messages)}";

                }

                results.Add(result);
            }


            return new InsertOrderResult { Success = true, Results = results };

        }

    }
}
