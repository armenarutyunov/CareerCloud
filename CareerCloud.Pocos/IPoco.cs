using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("sysdiagrams")]
    public class IPoco
    {
        [Key]
        public String Code { get; set; }
        public String Name { get; set; }
       
    }
}
