using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRoleSession.Models
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }
    }
}