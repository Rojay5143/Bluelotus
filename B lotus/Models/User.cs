using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace B_lotus.Models
{
    public class User
    {
       [Key]
       public int UserId { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set;}
        public string MiddleName { get; set;}

        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set;}
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]

        [Required(ErrorMessage = "Contact Number Required")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Full Address Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        public byte[] Profile { get; set; }
        public string LoginId { get; set;}
        public string Password { get; set;}

        [Required(ErrorMessage = "User Rool Required")]
        public string Role { get; set; }

        public bool Delete { get; set; }
        public bool PasswordChanged { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "User Profile Required")]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ProfileImage { get; set; }
        public int CompanyId { get; set; }




    }
}
