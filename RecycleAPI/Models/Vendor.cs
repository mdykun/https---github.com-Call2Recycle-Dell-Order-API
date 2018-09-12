using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecycleAPI.Models
{

    public class Vendor : TableBase 
    {
        public int VendorId { get; set; }

        [Required()]
        [MaxLength(128)]
        public string VendorName { get; set; }
        public bool Active { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual IList<APIKey> Keys { get; set; }
        public bool IsAdministrator { get; set; }
        public bool AllowDuplicateOrderNumbers { get; set; }

        public Vendor()
        {
            Orders = new List<Order>();
            Keys = new List<APIKey>();
        }
    }


}
