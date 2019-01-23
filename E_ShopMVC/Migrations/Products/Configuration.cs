using E_ShopMVC.Data;
using E_ShopMVC.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace E_ShopMVC.Migrations.Product
{
    internal sealed class Configuration : DbMigrationsConfiguration<EShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Products";
        }

        protected override void Seed(EShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.CategoriesTable.AddOrUpdate(c => c.CategoryId,
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Standard",
                    CategoryDescription = "Som namnet  ...."
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Popular",
                    CategoryDescription = "Här hittar du våra mest köpta ..."
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Training",
                    CategoryDescription = "Dessa springskor..."
                });
            context.SaveChanges();

            context.ProductsTable.AddOrUpdate(x => x.ProductId,
                new Models.Product
                {
                    ProductId = 1,
                    ProductDetail = "Blah blah blah",
                    ProductName = " Nike",
                    ProductPrice = 4999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 1),

                },
                new Models.Product
                {
                    ProductId = 2,
                    ProductDetail = "sfdfsd",
                    ProductName = "Addidas",
                    ProductPrice = 8999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 2),
                    //CategoryName = "Professional"

                },
                new Models.Product
                {
                    ProductId = 3,
                    ProductDetail = "fhfdhfghfhg",
                    ProductName = "Puma",
                    ProductPrice = 17999,
                    Category = context.CategoriesTable.First(x => x.CategoryId == 3),

                }
                );
            context.SaveChanges();
        }
    }
}
