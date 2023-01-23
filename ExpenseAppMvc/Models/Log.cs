using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppMvc.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Exception { get; set; }
        public DateTime CreateDate { get; set; }
        public string TransactionDetail { get; set; }
    }
}