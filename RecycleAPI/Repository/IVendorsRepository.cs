using System.Collections.Generic;
using RecycleAPI.Models;

namespace RecycleAPI.Repository
{
    public interface IVendorsRepository
    {
        void Add(Vendor vendor);
        List<Vendor> GetAll();
        Vendor Find(int id);
        APIKey FindByVendorKey(string vendorKey);
    }
}