using System.ComponentModel.DataAnnotations;
using System;

namespace FabLabSandboxAPI.Dtos
{
    public class MakerSpaceIdReadDto
    {

        public Guid MakerSpaceId { get; set; }

        public string MakerSpaceName { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public bool? IsAccepted { get; set; } = false;

    }
}