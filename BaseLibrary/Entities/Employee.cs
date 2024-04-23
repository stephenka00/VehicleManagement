
using System.ComponentModel.DataAnnotations;



namespace BaseLibrary.Entities
{
    public class Employee : BaseEntity
    {
        [Key]
        public int employee_id { get; set; }
        public string? employee_FullName { get; set; } 
        public string? employee_name { get; set; } 
        public string? employee_phone { get; set; } 
        public string? employee_pass { get; set; } 
        public string? employee_gmail { get; set; } 
        public string? employee_address { get; set; } 
        public string? employee_position { get; set; } 
    }
}
