using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_lotus.Models
{
    public class Server
    {
        [Key]
        public int ServerId { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("Company")]
        public string CompanyId { get; set; }
    }
}
