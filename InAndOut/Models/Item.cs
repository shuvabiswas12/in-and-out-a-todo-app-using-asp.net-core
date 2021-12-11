using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Item
    {
        public Item()
        {

        }

        [Key]
        public int id { get; set; }

        public string borrower { get; set; }
        
        public string lender { get; set; }

        public string itemName { get; set; }
    }
}
