using System.ComponentModel.DataAnnotations;
using FabLabSandboxAPI.Authorization.AuthenticationDB;
using System;
using Microsoft.AspNetCore.Identity;

namespace FabLabSandboxAPI.Models
{
    public class UserAttendingEvent
    {
        public string memberId { get; set; }
        public IdentityUser member { get; set; }
        public Guid EventId { get; set; }
        public Event evt { get; set; }


    }
}