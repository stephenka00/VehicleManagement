using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Admin : BaseEntity
    {
        [Key]
        public int? admin_id {  get; set; }
    }
}
