using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Car : BaseEntity
    {
        [Key]
        public int? car_id {  get; set; }
        public string? car_model { get; set; } 
        public string? car_manufacturer { get; set; } 
        public string? car_name { get; set; } 
        public string? car_description { get; set; } 
        public string? car_type { get; set; } 
        public string? car_color { get; set; } 
        public string? car_status { get; set; } 
        [Column(TypeName = "decimal(18,2)")]
        public decimal car_price { get; set; }
    }
}
