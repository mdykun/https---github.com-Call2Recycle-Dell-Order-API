using RecycleAPI.Models;

namespace RecycleAPI.Services
{
    public interface IVendorService
    {
        APIKey ValidateAPIKey(string vendorKey);
    }
}