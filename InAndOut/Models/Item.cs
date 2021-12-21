using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Id { get; set; }

        public string Borrower { get; set; }

        public string Lender { get; set; }

        // this annotation we used for display an item name heders like this "Item Name" istead of "ItemName"
        [DisplayName("Item name")]
        public string ItemName { get; set; }
    }
}
