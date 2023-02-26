using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace aldiSatti.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>()
            {
                new Category() { name="KAMERA", description="KAMERA ÜRÜNLERİ" },
                new Category() { name="TELEFON", description="TELEFON ÜRÜNLERİ" },
                new Category() { name="BİLGİSAYAR", description="BİLGİSAYAR ÜRÜNLERİ" },
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product() { name="Canon", description="Kamera ürünleri", price=3000, stock=110, isHome=true, isApproved=true, isFeatured=false, slider=true, categoryId=1, image="canon.jpg" },
                new Product() { name="Casper", description="Bilgisayar ürünleri", price=4500, stock=80, isHome=true, isApproved=true, isFeatured=true, slider=true, categoryId=3, image="pc1.jpg" },
                new Product() { name="Asus", description="Bilgisayar ürünleri", price=4000, stock=100, isHome=false, isApproved=true, isFeatured=true, slider=false, categoryId=3, image="pc2.jpg" },
                new Product() { name="Samsung 6S", description="Telefon ürünleri", price=2500, stock=75, isHome=true, isApproved=true, isFeatured=true, slider=true, categoryId=2, image="samsungs6.2 .jpg" },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            base.Seed(context); 
        }
    }
}