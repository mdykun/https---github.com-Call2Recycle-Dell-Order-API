using RecycleAPI.Models;
using RecycleAPI.Repository;

namespace RecycleAPI.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorsRepository _repository;

        public VendorService(IVendorsRepository repository)
        {
            _repository = repository;
        }

        public APIKey ValidateAPIKey(string vendorKey)
        {
            return _repository.FindByVendorKey(vendorKey);
        }
    }
}