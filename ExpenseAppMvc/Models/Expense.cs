using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppMvc.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [Range(1, 5000, ErrorMessage = "Please do not enter the amount more than 5000.")]
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int ExpenseFormId { get; set; }
        public virtual ExpenseForm ExpenseForm { get; set; }
       
    }
}