using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoreapp.Models
{
    /// <summary>
    /// The class that will be used to encapsulate DB Mapping and Transactions
    /// Use EF Core for DB Programming
    /// Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer
    /// Microsoft.EntityFrameworkCore.Tools
    /// The DbContext class, from EF Core will manage Db Connection and Transactions
    /// The DbSet<T> class will map the CLR class of name T with Table of name T
    /// </summary>
    public class CoreFisContext : DbContext
    {
        // mapping definitions
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// The COnstructor will be injected with DbContextOptions<T>
        /// T is the DbContext class that will  be injected in the Current Web App
        /// The DI will provide the Connection String to DbContext class
        /// for DB Connection and Transactions
        /// </summary>
        public CoreFisContext(DbContextOptions<CoreFisContext> options):base(options)
        {
        }
        // This method will create Model Objects using DbSet<T> and 
        // map with Db Tables when the EF Core will migrate to Database
        // server using the Connection String
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
