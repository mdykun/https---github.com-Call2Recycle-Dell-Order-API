using System.Collections.Generic;
using RecycleAPI.Models;

namespace RecycleAPI.Messaging
{
    public class VendorListResult : BaseResult
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }

        public List<VendorLight> Items { get; set; }
        public VendorListResult() { Items = new List<VendorLight>(); }
    }
}