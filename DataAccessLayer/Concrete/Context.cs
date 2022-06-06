using EntityLayer.Concrete;
using EntityLayer.Concrete.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AspNetUser> 
    {

        public Context() : base("Context")
        {

        }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<Loan> Loans { get; set; } 
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<AutomaticOrManuel> AutomaticOrManuels { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PeriodType> PeriodTypes { get; set; }
        public DbSet<RepetitiveTransaction> RepetitiveTransactions { get; set; }
        public DbSet<V_DailyView> V_DailyView { get; set; }
        public DbSet<V_MonthlyView> V_MonthlyView { get; set; }
        public DbSet<V_AnnualyView> V_AnnualyView { get; set; }
        public DbSet<V_AllTimeBalance> V_AllTimeBalance { get; set; }
        public DbSet<V_IncomeCategorySums> V_IncomeCategorySums { get; set; }
        public DbSet<V_ExpenseCategorySums> V_ExpenseCategorySums { get; set; }







        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<V_DailyView>().HasKey(r => r.ViewID);
            modelBuilder.Entity<V_MonthlyView>().HasKey(r => r.ViewID);
            modelBuilder.Entity<V_AnnualyView>().HasKey(r => r.ViewID);
            modelBuilder.Entity<V_ExpenseCategorySums>().HasKey(r => r.ViewID);
            modelBuilder.Entity<V_IncomeCategorySums>().HasKey(r => r.ViewID);
            modelBuilder.Entity<V_AllTimeBalance>().HasKey(r => r.Id);
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);

        }
        




    }




}
