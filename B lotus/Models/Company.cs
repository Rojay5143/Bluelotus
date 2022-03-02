using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_lotus.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Company Name Required")]
        public string CompanyName { get; set; }
        [Required (ErrorMessage ="Registration no. Required")]
        public string Reg_No { get; set; }
        [Required (ErrorMessage ="VAT/PAN no. Required")]
        public string VATorPAN { get; set; }
        public string Phone_No { get; set; }
        [Required(ErrorMessage = "Mobile no. Required")]
        public string Mobile_No { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        public string WebSite { get; set; }

        [Required(ErrorMessage = "Country Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        public byte[] LogoByte { get; set; }

        [Required(ErrorMessage = "Logo Required")]
        [NotMapped]
        public IFormFile Logo { get; set; }
        [NotMapped]
        public string CompanyProfile { get; set; }

       public Server Servers { get; set; }
        


    }
}
