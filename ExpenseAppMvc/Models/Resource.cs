using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppMvc.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Key { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Value { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Locale { get; set; }
    }
}