using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExpenseAppMvc.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Username { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        public string Password { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public int UserRoleId { get; set; }
        public int? ManagerId { get; set; }
        public virtual UserRole UserRole { get; set; }
        public ICollection<ExpenseForm> ExpenseForms { get; set; }
       
    }
}