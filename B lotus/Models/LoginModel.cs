using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace B_lotus.Models
{
    public class Login
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } 

    }

    public class ChangePassword { 
    public int UserId { get; set; }
        public string OldPassword { get; set; }    
        public string NewPassword { get; set; }    
    }
}
