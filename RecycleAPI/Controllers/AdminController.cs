using Microsoft.AspNetCore.Mvc;
using RecycleAPI.Messaging;
using RecycleAPI.Repository;
using RecycleAPI.Services;

namespace RecycleAPI.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IVendorService _vendorService;

        public AdminController(IOrderRepository orderRepository, IVendorService vendorService)
        {
            _orderRepository = orderRepository;
            _vendorService = vendorService;
        }

        [HttpGet, Route("GetOpenOrders")]
        public GetOrderListResult GetOpenOrders([FromHeader]string vendorKey)
        {
            var key = _vendorService.ValidateAPIKey(vendorKey);
            if (key == null)
            {
                var result = new GetOrderListResult() { Success = false, Message = "Invalid Vendor Key specified"};
                return result;
            }

            if (!key.Vendor.IsAdministrator)
            {
                var result = new GetOrderListResult() { Success = false, Message = "Invalid Vendor Key specified" };
                return result;
            }

            var list = _orderRepository.GetOpenOrders();
            return list;
        }




    }
}
