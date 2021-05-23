using DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EfCore
{
    public class StdContext:DbContext
    {
        public StdContext()
        {

        }

        public StdContext(DbContextOptions<StdContext> options):base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=LAPTOP-4JFM667R\SQLEXPRESS;Database=StudentDemo; User ID=Ramazan;Password=7262926;Integrated Security=true;");
        //}

        public  DbSet<Shipment>Shipments{ get; set; }
        public  DbSet<ShippmentPackage> ShippmentPackages{ get; set; }

        public  DbSet<WeightAndSize> WeightAndSizes{ get; set; }
    }
}
