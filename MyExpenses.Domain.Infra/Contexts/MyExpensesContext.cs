using Microsoft.EntityFrameworkCore;
using MyExpenses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Infra.Contexts
{
    public class DataCotnext : DbContext
    {
        public DataCotnext() { }
        public DataCotnext(DbContextOptions<DataCotnext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<IncomeSource> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer("Server=localhost,1433\\SQLEXPRESS;Database=MyExpenses;User ID=sa;Encrypt=False;Password=1q2w3e4r@#$");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name.FirstName).HasMaxLength(120).HasColumnType("VARCHAR(120)");
            modelBuilder.Entity<User>().Property(x => x.Name.LastName).HasMaxLength(120).HasColumnType("VARCHAR(120)");
            modelBuilder.Entity<User>().Property(x => x.Email.Address).HasMaxLength(120).HasColumnType("VARCHAR(120)");
            modelBuilder.Entity<User>().Property(x => x.Image).HasColumnType("NVARCHAR");
            modelBuilder.Entity<User>().Property(x => x.IsPremium).HasColumnType("BIT");
            modelBuilder.Entity<User>().Property(x => x.EntryDate).HasColumnType("DATETIME");

            modelBuilder.Entity<IncomeSource>().ToTable("Income");
            modelBuilder.Entity<IncomeSource>().HasKey(x => x.Id);
            modelBuilder.Entity<IncomeSource>().Property(x => x.Title).HasMaxLength(60).HasColumnType("VARCHAR(60)");
            modelBuilder.Entity<IncomeSource>().Property(x => x.Income).HasMaxLength(60).HasColumnType("DECIMAL");

            modelBuilder.Entity<Expense>().ToTable("Expense");
            modelBuilder.Entity<Expense>().HasKey(x => x.Id);
            modelBuilder.Entity<Expense>().Property(x => x.Title).HasMaxLength(60).HasColumnType("VARCHAR(60)");
            modelBuilder.Entity<Expense>().Property(x => x.Price).HasMaxLength(60).HasColumnType("DECIMAL");
            modelBuilder.Entity<Expense>().Property(x => x.IsSubscription).HasColumnType("BIT");
        }
    }
}
