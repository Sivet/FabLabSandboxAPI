using System.ComponentModel.DataAnnotations;

namespace FabLabSandboxAPI.Dtos
{
    public class MakerSpaceUpdateDto
    {
    
        /// <summary>Name for create MakerSpase - Required field</summary>
      
        public string MakerSpaceName { get; set; }

        /// <summary>PostCode for create MakerSpase - Required field</summary>
     
        public string MakerSpacePostCode { get; set; }

        /// <summary>Street for create MakerSpase - Required field</summary>
      
        public string MakerSpaceStreet { get; set; }

        /// <summary>City for create MakerSpase - Required field</summary>
      
        public string MakerSpaceCity { get; set; }

        /// <summary>MakerSpace accepted by Admin or not</summary>
        public bool IsAccepted { get; set; }

    }
}