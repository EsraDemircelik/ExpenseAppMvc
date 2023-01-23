using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppMvc.Models
{
    public class ExpenseForm
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string RejectReason { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int ExpenseStatusId { get; set; }
        public virtual ExpenseStatus ExpenseStatus { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}