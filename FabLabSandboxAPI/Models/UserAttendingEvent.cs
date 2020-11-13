using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;
using System;

namespace FabLabSandboxAPI.Models
{
    public class UserAttendingEvent
    {
        public Guid UserId { get; set; }
        public AppUser user { get; set; }

        public int EventId { get; set; }
        public Event evt { get; set; }


    }
}