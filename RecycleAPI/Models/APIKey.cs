using System;
using System.ComponentModel.DataAnnotations;

namespace RecycleAPI.Models
{
    public class APIKey : TableBase
    {
        public int APIKeyId { get; set; }

        [MaxLength(36)]
        [Required]
        public string Key { get; set; }

        public bool Enabled { get; set; }

        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [MaxLength(128)]
        public string EmailAddress { get; set; }

        public Vendor Vendor { get; set; }

        public APIKey()
        {
            Key = Guid.NewGuid().ToString();
        }



    }
}
