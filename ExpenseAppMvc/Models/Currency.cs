using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ExpenseAppMvc.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]

        public string Code { get; set; }
        public ICollection<ExpenseForm> ExpenseForms { get; set; }
    }
}