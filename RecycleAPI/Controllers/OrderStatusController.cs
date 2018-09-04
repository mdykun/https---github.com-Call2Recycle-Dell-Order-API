using Microsoft.AspNetCore.Mvc;
using RecycleAPI.Models;
using RecycleAPI.Repository;
using RecycleAPI.Services;

namespace RecycleAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderStatusController : ControllerBase
    {

        private readonly IOrderRepository _repository;
        private readonly IVendorService _vendorService;

        public OrderStatusController(IOrderRepository repository, IVendorService vendorService)
        {
            _repository = repository;
            _vendorService = vendorService;
        }

        [HttpPost()]
        public ActionResult UpdateStatus(
            [FromHeader] string vendorKey, 
            [FromBody] OrderStatusItem[] items)
        {

            var key = _vendorService.ValidateAPIKey(vendorKey);
            if (key == null || !key.Enabled)
            {
                return Forbid();
            }

            if (items == null)
            {
                return BadRequest();
            }

            foreach (var item in items)
            {
                var itemId = item.ItemId;
                _repository.UpdateOrderStatusItem(key, item);

            }

            return Ok();
        }

    }
}
