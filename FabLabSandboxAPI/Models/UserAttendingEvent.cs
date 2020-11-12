using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;

namespace FabLabSandboxAPI.Models
{
    public class UserAttendingEvent
    {
        public int UserId { get; set; }
        public AppUser user { get; set; }

        public int EventId { get; set; }
        public Event evt { get; set; }


    }
}