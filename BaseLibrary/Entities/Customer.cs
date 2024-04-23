using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Customer : BaseEntity
    {
        [Key]
        public int customer_id {  get; set; }
        public string name { get; set; } = string.Empty;
        public string customer_name { get; set; } = string.Empty;
        public string customer_email { get; set; } = string.Empty;
        public string customer_phone { get; set; } = string.Empty;
        public string customer_address { get; set; } = string.Empty;
        public string customer_password { get; set; } = string.Empty;
    }
}
