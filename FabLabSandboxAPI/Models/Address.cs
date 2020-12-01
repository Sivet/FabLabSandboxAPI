using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Models
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public ICollection<MakerSpace> MakerSpaces { get; set; }

    }
}