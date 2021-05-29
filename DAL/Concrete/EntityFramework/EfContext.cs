using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Castle.Core.Configuration;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DAL.Concrete.EntityFramework
{
    public class EfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB;Database=MyProjectEComm;Trusted_Connection=true");
        }
        //public EfContext(DbContextOptions<EfContext>options):base(options)
        //{

        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Category1> Categories1 { get; set; }
        public DbSet<Category2> Categories2 { get; set; }
        public DbSet<Category3> Categories3 { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
