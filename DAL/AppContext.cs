using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using OnlineShippingApp.Models;

namespace OnlineShippingApp.DAL
{
   

        public class AppContext : DbContext

        {
            public AppContext() : base("AppContext")
            {

            }

            public DbSet<Order> Orders { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }


        }


    
}