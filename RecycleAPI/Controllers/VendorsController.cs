using Microsoft.AspNetCore.Mvc;
using RecycleAPI.Messaging;
using RecycleAPI.Models;
using RecycleAPI.Repository;
using RecycleAPI.Services;
using System.Collections.Generic;

namespace RecycleAPI.Controllers
{
    [Route("api/[controller]")]
    public class VendorsController
    {

        private readonly IVendorService _vendorService;
        private readonly IVendorsRepository _vendorRepository;

        public VendorsController(IVendorService vendorService, IVendorsRepository respository)
        {
            _vendorService = vendorService;
            _vendorRepository = respository;
        }


        [HttpGet]
        public VendorListResult Get([FromHeader]string vendorKey)
        {
            var key = _vendorService.ValidateAPIKey(vendorKey);
            if (key == null)
            {
                var result = new VendorListResult()
                {
                    Success = false,
                    Message = "Invalid Vendor Key specified"
                };
                return result;
            }

            if (!key.Vendor.IsAdministrator)
            {
                var result = new VendorListResult()
                {
                    Success = false,
                    Message = "Invalid permissions for this action"
                };
                return result;
            }

            var vendors = _vendorRepository.GetAll();
            var items = new List<VendorLight>();
            foreach (var vendor in vendors)
            {
                items.Add(new VendorLight(vendor));
            }

            var listResult = new VendorListResult() { Items = items, TotalItems = items.Count };
            return listResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public VendorResult Get([FromHeader]string vendorKey, int id)
        {

            var key = _vendorService.ValidateAPIKey(vendorKey);
            if (key == null)
            {
                var result = new VendorResult()
                {
                    Success = false,
                    Message = "Invalid Vendor Key specified"
                };
                return result;
            }

            if (!key.Vendor.IsAdministrator)
            {

                var result = new VendorResult()
                {
                    Success = false,
                    Message = "Invalid permissions for this action"
                };

                return result;
            }

            var vendor = _vendorRepository.Find(id);
            var light = vendor != null ? new VendorLight(vendor) : null;

            var vendorResult = new VendorResult()
            {
                Item = light,
                Success = light != null,
                Message = light != null ? string.Empty : "Vendor not found"
            };

            return vendorResult;
        }

        // POST api/values
        [HttpPost]
        public void Post(
            [FromHeader]string vendorKey,
            [FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(
            [FromHeader]string vendorKey,
            int id,
            [FromBody]string value)
        {

        }
    }
}
