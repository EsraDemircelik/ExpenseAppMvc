using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace ExpenseAppMvc.Models
{
    public class Context:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder
            //.Entity<Expense>()
            //  .ToTable("Expenses", c => c.IsTemporal());


        }


        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseForm> ExpenseForms { get; set; }
        public DbSet<ExpenseFormHistory> expenseFormHistories { get; set; }
        public DbSet<ExpenseHistory> ExpenseHistories { get; set; }
        public DbSet<ExpenseStatus> ExpenseStatuses { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ConfigurationParameter> ConfigurationParameters { get; set; }
    }
}