using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecycleAPI.Models;
using RecycleAPI.Services;

namespace RecycleAPI.Repository
{
    public class VendorsRepository : IVendorsRepository
    {

        private readonly APIContext _context;

        public VendorsRepository(APIContext context)
        {
            _context = context;
        }

        public void Add(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
        }

        public Vendor Find(int id)
        {
            return _context.Vendors.FirstOrDefault(v => v.VendorId == id);
        }

        public APIKey FindByVendorKey(string vendorKey)
        {
            return _context.Keys.Include(k => k.Vendor).FirstOrDefault(k => k.Key == vendorKey);
        }

        public List<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }
    }
}
