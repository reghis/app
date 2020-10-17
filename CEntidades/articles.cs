using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CEntidades
{
    public class articles
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal total_in_shelf { get; set; }      // despensa
        public decimal total_in_vault { get; set; }     // bodega
        public int store_id { get; set; }
        public virtual stores Stores { get; set; }
    }
}
