
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BaseLibrary.Entities
{
    public class Invoice : BaseEntity
    {
       
        [Key]
        public int? invoice_id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalDiscount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalTax { get; set; }
        public string? Status { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        //Relationship : Many to One
        public int CustomerId { get; set; }

        public Customer? Customers { get; set; } 
        public int CarId { get; set; }

        public Car? Car { get; set; }
        public int EmployeeID { get; set; }

        public Employee? Employee { get; set; }

    }
}
