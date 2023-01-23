using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ExpenseAppMvc.Models
{
    public class ExpenseHistory
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ExpenseDescription { get; set; }
        public int ExpenseAmount { get; set; }
        public int ExpenseFormId { get; set; }

        public DateTime ExpenseDate { get; set; }
        public int ExpenseFormStatusId { get; set; }
        public int ExpenseFormHistoryId { get; set; }
        public DateTime CraeteDate { get; set; }
        public bool IsExpenseDeleted { get; set; }
    }
}