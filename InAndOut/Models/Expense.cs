using System;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public String ExpenseName { get; set; }

        public int Amount { get; set; }
    }
}
