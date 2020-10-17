using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CEntidades
{
    public class stores
    {
        [Key]
        public int storesid { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public virtual ICollection<articles> Articles { get; set; }
        

    }
}
