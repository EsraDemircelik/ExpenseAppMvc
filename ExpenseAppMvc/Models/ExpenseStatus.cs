using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppMvc.Models
{
    public class ExpenseStatus
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<ExpenseForm> ExpenseForms { get; set; }
    }
}