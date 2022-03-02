using System.ComponentModel.DataAnnotations;

namespace B_lotus.Models
{
    public class DataBaseServer
    {
        [Key]
        public int ServerId { get; set; }
        public string ServerName { get; set; }
        public string HostName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
