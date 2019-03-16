using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebShop.Models
{
    public class ShopFactory:DbContext
    {
        public ShopFactory()
        {
            Database.SetInitializer(new ShopInitializer());
        }
        public DbSet<Product> Products { get; set; }
    }
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopFactory>
    {
        protected override void Seed(ShopFactory context)
        {
            context.Products.Add(new Product() {
            Name="Badminton",
            Description="This is very good one made by Nike",
            Price=100M,
            ImageName="Badminton"});
            context.Products.Add(new Product()
            {
                Name = "Football",
                Description = "This is very good one made by Nike",
                Price = 500M,
                ImageName="Football"
            });
            context.Products.Add(new Product()
            {
                Name = "CricketBat",
                Description = "Famous player Sachin Tendulkar played by this one",
                Price = 200M,
                ImageName="CricketBat"
            });
        }
    }
}