using System.ComponentModel.DataAnnotations;

namespace B_lotus.CompanyModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

    }
}
