using netmvc_relatable.Models;

namespace netmvc_relatable.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<netmvc_relatable.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(netmvc_relatable.Models.MyContext context)
        {
            context.Categories.AddOrUpdate(x=> x.ID, 
                new Category() { ID = 1, Name = "Coffee Type 1" },
                new Category() { ID = 2, Name = "Coffee Type 2" },
                new Category() { ID = 3, Name = "Coffee Type 3" }
                );
            context.Products.AddOrUpdate(x => x.ID,
                new Product() { ID = 1, Name = "Coffee 1", Price = 50, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 1},
                new Product() { ID = 2, Name = "Coffee 2", Price = 10, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 1},
                new Product() { ID = 3, Name = "Coffee 3", Price = 20, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 2},
                new Product() { ID = 4, Name = "Coffee 4", Price = 10, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 3},
                new Product() { ID = 5, Name = "Coffee 5", Price = 25, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 3},
                new Product() { ID = 6, Name = "Coffee 6", Price = 30, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 1},
                new Product() { ID = 7, Name = "Coffee 7", Price = 55, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 2},
                new Product() { ID = 8, Name = "Coffee 8", Price = 10, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 3},
                new Product() { ID = 9, Name = "Coffee 9", Price = 20, Thumbnail = "http://hdhousecoffee.com/Uploads/Images/2a67890e-447a-49b5-873b-33bd8d430071.jpg", CategoryID = 1}

            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
