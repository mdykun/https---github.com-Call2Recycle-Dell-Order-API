namespace RecycleAPI.Models
{
    public class VendorLight : TableBase 
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public bool Active { get; set; }
        public bool IsAdministrator { get; set; }

        public VendorLight() { }

        public VendorLight(Vendor vendor)
        {
            CreatedBy = vendor.CreatedBy;
            CreatedDate = vendor.CreatedDate;
            ModifiedBy = vendor.ModifiedBy;
            ModifiedDate = vendor.ModifiedDate;
            VendorId = vendor.VendorId;
            VendorName = vendor.VendorName;
            Active = vendor.Active;
            IsAdministrator = vendor.IsAdministrator;
        }

    }
}
