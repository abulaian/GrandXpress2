using GrandXpress.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrandXpress.Data.Entities
{
   public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.Sender)
                .WithMany(r => r.Transactions)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Receiver)
                .WithMany(r=>r.Transactions)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sender>().Property(s => s.LastName).IsConcurrencyToken();

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GrandPrairieDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    //optionsBuilder.UseSqlServer(connStr);
        //}
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Sender> Senders { get; set; }
    }
}
