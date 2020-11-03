using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FabLabSandboxAPI.Authorization.AuthServises
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is requred")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Email is requred")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Password is requred")]
        public string Password { get; set; }
    }
}
