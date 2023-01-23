using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExpenseAppMvc.Models
{
    public class ExpenseFormHistory
    {
        public int Id { get; set; }
        public int ExpenseFormId { get; set; }
        public int ExpenseFormStatusId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ExpenseFormDescription { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ExpenseFormRejectReason { get; set; }
        public int ExpenseFormCurrencyId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsExpenseFormDeleted { get; set; }
    }
}